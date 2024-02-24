using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsTrackingApp.Core.Dtos.OrderItemDtos
{
	public class ResultOrderItemDto :BaseDto
	{
		public string ProductName { get; set; }
		public decimal Price { get; set; }
		public int Quantity { get; set; }

		public int OrderId { get; set; }
	}
}
