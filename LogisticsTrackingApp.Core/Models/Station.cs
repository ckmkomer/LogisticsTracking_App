using LogisticsTrackingApp.Core.Models.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsTrackingApp.Core.Models
{
	public class Station :BaseEntity

 	{
        public string Location { get; set; }
        public string Destination { get; set; }


		public ICollection<Shipment> Shipments { get; set; }
	}
}
