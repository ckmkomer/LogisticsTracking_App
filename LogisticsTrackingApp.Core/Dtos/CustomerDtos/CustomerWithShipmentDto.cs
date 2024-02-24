using LogisticsTrackingApp.Core.Dtos.ShipmentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsTrackingApp.Core.Dtos.CustomerDtos
{
	public class CustomerWithShipmentDto :CreateCustomerDto
	{
        public  CreateShipmentDto Shipment{ get; set; }
    }
}
