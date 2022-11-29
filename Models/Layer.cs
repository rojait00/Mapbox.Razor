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
        public List<object>? Filter { get; set; }

        [JsonProperty("minzoom")]
        public int? MinZoom { get; set; }

        [JsonProperty("maxzoom")]
        public int? MaxZoom { get; set; }

        [JsonProperty("metadata")]
        public string? MeteData { get; set; }
    }
}
