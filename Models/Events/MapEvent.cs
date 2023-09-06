namespace Mapbox.Razor.Models.Events
{
    public class MapEvent
    {
        public string EventId { get; set; }

        public Action<MapEventArgs> Action { get; set; }
    }
}
