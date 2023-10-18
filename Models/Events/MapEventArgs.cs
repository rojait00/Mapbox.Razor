using BAMCIS.GeoJSON;
using System.Runtime.InteropServices;

namespace Mapbox.Razor.Models.Events
{
    public class MapEventArgs
    {
        public string EventId { get; set; }

        public Point SouthWestBorder { get; set; } = null!;
        public Point NorthEastBorder { get; set; } = null!;
    }
}