using System.Collections.Generic;
using System.Linq;
using DataFormer.ApplicationCore.BusinessLogics;
using DataFormer.ApplicationCore.Entities;
using DataFormer.ApplicationCore.ValueObjects;
using Xunit;

namespace DataFormer.ApplicationCore.Test
{
    public class MatrixDataMangerTest
    {
        [Fact]
        public void GetPositionCorrectly()
        {
            var target = new MatrixDataManger();

            var rule = new SearchBlock
            {
                Direction = SearchDirection.Row,
                RowSize = 3,
                ColumnSize = 3,
                ColumnSearch = new List<SearchConfig>
                {
                    new SearchConfig
                    {
                        InitialRow = 1,
                        InitialColumn = "A",
                        RowIncrement = 1,
                        ColumnIncrement = 1,
                    }
                }
            };

            var actual = target.GetPosition(0, rule, rule.ColumnSearch.First());
            Assert.Equal(0, actual.Row);
            Assert.Equal(0, actual.Column);

            actual = target.GetPosition(3, rule, rule.ColumnSearch.First());
            Assert.Equal(0, actual.Row);
            Assert.Equal(1, actual.Column);

            actual = target.GetPosition(4, rule, rule.ColumnSearch.First());
            Assert.Equal(1, actual.Row);
            Assert.Equal(1, actual.Column);

            actual = target.GetPosition(7, rule, rule.ColumnSearch.First());
            Assert.Equal(1, actual.Row);
            Assert.Equal(2, actual.Column);

            actual = target.GetPosition(8, rule, rule.ColumnSearch.First());
            Assert.Equal(2, actual.Row);
            Assert.Equal(2, actual.Column);
        }

        [Theory]
        [InlineData("A", 0)]
        [InlineData("M", 12)]
        [InlineData("Z", 25)]
        [InlineData("AA", 26)]
        [InlineData("BM", 64)]
        [InlineData("CZ", 103)]
        [InlineData("IV", 255)]
        public void GetColumnIndexCorrectly(string columnString, int columnsIndex)
        {
            var target = new MatrixDataManger();
            var actual = target.GetColumnIndex(columnString);
            Assert.Equal(columnsIndex, actual);
        }
    }
}
