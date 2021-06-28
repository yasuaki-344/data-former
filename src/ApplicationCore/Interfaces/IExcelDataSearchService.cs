using System;
using System.Collections.Generic;
using DataFormer.ApplicationCore.Entities;
using DataFormer.ApplicationCore.ValueObjects;
using NPOI.SS.UserModel;

namespace DataFormer.ApplicationCore.Interfaces
{
    public interface IExcelDataSearchService
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="config"></param>
        void ExtractData(ExtractConfig config);

        /// <summary>
        /// Searchs the date time values based on the specified search rule.
        /// </summary>
        /// <param name="sheet">Excel sheet object</param>
        /// <param name="rule">Search rule to get value</param>
        /// <returns>List of searched data</returns>
        IList<DateTime?> SearchDateTimes(ISheet sheet, SearchRule rule);

        /// <summary>
        /// Searchs the string values based on the specified search rule.
        /// </summary>
        /// <param name="sheet">Excel sheet object</param>
        /// <param name="rule">Search rule to get value</param>
        /// <returns>List of searched data</returns>
        IList<string?> SearchLabels(ISheet sheet, SearchRule rule);

        /// <summary>
        /// Searchs the numeric values based on the specified search rule.
        /// </summary>
        /// <param name="sheet">Excel sheet object</param>
        /// <param name="rule">Search rule to get value</param>
        /// <returns>List of searched data</returns>
        IList<double?> SearchNumerics(ISheet sheet, SearchRule rule);
    }
}
