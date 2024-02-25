using AutoMapper;
using LogisticsTrackingApp.Core.Dtos;
using LogisticsTrackingApp.Core.Dtos.CustomerDtos;
using LogisticsTrackingApp.Core.Models;
using LogisticsTrackingApp.Service.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsTrackingApp.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomersController : ControllerBase
	{
		private readonly ICustomerService _customerService;
		private readonly IMapper _mapper;

		public CustomersController(ICustomerService customerService, IMapper mapper)
		{
			_customerService = customerService;
			_mapper = mapper;
		}


		[HttpGet("[action]")]
         public async Task<ActionResult<List<CustomerWithShipmentDto>>> GetCustomerWitShipment()
		{
			return await _customerService.GetCustomerWitShipment();

		}
			[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var values = await _customerService.GetAllAsync();
			return Ok(values);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var values = await _customerService.GetIdAsync(id);
			return Ok(values);
		}

		[HttpPost]
		public async Task<IActionResult> Add(CreateCustomerDto createCustomer)
		{
			var values =  _mapper.Map<CreateCustomerDto, Customer>(createCustomer);
		     await _customerService.InsertAsync(values);
			 return Ok();

		}

		[HttpPut]
		public async Task<IActionResult> Update(UpdateCustomerDto updateCustomer)
		{
			await _customerService.UpdateAsync(_mapper.Map<Customer>(updateCustomer));

			return Ok();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var customer = await _customerService.GetIdAsync(id);
			await _customerService.DeleteAsync(customer);
			return Ok();


		}
	}
}
