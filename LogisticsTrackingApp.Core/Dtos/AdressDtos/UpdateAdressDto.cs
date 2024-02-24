using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsTrackingApp.Core.Dtos.AdressDtos
{
	public class UpdateAdressDto :BaseDto
	{
	
		public string Street { get; set; }
		public string City { get; set; }
		public string PostalCode { get; set; }
		public string Country { get; set; }
	}
}
