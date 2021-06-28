using System.Text.Json.Serialization;

namespace DataFormer.ApplicationCore.Entities
{
    public class ColumnConfig
    {
        [JsonPropertyName("column_name")]
        public string ColumnName { get; set; } = string.Empty;
    }
}
