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
        [InlineData(10.1111)]
        [InlineData(22.4444)]
        [InlineData(55.5555)]
        public void ReturnNumericCorrectly(double expect)
        {
            var book = new XSSFWorkbook();
            var sheet = book.CreateSheet("title");
            var row = sheet.CreateRow(0);
            var readCell = row.CreateCell(0);
            readCell.SetCellValue(expect);
            var writeCell = row.CreateCell(1);

            var target = new CellDataAccessor();
            target.ExtractCellValue(DataType.Integer, readCell, writeCell);
            Assert.Equal(Math.Floor(expect), writeCell.NumericCellValue);
        }

        [Theory]
        [InlineData(11.1)]
        [InlineData(23.4)]
        [InlineData(45.6)]
        public void ReturnDecimalCorrectly(double expect)
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
        [InlineData(1970, 1, 1, 0, 0, 0)]
        [InlineData(2021, 6, 14, 12, 30, 30)]
        [InlineData(9999, 12, 31, 23, 59, 59)]
        public void ReturnDateTimeCorrectly(int year, int month, int day, int hour, int minute, int second)
        {
            var expect = new DateTime(year, month, day, hour, minute, second);
            var book = new XSSFWorkbook();
            var sheet = book.CreateSheet("title");
            var row = sheet.CreateRow(0);
            var readCell = row.CreateCell(0);
            readCell.SetCellValue(expect);
            var writeCell = row.CreateCell(1);

            var target = new CellDataAccessor();
            target.ExtractCellValue(DataType.DateTime, readCell, writeCell);
            Assert.Equal(expect.ToString("yyyy/MM/dd HH:mm:ss"), writeCell.StringCellValue);
        }

        [Theory]
        [InlineData(2021, 1, 1)]
        [InlineData(2021, 6, 30)]
        [InlineData(2021, 12, 31)]
        public void ReturnDateCorrectly(int year, int month, int day)
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
            Assert.Equal(expect.ToString("yyyy/MM/dd"), writeCell.StringCellValue);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(12, 30, 30)]
        [InlineData(23, 59, 59)]
        public void ReturnTimeCorrectly(int hour, int minute, int second)
        {
            var expect = new DateTime(2021, 1, 1, hour, minute, second);
            var book = new XSSFWorkbook();
            var sheet = book.CreateSheet("title");
            var row = sheet.CreateRow(0);
            var readCell = row.CreateCell(0);
            readCell.SetCellValue(expect);
            var writeCell = row.CreateCell(1);

            var target = new CellDataAccessor();
            target.ExtractCellValue(DataType.Time, readCell, writeCell);
            Assert.Equal(expect.ToString("HH:mm:ss"), writeCell.StringCellValue);
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

        [Fact]
        public void ReturnFormulaCorrectly()
        {
            var expect = "1+1";

            var book = new XSSFWorkbook();
            var sheet = book.CreateSheet("title");
            var row = sheet.CreateRow(0);
            var readCell = row.CreateCell(0);
            readCell.SetCellFormula(expect);
            var writeCell = row.CreateCell(1);

            var target = new CellDataAccessor();
            target.ExtractCellValue(DataType.Formula, readCell, writeCell);
            Assert.Equal(expect, writeCell.StringCellValue);
        }

        [Fact]
        public void RetrunCellCommentCorrectly()
        {
            var expect = "cell comment";

            var book = new XSSFWorkbook();
            var sheet = book.CreateSheet("title");
            var row = sheet.CreateRow(0);
            var readCell = row.CreateCell(0);
            var writeCell = row.CreateCell(1);

            var drawing = sheet.CreateDrawingPatriarch();
            var anchor = book.GetCreationHelper().CreateClientAnchor();
            var comment = drawing.CreateCellComment(anchor);
            comment.String = new XSSFRichTextString(expect);

            readCell.CellComment = comment;

            var target = new CellDataAccessor();
            target.ExtractCellValue(DataType.Comment, readCell, writeCell);
            Assert.Equal(expect, writeCell.StringCellValue);
        }
    }
}
