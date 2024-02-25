using AutoMapper;
using LogisticsTrackingApp.Core.Dtos.ContactDtos;
using LogisticsTrackingApp.Core.Dtos.StationDtos;
using LogisticsTrackingApp.Core.Models;
using LogisticsTrackingApp.Service.Services.Abstract;
using LogisticsTrackingApp.Service.Services.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsTrackingApp.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StationController : ControllerBase
	{
		private readonly IStationService _stationService;
		private readonly IMapper _mapper;

		public StationController(IStationService stationService, IMapper mapper)
		{
			_stationService = stationService;
			_mapper = mapper;
		}


		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var values = await _stationService.GetAllAsync();
			return Ok(values);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var values = await _stationService.GetIdAsync(id);
			return Ok(values);
		}

		[HttpPost]
		public async Task<IActionResult> Add(CreateStationDto createStation)
		{
			var values = _mapper.Map<CreateStationDto, Station>(createStation);
			await _stationService.InsertAsync(values);
			return Ok();
		}

		[HttpPut]
		public async Task<IActionResult> Update(UpdateStationDto updateStation)
		{
			await _stationService.UpdateAsync(_mapper.Map<Station>(updateStation));

			return Ok();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var values = await _stationService.GetIdAsync(id);
			await _stationService.DeleteAsync(values);
			return Ok();


		}

	}
}
