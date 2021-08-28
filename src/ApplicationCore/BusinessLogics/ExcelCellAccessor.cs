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
    }
}
