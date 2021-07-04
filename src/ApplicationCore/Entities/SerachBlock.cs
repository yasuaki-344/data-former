using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DataFormer.ApplicationCore.Entities
{
    public class SearchBlock
    {
        [JsonPropertyName("column_search")]
        public List<SearchConfig> ColumnSearch { get; set; } = new List<SearchConfig>();
    }
}
