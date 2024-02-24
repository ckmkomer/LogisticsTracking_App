using AutoMapper;
using LogisticsTrackingApp.Core.Dtos.ContactDtos;
using LogisticsTrackingApp.Core.Dtos.ReturnDtos;
using LogisticsTrackingApp.Core.Models;
using LogisticsTrackingApp.Service.Services.Abstract;
using LogisticsTrackingApp.Service.Services.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsTrackingApp.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReturnController : ControllerBase
	{
		private readonly IReturnService _returnService;
		private readonly IMapper _mapper;

		public ReturnController(IReturnService returnService, IMapper mapper)
		{
			_returnService = returnService;
			_mapper = mapper;
		}


		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var values = await _returnService.GetAllAsync();
			return Ok(values);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var values = await _returnService.GetIdAsync(id);
			return Ok(values);
		}

		[HttpPost]
		public async Task<IActionResult> Add(CreateReturnDto createReturn)
		{
			var values = _mapper.Map<CreateReturnDto, Return>(createReturn);
			await _returnService.InsertAsync(values);
			return Ok("Başarılı şekilde eklendi");
		}

		[HttpPut]
		public async Task<IActionResult> Update(UpdateReturnDto updateReturn)
		{
			await _returnService.UpdateAsync(_mapper.Map<Return>(updateReturn));

			return Ok("Başarılı şekilde güncellendi");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var values = await _returnService.GetIdAsync(id);
			await _returnService.DeleteAsync(values);
			return Ok("Başarılı şekilde silindi");


		}
	}
}
