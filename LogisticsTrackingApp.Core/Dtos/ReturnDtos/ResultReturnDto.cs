using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsTrackingApp.Core.Dtos.ReturnDtos
{
	public class ResultReturnDto :BaseDto
	{
		public string Reason { get; set; }

		public DateTime ReturnDate { get; set; }

		public int ShipmentId { get; set; }

		public int CustomerId { get; set; }

	}
}
