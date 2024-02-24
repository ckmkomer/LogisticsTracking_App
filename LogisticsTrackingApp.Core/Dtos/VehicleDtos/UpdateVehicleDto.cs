using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsTrackingApp.Core.Dtos.VehicleDtos
{
	public class UpdateVehicleDto :BaseDto
	{
		
		public string PlateNumber { get; set; }
		public string Model { get; set; }
		public string Brand { get; set; }
	}
}
