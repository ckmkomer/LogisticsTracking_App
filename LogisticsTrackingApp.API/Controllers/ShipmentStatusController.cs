using AutoMapper;
using LogisticsTrackingApp.Core.Dtos.AboutDtos;
using LogisticsTrackingApp.Core.Dtos.Abouts;
using LogisticsTrackingApp.Core.Dtos.ShipmentStatus;
using LogisticsTrackingApp.Core.Models;
using LogisticsTrackingApp.Service.Services.Abstract;
using LogisticsTrackingApp.Service.Services.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsTrackingApp.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ShipmentStatusController : ControllerBase
	{
		private readonly IShipmentStatusService _shipmentStatusService;
		private readonly IMapper _mapper;

		public ShipmentStatusController(IShipmentStatusService shipmentStatusService, IMapper mapper)
		{
			_shipmentStatusService = shipmentStatusService;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var values = await _shipmentStatusService.GetAllAsync();
			return Ok(values);
		}

		
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var values = await _shipmentStatusService.GetIdAsync(id);
			return Ok(values);
		}

		[HttpPost]
		public async Task<IActionResult> Add(CreateShipmentStatusDto createShipment)
		{
			var values = _mapper.Map<CreateShipmentStatusDto, ShipmentStatus>(createShipment);
			await _shipmentStatusService.InsertAsync(values);
			return Ok();
		}

		[HttpPut]
		public async Task<IActionResult> Update(UpdateShipmentStatusDto updateShipment)
		{
			await _shipmentStatusService.UpdateAsync(_mapper.Map<ShipmentStatus>(updateShipment));

			return Ok();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var about = await _shipmentStatusService.GetIdAsync(id);
			await _shipmentStatusService.DeleteAsync(about);
			return Ok();


		}
	}
}
