using LogisticsTrackingApp.Core.Models;
using LogisticsTrackingApp.Data.Context;
using LogisticsTrackingApp.Data.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsTrackingApp.Data.Repositories.Concrete
{
	public class VehicleRepository : GenericRepository<Vehicle>, IVehicleRepository
	{
		public VehicleRepository(LogisticsDbContext dbContext) : base(dbContext)
		{
		}
	}
}
