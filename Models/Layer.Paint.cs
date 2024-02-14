using Newtonsoft.Json;

namespace Mapbox.Razor.Models
{
    public partial class Layer
    {
        [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
        public class PaintDetails : IMapboxClass
        {
            [JsonProperty("line-color")]
            public dynamic? LineColor { get; set; }

            [JsonProperty("line-width")]
            public dynamic? LineWidth { get; set; }

            [JsonProperty("fill-color")]
            public dynamic? FillColor { get; set; }

            /// <summary>
            /// Optional number between 0 and 1 inclusive.
            /// </summary>
            [JsonProperty("fill-opacity")]
            public dynamic? FillOpacity { get; set; }

            [JsonProperty("fill-pattern")]
            public dynamic? FillPattern { get; set; }

            [JsonProperty("raster-fade-duration")]
            public double? RasterFadeDuration { get; set; }

            //[JsonProperty("line-opacity")]
            //public List<dynamic>? LineOpacity { get; set; }

            [JsonProperty("background-color")]
            public dynamic? BackgroundColor { get; set; }

            [JsonProperty("circle-radius")]
            public dynamic? CircleRadius { get; set; }

            [JsonProperty("circle-color")]
            public dynamic? CircleColor { get; set; }

            [JsonProperty("fill-extrusion-color")]
            public dynamic? FillExtrusionColor { get; set; }

            [JsonProperty("fill-extrusion-opacity")]
            public double? FillExtrusionOpacity { get; set; }

            [JsonProperty("fill-extrusion-height")]
            public double? FillExtrusionHeight { get; set; }

            [JsonProperty("fill-extrusion-base")]
            public double? FillExtrusionBase { get; set; }

            [JsonProperty("circle-stroke-width")]
            public double? CircleStrokeWidth { get; set; }

            [JsonProperty("circle-stroke-color")]
            public dynamic? CircleStrokeColor { get; set; }

            [JsonProperty("line-gradient")]
            public dynamic? LineGradient { get; set; }

            [JsonProperty("heatmap-weight")]
            public double? HeatmapWeight { get; set; }

            [JsonProperty("heatmap-intensity")]
            public double? HeatmapIntensity { get; set; }

            [JsonProperty("heatmap-color")]
            public dynamic? HeatmapColor { get; set; }

            [JsonProperty("heatmap-radius")]
            public dynamic? HeatmapRadius { get; set; }

            [JsonProperty("heatmap-opacity")]
            public double? HeatmapOpacity { get; set; }

            [JsonProperty("circle-opacity")]
            public double? CircleOpacity { get; set; }

            [JsonProperty("text-color")]
            public dynamic? TextColor { get; set; }

            [JsonProperty("line-dasharray")]
            public List<double>? LineDasharray { get; set; }

            [JsonProperty("line-opacity")]
            public double? LineOpacity { get; set; } = null;
        }
    }
}
