using LogisticsTrackingApp.Core.Models;
using LogisticsTrackingApp.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsTrackingApp.Data.Repositories.Concrete
{
	public class ShipmentStatusRepository : GenericRepository<ShipmentStatus>
	{
		public ShipmentStatusRepository(LogisticsDbContext dbContext) : base(dbContext)
		{
		}
	}
}
