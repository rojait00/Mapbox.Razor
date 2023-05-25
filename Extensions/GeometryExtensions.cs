using BAMCIS.GeoJSON;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapbox.Razor.Extensions
{
    public static class GeometryExtensions
    {
        public static Position ToPosition(this DbGeography point)
        {
            return new Position(point.Longitude ?? 0, point.Latitude ?? 0);
        }
    }
}