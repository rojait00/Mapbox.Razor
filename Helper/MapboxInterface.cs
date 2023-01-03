using BAMCIS.GeoJSON;
using Mapbox.Razor.Models;
using Mapbox.Razor.Models.Controls;
using Mapbox.Razor.Models.Events;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using Microsoft.JSInterop.Implementation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Mapbox.Razor.Helper
{
    internal class MapboxInterface : IMapboxInterface
    {
        private Action<MapClickEventArgs>? onMapClicked = null;
        private readonly Dictionary<string, Action<LayerClickEventArgs>> onLayerClicked = new();
        private readonly Dictionary<(string layer, string eventId), Action<LayerEventArgs>> onLayerEvent = new();

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


        public async Task InitMapAsync()
        {
            var module = await moduleTask.Value;
            await module.InvokeAsync<string>("initMap", mapInterfaceRef, mapConfiguration.GetJson());
        }

        [JSInvokable("HandleOnMapLoadAsync")]
        public async Task HandleOnMapLoadAsync()
        {
            await AddImagesAsync();
            await AddSourcesAsync();
            await AddLayersAsync();
            await AddControlsAsync();
            await AddOnLayerClickEventlistnersAsync();
            await AddOnMapClickEventlistnersAsync();
            await AddEventlistnersAsync();
        }

        #region foreach
        public async Task AddImagesAsync()
        {
            foreach (var image in mapConfiguration.Images)
            {
                await AddImageAsync(image.Id, image.Url);
            }
        }

        public async Task AddSourcesAsync()
        {
            foreach (var source in mapConfiguration.Sources)
            {
                await AddSourceAsync(source.Id, source.GetJson());
            }
        }

        public async Task AddLayersAsync()
        {
            foreach (var layer in mapConfiguration.Layers)
            {
                await AddLayerAsync(layer.GetJson());
            }
        }

        public async Task AddControlsAsync()
        {
            foreach (var control in mapConfiguration.Controls)
            {
                await AddControlAsync(control.Id, control.GetJson());
            }
        }

        private async Task AddOnLayerClickEventlistnersAsync()
        {
            foreach (var eventDetails in mapConfiguration.LayerClickHandler)
            {
                await AddOnLayerClickEventlistnerAsync(eventDetails.LayerId, eventDetails.Action);
            }
        }

        private async Task AddOnMapClickEventlistnersAsync()
        {
            foreach (var eventDetails in mapConfiguration.MapClickHandler)
            {
                await AddOnMapClickEventlistnerAsync(eventDetails.Action);
            }
        }

        private async Task AddEventlistnersAsync()
        {
            foreach (var eventDetails in mapConfiguration.LayerEventHandler)
            {
                await AddEventlistnerAsync(eventDetails.LayerId, eventDetails.EventId, eventDetails.Action);
            }
        }
        #endregion


        #region from Interface
        public async Task AddImageAsync(string id, string url)
        {
            var module = await moduleTask.Value;
            await module.InvokeAsync<string>("addImage", id, url);
        }

        public async Task RemoveImageAsync(string id)
        {
            var module = await moduleTask.Value;
            await module.InvokeAsync<string>("removeImage", id);
        }

        public async Task AddSourceAsync(string id, string sourceJson)
        {
            var module = await moduleTask.Value;
            await module.InvokeAsync<string>("addSource", id, sourceJson);
        }

        public async Task RemoveSourceAsync(string id)
        {
            var module = await moduleTask.Value;
            await module.InvokeAsync<string>("removeSource", id);
        }

        public async Task AddLayerAsync(string layerJson)
        {
            var module = await moduleTask.Value;
            await module.InvokeAsync<string>("addLayer", layerJson);
        }

        public async Task RemoveLayerAsync(string id)
        {
            var module = await moduleTask.Value;
            await module.InvokeAsync<string>("removeLayer", id);
        }

        public async Task AddControlAsync(string type, string controlJson)
        {
            var module = await moduleTask.Value;
            await module.InvokeAsync<string>("addControl", type, controlJson);
        }

        public async Task RemoveControlAsync(string id)
        {
            var module = await moduleTask.Value;
            await module.InvokeAsync<string>("removeControl", id);
        }

        public async Task AddEventlistnerAsync(string onEventId, string forLayer, Action<LayerEventArgs> action)
        {
            onLayerEvent[(layer: forLayer, eventId: onEventId)] = action;
            var module = await moduleTask.Value;
            await module.InvokeAsync<string>("addEventlistner", onEventId, forLayer, mapInterfaceRef);
        }

        public async Task AddOnLayerClickEventlistnerAsync(string forLayer, Action<LayerClickEventArgs> action)
        {
            onLayerClicked[forLayer] = action;
            var module = await moduleTask.Value;
            await module.InvokeAsync<string>("addOnLayerClickEventlistner", forLayer, mapInterfaceRef);
        }

        public async Task AddOnMapClickEventlistnerAsync(Action<MapClickEventArgs>? action)
        {
            onMapClicked = action;
            var module = await moduleTask.Value;
            await module.InvokeAsync<string>("addOnMapClickEventlistner", mapInterfaceRef);
        }

        [JSInvokable("HandleEvent")]
        public void HandleEvent(string onEventId, string forLayer)
        {
            if (onLayerEvent.TryGetValue((layer: forLayer, eventId: onEventId), out Action<LayerEventArgs>? value))
            {
                value.Invoke(new LayerEventArgs { LayerId = forLayer, EventId = onEventId });
            }
        }

        [JSInvokable("HandleLayerClickEvent")]
        public void HandleLayerClickEvent(string forLayer, double lat, double lng, Dictionary<string, dynamic> properties)
        {
            if (onLayerClicked.TryGetValue(forLayer, out Action<LayerClickEventArgs>? value))
            {
                value.Invoke(new LayerClickEventArgs { LayerId = forLayer, Position = new Position(lng, lat), Properties = properties });
            }
        }

        [JSInvokable("HandleMapClickEvent")]
        public void HandleMapClickEvent(double lat, double lng)
        {
            onMapClicked?.Invoke(new MapClickEventArgs { Position = new Position(lng, lat) });
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