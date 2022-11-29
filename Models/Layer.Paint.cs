using Newtonsoft.Json;

namespace Mapbox.Razor.Models
{
    public partial class Layer
    {
        [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
        public class PaintDetails : IMapboxClass
        {
            [JsonProperty("line-color")]
            public string LineColor { get; set; } = "#000000";

            [JsonProperty("line-width")]
            public int? LineWidth { get; set; }

            [JsonProperty("fill-color")]
            public string? FillColor { get; set; }

            /// <summary>
            /// Optional number between 0 and 1 inclusive.
            /// </summary>
            [JsonProperty("fill-opacity")]
            public double FillOpacity { get; set; } = 1;

            [JsonProperty("fill-pattern")]
            public string? FillPattern { get; set; }

            [JsonProperty("raster-fade-duration")]
            public int? RasterFadeDuration { get; set; }

            [JsonProperty("line-opacity")]
            public double? LineOpacity { get; set; }

            [JsonProperty("background-color")]
            public string? BackgroundColor { get; set; }

            [JsonProperty("circle-radius")]
            public double? CircleRadius { get; set; }

            [JsonProperty("circle-color")]
            public string CircleColor { get; set; } = "#000000";

            [JsonProperty("fill-extrusion-color")]
            public string FillExtrusionColor { get; set; } = "#000000";

            [JsonProperty("fill-extrusion-opacity")]
            public double? FillExtrusionOpacity { get; set; }

            [JsonProperty("fill-extrusion-height")]
            public double? FillExtrusionHeight { get; set; }

            [JsonProperty("fill-extrusion-base")]
            public double? FillExtrusionBase { get; set; }

            [JsonProperty("circle-stroke-width")]
            public int? CircleStrokeWidth { get; set; }

            [JsonProperty("circle-stroke-color")]
            public string? CircleStrokeColor { get; set; }

            [JsonProperty("line-gradient")]
            public string? LineGradient { get; set; }

            [JsonProperty("heatmap-weight")]
            public double? HeatmapWeight { get; set; }

            [JsonProperty("heatmap-intensity")]
            public double? HeatmapIntensity { get; set; }

            [JsonProperty("heatmap-color")]
            public string? HeatmapColor { get; set; }

            [JsonProperty("heatmap-radius")]
            public string? HeatmapRadius { get; set; }

            [JsonProperty("heatmap-opacity")]
            public double? HeatmapOpacity { get; set; }

            [JsonProperty("circle-opacity")]
            public double? CircleOpacity { get; set; }

            [JsonProperty("text-color")]
            public string? TextColor { get; set; }
        }
    }
}
