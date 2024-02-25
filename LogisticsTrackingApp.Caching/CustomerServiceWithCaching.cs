using AutoMapper;
using LogisticsTrackingApp.Core.Dtos.CustomerDtos;
using LogisticsTrackingApp.Core.Models;
using LogisticsTrackingApp.Core.Services;
using LogisticsTrackingApp.Data.Repositories.Abstract;
using LogisticsTrackingApp.Data.UnitOfWork;
using LogisticsTrackingApp.Service.Exceptions;
using LogisticsTrackingApp.Service.Services.Abstract;
using StackExchange.Redis;
using System.Text.Json;

namespace LogisticsTrackingApp.Caching
{
	public class CustomerServiceWithCaching : ICustomerService
	{
		private const string CacheCustomerKey = "customerCaches";
		private readonly ICustomerRepository _customerRepository;
		private readonly RedisService _redisService;
		private readonly UnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IDatabase _cacheRepository;

		public CustomerServiceWithCaching(ICustomerRepository customerRepository, RedisService redisService, UnitOfWork unitOfWork, IMapper mapper)
		{
			_customerRepository = customerRepository;
			_redisService = redisService;
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_cacheRepository = _redisService.GetDatabase(0);

			InitializeCache(); // InitializeCache metodu çağrılıyor
		}

		private void InitializeCache()
		{
			var cachedCustomers = _cacheRepository.StringGet(CacheCustomerKey);
			if (!cachedCustomers.IsNullOrEmpty)
			{
				_cacheRepository.StringSet(CacheCustomerKey, JsonSerializer.Serialize(_customerRepository.GetAllAsync().Result)); //senkron
			}
		}

		public async Task Add(Customer entity)
		{
			_customerRepository.Add(entity);
			await _unitOfWork.CommitAsync();
			await CacheAllCustomer();
		}

		public async Task<Customer> DeleteAsync(Customer entity)
		{
			_customerRepository.Delete(entity);
			await _unitOfWork.CommitAsync();
			await CacheAllCustomer();
			return entity;
		}

		public Task<IEnumerable<Customer>> GetAllAsync()
		{
			var cachedCustomers = _cacheRepository.StringGet(CacheCustomerKey);
			return Task.FromResult(JsonSerializer.Deserialize<IEnumerable<Customer>>(cachedCustomers));
		}

		public async Task<List<CustomerWithShipmentDto>> GetCustomerWitShipment()
		{
			var customer = await _customerRepository.GetCustomerWitShipment();
			var customerWithShipment = _mapper.Map<List<CustomerWithShipmentDto>>(customer);
			return customerWithShipment;
		}

		public async Task<Customer> GetIdAsync(int id)
		{
			var cachedCustomers = _cacheRepository.StringGet(CacheCustomerKey);
			var cacheCustomer = JsonSerializer.Deserialize<IEnumerable<Customer>>(cachedCustomers).FirstOrDefault(x => x.Id == id);
			if (cacheCustomer == null)
			{
				throw new NotFoundExcepiton($"{typeof(Customer).Name}({id}) not found");
			}
			return cacheCustomer;
		}

		public async Task<Customer> InsertAsync(Customer entity)
		{
			await _customerRepository.AddAsync(entity);
			await _unitOfWork.CommitAsync();
			await CacheAllCustomer();
			return entity;
		}

		public async Task<Customer> UpdateAsync(Customer entity)
		{
			_customerRepository.Update(entity);
			await _unitOfWork.CommitAsync();
			await CacheAllCustomer();
			return entity;
		}

		private async Task CacheAllCustomer()
		{
			var customers = await _customerRepository.GetAllAsync();
			_cacheRepository.StringSet(CacheCustomerKey, JsonSerializer.Serialize(customers));
		}

		void IService<Customer>.Add(Customer entity)
		{
			throw new NotImplementedException();
		}
	}
}
