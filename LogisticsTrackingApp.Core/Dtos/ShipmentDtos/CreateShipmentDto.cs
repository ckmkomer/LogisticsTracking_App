using LogisticsTrackingApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsTrackingApp.Core.Dtos.ShipmentDtos
{
	public class CreateShipmentDto :BaseDto
	{

		public string TrackingNumber { get; set; }

		public DateTime DeliverDate { get; set; }

		public int AdressId { get; set; }
		
		public int CustomerId { get; set; }
	

		public int OrderId { get; set; }
		

		public int VehicleId { get; set; }
	

	

	}
}
