using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapbox.Razor.Models.Events
{
    public class MapClickEvent
    {
        public Action<MapClickEventArgs>? Action { get; set; }
    }
}
