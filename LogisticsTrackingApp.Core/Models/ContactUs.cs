using LogisticsTrackingApp.Core.Models.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsTrackingApp.Core.Models
{
	public  class ContactUs : BaseEntity
	{
        public string Email { get; set; }
		public string Phone { get; set; }
		public string Adress { get; set; }
    }
}
