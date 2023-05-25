using Mapbox.Razor.Extensions;
using Mapbox.Razor.Helper;
using Mapbox.Razor.Models;

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
            if (MapConfiguration?.Bounds?.Count > 2)
            {
                MapConfiguration.Bounds = MapConfiguration.Bounds.GetOuterBounds();
            }
            else if (MapConfiguration?.Bounds?.Count == 0)
            {
                //MapConfiguration.Bounds = null;
            }
        }
    }
}