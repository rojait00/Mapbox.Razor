using Newtonsoft.Json;

namespace Mapbox.Razor.Models
{
    public partial class Layer
    {
        [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
        public class LayoutDetails : IMapboxClass
        {
            [JsonProperty("icon-image")]
            public dynamic? IconImage { get; set; }

            [JsonProperty("line-join")]
            public dynamic? LineJoin { get; set; }

            //[JsonProperty("line-cap")]
            //public List<dynamic>? LineCap { get; set; }

            [JsonProperty("text-field")]
            public dynamic? TextField { get; set; }

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
            public dynamic? TextAnchor { get; set; }

            [JsonProperty("icon-rotate")]
            public double? IconRotate { get; set; }

            [JsonProperty("icon-rotation-alignment")]
            public dynamic? IconRotationAlignment { get; set; }

            [JsonProperty("icon-ignore-placement")]
            public bool? IconIgnorePlacement { get; set; }

            [JsonProperty("text-size")]
            public List<dynamic>? TextSize { get; set; }
        }
    }
}
