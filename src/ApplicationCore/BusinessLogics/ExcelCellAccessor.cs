using System;
using System.Linq;
using System.Text.RegularExpressions;
using DataFormer.ApplicationCore.Interfaces;
using NPOI.SS.UserModel;

namespace DataFormer.ApplicationCore.BusinessLogics
{
    public class ExcelCellAccessor : IExcelCellAccessor
    {
        /// <summary>
        /// Initializes a new instance of ExcelCellAccessor class.
        /// </summary>
        public ExcelCellAccessor()
        {
        }

        /// <inheritdoc/>
        public ICell? GetReadCell(ISheet sheet, int rowIndex, int columnIndex)
        {
            var row = sheet.GetRow(rowIndex);
            var cell = row?.GetCell(columnIndex);
            return cell;
        }

        /// <inheritdoc/>
        public ICell GetWriteCell(ISheet sheet, int rowIndex, int columnIndex)
        {
            var row = sheet.GetRow(rowIndex) ?? sheet.CreateRow(rowIndex);
            var cell = row.GetCell(columnIndex) ?? row.CreateCell(columnIndex);
            return cell;
        }

        /// <inheritdoc/>
        public int GetColumnIndex(string columnString)
        {
            var columnIndex = -1;
            var reg = "^[A-Z]+$";
            var matcher = Regex.Match(columnString, reg);
            if (matcher.Success)
            {
                var chars = columnString.ToCharArray();
                var j = 0;
                foreach (var x in chars.Reverse())
                {
                    var coeff = (j == 0 ? 1 : (int)Math.Pow(26, j));
                    columnIndex += ((int)x - 65 + 1) * coeff;
                    j++;
                }
            }
            return columnIndex;
        }
    }
}
