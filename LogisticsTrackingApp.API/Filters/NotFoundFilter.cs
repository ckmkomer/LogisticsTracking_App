using LogisticsTrackingApp.Core.Dtos;
using LogisticsTrackingApp.Core.Models.BaseEntities;
using LogisticsTrackingApp.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LogisticsTrackingApp.API.Filters
{
	public class NotFoundFilter<T> :IAsyncActionFilter where T : BaseEntity
	{ 
		private readonly IService<T> _genericService;

		public NotFoundFilter(IService<T> genericService)
		{
			_genericService = genericService;
		}

		public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{

			var idValue = context.ActionArguments.Values.FirstOrDefault();

			if (idValue == null)
			{
				await next.Invoke();
				return;
			}

			var id = (int)idValue;
			var anyEntity = await _genericService.GetIdAsync(id);

			if ((bool)(object)anyEntity)
			{
				await next.Invoke();
				return;
			}

			context.Result = new NotFoundObjectResult(CustomResponseDto<NoContentDto>.Fail(404, $"{typeof(T).Name}({id}) not found"));

		}
	}
}
