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
    }
}
