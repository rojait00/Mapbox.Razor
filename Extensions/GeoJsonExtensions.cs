using BAMCIS.GeoJSON;
using Microsoft.SqlServer.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapbox.Razor.Extensions
{
    public static class GeoJsonExtensions
    {
        private const int srid = 4326;

        public static Position GetCenter(this MultiPoint multiPoint)
        {
            var sqlGeometry = multiPoint.ToSqlGeometry();
            SqlGeometry center = sqlGeometry.STCentroid();

            return new Position(center.STX.Value, center.STY.Value);
        }

        public static bool IsWithin(this Position position, MultiPoint multiPoint)
        {
            SqlGeometry sqlGeometry = multiPoint.ToSqlGeometry();
            SqlGeometry sqlPos = position.ToSqlGeometry();

            return sqlPos.STIntersects(sqlGeometry).Value;
        }

        public static SqlGeometry ToSqlGeometry(this Position pos)
        {
            var gb = new SqlGeometryBuilder();
            gb.SetSrid(srid);

            AddPosition(gb, pos);

            gb.EndGeometry();
            return gb.ConstructedGeometry;
        }

        public static SqlGeometry ToSqlGeometry(this MultiPoint multiPoint)
        {
            var gb = new SqlGeometryBuilder();
            gb.SetSrid(srid);
            gb.BeginGeometry(OpenGisGeometryType.MultiPoint);

            foreach (Position position in multiPoint.Coordinates)
            {
                AddPosition(gb, position);
            }

            gb.EndGeometry();
            return gb.ConstructedGeometry;
        }

        private static void AddPosition(SqlGeometryBuilder gb, Position position)
        {
            gb.BeginGeometry(OpenGisGeometryType.Point);
            gb.BeginFigure(position.Longitude, position.Latitude);
            gb.EndFigure();
            gb.EndGeometry();
        }
    }
}
