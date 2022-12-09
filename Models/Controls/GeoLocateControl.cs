using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mapbox.Razor.Models.Controls
{
    public class GeoLocateControl : IControl
    {
        /// <summary>
        /// InternalId
        /// </summary>
        [JsonIgnore]
        public string Id { get; } = "geo_locate_control_id";

        ///<summary>
        /// A Map#fitBounds options dynamic to use when the map is panned and zoomed to the user's location. The default is to use a maxZoom of 15 to limit how far the map will zoom in for very accurate locations.
        /// Default Value: {maxZoom:15}
        ///</summary>
        [JsonProperty("fitBoundsOptions")]
        public dynamic? FitBoundsOptions { get; set; }

        ///<summary>
        /// window.navigator.geolocation by default; you can provide an dynamic with the same shape to customize geolocation handling.
        /// Default Value: window.navigator.geolocation
        ///</summary>
        [JsonProperty("geolocation")]
        public dynamic? Geolocation { get; set; }

        ///<summary>
        /// A Geolocation API PositionOptions object.
        /// Default Value: {enableHighAccuracy:false,timeout:6000}
        ///</summary>
        [JsonProperty("positionOptions")]
        public dynamic? PositionOptions { get; set; }

        ///<summary>
        /// By default, if showUserLocation is true , a transparent circle will be drawn around the user location indicating the accuracy (95% confidence level) of the user's location. Set to false to disable. Always disabled when showUserLocation is false .
        /// Default Value: true
        ///</summary>
        [JsonProperty("showAccuracyCircle")]
        public dynamic ShowAccuracyCircle { get; set; } = true;

        ///<summary>
        /// If true an arrow will be drawn next to the user location dot indicating the device's heading. This only has affect when trackUserLocation is true .
        /// Default Value: false
        ///</summary>
        [JsonProperty("showUserHeading")]
        public dynamic ShowUserHeading { get; set; } = false;

        ///<summary>
        /// By default a dot will be shown on the map at the user's location. Set to false to disable.
        /// Default Value: true
        ///</summary>
        [JsonProperty("showUserLocation")]
        public dynamic ShowUserLocation { get; set; } = true;

        ///<summary>
        /// If true the GeolocateControl becomes a toggle button and when active the map will receive updates to the user's location as it changes.
        /// Default Value: false
        ///</summary>
        [JsonProperty("trackUserLocation")]
        public dynamic TrackUserLocation { get; set; } = false;

        ///<summary>
        /// If true , force a compact attribution that shows the full attribution on mouse hover. If false , force the full attribution control. The default is a responsive attribution that collapses when the map is less than 640 pixels wide. Attribution should not be collapsed if it can comfortably fit on the map. compact should only be used to modify default attribution when map size makes it impossible to fit default attribution and when the automatic compact resizing for default settings are not sufficient .
        /// Default Value: 
        ///</summary>
        [JsonProperty("compact")]
        public bool? Compact { get; set; }

        ///<summary>
        /// String or strings to show in addition to any other attributions. You can also set a custom attribution when initializing your map with the customAttribution option ./// Default Value: 
        ///</summary>
        [JsonProperty("customAttribution")]
        public dynamic? CustomAttribution { get; set; }
    }
}
