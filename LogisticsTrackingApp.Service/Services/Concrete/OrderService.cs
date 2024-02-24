using LogisticsTrackingApp.Core.Models;
using LogisticsTrackingApp.Core.Repositories;
using LogisticsTrackingApp.Data.UnitOfWork;
using LogisticsTrackingApp.Service.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsTrackingApp.Service.Services.Concrete
{
	public class OrderService : Service<Order>, IOrderService
	{
		public OrderService(IGenericRepository<Order> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
		{
		}
	}
}
