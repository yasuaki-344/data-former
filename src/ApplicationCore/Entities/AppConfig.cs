using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DataFormer.ApplicationCore.Entities
{
    public class AppConfig
    {
        [JsonPropertyName("input_file_path")]
        public string InputFilePath { get; set; } = string.Empty;

        [JsonPropertyName("output_file_path")]
        public string OutputFilePath { get; set; } = string.Empty;

        [JsonPropertyName("sheets")]
        public List<SheetConfig> Sheets { get; set; } = new List<SheetConfig>();

    }
}
