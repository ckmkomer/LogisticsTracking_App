using AutoMapper;
using LogisticsTrackingApp.Core.Dtos.AboutDtos;
using LogisticsTrackingApp.Core.Dtos.Abouts;
using LogisticsTrackingApp.Core.Dtos.AdressDtos;
using LogisticsTrackingApp.Core.Dtos.ContactDtos;
using LogisticsTrackingApp.Core.Dtos.ContactUsDtos;
using LogisticsTrackingApp.Core.Dtos.CustomerDtos;
using LogisticsTrackingApp.Core.Dtos.OrderDtos;
using LogisticsTrackingApp.Core.Dtos.OrderItemDtos;
using LogisticsTrackingApp.Core.Dtos.ReturnDtos;
using LogisticsTrackingApp.Core.Dtos.ShipmentDtos;
using LogisticsTrackingApp.Core.Dtos.ShipmentStatus;
using LogisticsTrackingApp.Core.Dtos.StationDtos;
using LogisticsTrackingApp.Core.Dtos.VehicleDtos;
using LogisticsTrackingApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsTrackingApp.Service.Mapping
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Customer,CreateCustomerDto>().ReverseMap();
			CreateMap<Customer,UpdateCustomerDto>().ReverseMap();
			CreateMap<Customer,ResultCustomerDto>().ReverseMap();

			CreateMap<Customer, CustomerWithShipmentDto>();

			CreateMap<About, CreateAboutDto>().ReverseMap();
			CreateMap<About, UpdateAboutDto>().ReverseMap();
			CreateMap<About, ResultAboutDto>().ReverseMap();

			CreateMap<Adress, CreateAdressDto>().ReverseMap();
			CreateMap<Adress, UpdateAdressDto>().ReverseMap();
			CreateMap<Adress, ResultAdressDto>().ReverseMap();

			CreateMap<Contact, CreateContactDto>().ReverseMap();
			CreateMap<Contact, UpdateContactDto>().ReverseMap();
			CreateMap<Contact, ResultContactDto>().ReverseMap();

			CreateMap<ContactUs, CreateContactUsDto>().ReverseMap();
			CreateMap<ContactUs, UpdateContactUsDto>().ReverseMap();
			CreateMap<ContactUs, ResultContactUsDto>().ReverseMap();

			CreateMap<Return, CreateReturnDto>().ReverseMap();
			CreateMap<Return, UpdateReturnDto>().ReverseMap();
			CreateMap<Return, ResultReturnDto>().ReverseMap();

			CreateMap<Shipment, CreateShipmentDto>().ReverseMap();
			CreateMap<Shipment, UpdateShipmentDto>().ReverseMap();
			CreateMap<Shipment, ResultShipmentDto>().ReverseMap();

			CreateMap<Station, CreateStationDto>().ReverseMap();
			CreateMap<Station, UpdateStationDto>().ReverseMap();
			CreateMap<Station, ResultStationDto>().ReverseMap();

			CreateMap<ShipmentStatus, CreateShipmentStatusDto>().ReverseMap();
			CreateMap<ShipmentStatus, UpdateShipmentStatusDto>().ReverseMap();
			CreateMap<ShipmentStatus, CreateShipmentStatusDto>().ReverseMap();


			CreateMap<Order, CreateOrderDto>().ReverseMap();
			CreateMap<Order, UpdateOrderDto>().ReverseMap();
			CreateMap<Order, ResultOrderDto>().ReverseMap();

			CreateMap<OrderItem, CreateOrderItemDto>().ReverseMap();
			CreateMap<OrderItem, UpdateOrderItemDto>().ReverseMap();
			CreateMap<OrderItem, ResultOrderItemDto>().ReverseMap();

			CreateMap<Vehicle, CreateVehicleDto>().ReverseMap();
			CreateMap<Vehicle, UpdateVehicleDto>().ReverseMap();
			CreateMap<Vehicle, ResultVehicleDto>().ReverseMap();


		}
	}
}
