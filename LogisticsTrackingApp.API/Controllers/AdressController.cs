using AutoMapper;
using LogisticsTrackingApp.Core.Dtos.AboutDtos;
using LogisticsTrackingApp.Core.Dtos.Abouts;
using LogisticsTrackingApp.Core.Dtos.AdressDtos;
using LogisticsTrackingApp.Core.Models;
using LogisticsTrackingApp.Service.Services.Abstract;
using LogisticsTrackingApp.Service.Services.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsTrackingApp.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AdressController : ControllerBase
	{
		private readonly IAdressService _adressService;
		private readonly IMapper _mapper;

		public AdressController(IAdressService adressService, IMapper mapper)
		{
			_adressService = adressService;
			_mapper = mapper;
		}


		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var values = await _adressService.GetAllAsync();
			return Ok(values);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var values = await _adressService.GetIdAsync(id);
			return Ok(values);
		}

		[HttpPost]
		public async Task<IActionResult> Add(CreateAdressDto createAdress)
		{
			var values = _mapper.Map<CreateAdressDto, Adress>(createAdress);
			await _adressService.InsertAsync(values);
			return Ok("Başarılı şekilde eklendi");
		}

		[HttpPut]
		public async Task<IActionResult> Update(UpdateAboutDto updateAbout)
		{
			await _adressService.UpdateAsync(_mapper.Map<Adress>(updateAbout));

			return Ok("Başarılı şekilde güncellendi");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var adress = await _adressService.GetIdAsync(id);
			await _adressService.DeleteAsync(adress);
			return Ok("Başarılı şekilde silindi");


		}

	}
}
