using System;
using NPOI.SS.UserModel;

namespace DataFormer.ApplicationCore.Interfaces
{
    public interface IExcelDataExtractService
    {
        /// <summary>
        /// Read the date time value from the specified cell.
        /// </summary>
        /// <param name="sheet">Excel sheet object</param>
        /// <param name="rowIndex">Row index of cell</param>
        /// <param name="columnIndex">Column index of cell</param>
        /// <returns>Return cell value if cell exists, otherwise null</returns>
        DateTime? ReadDateTime(ISheet sheet, int rowIndex, int columnIndex);

        /// <summary>
        /// Read the string value from the specified cell.
        /// </summary>
        /// <param name="sheet">Excel sheet object</param>
        /// <param name="rowIndex">Row index of cell</param>
        /// <param name="columnIndex">Column index of cell</param>
        /// <returns>Return cell value if cell exists, otherwise null</returns>
        string? ReadLabel(ISheet sheet, int rowIndex, int columnIndex);

        /// <summary>
        /// Read the numeric value from the specified cell.
        /// </summary>
        /// <param name="sheet">Excel sheet object</param>
        /// <param name="rowIndex">Row index of cell</param>
        /// <param name="columnIndex">Column index of cell</param>
        /// <returns>Return cell value if cell exists, otherwise null</returns>
        double? ReadValue(ISheet sheet, int rowIndex, int columnIndex);
    }
}
