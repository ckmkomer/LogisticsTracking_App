using LogisticsTrackingApp.Core.Models.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsTrackingApp.Core.Models
{
	public class Adress :BaseEntity
	{
		public string Street { get; set; }
		public string City { get; set; }
		public string PostalCode { get; set; }
		public string Country { get; set; }

		public ICollection<Shipment> Shipments { get; set; }

	}
}
