using System.Text.Json.Serialization;

namespace DataFormer.ApplicationCore.Entities
{
    public class ExtractConfig
    {
        [JsonPropertyName("input_file_path")]
        public string InputFilePath { get; set; } = string.Empty;

        [JsonPropertyName("output_file_path")]
        public string OutputFilePath { get; set; } = string.Empty;
    }
}
