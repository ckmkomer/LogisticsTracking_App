using AutoMapper;
using LogisticsTrackingApp.API.Filters;
using LogisticsTrackingApp.Core.Dtos.AboutDtos;
using LogisticsTrackingApp.Core.Dtos.Abouts;
using LogisticsTrackingApp.Core.Dtos.CustomerDtos;
using LogisticsTrackingApp.Core.Models;
using LogisticsTrackingApp.Service.Services.Abstract;
using LogisticsTrackingApp.Service.Services.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsTrackingApp.API.Controllers
{
	
	[Route("api/[controller]")]
	[ApiController]
	public class AboutController : ControllerBase
	{
		private readonly IAboutService _aboutService;
		private readonly IMapper _mapper;

		public AboutController(IAboutService aboutService, IMapper mapper)
		{
			_aboutService = aboutService;
			_mapper = mapper;
		}

		
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var values = await _aboutService.GetAllAsync();
			return Ok(values);
		}

		//[ServiceFilter(typeof(NotFoundFilter<About>))]
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var values = await _aboutService.GetIdAsync(id);
			return Ok(values);
		}

		[HttpPost]
		public async Task<IActionResult> Add(CreateAboutDto  createAbout)
		{
			var values = _mapper.Map<CreateAboutDto, About>(createAbout);
			await _aboutService.InsertAsync(values);
			return Ok();
		}

		[HttpPut]
		public async Task<IActionResult> Update(UpdateAboutDto updateAbout)
		{
			await _aboutService.UpdateAsync(_mapper.Map<About>(updateAbout));

			return Ok();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var about = await _aboutService.GetIdAsync(id);
			await _aboutService.DeleteAsync(about);
			return Ok();


		}



	}
}
