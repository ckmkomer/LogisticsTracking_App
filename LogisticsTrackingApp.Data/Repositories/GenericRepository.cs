using LogisticsTrackingApp.Core.Models.BaseEntities;
using LogisticsTrackingApp.Core.Repositories;
using LogisticsTrackingApp.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsTrackingApp.Data.Repositories
{
	public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
	{
		protected readonly LogisticsDbContext _dbContext;
		private readonly DbSet<T> _dbSet;

		public GenericRepository(LogisticsDbContext dbContext)
		{
			_dbContext = dbContext;
			_dbSet = _dbContext.Set<T>();
		}

		public void Add(T entity)
		{
			_dbSet.Add(entity);
		}

		public async Task AddAsync(T entity)
		{
			await _dbSet.AddAsync(entity);
		}

		public void Delete(T entity)
		{
			_dbSet.Remove(entity);
		}

		public async Task<IEnumerable<T>> GetAllAsync()
		{
			return await _dbSet.ToListAsync();
		}

		public async Task<T> GetIdAsync(int id)
		{
			return await _dbSet.FindAsync(id);
		}

		public void  Remove(T entity)
		{
		   _dbSet.Remove(entity);
		}

		public void Update(T entity)
		{
			_dbSet.Update(entity);
		}


	}
}
