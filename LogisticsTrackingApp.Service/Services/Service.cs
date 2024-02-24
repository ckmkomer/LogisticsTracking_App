using LogisticsTrackingApp.Core.Models.BaseEntities;
using LogisticsTrackingApp.Core.Repositories;
using LogisticsTrackingApp.Core.Services;
using LogisticsTrackingApp.Data.UnitOfWork;
using LogisticsTrackingApp.Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsTrackingApp.Service.Services
{
	public class Service<T> : IService<T> where T : BaseEntity
	{ 
	    private readonly IGenericRepository<T> _repository;
		private readonly IUnitOfWork _unitOfWork;

		public Service(IGenericRepository<T> repository, IUnitOfWork unitOfWork)
		{
			_repository = repository;
			_unitOfWork = unitOfWork;
		}

		public void Add(T entity)
		{
			throw new NotImplementedException();
		}

		public async Task<T> DeleteAsync(T entity) 
		{
		     _repository.Delete(entity);
			await _unitOfWork.CommitAsync();
			return entity;
		}

		public async Task<IEnumerable<T>> GetAllAsync()
		{
			return await _repository.GetAllAsync();
		}

		public async Task<T> GetIdAsync(int id)
		{
			var hasValues = await _repository.GetIdAsync(id);
			if (hasValues == null)
			{
				throw new NotFoundExcepiton($"{typeof(T).Name}({id}) not found");
			}
			return hasValues;
		}

		public async Task<T> InsertAsync(T entity)
		{
			await _repository.AddAsync(entity);
			await _unitOfWork.CommitAsync();
			return entity;
		}

		public async Task<T> UpdateAsync(T entity)
		{
	     	 _repository.Update(entity);
			await _unitOfWork.CommitAsync();
			return entity;
		}
	}
}
