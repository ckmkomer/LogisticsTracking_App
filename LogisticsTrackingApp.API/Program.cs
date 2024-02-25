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
using LogisticsTrackingApp.Service.Logging;
using Microsoft.EntityFrameworkCore.Storage;
using LogisticsTrackingApp.Caching;
using Microsoft.Extensions.DependencyInjection;

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

builder.Services.AddSingleton<RedisService>(sp =>
{
	return new RedisService(builder.Configuration["CacheOptions:url"]);
});

builder.Services.AddSingleton<StackExchange.Redis.IDatabase>(sp =>
{
	var redisService = sp.GetRequiredService<RedisService>();
	return redisService.GetDatabase(0);
});



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
