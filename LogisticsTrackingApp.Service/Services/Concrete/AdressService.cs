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
	public class AdressService : Service<Adress>, IAdressService
	{
		public AdressService(IGenericRepository<Adress> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
		{
		}
	}
}
