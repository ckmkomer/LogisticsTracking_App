using AutoMapper;
using LogisticsTrackingApp.Core.Dtos;
using LogisticsTrackingApp.Core.Dtos.AdressDtos;
using LogisticsTrackingApp.Core.Dtos.VehicleDtos;
using LogisticsTrackingApp.Core.Models;
using LogisticsTrackingApp.Core.Repositories;
using LogisticsTrackingApp.Data.Repositories.Abstract;
using LogisticsTrackingApp.Data.UnitOfWork;
using LogisticsTrackingApp.Service.Exceptions;
using LogisticsTrackingApp.Service.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsTrackingApp.Service.Services.Concrete
{
	public class VehicleService : Service<Vehicle>, IVehicleService
	{
		private readonly IVehicleRepository _vehicleRepository;
		private readonly IMapper _mapper;
		public VehicleService(IGenericRepository<Vehicle> repository, IUnitOfWork unitOfWork, IVehicleRepository vehicleRepository, IMapper mapper) : base(repository, unitOfWork)
		{
			_vehicleRepository = vehicleRepository;
			_mapper = mapper;
		}

		public async Task AddVehicleAsync(CreateVehicleDto createVehicle)
		{
			var values = _mapper.Map<CreateVehicleDto, Vehicle>(createVehicle);
			await _vehicleRepository.AddAsync(values);
			
		}

		public async Task DeleteVehicleAsync(int id)
		{
			var values = await _vehicleRepository.GetIdAsync(id);
			_vehicleRepository.Delete(values);
		
		}

		public async Task UpdateVehicleAsync(int id, UpdateVehicleDto updatedVehicle)
		{
			var vehicleToUpdate = await _vehicleRepository.GetIdAsync(id);

			if (vehicleToUpdate == null)
			{
				throw new NotFoundExcepiton("Vehicle not found");
			}

			 _vehicleRepository.Update(_mapper.Map<Vehicle>(vehicleToUpdate));
			


		}

		public async Task<List<ResultVehicleDto>> GetAllVehicleAsync()
		{
			var vehicles = await _vehicleRepository.GetAllAsync();
			var resultDtoList = _mapper.Map<List<ResultVehicleDto>>(vehicles);
			return resultDtoList;
		}

	}
}
