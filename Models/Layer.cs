using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapbox.Razor.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public partial class Layer : IMapboxClass
    {
        [JsonProperty("id")]
        public string Id { get; set; } = "layer_" + Guid.NewGuid().ToString();

        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("source")]
        public string? Source { get; set; }

        [JsonProperty("layout")]
        public LayoutDetails? Layout { get; set; }

        [JsonProperty("paint")]
        public PaintDetails? Paint { get; set; }

        [JsonProperty("source-layer")]
        public string? SourceLayer { get; set; }

        [JsonProperty("filter")]
        public List<dynamic>? Filter { get; set; }

        [JsonProperty("minzoom")]
        public double? MinZoom { get; set; }

        [JsonProperty("maxzoom")]
        public double? MaxZoom { get; set; }

        [JsonProperty("metadata")]
        public dynamic? MeteData { get; set; }
        [JsonIgnore]
        public bool Clickable { get; set; } = false;

        [JsonProperty("dashArraySequence")]
        public List<List<double>>? DashArraySequence { get; set; }
    }
}
