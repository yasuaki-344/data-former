using System;
using System.Collections.Generic;
using DataFormer.ApplicationCore.Interfaces;
using DataFormer.ApplicationCore.ValueObjects;
using NPOI.SS.UserModel;

namespace DataFormer.ApplicationCore.Services
{
    public class ExcelDataSearchService : IExcelDataSearchService
    {
        /// <summary>
        /// Initializes a new instance of ExcelDataSearchService class.
        /// </summary>
        public ExcelDataSearchService()
        {
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
