using System;
using System.Collections.Generic;
using DataFormer.ApplicationCore.Entities;
using DataFormer.ApplicationCore.Interfaces;
using DataFormer.ApplicationCore.ValueObjects;
using Microsoft.Extensions.Logging;
using NPOI.SS.UserModel;

namespace DataFormer.ApplicationCore.Services
{
    public class ExcelDataSearchService : IExcelDataSearchService
    {
        private readonly ILogger<ExcelDataSearchService> _logger;
        private readonly IExcelFileController _fileController;
        private readonly IExcelDataExtractService _extractor;

        /// <summary>
        /// Initializes a new instance of ExcelDataSearchService class.
        /// </summary>
        /// <param name="logger">Logger object</param>
        /// <param name="fileController">Excel file controll object</param>
        /// <param name="extractor">Excel cell data extract object</param>
        public ExcelDataSearchService(
            ILogger<ExcelDataSearchService> logger,
            IExcelFileController fileController,
            IExcelDataExtractService extractor
        )
        {
            _logger = logger;
            _fileController = fileController;
            _extractor = extractor;
        }

        /// <inheritdoc/>
        public void ExtractData(ExtractConfig config)
        {
            try
            {
                var book = _fileController.Read(config.InputFilePath);
                // TODO: data extract process
                _fileController.Write(book, config.OutputFilePath);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

        }

        /// <inheritdoc/>
        public IList<DateTime?> SearchDateTimes(ISheet sheet, SearchRule rule)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc/>
        public IList<string?> SearchLabels(ISheet sheet, SearchRule rule)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc/>
        public IList<double?> SearchNumerics(ISheet sheet, SearchRule rule)
        {
            throw new System.NotImplementedException();
        }
    }
}
