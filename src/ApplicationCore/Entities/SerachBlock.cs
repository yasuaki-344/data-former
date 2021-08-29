using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DataFormer.ApplicationCore.Entities
{
    public class SearchBlock
    {
        [JsonPropertyName("row_size")]
        public int RowSize { get; set; }

        [JsonPropertyName("column_size")]
        public int ColumnSize { get; set; }

        [JsonPropertyName("column_search")]
        public List<SearchConfig> ColumnSearch { get; set; } = new List<SearchConfig>();
    }
}
