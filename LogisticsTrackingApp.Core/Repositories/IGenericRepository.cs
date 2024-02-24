using LogisticsTrackingApp.Core.Models.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsTrackingApp.Core.Repositories
{
	public interface IGenericRepository<T> where T : BaseEntity
	{

		Task<IEnumerable<T>> GetAllAsync();

		Task<T> GetIdAsync(int id);

		Task AddAsync(T entity);
		void Add(T entity);
		void Update(T entity);

		void Delete(T entity);

	}
}
