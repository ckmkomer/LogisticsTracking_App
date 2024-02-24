using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsTrackingApp.Core.Dtos.ContactUsDtos
{
	public class UpdateContactUsDto :BaseDto
	{
      
        public string Email { get; set; }
		public string Phone { get; set; }
		public string Adress { get; set; }
	}
}
