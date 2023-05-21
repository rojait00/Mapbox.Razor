using BAMCIS.GeoJSON;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapbox.Razor.Extensions
{
    public static class FeatureCollectionExtensions
    {
        public static List<Position> GetAllCoordinates(this FeatureCollection featureCollection)
        {
            var coordinates = new List<Position>();
            foreach (var feature in featureCollection.Features)
            {
                if (feature.Geometry is Point point)
                {
                    coordinates.Add(point.Coordinates);
                }
                else if (feature.Geometry is MultiPoint multiPoint)
                {
                    coordinates.AddRange(multiPoint.Coordinates);
                }
                else if (feature.Geometry is LineString lineString)
                {
                    coordinates.AddRange(lineString.Coordinates);
                }
                else if (feature.Geometry is MultiLineString multiLineString)
                {
                    foreach (var line in multiLineString.Coordinates)
                    {
                        coordinates.AddRange(line.Coordinates);
                    }
                }
                else if (feature.Geometry is Polygon polygon)
                {
                    foreach (var ring in polygon.Coordinates)
                    {
                        coordinates.AddRange(ring.Coordinates);
                    }
                }
                else if (feature.Geometry is MultiPolygon multiPolygon)
                {
                    foreach (var subPolygon in multiPolygon.Coordinates)
                    {
                        foreach (var ring in subPolygon.Coordinates)
                        {
                            coordinates.AddRange(ring.Coordinates);
                        }
                    }
                }
            }

            return coordinates;
        }
    }
}