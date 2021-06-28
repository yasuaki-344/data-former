using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using ConsoleAppFramework;
using DataFormer.ApplicationCore.BusinessLogics;
using DataFormer.ApplicationCore.Entities;
using DataFormer.ApplicationCore.Interfaces;
using DataFormer.ApplicationCore.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DataFormer.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await Host.CreateDefaultBuilder()
                .ConfigureLogging(logging =>
                {

                })
                .ConfigureServices((context, services) =>
                {
                    // Dependency injection setting
                    services.AddScoped<IExcelDataExtractService, ExcelDataExtractService>();
                    services.AddScoped<IExcelDataSearchService, ExcelDataSearchService>();
                })
                .RunConsoleAppFrameworkAsync<ApplicationLogic>(args);
        }
    }

    public class ApplicationLogic : ConsoleAppBase
    {
        private readonly ILogger<ApplicationLogic> _logger;

        /// <summary>
        /// Initializes a new instance of ApplicationLogic class.
        /// </summary>
        /// <param name="logger">Logger object</param>
        /// <param name="extractor">Excel cell data extract object</param>
        public ApplicationLogic(
            ILogger<ApplicationLogic> logger
        )
        {
            _logger = logger;
        }

        public void ExtractDataFromExcelFile(
            [Option("c", "config file path.")] string configFilePath = "default.json"
        )
        {
            _logger.LogInformation(Directory.GetCurrentDirectory());
            if (File.Exists(configFilePath))
            {
                using (var sr = File.OpenText(configFilePath))
                {
                    var jsonString = sr.ReadToEnd();
                    var config = JsonSerializer.Deserialize<ExtractConfig>(jsonString);
                    if (config != null)
                    {

                    }
                }
            }
            else
            {
                _logger.LogError($"config file not found: {configFilePath}");
            }
        }
    }
}
