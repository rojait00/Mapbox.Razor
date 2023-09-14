using BAMCIS.GeoJSON;
using System.Runtime.InteropServices;

namespace Mapbox.Razor.Models.Events
{
    public class MapEventArgs
    {
        public string EventId { get; set; }
        //const swlat = coordinateList._sw.lngLat.lat;
        //const swlng = coordinateList._sw.lngLat.lng;
        //const nelat = coordinateList._ne.lngLat.lat;
        //const nelng = coordinateList._ne.lngLat.lng;

        public Point? SouthWestBorder { get; set; }
        public Point? NorthEastBorder { get; set; }
    }
}