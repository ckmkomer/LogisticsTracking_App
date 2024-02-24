using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsTrackingApp.Core.Dtos.StationDtos
{
	public class UpdateStationDto :BaseDto
	{
       
        public string Location { get; set; }
		public string Destination { get; set; }
	}
}
