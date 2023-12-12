using BAMCIS.GeoJSON;
using Mapbox.Razor.Extensions;
using Mapbox.Razor.Helper;
using Mapbox.Razor.Models;
using Newtonsoft.Json;

namespace Mapbox.Razor.Views
{
    public partial class Map
    {
        private const string mapContainerId = "mapbox-container";

        private MapboxInterface? map;

        protected override async Task OnInitializedAsync()
        {
            await InitMapAsync();

            await base.OnInitializedAsync();
        }

        /// <summary>
        /// Removes the map from the DOM.
        /// </summary>
        /// <returns></returns>
        public async Task RemoveAsync()
        {
            if (map != null)
            {
                await map.RemoveAsync();
            }
        }

        /// <summary>
        /// Adds all Layers in MapConfiguration if not added yet
        /// </summary>
        /// <returns></returns>
        public async Task UpdateMapStyleAsync()
        {
            if (map != null && MapConfiguration?.Style != null)
            {
                await map.UpdateMapStyleAsync(MapConfiguration.Style);
            }
        }

        /// <summary>
        /// Uses the Id and the DataGeoJson Property to update the data of the source.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public async Task UpdateSourceAsync(Source source)
            => await UpdateSourceAsync(source.Id, source.DataGeoJson);

        /// <summary>
        /// Uses the Id and the GeoJson Parameter to update the data of the source.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public async Task UpdateSourceAsync(string id, GeoJson? geoJson)
        {
            if (map != null && geoJson != null)
            {
                await map.UpdateSourceAsync(id, geoJson.ToJson());
            }
            else
            {
                throw new ArgumentNullException(nameof(geoJson));
            }
        }

        /// <summary>
        /// Adds all Layers in MapConfiguration if not added yet
        /// </summary>
        /// <returns></returns>
        public async Task UpdateLayersAsync()
        {
            if (map != null)
            {
                await map.AddLayersAsync();
            }
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

        /// <summary>
        /// Removes all Layers and sources and add them again.
        /// </summary>
        /// <returns></returns>
        public async Task ReloadSourcesAsync()
        {
            if (MapConfiguration == null || map == null)
                return;

            foreach (var layer in MapConfiguration.Layers)
            {
                await map.RemoveLayerAsync(layer.Id);
            }
            foreach (var source in MapConfiguration.Sources)
            {
                await map.RemoveSourceAsync(source.Id);
            }

            await map.AddSourcesAsync();
            await map.AddLayersAsync();
        }

        /// <summary>
        /// Calls `Map.FitBounds` with the bounds specifed within the MapConfig.
        /// </summary>
        /// <returns></returns>
        public async Task FitBoundsAsync()
        {
            UpdateMapBounds();

            if (map == null || MapConfiguration?.Bounds?.Count != 2)
                return;

            var boundsJson = JsonConvert.SerializeObject(MapConfiguration.Bounds);
            await map.FitBoundsAsync(boundsJson);
        }

        private void UpdateMapBounds()
        {
            if (MapConfiguration?.Bounds?.Count > 2)
            {
                MapConfiguration.Bounds = MapConfiguration.Bounds.GetOuterBounds();
            }
        }
    }
}