using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using RenombrarDocs.Core.DTOs;
using RenombrarDocs.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace RenombrarDocs.AsiaShipping.Worker
{
	public class Worker : BackgroundService
	{
		private readonly IWatcherFolder _watcherFolder;
		private readonly IConfiguration _configuration;
		private readonly ILogger<Worker> _logger;

		public Worker(ILogger<Worker> logger, IConfiguration configuration, IWatcherFolder watcherFolder)
		{
			_configuration = configuration;
			_watcherFolder = watcherFolder;
			_logger = logger;
		}

		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			while (!stoppingToken.IsCancellationRequested) 
			{
				try
				{
					var pathConfig = _configuration.GetSection("PathsConfiguration").Get<PathsConfigurationDto>();
					await _watcherFolder.Watcher(pathConfig.PathIn, pathConfig.PathOut, _logger);
					await Task.Delay(Timeout.Infinite, stoppingToken);
				}
				catch (Exception ex) 
				{
					Console.WriteLine(ex.Message);
					_logger.LogInformation(ex.Message,ex);
				}
				
			}
					
		}
	}
}
