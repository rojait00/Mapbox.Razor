using Mapbox.Razor.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapbox.Razor.Helper
{
    internal static class IMapboxClassExtensions
    {
        internal static string GetJson(this IMapboxClass mapboxClass)
        {
            return JsonConvert.SerializeObject(mapboxClass);
        }
    }
}
