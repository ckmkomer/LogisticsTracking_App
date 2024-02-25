using AutoMapper;
using LogisticsTrackingApp.Core.Dtos.AboutDtos;
using LogisticsTrackingApp.Core.Dtos.Abouts;
using LogisticsTrackingApp.Core.Dtos.OrderDtos;
using LogisticsTrackingApp.Core.Models;
using LogisticsTrackingApp.Service.Services.Abstract;
using LogisticsTrackingApp.Service.Services.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsTrackingApp.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderController : ControllerBase
	{
		private readonly IOrderService _orderService;
		private readonly IMapper _mapper;

		public OrderController(IOrderService orderService, IMapper mapper)
		{
			_orderService = orderService;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var values = await _orderService.GetAllAsync();
			return Ok(values);
		}

		
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var values = await _orderService.GetIdAsync(id);
			return Ok(values);
		}

		[HttpPost]
		public async Task<IActionResult> Add(CreateOrderDto createOrder)
		{
			var values = _mapper.Map<CreateOrderDto, Order>(createOrder);
			await _orderService.InsertAsync(values);
			return Ok();
		}

		[HttpPut]
		public async Task<IActionResult> Update(UpdateOrderDto updateOrder)
		{
			await _orderService.UpdateAsync(_mapper.Map<Order>(updateOrder));

			return Ok();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var values = await _orderService.GetIdAsync(id);
			await _orderService.DeleteAsync(values);
			return Ok();


		}
	}
}
