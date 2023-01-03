using BAMCIS.GeoJSON;

namespace Mapbox.Razor.Models.Events
{
    public class LayerClickEventArgs
    {
        public string LayerId { get; set; }

        public Position Position { get; set; }

        public Dictionary<string, dynamic> Properties { get; set; }
    }
}