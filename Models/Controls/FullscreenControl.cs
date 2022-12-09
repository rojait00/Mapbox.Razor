using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapbox.Razor.Models.Controls
{
    public class FullscreenControl : IControl
    {
        /// <summary>
        /// InternalId
        /// </summary>
        [JsonIgnore]
        public string Id { get; } = "fullscreen_control_id";

        ///<summary>
        /// jQuery selector for container. Container is the compatible DOM element which should be made full screen. By default, the map container element will be made full screen.
        ///</summary>
        [JsonProperty("container")]
        public string? Container { get; set; }

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
