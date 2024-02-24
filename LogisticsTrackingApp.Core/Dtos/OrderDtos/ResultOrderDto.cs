using LogisticsTrackingApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsTrackingApp.Core.Dtos.OrderDtos
{
	public class ResultOrderDto :BaseDto
	{
		public string OrderNumber { get; set; }
		public DateTime OrderDate { get; set; }
		public decimal TotalAmount { get; set; }
		public string CustomerName { get; set; }
		public string CustomerEmail { get; set; }
		public string ShippingAddress { get; set; }
		public string BillingAddress { get; set; }

		public int CustomerId { get; set; }
		public Customer Customer { get; set; }
	}
}
