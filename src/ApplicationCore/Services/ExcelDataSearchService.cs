using System;
using System.Collections.Generic;
using DataFormer.ApplicationCore.Entities;
using DataFormer.ApplicationCore.Interfaces;
using DataFormer.ApplicationCore.ValueObjects;
using NPOI.SS.UserModel;

namespace DataFormer.ApplicationCore.Services
{
    public class ExcelDataSearchService : IExcelDataSearchService
    {
        private readonly IExcelDataExtractService _extractor;

        /// <summary>
        /// Initializes a new instance of ExcelDataSearchService class.
        /// </summary>
        /// <param name="extractor">Excel cell data extract object</param>
        public ExcelDataSearchService(IExcelDataExtractService extractor)
        {
            _extractor = extractor;
        }

        /// <inheritdoc/>
        public void ExtractData(ExtractConfig config)
        {
            throw new System.NotImplementedException();
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
