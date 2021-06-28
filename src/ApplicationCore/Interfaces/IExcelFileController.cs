using NPOI.SS.UserModel;

namespace DataFormer.ApplicationCore.Interfaces
{
    public interface IExcelFileController
    {
        /// <summary>
        /// Output given workbook to the specified excel file path.
        /// </summary>
        /// <param name="filePath">excel file path</param>
        /// <returns>excel workbook</returns>
        IWorkbook Read(string filePath);

        /// <summary>
        /// Output given workbook to the specified excel file path.
        /// </summary>
        /// <param name="book">workbook to output</param>
        /// <param name="filePath">Output excel file path</param>
        void Write(IWorkbook book, string filePath);
    }
}
