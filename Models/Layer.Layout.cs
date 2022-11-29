using Newtonsoft.Json;

namespace Mapbox.Razor.Models
{
    public partial class Layer
    {
        [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
        public class LayoutDetails : IMapboxClass
        {
            [JsonProperty("icon-image")]
            public string? IconImage { get; set; }

            [JsonProperty("line-join")]
            public string? LineJoin { get; set; }

            [JsonProperty("line-cap")]
            public string? LineCap { get; set; }

            [JsonProperty("text-field")]
            public string? TextField { get; set; }

            [JsonProperty("icon-text-fit")]
            public string? IconTextFit { get; set; }

            [JsonProperty("icon-allow-overlap")]
            public bool? IconAllowOverlap { get; set; }

            [JsonProperty("text-allow-overlap")]
            public bool? TextAllowOverlap { get; set; }

            [JsonProperty("icon-size")]
            public double? IconSize { get; set; }

            [JsonProperty("text-font")]
            public List<string>? TextFont { get; set; }

            [JsonProperty("text-offset")]
            public List<double>? TextOffset { get; set; }

            [JsonProperty("text-anchor")]
            public string? TextAnchor { get; set; }

            [JsonProperty("icon-rotate")]
            public double? IconRotate { get; set; }

            [JsonProperty("icon-rotation-alignment")]
            public string? IconRotationAlignment { get; set; }

            [JsonProperty("icon-ignore-placement")]
            public bool? IconIgnorePlacement { get; set; }

            [JsonProperty("text-size")]
            public double? TextSize { get; set; }
        }
    }
}
