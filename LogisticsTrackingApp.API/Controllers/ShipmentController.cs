using AutoMapper;
using LogisticsTrackingApp.Core.Dtos.ContactDtos;
using LogisticsTrackingApp.Core.Dtos.ShipmentDtos;
using LogisticsTrackingApp.Core.Models;
using LogisticsTrackingApp.Service.Services.Abstract;
using LogisticsTrackingApp.Service.Services.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsTrackingApp.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ShipmentController : ControllerBase
	{
		private readonly IShipmentService _shipmentService;
		private readonly IMapper _mapper;

		public ShipmentController(IShipmentService shipmentService, IMapper mapper)
		{
			_shipmentService = shipmentService;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var values = await _shipmentService.GetAllAsync();
			return Ok(values);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var values = await _shipmentService.GetIdAsync(id);
			return Ok(values);
		}

		[HttpPost]
		public async Task<IActionResult> Add(CreateShipmentDto createShipment)
		{
			var values = _mapper.Map<CreateShipmentDto, Shipment>(createShipment);
			await _shipmentService.InsertAsync(values);
			return Ok("Başarılı şekilde eklendi");
		}

		[HttpPut]
		public async Task<IActionResult> Update(UpdateShipmentDto updateShipment)
		{
			await _shipmentService.UpdateAsync(_mapper.Map<Shipment>(updateShipment));

			return Ok("Başarılı şekilde güncellendi");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var values = await _shipmentService.GetIdAsync(id);
			await _shipmentService.DeleteAsync(values);
			return Ok("Başarılı şekilde silindi");


		}


	}
}
