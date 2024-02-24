using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsTrackingApp.Core.Dtos.CustomerDtos
{
	public  class CreateCustomerDto
	{
        public int Id { get; set; }
        public string FullName { get; set; }
		public string City { get; set; }
	}
}
