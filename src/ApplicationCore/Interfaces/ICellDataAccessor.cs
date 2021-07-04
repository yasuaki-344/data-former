using DataFormer.ApplicationCore.ValueObjects;
using NPOI.SS.UserModel;

namespace DataFormer.ApplicationCore.Interfaces
{
    public interface ICellDataAccessor
    {
        /// <summary>
        /// Extracts cell value and output it to the specified cell.
        /// </summary>
        /// <param name="type">Data type of cell value</param>
        /// <param name="readCell">Excel cell object to get data</param>
        /// <param name="writeCell">Excel cell object to set data</param>
        void ExtractCellValue(DataType type, ICell readCell, ICell writeCell);
    }
}
