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
	public class OrderItemService : Service<OrderItem>, IOrderItemService
	{
		public OrderItemService(IGenericRepository<OrderItem> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
		{
		}
	}
}
