using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ConsoleAppFramework;
using DataFormer.ApplicationCore.BusinessLogics;
using DataFormer.ApplicationCore.Entities;
using DataFormer.ApplicationCore.Interfaces;
using DataFormer.ApplicationCore.Services;
using DataFormer.Infrastructure;
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
                    services.AddScoped<IExcelCellAccessor, ExcelCellAccessor>();
                    services.AddScoped<IMatrixDataManger, MatrixDataManger>();
                    services.AddScoped<ICellDataAccessor, CellDataAccessor>();
                    services.AddScoped<IExcelDataCleanService, ExcelDataCleanService>();
                    services.AddScoped<IExcelFileController, ExcelFileController>();
                })
                .RunConsoleAppFrameworkAsync<ApplicationLogic>(args);
        }
    }

    public class ApplicationLogic : ConsoleAppBase
    {
        private readonly ILogger<ApplicationLogic> _logger;

        private readonly IExcelDataCleanService _cleaner;
        /// <summary>
        /// Initializes a new instance of ApplicationLogic class.
        /// </summary>
        /// <param name="logger">Logger object</param>
        /// <param name="cleaner">Excel data cleaner object</param>
        public ApplicationLogic(
            ILogger<ApplicationLogic> logger,
            IExcelDataCleanService cleaner
        )
        {
            _logger = logger;
            _cleaner = cleaner;
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
                    var options = new JsonSerializerOptions
                    {
                        Converters =
                        {
                            new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
                        }
                    };
                    var config = JsonSerializer.Deserialize<AppConfig>(jsonString, options);
                    if (config != null)
                    {
                        _cleaner.CleanData(config);
                    }
                    else
                    {
                        _logger.LogError("config file read error");
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
