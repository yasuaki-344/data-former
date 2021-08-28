using NPOI.SS.UserModel;

namespace DataFormer.ApplicationCore.Interfaces
{
    public interface IExcelCellAccessor
    {
        /// <summary>
        /// Gets the cell of specified row and column index in the specified sheet
        /// </summary>
        /// <param name="sheet">Excel sheet object</param>
        /// <param name="rowIndex">Row index of cell</param>
        /// <param name="columnIndex">Column index of cell</param>
        /// <returns></returns>
        ICell? GetReadCell(ISheet sheet, int rowIndex, int columnIndex);

        /// <summary>
        /// Gets or creates the cell of specified row and column index in the specified sheet
        /// </summary>
        /// <param name="sheet">Excel sheet object</param>
        /// <param name="rowIndex">Row index of cell</param>
        /// <param name="columnIndex">Column index of cell</param>
        /// <returns></returns>
        ICell GetWriteCell(ISheet sheet, int rowIndex, int columnIndex);

        /// <summary>
        /// Gets column index from column name.
        /// </summary>
        /// <param name="columnString">excel column name (ex. AC)</param>
        /// <returns>Colmun index</returns>
        int GetColumnIndex(string columnString);
    }
}
