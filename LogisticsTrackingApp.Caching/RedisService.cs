using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsTrackingApp.Caching
{
	public class RedisService
	{
		private readonly IConnectionMultiplexer _connectionMultiplexer;


		public RedisService(string connectionString)
		{
			_connectionMultiplexer = ConnectionMultiplexer.Connect(connectionString);
		}

		public RedisService(IConnectionMultiplexer connectionMultiplexer)
		{
			_connectionMultiplexer = connectionMultiplexer;
		}

		public IDatabase GetDatabase(int dbIndex)
		{
			return _connectionMultiplexer.GetDatabase(dbIndex);
		}
		
	}
}
