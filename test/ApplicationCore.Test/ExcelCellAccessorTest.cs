using DataFormer.ApplicationCore.BusinessLogics;
using Xunit;

namespace DataFormer.ApplicationCore.Test
{
    public class ExcelCellAccessorTest
    {
        [Theory]
        [InlineData("A", 0)]
        [InlineData("M", 12)]
        [InlineData("Z", 25)]
        [InlineData("AA", 26)]
        [InlineData("BM", 64)]
        [InlineData("CZ", 103)]
        [InlineData("IV", 255)]
        public void CreateCorrectly(string columnString, int columnsIndex)
        {
            var target = new ExcelCellAccessor();
            var actual = target.GetColumnIndex(columnString);
            Assert.Equal(columnsIndex, actual);
        }
    }
}
