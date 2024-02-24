using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsTrackingApp.Core.Dtos.ShipmentStatus
{
	public class ResultShipmentStatusDto :BaseDto
	{
		public string Status { get; set; } 
		public DateTime StatusDate { get; set; }


		public int ShipmentId { get; set; }
	}
}
