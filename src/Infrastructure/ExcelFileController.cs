using System;
using System.IO;
using DataFormer.ApplicationCore.Interfaces;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace DataFormer.Infrastructure
{
    public class ExcelFileController : IExcelFileController
    {
        /// <summary>
        /// Initializes a new instance of ExcelFileController class.
        /// </summary>
        public ExcelFileController()
        {
        }

        /// <inheritdoc/>
        public IWorkbook Read(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            var extension = Path.GetExtension(filePath);

            try
            {
                return new XSSFWorkbook(filePath);
            }
            catch (IOException)
            {
                throw;
            }
        }

        /// <inheritdoc/>
        public void Write(IWorkbook book, string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            var extension = Path.GetExtension(filePath);
            if (extension != ".xlsx")
            {
                throw new ArgumentException("extention is not xlsx");
            }

            try
            {
                using (var fs = new FileStream(filePath, FileMode.Create))
                {
                    book.Write(fs);
                }
            }
            catch (IOException)
            {
                throw;
            }
        }
    }
}
