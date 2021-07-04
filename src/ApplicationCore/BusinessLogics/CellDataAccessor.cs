using System;
using DataFormer.ApplicationCore.Interfaces;
using DataFormer.ApplicationCore.ValueObjects;
using NPOI.SS.UserModel;

namespace DataFormer.ApplicationCore.BusinessLogics
{
    public class CellDataAccessor : ICellDataAccessor
    {
        /// <summary>
        /// Initializes a new instance of CellDataAccessor class.
        /// </summary>
        public CellDataAccessor()
        {
        }

        /// <inheritdoc/>
        public void ExtractCellValue(DataType type, ICell readCell, ICell writeCell)
        {
            switch (type)
            {
                case DataType.Integer:
                    throw new NotImplementedException();
                case DataType.Decimal:
                    throw new NotImplementedException();
                case DataType.Numeric:
                    {
                        var value = readCell.NumericCellValue;
                        writeCell.SetCellValue(value);
                    }
                    break;
                case DataType.DateTime:
                    {
                        var value = readCell.DateCellValue;
                        writeCell.SetCellValue(((DateTime)value).ToString("yyyy/MM/dd HH:mm:ss"));
                    }
                    break;
                case DataType.Time:
                    throw new NotImplementedException();
                case DataType.Label:
                    {
                        var value = readCell.StringCellValue;
                        writeCell.SetCellValue(value);
                    }
                    break;
                case DataType.Boolean:
                    throw new NotImplementedException();
                default:
                    break;
            }
        }
    }
}
