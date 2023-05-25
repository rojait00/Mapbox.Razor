using BAMCIS.GeoJSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapbox.Razor.Extensions
{
    public static class PositionListExtensions
    {
        public static List<Position> GetOuterBounds(this List<Position> bounds)
        {
            var minLat = bounds.Min(x => x.Latitude);
            var maxLat = bounds.Max(x => x.Latitude);

            var minLong = bounds.Min(x => x.Longitude);
            var maxLong = bounds.Max(x => x.Longitude);
            var newBounds = new List<Position>
                {
                    new Position(maxLong, minLat),
                    new Position(minLong, maxLat),
                };
            return newBounds;
        }
    }
}
