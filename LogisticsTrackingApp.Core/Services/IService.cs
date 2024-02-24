using LogisticsTrackingApp.Core.Models.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsTrackingApp.Core.Services
{
	public interface IService<T> where T : BaseEntity
	{
		Task<IEnumerable<T>> GetAllAsync();

		Task<T> GetIdAsync(int id);

		Task<T> InsertAsync(T entity);

		void Add(T entity);

		Task<T> UpdateAsync(T entity);

		Task<T> DeleteAsync(T Entity);
	}
}
