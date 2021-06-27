using System;
using DataFormer.ApplicationCore.BusinessLogics;
using NPOI.XSSF.UserModel;
using Xunit;

namespace DataFormer.ApplicationCore.Test
{
    public class ExcelDataExtractServiceTest
    {
        [Theory]
        [InlineData(0, 0, 2021, 1, 1)]
        [InlineData(5, 1, 2021, 6, 30)]
        [InlineData(1, 5, 2021, 12, 31)]
        public void ReturnDateTimeCorrectly(int rowIndex, int columnIndex, int year, int month, int day)
        {
            var expect = new DateTime(year, month, day);
            var book = new XSSFWorkbook();
            book.CreateSheet("title");
            var sheet = book.GetSheet("title");
            var row = sheet.CreateRow(rowIndex);
            row.CreateCell(columnIndex).SetCellValue(expect);

            var target = new ExcelDataExtractService();
            var actual = target.ReadDateTime(sheet, rowIndex, columnIndex);
            Assert.Equal(expect, actual);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(5, 1)]
        [InlineData(1, 5)]
        public void ReadDateTimeReturnNullIfCellNotExists(int rowIndex, int columnIndex)
        {
            var book = new XSSFWorkbook();
            book.CreateSheet("test");
            var sheet = book.GetSheet("test");

            var target = new ExcelDataExtractService();
            var actual = target.ReadDateTime(sheet, rowIndex, columnIndex);
            Assert.Null(actual);
        }

        [Theory]
        [InlineData(0, 0, "")]
        [InlineData(5, 1, "test")]
        [InlineData(1, 5, "sample label")]
        public void ReturnLabelCorrectly(int rowIndex, int columnIndex, string expect)
        {
            var book = new XSSFWorkbook();
            book.CreateSheet("title");
            var sheet = book.GetSheet("title");
            var row = sheet.CreateRow(rowIndex);
            row.CreateCell(columnIndex).SetCellValue(expect);

            var target = new ExcelDataExtractService();
            var actual = target.ReadLabel(sheet, rowIndex, columnIndex);
            Assert.Equal(expect, actual);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(5, 1)]
        [InlineData(1, 5)]
        public void ReadLabelReturnNullIfCellNotExists(int rowIndex, int columnIndex)
        {
            var book = new XSSFWorkbook();
            book.CreateSheet("test");
            var sheet = book.GetSheet("test");

            var target = new ExcelDataExtractService();
            var actual = target.ReadLabel(sheet, rowIndex, columnIndex);
            Assert.Null(actual);
        }

        [Theory]
        [InlineData(0, 0, 11.1)]
        [InlineData(5, 1, 23.4)]
        [InlineData(1, 5, 45.6)]
        public void ReturnNumericCorrectly(int rowIndex, int columnIndex, double expect)
        {
            var book = new XSSFWorkbook();
            book.CreateSheet("title");
            var sheet = book.GetSheet("title");
            var row = sheet.CreateRow(rowIndex);
            row.CreateCell(columnIndex).SetCellValue(expect);

            var target = new ExcelDataExtractService();
            var actual = target.ReadNumeric(sheet, rowIndex, columnIndex);
            Assert.Equal(expect, actual);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(5, 1)]
        [InlineData(1, 5)]
        public void ReadNumericReturnNullIfCellNotExists(int rowIndex, int columnIndex)
        {
            var book = new XSSFWorkbook();
            book.CreateSheet("test");
            var sheet = book.GetSheet("test");

            var target = new ExcelDataExtractService();
            var actual = target.ReadNumeric(sheet, rowIndex, columnIndex);
            Assert.Null(actual);
        }
    }
}
