using System;
using System.Linq;
using System.Text.RegularExpressions;
using DataFormer.ApplicationCore.Entities;
using DataFormer.ApplicationCore.Interfaces;
using DataFormer.ApplicationCore.ValueObjects;

namespace DataFormer.ApplicationCore.BusinessLogics
{
    public class MatrixDataManger : IMatrixDataManger
    {
        /// <summary>
        /// Initializes a new instance of MatrixDataManger class.
        /// </summary>
        public MatrixDataManger()
        {
        }

        /// <inheritdoc/>
        public int GetMaxDataNumber(SearchBlock block)
        {
            var maxDataNumber = block.ColumnSearch.Select(x => x.ColumnSize * x.RowSize).Max();
            return maxDataNumber;
        }

        /// <inheritdoc/>
        public (int Row, int Column) GetPosition(int index, SearchConfig config)
        {
            var modifiedIndex = index % (config.RowSize * config.ColumnSize);
            var rowIndex = config.InitialRow - 1;
            var columnIndex = GetColumnIndex(config.InitialColumn);
            if (columnIndex < 0)
            {
                throw new ArgumentException($"column name: {config.InitialColumn}");
            }

            switch (config.Direction)
            {
                case SearchDirection.Row:
                    {
                        int quotient = Math.DivRem(modifiedIndex, config.RowSize, out int remainder);
                        var rowPosition = rowIndex + remainder * config.RowIncrement;
                        var columnPosition = columnIndex + quotient * config.ColumnIncrement;
                        return (rowPosition, columnPosition);
                    }
                case SearchDirection.Column:
                    {
                        int quotient = Math.DivRem(modifiedIndex, config.ColumnSize, out int remainder);
                        var rowPosition = rowIndex + quotient * config.RowIncrement;
                        var columnPosition = columnIndex + remainder * config.ColumnIncrement;
                        return (rowPosition, columnPosition);
                    }
                default:
                    throw new ArgumentException();
            }
        }

        public int GetColumnIndex(string columnString)
        {
            var columnIndex = -1;
            var reg = "^[A-Z]+$";
            var matcher = Regex.Match(columnString, reg);
            if (matcher.Success)
            {
                var chars = columnString.ToCharArray();
                var j = 1;
                foreach (var x in chars.Reverse())
                {
                    columnIndex += ((int)x - 65 + 1) * j;
                    j *= 26;
                }
            }
            return columnIndex;
        }
    }
}
