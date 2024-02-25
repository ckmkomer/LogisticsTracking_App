using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Serilog;
using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LogisticsTrackingApp.Service.Logging
{
	public class SerilogExceptionMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ILogger _logger;

		public SerilogExceptionMiddleware(RequestDelegate next, ILogger logger)
		{
			_next = next;
			_logger = logger;
		}

		public async Task Invoke(HttpContext context)
		{
			var watch = Stopwatch.StartNew();
			try
			{
				string message = "[Request] HTTP " + context.Request.Method + " " + context.Request.Path;
				_logger.Information(message);
				await _next(context);

				watch.Stop();

				message = "[Request] HTTP " + context.Request.Method + " " + context.Request.Path + " Responded " + context.Response.StatusCode + " in " + watch.Elapsed.TotalMilliseconds + " ms";
				_logger.Information(message);
			}
			catch (Exception ex)
			{
				watch.Stop();
				await HandleException(context, ex, watch);
			}
		}

		private async Task HandleException(HttpContext context, Exception ex, Stopwatch watch)
		{
			context.Response.ContentType = "application/json";
			context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

			var customErrorMessage = "İşlem sırasında bir hata oluştu. Lütfen hata mesajını gözden geçiriniz.";

			string message = "[Error] HTTP " + context.Request.Method + " - " + context.Response.StatusCode + " Error Message " + customErrorMessage + " in " + watch.Elapsed.TotalMilliseconds + " ms";
			_logger.Error(ex, message);

			var result = JsonConvert.SerializeObject(new { error = customErrorMessage });
			await context.Response.WriteAsync(result);
		}
	}

	public static class CustomExceptionMiddlewareExtensions
	{
		public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<SerilogExceptionMiddleware>();
		}
	}
}
