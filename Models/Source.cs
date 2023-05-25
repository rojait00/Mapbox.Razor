using BAMCIS.GeoJSON;
using Newtonsoft.Json;

namespace Mapbox.Razor.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]

    public partial class Source : IMapboxClass
    {
        [JsonIgnore]
        public string Id { get; set; } = "source_" + Guid.NewGuid().ToString();

        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("url")]
        public string? Url { get; set; }

        [JsonProperty("tileSize")]
        public int? TileSize { get; set; }

        [JsonProperty("maxzoom")]
        public double? Maxzoom { get; set; }

        [JsonProperty("canvas")]
        public string? Canvas { get; set; }

        [JsonProperty("coordinates")]
        public List<Position>? Coordinates { get; set; }

        [JsonProperty("animate")]
        public bool? Animate { get; set; }

        [JsonProperty("data")]
        public dynamic? Data
        {
            get
            {
                if (DataUrl != null)
                {
                    return DataUrl;
                }
                else
                {
                    return DataGeoJson;
                }
            }
        }

        [JsonIgnore]
        public string? DataUrl { get; set; } = null;

        [JsonIgnore]
        public GeoJson? DataGeoJson { get; set; } = null;

        [JsonProperty("tiles")]
        public List<string>? Tiles { get; set; }

        [JsonProperty("minzoom")]
        public double? Minzoom { get; set; }

        [JsonProperty("lineMetrics")]
        public bool? LineMetrics { get; set; }

        [JsonProperty("cluster")]
        public bool? Cluster { get; set; }

        [JsonProperty("clusterMaxZoom")]
        public double? ClusterMaxZoom { get; set; }

        [JsonProperty("clusterRadius")]
        public double? ClusterRadius { get; set; }

        [JsonIgnore]
        public dynamic? AdditionalParameters { get; set; } = null;
    }
}