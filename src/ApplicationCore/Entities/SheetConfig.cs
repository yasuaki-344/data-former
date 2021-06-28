using System.Text.Json.Serialization;

namespace DataFormer.ApplicationCore.Entities
{
    public class SheetConfig
    {
        [JsonPropertyName("sheet_name")]
        public string SheetName { get; set; } = string.Empty;
    }
}
