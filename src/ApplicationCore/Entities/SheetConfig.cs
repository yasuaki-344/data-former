using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DataFormer.ApplicationCore.Entities
{
    public class SheetConfig
    {
        [JsonPropertyName("sheet_name")]
        public string SheetName { get; set; } = string.Empty;

        [JsonPropertyName("headers")]
        public List<ColumnConfig> Headers { get; set; } = new List<ColumnConfig>();

        [JsonPropertyName("search_blocks")]
        public List<SearchBlock> SearchBlocks { get; set; } = new List<SearchBlock>();
    }
}
