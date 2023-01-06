using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BAMCIS.GeoJSON;
using Mapbox.Razor.Helper;
using Mapbox.Razor.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Mapbox.Razor.Views
{
    public partial class Map
    {
        private const string mapContainerId = "map";

        private MapboxInterface? map;

        protected override async Task OnInitializedAsync()
        {
            await InitMapAsync();

            await base.OnInitializedAsync();
        }

        /// <summary>
        /// Is triggered automatically.
        /// Can be called to reload config.
        /// </summary>
        /// <returns></returns>
        public async Task InitMapAsync()
        {
            if (MapConfiguration != null)
            {
                MapConfiguration.Container = mapContainerId;
                map = new MapboxInterface(jsRuntime, MapConfiguration);
                UpdateMapBounds();
                await map.InitMapAsync();
            }
        }

        private void UpdateMapBounds()
        {
            if(MapConfiguration?.Bounds?.Count > 2)
            {
                var minLat = MapConfiguration.Bounds.Min(x => x.Latitude); 
                var maxLat = MapConfiguration.Bounds.Max(x => x.Latitude); 

                var minLong = MapConfiguration.Bounds.Min(x => x.Longitude); 
                var maxLong = MapConfiguration.Bounds.Max(x => x.Longitude);

                MapConfiguration.Bounds = new List<Position>
                {
                    new Position(maxLong, minLat),
                    new Position(minLong, maxLat),
                };
            }
        }
    }
}