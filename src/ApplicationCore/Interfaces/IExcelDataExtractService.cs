using System;
using NPOI.SS.UserModel;

namespace DataFormer.ApplicationCore.Interfaces
{
    public interface IExcelDataExtractService
    {
        DateTime? ReadDateTime(ISheet sheet, int rowIndex, int columnIndex);
        string? ReadLabel(ISheet sheet, int rowIndex, int columnIndex);
        double? ReadValue(ISheet sheet, int rowIndex, int columnIndex);
    }
}
