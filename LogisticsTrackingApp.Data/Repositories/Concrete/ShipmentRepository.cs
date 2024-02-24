using LogisticsTrackingApp.Core.Models;
using LogisticsTrackingApp.Data.Context;
using LogisticsTrackingApp.Data.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsTrackingApp.Data.Repositories.Concrete
{
	public class ShipmentRepository : GenericRepository<Shipment>, IShipmentRepository
	{
		public ShipmentRepository(LogisticsDbContext dbContext) : base(dbContext)
		{
		}
	}
}
