using BAMCIS.GeoJSON;
using Mapbox.Razor.Models;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using Microsoft.JSInterop.Implementation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapbox.Razor.Helper
{
    internal class MapboxInterface : IAsyncDisposable
    {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask;
        private readonly DotNetObjectReference<MapboxInterface> mapInterfaceRef;
        private readonly MapConfiguration mapConfiguration;

        public MapboxInterface(IJSRuntime jsRuntime, MapConfiguration mapConfiguration)
        {
            this.mapConfiguration = mapConfiguration;
            mapInterfaceRef = DotNetObjectReference.Create(this);

            moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
                "import", "./_content/Mapbox.Razor/mapbox-interface.js").AsTask());
        }

        #region generated https://regex101.com/r/7oFiTN/1
        internal async ValueTask<string> InitAsync()
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<string>("initMap", mapConfiguration.GetJson(), mapInterfaceRef);
        }

        internal async Task HandleOnMapLoadAsync()
        {
            await AddSourcesAsync();
            await AddLayersAsync();
        }

        internal async Task AddSourcesAsync()
        {
            var module = await moduleTask.Value;
            foreach (var source in mapConfiguration.Sources)
            {
                await module.InvokeAsync<string>("addSource", source.Id, source.GetJson());
            }
        }

        internal async Task AddLayersAsync()
        {
            var module = await moduleTask.Value;
            foreach (var layer in mapConfiguration.Layers)
            {
                await module.InvokeAsync<string>("addLayer", layer.GetJson());
            }
        }

        internal async Task RemoveSourceAsync(string id)
        {
            var module = await moduleTask.Value;
            await module.InvokeAsync<string>("removeSource", id);
        }

        internal async Task RemoveLayerAsync(string id)
        {
            var module = await moduleTask.Value;
            await module.InvokeAsync<string>("removeLayer", id);
        }

        internal async Task AddEventlistnerAsync(string onEventId, string forLayer)
        {
            var module = await moduleTask.Value;
            await module.InvokeAsync<string>("addEventlistner", onEventId, forLayer, mapInterfaceRef);
        }

        internal async Task AddOnLayerClickEventlistnerAsync(string forLayer)
        {
            var module = await moduleTask.Value;
            await module.InvokeAsync<string>("addOnLayerClickEventlistner", forLayer, mapInterfaceRef);
        }

        internal async Task AddOnMapClickEventlistnerAsync()
        {
            var module = await moduleTask.Value;
            await module.InvokeAsync<string>("addOnMapClickEventlistner", mapInterfaceRef);
        }


        #endregion

        public async ValueTask DisposeAsync()
        {
            if (moduleTask.IsValueCreated)
            {
                var module = await moduleTask.Value;
                await module.DisposeAsync();
            }
            mapInterfaceRef.Dispose();
        }
    }
}
