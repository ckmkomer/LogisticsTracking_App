using LogisticsTrackingApp.Core.Dtos;
using LogisticsTrackingApp.Service.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Serilog;
using System;
using System.Text.Json;

namespace LogisticsTrackingApp.API.Middlewares
{
	public static class UseCustomExceptionHandler
	{
		public static void UseCustomException(this IApplicationBuilder app)
		{
			app.UseExceptionHandler(config =>
			{
				config.Run(async context =>
				{
					context.Response.ContentType = "application/json";
					var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();

					var statusCode = exceptionFeature.Error switch
					{
						ClientSideException => 400,
						NotFoundExcepiton => 404,
						_ => 500
					};
					context.Response.StatusCode = statusCode;

					//serilog
					Log.Logger.Error(exceptionFeature.Error, "Unhandled exception occurred.");

					var response = CustomResponseDto<NoContentDto>.Fail(statusCode, exceptionFeature.Error.Message);

					await context.Response.WriteAsync(JsonSerializer.Serialize(response));
				});
			});
		}
	}
}
