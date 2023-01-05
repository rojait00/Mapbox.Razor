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
                await map.InitMapAsync();
            }
        }
    }
}