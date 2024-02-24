using Autofac.Extensions.DependencyInjection;
using Autofac;
using LogisticsTrackingApp.API.Filters;
using LogisticsTrackingApp.API.Middlewares;
using LogisticsTrackingApp.API.Modules;
using LogisticsTrackingApp.Core.Repositories;
using LogisticsTrackingApp.Core.Services;
using LogisticsTrackingApp.Data.Context;
using LogisticsTrackingApp.Data.Repositories;
using LogisticsTrackingApp.Data.Repositories.Abstract;
using LogisticsTrackingApp.Data.Repositories.Concrete;
using LogisticsTrackingApp.Data.UnitOfWork;
using LogisticsTrackingApp.Service.Mapping;
using LogisticsTrackingApp.Service.Services;
using LogisticsTrackingApp.Service.Services.Abstract;
using LogisticsTrackingApp.Service.Services.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => { options.Filters.Add(new ValidaterFilterAttribute()); });

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
	options.SuppressModelStateInvalidFilter = true; //validatiortfilter akif deðil. 
});
	
	//.AddFluentValidation(x=>x.RegisterValidatorsFromAssemblyContaining<AboutValidator>());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionString = builder.Configuration.GetConnectionString("DbCon");
builder.Services.AddDbContext<LogisticsDbContext>(x => x.UseNpgsql(connectionString));
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped(typeof(NotFoundFilter<>));

//builder.Services.AddScoped<IUnitOfWork , UnitOfWork>();
//builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
//builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));


//builder.Services.AddScoped<ICustomerRepository,CustomerRepository>();
//builder.Services.AddScoped<ICustomerService ,CustomerService>();

//builder.Services.AddScoped<IAboutRepository,AboutRepository>();
//builder.Services.AddScoped<IAboutService, AboutService>();
//builder.Services.AddScoped<IAdressRepository, AdressRepository>();
//builder.Services.AddScoped<IAdressService, AdressService>();
//builder.Services.AddScoped<IContactRepository, ContactRepository>();
//builder.Services.AddScoped<IContactService, ContactService>();
//builder.Services.AddScoped<IContactUsRepository, ContactUsRepository>();
//builder.Services.AddScoped<IContactUsService, ContactUsService>();
//builder.Services.AddScoped<IReturnRepository, ReturnRepository>();
//builder.Services.AddScoped<IReturnService, ReturnService>();
//builder.Services.AddScoped<IShipmentRepository, ShipmentRepository>();
//builder.Services.AddScoped<IShipmentService, ShipmentService>();
//builder.Services.AddScoped<IStationRepository, StationRepository>();
//builder.Services.AddScoped<IStationService, StationService>();

builder.Host.UseServiceProviderFactory
	(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<Autofac.ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new RepoServiceModule()));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseCustomException();

app.UseAuthorization();

app.MapControllers();

app.Run();
