using System;
using DataFormer.ApplicationCore.Entities;
using DataFormer.ApplicationCore.Interfaces;
using DataFormer.ApplicationCore.ValueObjects;
using NPOI.SS.UserModel;

namespace DataFormer.ApplicationCore.BusinessLogics
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

        public (int Row, int Column) GetCellPosition(int index, SearchConfig rule)
        {
            switch (rule.Direction)
            {
                case SearchDirection.Row:
                    {
                        int quotient = Math.DivRem(index, rule.RowSize, out int remainder);
                        var rowPosition = rule.InitialRowPostion + remainder * rule.RowIncrement;
                        var columnPosition = rule.InitialColumnPosition + quotient * rule.ColumnIncrement;
                        return (rowPosition, columnPosition);
                    }
                case SearchDirection.Column:
                    {
                        int quotient = Math.DivRem(index, rule.ColumnSize, out int remainder);
                        var rowPosition = rule.InitialRowPostion + quotient * rule.RowIncrement;
                        var columnPosition = rule.InitialColumnPosition + remainder * rule.ColumnIncrement;
                        return (rowPosition, columnPosition);
                    }
                default:
                    throw new ArgumentException();
            }
        }
    }
}
