using LogisticsTrackingApp.Core.Dtos;
using LogisticsTrackingApp.Core.Dtos.AboutDtos;
using LogisticsTrackingApp.Core.Dtos.Abouts;
using LogisticsTrackingApp.Core.Dtos.VehicleDtos;
using LogisticsTrackingApp.Core.Models;
using LogisticsTrackingApp.Service.Services.Abstract;
using LogisticsTrackingApp.Service.Services.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsTrackingApp.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class VehicleController : ControllerBase
	{
		private readonly IVehicleService _vehicleService;

		public VehicleController(IVehicleService vehicleService)
		{
			_vehicleService = vehicleService;
		}


		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var values = await _vehicleService.GetAllVehicleAsync();
			return Ok(values);
		}

		
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var values = await _vehicleService.GetIdAsync(id);
			return Ok(values);
		}

		[HttpPost]
		public async Task<IActionResult> Add(CreateVehicleDto createVehicle)
		{

			await _vehicleService.AddVehicleAsync(createVehicle);

			return Ok();
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, UpdateVehicleDto updatedVehicle)
		{
			await _vehicleService.UpdateVehicleAsync(id, updatedVehicle);
			return Ok();
		}


		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
		  await _vehicleService.DeleteVehicleAsync(id);
			return Ok();

		}

	}
}
