using System;
using System.Collections.Generic;
using System.Linq;
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
            switch (config.Direction)
            {
                case SearchDirection.Row:
                    {
                        int quotient = Math.DivRem(modifiedIndex, config.RowSize, out int remainder);
                        var rowPosition = config.InitialRowPostion + remainder * config.RowIncrement;
                        var columnPosition = config.InitialColumnPosition + quotient * config.ColumnIncrement;
                        return (rowPosition, columnPosition);
                    }
                case SearchDirection.Column:
                    {
                        int quotient = Math.DivRem(modifiedIndex, config.ColumnSize, out int remainder);
                        var rowPosition = config.InitialRowPostion + quotient * config.RowIncrement;
                        var columnPosition = config.InitialColumnPosition + remainder * config.ColumnIncrement;
                        return (rowPosition, columnPosition);
                    }
                default:
                    throw new ArgumentException();
            }
        }
    }
}
