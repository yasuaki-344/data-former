﻿using System.Text.Json.Serialization;
using DataFormer.ApplicationCore.ValueObjects;

namespace DataFormer.ApplicationCore.Entities
{
    public class SearchConfig
    {
        [JsonPropertyName("sheet_name")]
        public string SheetName { get; set; } = string.Empty;

        [JsonPropertyName("direction")]
        public SearchDirection Direction { get; set; }

        [JsonPropertyName("initial_row")]
        public int InitialRow { get; set; }

        [JsonPropertyName("initial_column")]
        public string InitialColumn { get; set; } = string.Empty;

        [JsonPropertyName("row_increment")]
        public int RowIncrement { get; set; }

        [JsonPropertyName("column_increment")]
        public int ColumnIncrement { get; set; }
    }
}
