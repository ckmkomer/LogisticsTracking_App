using AutoMapper;
using LogisticsTrackingApp.Core.Dtos.OrderDtos;
using LogisticsTrackingApp.Core.Dtos.OrderItemDtos;
using LogisticsTrackingApp.Core.Models;
using LogisticsTrackingApp.Service.Services.Abstract;
using LogisticsTrackingApp.Service.Services.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsTrackingApp.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderItemController : ControllerBase
	{
		private readonly IOrderItemService _orderItemService;
		private readonly IMapper _mapper;

		public OrderItemController(IOrderItemService orderItemService, IMapper mapper)
		{
			_orderItemService = orderItemService;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var values = await _orderItemService.GetAllAsync();
			return Ok(values);
		}


		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var values = await _orderItemService.GetIdAsync(id);
			return Ok(values);
		}

		[HttpPost]
		public async Task<IActionResult> Add(CreateOrderItemDto createOrderItem)
		{
			var values = _mapper.Map<CreateOrderItemDto, OrderItem>(createOrderItem);
			await _orderItemService.InsertAsync(values);
			return Ok();
		}

		[HttpPut]
		public async Task<IActionResult> Update(UpdateOrderItemDto updateOrderItem)
		{
			await _orderItemService.UpdateAsync(_mapper.Map<OrderItem>(updateOrderItem));
			return Ok();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var about = await _orderItemService.GetIdAsync(id);
			await _orderItemService.DeleteAsync(about);
			return Ok();


		}

	}
}
