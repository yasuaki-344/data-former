using System;
using DataFormer.ApplicationCore.BusinessLogics;
using DataFormer.ApplicationCore.ValueObjects;
using NPOI.XSSF.UserModel;
using Xunit;

namespace DataFormer.ApplicationCore.Test
{
    public class ExcelDataExtractServiceTest
    {
        [Theory]
        [InlineData(2021, 1, 1)]
        [InlineData(2021, 6, 30)]
        [InlineData(2021, 12, 31)]
        public void ReturnDateTimeCorrectly(int year, int month, int day)
        {
            var expect = new DateTime(year, month, day);
            var book = new XSSFWorkbook();
            var sheet = book.CreateSheet("title");
            var row = sheet.CreateRow(0);
            var readCell = row.CreateCell(0);
            readCell.SetCellValue(expect);
            var writeCell = row.CreateCell(1);

            var target = new CellDataAccessor();
            target.ExtractCellValue(DataType.Date, readCell, writeCell);
            Assert.Equal(expect.ToString("yyyy/MM/dd HH:mm:ss"), writeCell.StringCellValue);
        }

        [Theory]
        [InlineData("")]
        [InlineData("test")]
        [InlineData("sample label")]
        public void ReturnLabelCorrectly(string expect)
        {
            var book = new XSSFWorkbook();
            var sheet = book.CreateSheet("title");
            var row = sheet.CreateRow(0);
            var readCell = row.CreateCell(0);
            readCell.SetCellValue(expect);
            var writeCell = row.CreateCell(1);

            var target = new CellDataAccessor();
            target.ExtractCellValue(DataType.Label, readCell, writeCell);
            Assert.Equal(expect, writeCell.StringCellValue);
        }

        [Theory]
        [InlineData(11.1)]
        [InlineData(23.4)]
        [InlineData(45.6)]
        public void ReturnNumericCorrectly(double expect)
        {
            var book = new XSSFWorkbook();
            var sheet = book.CreateSheet("title");
            var row = sheet.CreateRow(0);
            var readCell = row.CreateCell(0);
            readCell.SetCellValue(expect);
            var writeCell = row.CreateCell(1);

            var target = new CellDataAccessor();
            target.ExtractCellValue(DataType.Decimal, readCell, writeCell);
            Assert.Equal(expect, writeCell.NumericCellValue);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void ReturnBooleanCorrectly(bool expect)
        {
            var book = new XSSFWorkbook();
            var sheet = book.CreateSheet("title");
            var row = sheet.CreateRow(0);
            var readCell = row.CreateCell(0);
            readCell.SetCellValue(expect);
            var writeCell = row.CreateCell(1);

            var target = new CellDataAccessor();
            target.ExtractCellValue(DataType.Boolean, readCell, writeCell);
            Assert.Equal(expect, writeCell.BooleanCellValue);
        }
    }
}
