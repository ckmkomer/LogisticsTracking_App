using LogisticsTrackingApp.Core.Dtos.VehicleDtos;
using LogisticsTrackingApp.Core.Models;
using LogisticsTrackingApp.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsTrackingApp.Service.Services.Abstract
{
	public interface IVehicleService:IService<Vehicle>
	{
		Task AddVehicleAsync(CreateVehicleDto createVehicle);


		Task UpdateVehicleAsync(int id, UpdateVehicleDto updatedVehicle);



		Task DeleteVehicleAsync(int id);

		
		Task<List<ResultVehicleDto>> GetAllVehicleAsync();

	}
}
