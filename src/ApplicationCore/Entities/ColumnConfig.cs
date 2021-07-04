using System.Text.Json.Serialization;
using DataFormer.ApplicationCore.ValueObjects;

namespace DataFormer.ApplicationCore.Entities
{
    public class ColumnConfig
    {
        [JsonPropertyName("column_name")]
        public string ColumnName { get; set; } = string.Empty;

        [JsonPropertyName("type")]
        public DataType Type { get; set; }
    }
}
