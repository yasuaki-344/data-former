using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DataFormer.ApplicationCore.Entities
{
    public class SheetConfig
    {
        [JsonPropertyName("sheet_name")]
        public string SheetName { get; set; } = string.Empty;

        [JsonPropertyName("columns")]
        public List<ColumnConfig> Columns { get; set; } = new List<ColumnConfig>();
    }
}
