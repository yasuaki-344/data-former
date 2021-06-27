using System;
using System.Threading.Tasks;
using ConsoleAppFramework;
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
        /// <param name="logger">logger object</param>
        public ApplicationLogic(
            ILogger<ApplicationLogic> logger
        )
        {
            _logger = logger;
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
