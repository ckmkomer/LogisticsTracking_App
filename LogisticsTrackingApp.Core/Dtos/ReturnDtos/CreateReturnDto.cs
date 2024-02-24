using LogisticsTrackingApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsTrackingApp.Core.Dtos.ReturnDtos
{
	public class CreateReturnDto 
	{

		public string Reason { get; set; }

		public DateTime ReturnDate { get; set; }

		public int ShipmentId { get; set; }
		
		public int CustomerId { get; set; }
		

	}
}
