using LogisticsTrackingApp.Core.Models.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsTrackingApp.Core.Models
{
	public class Vehicle :BaseEntity
	{
		
		public string PlateNumber { get; set; }
		public string Model { get; set; }
		public string Brand { get; set; }

		public ICollection<Shipment> Shipments { get; set; }
	}
}
