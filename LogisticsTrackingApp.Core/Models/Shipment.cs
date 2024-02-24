using LogisticsTrackingApp.Core.Models.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsTrackingApp.Core.Models
{
	public class Shipment :BaseEntity
	{
        public string TrackingNumber { get; set; }

        public DateTime DeliverDate { get; set; }

		public int AdressId { get; set; }
		public Adress Adress { get; set; }
		public int CustomerId { get; set; }
        public Customer Customer { get; set; }

		public int OrderId { get; set; } 
		public Order Order { get; set; }

		public int VehicleId { get; set; } 
		public Vehicle Vehicle { get; set; }

		public ICollection<ShipmentStatus> ShipmentStatuses { get; set; }








	}


}
