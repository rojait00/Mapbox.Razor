using BAMCIS.GeoJSON;
using System.Data.Entity.Spatial;

namespace Mapbox.Razor.Extensions
{
    public static class PositionExtensions
    {
        public static DbGeography ToGeometry(this Position pos)
        {
            var point = string.Format("POINT({0} {1})", pos.Longitude, pos.Latitude);
            return DbGeography.FromText(point);
        }
    }
}