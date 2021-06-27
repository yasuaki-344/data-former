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

        /// <inheritdoc/>
        public DateTime? ReadDateTime(ISheet sheet, int rowIndex, int columnIndex)
        {
            var row = sheet.GetRow(rowIndex);
            if (row != null)
            {
                var cell = row.GetCell(columnIndex);
                return cell != null ? cell.DateCellValue : null;
            }
            else
            {
                return null;
            }
        }

        /// <inheritdoc/>
        public string? ReadLabel(ISheet sheet, int rowIndex, int columnIndex)
        {
            var row = sheet.GetRow(rowIndex);
            if (row != null)
            {
                var cell = row.GetCell(columnIndex);
                return cell != null ? cell.StringCellValue : null;
            }
            else
            {
                return null;
            }
        }

        /// <inheritdoc/>
        public double? ReadNumeric(ISheet sheet, int rowIndex, int columnIndex)
        {
            var row = sheet.GetRow(rowIndex);
            if (row != null)
            {
                var cell = row.GetCell(columnIndex);
                return cell != null ? cell.NumericCellValue : null;
            }
            else
            {
                return null;
            }
        }
    }
}
