using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapbox.Razor.Models.Controls
{
    public class NavigationControl : IControl
    {
        /// <summary>
        /// InternalId
        /// </summary>
        [JsonIgnore]
        public string Id { get; } = "navigation_control_id";

        ///<summary>
        /// If true the compass button is included.
        /// Default Value: true
        ///</summary>
        [JsonProperty("showCompass")]
        public bool ShowCompass { get; set; } = true;

        ///<summary>
        /// If true the zoom-in and zoom-out buttons are included.
        /// Default Value: true
        ///</summary>
        [JsonProperty("showZoom")]
        public bool ShowZoom { get; set; } = true;

        ///<summary>
        /// If true the pitch is visualized by rotating X-axis of compass.
        /// Default Value: false
        ///</summary>
        [JsonProperty("visualizePitch")]
        public bool VisualizePitch { get; set; } = false;

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
