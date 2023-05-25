using BAMCIS.GeoJSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapbox.Razor.Models.Events
{
    public class LayerEvent
    {
        public string LayerId { get; set; }

        public string EventId { get; set; }

        public Action<LayerEventArgs> Action { get; set; }
    }
}
