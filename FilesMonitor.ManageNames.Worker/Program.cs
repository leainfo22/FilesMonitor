using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RenombrarDocs.AsiaShipping.Worker;
using RenombrarDocs.Core.DTOs;
using RenombrarDocs.Infraestructure.Repository;
using RenombrarDocs.Core.Interfaces;
using System.Data;
using System.Data.SqlClient;
using RenombrarDocs.Core.Services;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

IHost host = Host.CreateDefaultBuilder(args)
	.ConfigureServices((context, services) =>
	{
		var dbConfig = context.Configuration.GetSection("ConnectionStrings").Get<ConnectionStringsDto>();
		var pathConfig = context.Configuration.GetSection("PathsConfiguration").Get<PathsConfigurationDto>();
		services.AddSingleton<IAgiliceDataBaseRepository, AgiliceDataBaseRepository>();
		services.AddSingleton<IWatcherFolder, WatcherFolder>();

		services.AddSingleton<IDbConnection>((sp) => new SqlConnection(dbConfig.AgiliceConnectionString));
		services.AddHostedService<Worker>();
		
	}).UseWindowsService(options =>
	{
		options.ServiceName = "Change name folder Asia Shipping";
	}).ConfigureLogging((context, log) =>
	{
		log.ClearProviders();
		log.SetMinimumLevel(LogLevel.Trace);
		log.AddNLog(context.Configuration);

	}).Build();

await host.RunAsync();