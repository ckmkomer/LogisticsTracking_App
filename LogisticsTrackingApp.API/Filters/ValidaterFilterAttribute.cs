using LogisticsTrackingApp.Core.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LogisticsTrackingApp.API.Filters
{
	public class ValidaterFilterAttribute :ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			if(!context.ModelState.IsValid )
			{
				var errors = context.ModelState.Values.SelectMany(x => x.Errors).Select(x=>x.ErrorMessage).ToList();
				context.Result = new BadRequestObjectResult(CustomResponseDto<NoContent>.Fail(400, errors));

			}
		}
	}
}
