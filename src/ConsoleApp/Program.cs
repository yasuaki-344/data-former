using System;
using System.Threading.Tasks;
using ConsoleAppFramework;
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
                })
                .RunConsoleAppFrameworkAsync<ApplicationLogic>(args);
        }
    }

    public class ApplicationLogic : ConsoleAppBase
    {
        private readonly ILogger<ApplicationLogic> _logger;
        private readonly IExcelDataExtractService _extractor;

        /// <summary>
        /// Initializes a new instance of ApplicationLogic class.
        /// </summary>
        /// <param name="logger">Logger object</param>
        /// <param name="extractor">Excel cell data extract object</param>
        public ApplicationLogic(
            ILogger<ApplicationLogic> logger,
            IExcelDataExtractService extractor
        )
        {
            _logger = logger;
            _extractor = extractor;
        }

        [Command("xlsx", "extract data from excel file")]
        public void ExtractDataFromExcelFile(
            [Option("i", "input Excel file path.")] string inputFilePath,
            [Option("o", "output Excel file path.")] string outputFilePath
        )
        {
            throw new System.NotImplementedException();
        }
    }
}
