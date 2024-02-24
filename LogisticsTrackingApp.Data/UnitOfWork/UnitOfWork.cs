using LogisticsTrackingApp.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsTrackingApp.Data.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly LogisticsDbContext _dbContext;

		public UnitOfWork(LogisticsDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public void Commit()
		{
			_dbContext.SaveChanges();
		}

		public async Task CommitAsync()
		{
			await _dbContext.SaveChangesAsync();
		}
	}
}
