using Mapbox.Razor.Models;
using Newtonsoft.Json;

namespace Mapbox.Razor.Extensions
{
    internal static class IMapboxClassExtensions
    {
        internal static string GetJson(this IMapboxClass mapboxClass)
        {
            return JsonConvert.SerializeObject(mapboxClass,
                                               new JsonSerializerSettings
                                               {
                                                   NullValueHandling = NullValueHandling.Ignore
                                               });
        }
    }
}
