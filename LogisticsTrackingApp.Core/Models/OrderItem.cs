using LogisticsTrackingApp.Core.Models.BaseEntities;

namespace LogisticsTrackingApp.Core.Models
{
	public class OrderItem :BaseEntity
	{
		public string ShipmentName { get; set; }
		public decimal Price { get; set; }
		public int Quantity { get; set; }

		public int OrderId { get; set; } 
		public Order Order { get; set; }
	}
}