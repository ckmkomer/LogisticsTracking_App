using AutoMapper;
using LogisticsTrackingApp.Core.Dtos;
using LogisticsTrackingApp.Core.Dtos.CustomerDtos;
using LogisticsTrackingApp.Core.Models;
using LogisticsTrackingApp.Core.Repositories;
using LogisticsTrackingApp.Data.Repositories.Abstract;
using LogisticsTrackingApp.Data.UnitOfWork;
using LogisticsTrackingApp.Service.Services.Abstract;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsTrackingApp.Service.Services.Concrete
{
	public class CustomerService : Service<Customer>, ICustomerService
	{
		private readonly ICustomerRepository _customerRepository;
		private readonly IMapper _mapper;

		public CustomerService(IGenericRepository<Customer> repository, IUnitOfWork unitOfWork, IMapper mapper, ICustomerRepository customerRepository) : base(repository, unitOfWork)
		{

			_mapper = mapper;
			_customerRepository = customerRepository;
		}

		
		public async Task<List<CustomerWithShipmentDto>> GetCustomerWitShipment()
		{
			var customers = await _customerRepository.GetCustomerWitShipment();
			var customerDtos = _mapper.Map<List<CustomerWithShipmentDto>>(customers).ToList();
			return customerDtos;
		}

		
	}
}

