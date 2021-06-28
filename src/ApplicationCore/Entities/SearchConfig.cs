using System.Text.Json.Serialization;

namespace DataFormer.ApplicationCore.Entities
{
    public class SearchConfig
    {
        [JsonPropertyName("sheet_name")]
        public string SheetName { get; set; } = string.Empty;

        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;

        [JsonPropertyName("direction")]
        public string Direction { get; set; } = string.Empty;

        [JsonPropertyName("initial_row_position")]
        public int InitialRowPostion { get; set; }

        [JsonPropertyName("initial_column_position")]
        public int InitialColumnPosition { get; set; }

        [JsonPropertyName("row_size")]
        public int RowSize { get; set; }

        [JsonPropertyName("column_size")]
        public int ColumnSize { get; set; }

        [JsonPropertyName("row_increment")]
        public int RowIncrement { get; set; }

        [JsonPropertyName("column_increment")]
        public int ColumnIncrement { get; set; }
    }
}
