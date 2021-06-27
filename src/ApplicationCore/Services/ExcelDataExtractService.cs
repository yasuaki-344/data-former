using System;
using DataFormer.ApplicationCore.Interfaces;
using NPOI.SS.UserModel;

namespace DataFormer.ApplicationCore.Services
{
    public class ExcelDataExtractService : IExcelDataExtractService
    {
        /// <summary>
        /// Initializes a new instance of ExcelDataExtractService class.
        /// </summary>
        public ExcelDataExtractService()
        {
        }

        public DateTime? ReadDateTime(ISheet sheet, int rowIndex, int columnIndex)
        {
            throw new NotImplementedException();
        }

        public string? ReadLabel(ISheet sheet, int rowIndex, int columnIndex)
        {
            throw new NotImplementedException();
        }

        public double? ReadValue(ISheet sheet, int rowIndex, int columnIndex)
        {
            throw new NotImplementedException();
        }
    }
}
