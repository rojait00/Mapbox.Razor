using BAMCIS.GeoJSON;

namespace Mapbox.Razor.Models
{
    public class GooglePosition : Position
    {
        public GooglePosition(double latitude, double longitude) : base(longitude, latitude) 
        {
        }
    }
}
