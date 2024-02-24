using LogisticsTrackingApp.Core.Models.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsTrackingApp.Core.Models
{
	public class Return :BaseEntity
	{
		
        public string Reason { get; set; }

        public DateTime ReturnDate { get; set; }

		public int ShipmentId { get; set; }
		public Shipment Shipment { get; set; }

		public int CustomerId { get; set; }
		public Customer Customer { get; set; }
	}
}
