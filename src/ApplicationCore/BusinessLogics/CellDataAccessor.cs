using System;
using DataFormer.ApplicationCore.Interfaces;
using DataFormer.ApplicationCore.ValueObjects;
using NPOI.SS.UserModel;

namespace DataFormer.ApplicationCore.BusinessLogics
{
    public class CellDataAccessor : ICellDataAccessor
    {
        private readonly string _datetimeFormat = "yyyy/MM/dd HH:mm:ss";
        private readonly string _dateFormat = "yyyy/MM/dd";
        private readonly string _timeFormat = "HH:mm:ss";

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
                    {
                        var value = Math.Floor(readCell.NumericCellValue);
                        writeCell.SetCellValue(value);
                    }
                    break;
                case DataType.Decimal:
                    {
                        var value = readCell.NumericCellValue;
                        writeCell.SetCellValue(value);
                    }
                    break;
                case DataType.DateTime:
                    {
                        var value = readCell.DateCellValue;
                        writeCell.SetCellValue(value.ToString(_datetimeFormat));
                    }
                    break;
                case DataType.Date:
                    {
                        var value = readCell.DateCellValue;
                        writeCell.SetCellValue(value.ToString(_dateFormat));
                    }
                    break;
                case DataType.Time:
                    {
                        var value = readCell.DateCellValue;
                        writeCell.SetCellValue(value.ToString(_timeFormat));
                    }
                    break;
                case DataType.Label:
                    {
                        var value = readCell.StringCellValue;
                        if (!string.IsNullOrEmpty(value))
                        {
                            writeCell.SetCellValue(value);
                        }
                    }
                    break;
                case DataType.Boolean:
                    {
                        var value = readCell.BooleanCellValue;
                        writeCell.SetCellValue(value);
                    }
                    break;
                case DataType.Formula:
                    {

                    }
                    break;
                case DataType.Comment:
                    {
                        var value = readCell.CellComment.String.String;
                        if (!string.IsNullOrEmpty(value))
                        {
                            writeCell.SetCellValue(value);
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
