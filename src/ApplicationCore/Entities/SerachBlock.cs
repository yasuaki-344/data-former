using System.Collections.Generic;
using System.Text.Json.Serialization;
using DataFormer.ApplicationCore.ValueObjects;

namespace DataFormer.ApplicationCore.Entities
{
    public class SearchBlock
    {
        [JsonPropertyName("direction")]
        public SearchDirection Direction { get; set; }

        [JsonPropertyName("row_size")]
        public int RowSize { get; set; }

        [JsonPropertyName("column_size")]
        public int ColumnSize { get; set; }

        [JsonPropertyName("column_search")]
        public List<SearchConfig> ColumnSearch { get; set; } = new List<SearchConfig>();
    }
}
