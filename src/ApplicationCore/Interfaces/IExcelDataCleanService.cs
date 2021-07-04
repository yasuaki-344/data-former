using DataFormer.ApplicationCore.Entities;

namespace DataFormer.ApplicationCore.Interfaces
{
    public interface IExcelDataCleanService
    {
        /// <summary>
        /// Extract, format, and output data based on the specified configuration.
        /// </summary>
        /// <param name="config">Data extract, format, and output configuration</param>
        void CleanData(AppConfig config);
    }
}
