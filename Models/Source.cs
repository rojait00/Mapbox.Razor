using BAMCIS.GeoJSON;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int? Maxzoom { get; set; }

        [JsonProperty("canvas")]
        public string? Canvas { get; set; }

        [JsonProperty("coordinates")]
        public List<Position>? Coordinates { get; set; }

        [JsonProperty("animate")]
        public bool? Animate { get; set; }

        [JsonProperty("data")]
        public object? Data { get; set; }

        public string? DataUrl { get; set; }

        public GeoJson? DataJson { get; set; }

        [JsonProperty("tiles")]
        public List<string>? Tiles { get; set; }

        [JsonProperty("minzoom")]
        public int? Minzoom { get; set; }

        [JsonProperty("lineMetrics")]
        public bool? LineMetrics { get; set; }

        [JsonProperty("cluster")]
        public bool? Cluster { get; set; }

        [JsonProperty("clusterMaxZoom")]
        public int? ClusterMaxZoom { get; set; }

        [JsonProperty("clusterRadius")]
        public int? ClusterRadius { get; set; }
    }
}