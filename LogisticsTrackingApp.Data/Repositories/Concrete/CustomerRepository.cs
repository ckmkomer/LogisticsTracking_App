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
	public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
	{
		public CustomerRepository(LogisticsDbContext dbContext) : base(dbContext)
		{
		}

		public async Task<List<Customer>> GetCustomerWitShipment()
		{
			return await _dbContext.Customers.Include(x=>x.Shipments).ToListAsync();
		}
	}
}
