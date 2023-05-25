using BAMCIS.GeoJSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapbox.Razor.Models.Events
{
    public class LayerClickEvent
    {
        public string LayerId { get; set; }

        public Action<LayerClickEventArgs> Action { get; set; }
    }
}
