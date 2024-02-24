using LogisticsTrackingApp.Core.Models.BaseEntities;

namespace LogisticsTrackingApp.Core.Models
{
	public class ShipmentStatus :BaseEntity
	{
		public string Status { get; set; } // Sevkiyat durumu (Hazırlanıyor, Kargoya Verildi, Teslim Edildi)
		public DateTime StatusDate { get; set; }


		public int ShipmentId { get; set; } 
		public Shipment Shipment { get; set; }

		

	}
}