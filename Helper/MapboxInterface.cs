using BAMCIS.GeoJSON;
using Mapbox.Razor.Models;
using Mapbox.Razor.Models.Controls;
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
    public class MapboxInterface : IAsyncDisposable
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
            return await module.InvokeAsync<string>("initMap", mapInterfaceRef, mapConfiguration.GetJson());
        }

        [JSInvokableAttribute("HandleOnMapLoadAsync")]
        public async Task HandleOnMapLoadAsync()
        {
            await AddImagesAsync();
            await AddSourcesAsync();
            await AddLayersAsync();
            await AddControlsAsync();
        }

        private async Task AddControlsAsync()
        {
            var module = await moduleTask.Value;
            foreach (var control in mapConfiguration.Controls)
            {
                await module.InvokeAsync<string>("addControl", control.Id, control.GetJson());
            }
        }

        private async Task AddImagesAsync()
        {
            var module = await moduleTask.Value;
            foreach (var image in mapConfiguration.Images)
            {
                await module.InvokeAsync<string>("addImage", image.Id, image.Url);
            }
        }

        private async Task AddSourcesAsync()
        {
            var module = await moduleTask.Value;
            foreach (var source in mapConfiguration.Sources)
            {
                await module.InvokeAsync<string>("addSource", source.Id, source.GetJson());
            }
        }

        private async Task AddLayersAsync()
        {
            var module = await moduleTask.Value;
            foreach (var layer in mapConfiguration.Layers)
            {
                await module.InvokeAsync<string>("addLayer", layer.GetJson());
            }
        }
        
        internal async Task RemoveImageAsync(string id)
        {
            var module = await moduleTask.Value;
            await module.InvokeAsync<string>("removeImage", id);
        }

        internal async Task RemoveSourceAsync(string id)
        {
            var module = await moduleTask.Value;
            await module.InvokeAsync<string>("removeSource", id);
        }

        internal async Task RemoveControlAsync(string id)
        {
            var module = await moduleTask.Value;
            await module.InvokeAsync<string>("removeControl", id);
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

        [JSInvokableAttribute("HandleEvent")]
        public void HandleEvent(string onEventId, string forLayer)
        {

        }

        [JSInvokableAttribute("HandleLayerClickEvent")]
        public void HandleLayerClickEvent(string forLayer, double lat, double lng, string description)
        {

        }

        [JSInvokableAttribute("HandleMapClickEvent")]
        public void HandleMapClickEvent(double lat, double lng, string description)
        {

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
