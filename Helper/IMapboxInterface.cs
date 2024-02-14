using BAMCIS.GeoJSON;
using Mapbox.Razor.Models;
using Mapbox.Razor.Models.Events;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using System;

namespace Mapbox.Razor.Helper
{
    public interface IMapboxInterface
    {
        // to js https://regex101.com/r/qdqoxA/1
        public Task InitMapAsync();
        public Task RemoveAsync();
        public Task UpdateMapStyleAsync(string mapStyleUrl);
        public Task FitBoundsAsync(string boundsJson);
        public Task AddImageAsync(string id, string url);
        public Task RemoveImageAsync(string id);
        public Task AddSourceAsync(string id, string sourceJson);
        public Task UpdateSourceAsync(string id, string geoJson);
        public Task RemoveSourceAsync(string id);
        public Task AddLayerAsync(string layerJson);
        public Task RemoveLayerAsync(string id);
        public Task AddControlAsync(string type, string controlJson);
        public Task RemoveControlAsync(string id);
        public Task AddLayerEventlistnerAsync(string onEventId, string forLayer, Action<LayerEventArgs> action);
        public Task AddMapEventlistnerAsync(string onEventId, Action<MapEventArgs> action);
        public Task AddOnLayerClickEventlistnerAsync(string forLayer, Action<LayerClickEventArgs> action, bool changeCursorOnHover);
        public Task AddOnMapClickEventlistnerAsync(Action<MapClickEventArgs> action);

        // callbacks https://regex101.com/r/nXjaK7/1
        [JSInvokable("HandleOnMapLoadAsync")]
        public Task HandleOnMapLoadAsync();

        [JSInvokable("HandleMapEvent")]
        public void HandleMapEvent(string onEventId, double swlat, double swlng, double nelat, double nelng);

        [JSInvokable("HandleLayerEvent")]
        public void HandleLayerEvent(string onEventId, string forLayer);

        [JSInvokable("HandleLayerClickEvent")]
        public void HandleLayerClickEvent(string forLayer, double lat, double lng, Dictionary<string, dynamic> properties);

        [JSInvokable("HandleMapClickEvent")]
        public void HandleMapClickEvent(double lat, double lng);
    }
}