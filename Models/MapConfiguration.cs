using BAMCIS.GeoJSON;
using Mapbox.Razor.Models.Controls;
using Mapbox.Razor.Models.Events;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Mapbox.Razor.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class MapConfiguration : IMapboxClass
    {
        [JsonIgnore]
        public List<Image> Images { get; set; } = new();

        [JsonIgnore]
        public List<Source> Sources { get; set; } = new List<Source>();

        [JsonIgnore]
        public List<Layer> Layers { get; set; } = new List<Layer>();

        [JsonIgnore]
        public List<IControl> Controls { get; set; } = new List<IControl>();

        [JsonIgnore]
        public List<LayerClickEvent> LayerClickHandler { get; set; } = new ();

        [JsonIgnore]
        public List<LayerEvent> LayerEventHandler { get; set; } = new ();

        [JsonIgnore]
        public List<MapClickEvent> MapClickHandler { get; set; } = new ();

        [JsonProperty("sprite")]
        public string? Sprite { get; set; }

        [JsonProperty("metadata")]
        public dynamic? MetaData { get; set; }

        [JsonProperty("created")]
        public string? Created { get; set; }

        [JsonProperty("modified")]
        public string? Modified { get; set; }

        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("owner")]
        public string? Owner { get; set; }

        [JsonProperty("visibility")]
        public string? Visibility { get; set; }

        [JsonProperty("protected")]
        public bool? Protected { get; set; }

        [JsonProperty("draft")]
        public bool? Draft { get; set; }

        [JsonProperty("version")]
        public int? Version { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("glyphs")]
        public string? Glyphs { get; set; }


        #region generated https://docs.mapbox.com/mapbox-gl-js/api/map/
        ///<summary>
        ///If specified, map will use this token instead of the one defined in mapboxgl.accessToken .
        ///</summary>
        [JsonProperty("accessToken")]
        public string? AccessToken { get; set; } = null;

        ///<summary>
        ///If true , the gl context will be created with MSAA antialiasing , which can be useful for antialiasing custom layers. This is false by default as a performance optimization.
        ///</summary>
        [JsonProperty("antialias")]
        public bool Antialias { get; set; } = false;

        ///<summary>
        ///If true , an AttributionControl will be added to the map.
        ///</summary>
        [JsonProperty("attributionControl")]
        public bool AttributionControl { get; set; } = true;

        ///<summary>
        ///The initial bearing (rotation) of the map, measured in degrees counter-clockwise from north. If bearing is not specified in the constructor options, Mapbox GL JS will look for it in the map's style object. If it is not specified in the style, either, it will default to 0 .
        ///</summary>
        [JsonProperty("bearing")]
        public double Bearing { get; set; } = 0;

        ///<summary>
        ///The threshold, measured in degrees, that determines when the map's bearing will snap to north. For example, with a bearingSnap of 7, if the user rotates the map within 7 degrees of north, the map will automatically snap to exact north.
        ///</summary>
        [JsonProperty("bearingSnap")]
        public double BearingSnap { get; set; } = 7;

        ///<summary>
        ///The initial bounds of the map. If bounds is specified, it overrides center and zoom constructor options.
        ///</summary>
        [JsonProperty("bounds")]
        public List<Position>? Bounds { get; set; } = null;

        ///<summary>
        ///If true , the "box zoom" interaction is enabled (see BoxZoomHandler ).
        ///</summary>
        [JsonProperty("boxZoom")]
        public bool BoxZoom { get; set; } = true;

        ///<summary>
        ///The initial geographical centerpoint of the map. If center is not specified in the constructor options, Mapbox GL JS will look for it in the map's style object. If it is not specified in the style, either, it will default to new Position(0, 0) Note: Mapbox GL uses longitude, latitude coordinate order (as opposed to latitude, longitude) to match GeoJSON.
        ///</summary>
        [JsonProperty("center")]
        public Position Center { get; set; } = new Position(0, 0);

        ///<summary>
        ///The max number of pixels a user can shift the mouse pointer during a click for it to be considered a valid click (as opposed to a mouse drag).
        ///</summary>
        [JsonProperty("clickTolerance")]
        public double ClickTolerance { get; set; } = 3;

        ///<summary>
        ///If true , Resource Timing API information will be collected for requests made by GeoJSON and Vector Tile web workers (this information is normally inaccessible from the main Javascript thread). Information will be returned in a resourceTiming property of relevant data events.
        ///</summary>
        [JsonProperty("collectResourceTiming")]
        public bool CollectResourceTiming { get; set; } = false;

        ///<summary>
        ///The HTML element in which Mapbox GL JS will render the map, or the element's string id . The specified element must have no children.
        ///</summary>
        [JsonProperty("container")]
        public string Container { get; set; } = "map";

        ///<summary>
        ///If true , scroll zoom will require pressing the ctrl or ⌘ key while scrolling to zoom map, and touch pan will require using two fingers while panning to move the map. Touch pitch will require three fingers to activate if enabled.
        ///</summary>
        [JsonProperty("cooperativeGestures")]
        public bool? CooperativeGestures { get; set; }

        ///<summary>
        ///If true , symbols from multiple sources can collide with each other during collision detection. If false , collision detection is run separately for the symbols in each source.
        ///</summary>
        [JsonProperty("crossSourceCollisions")]
        public bool CrossSourceCollisions { get; set; } = true;

        ///<summary>
        ///String or strings to show in an AttributionControl . Only applicable if options.attributionControl is true .
        ///</summary>
        [JsonProperty("customAttribution")]
        public string? CustomAttribution { get; set; } = null;

        ///<summary>
        ///If true , the "double click to zoom" interaction is enabled (see DoubleClickZoomHandler ).
        ///</summary>
        [JsonProperty("doubleClickZoom")]
        public bool DoubleClickZoom { get; set; } = true;

        ///<summary>
        ///If true , the "drag to pan" interaction is enabled. An Object value is passed as options to DragPanHandler#enable .
        ///</summary>
        [JsonProperty("dragPan")]
        public dynamic? DragPan { get; set; }

        ///<summary>
        ///If true , the "drag to rotate" interaction is enabled (see DragRotateHandler ).
        ///</summary>
        [JsonProperty("dragRotate")]
        public bool DragRotate { get; set; } = true;

        ///<summary>
        ///Controls the duration of the fade-in/fade-out animation for label collisions, in milliseconds. This setting affects all symbol layers. This setting does not affect the duration of runtime styling transitions or raster tile cross-fading.
        ///</summary>
        [JsonProperty("fadeDuration")]
        public double FadeDuration { get; set; } = 300;

        ///<summary>
        ///If true , map creation will fail if the performance of Mapbox GL JS would be dramatically worse than expected (a software renderer would be used).
        ///</summary>
        [JsonProperty("failIfMajorPerformanceCaveat")]
        public bool FailIfMajorPerformanceCaveat { get; set; } = false;

        ///<summary>
        ///A Map#fitBounds options object to use only when fitting the initial bounds provided above.
        ///</summary>
        [JsonProperty("fitBoundsOptions")]
        public dynamic? FitBoundsOptions { get; set; }

        ///<summary>
        ///If true , the map's position (zoom, center latitude, center longitude, bearing, and pitch) will be synced with the hash fragment of the page's URL. For example, http://path/to/my/page.html#2.59/39.26/53.07/-24.1/60 . An additional string may optionally be provided to indicate a parameter-styled hash, for example http://path/to/my/page.html#map=2.59/39.26/53.07/-24.1/60&foo=bar , where foo is a custom parameter and bar is an arbitrary hash distinct from the map hash.
        ///</summary>
        [JsonProperty("hash")]
        public dynamic? Hash { get; set; }

        ///<summary>
        ///If false , no mouse, touch, or keyboard listeners will be attached to the map, so it will not respond to interaction.
        ///</summary>
        [JsonProperty("interactive")]
        public bool Interactive { get; set; } = true;

        ///<summary>
        ///If true , keyboard shortcuts are enabled (see KeyboardHandler ).
        ///</summary>
        [JsonProperty("keyboard")]
        public bool Keyboard { get; set; } = true;

        ///<summary>
        ///A string with a BCP 47 language tag, or an array of such strings representing the desired languages used for the map's labels and UI components. Languages can only be set on Mapbox vector tile sources. By default, GL JS will not set a language so that the language of Mapbox tiles will be determined by the vector tile source's TileJSON. Valid language strings must be a BCP-47 language code . Unsupported BCP-47 codes will not include any translations. Invalid codes will result in an recoverable error. If a label has no translation for the selected language, it will display in the label's local language. If option is set to auto , GL JS will select a user's preferred language as determined by the browser's window.navigator.language property. If the locale property is not set separately, this language will also be used to localize the UI for supported languages.
        ///</summary>
        [JsonProperty("language")]
        public string? Language { get; set; } = null;

        ///<summary>
        ///A patch to apply to the default localization table for UI strings such as control tooltips. The locale object maps namespaced UI string IDs to translated strings in the target language; see src/ui/default_locale.js for an example with all supported string IDs. The object may specify all UI strings (thereby adding support for a new translation) or only a subset of strings (thereby patching the default translation table).
        ///</summary>
        [JsonProperty("locale")]
        public dynamic? Locale { get; set; }

        ///<summary>
        ///Defines a CSS font-family for locally overriding generation of all glyphs. Font settings from the map's style will be ignored, except for font-weight keywords (light/regular/medium/bold). If set, this option overrides the setting in localIdeographFontFamily.
        ///</summary>
        [JsonProperty("localFontFamily")]
        public dynamic? LocalFontFamily { get; set; }

        ///<summary>
        ///Defines a CSS font-family for locally overriding generation of glyphs in the 'CJK Unified Ideographs', 'Hiragana', 'Katakana', 'Hangul Syllables' and 'CJK Symbols and Punctuation' ranges. In these ranges, font settings from the map's style will be ignored, except for font-weight keywords (light/regular/medium/bold). Set to false , to enable font settings from the map's style for these glyph ranges. Note that Mapbox Studio sets this value to false by default. The purpose of this option is to avoid bandwidth-intensive glyph server requests. For an example of this option in use, see Use locally generated ideographs .
        ///</summary>
        [JsonProperty("localIdeographFontFamily")]
        public string LocalIdeographFontFamily { get; set; } = "sans-serif";

        ///<summary>
        ///A string representing the position of the Mapbox wordmark on the map. Valid options are top-left , top-right , bottom-left , bottom-right .
        ///</summary>
        [JsonProperty("logoPosition")]
        public string LogoPosition { get; set; } = "bottom-left";

        ///<summary>
        ///If set, the map will be constrained to the given bounds.
        ///</summary>
        [JsonProperty("maxBounds")]
        public List<Position>? MaxBounds { get; set; } = null;

        ///<summary>
        ///The maximum pitch of the map (0-85).
        ///</summary>
        [JsonProperty("maxPitch")]
        public double MaxPitch { get; set; } = 85;

        ///<summary>
        ///The maximum number of tiles stored in the tile cache for a given source. If omitted, the cache will be dynamically sized based on the current viewport.
        ///</summary>
        [JsonProperty("maxTileCacheSize")]
        public double? MaxTileCacheSize { get; set; } = null;

        ///<summary>
        ///The maximum zoom level of the map (0-24).
        ///</summary>
        [JsonProperty("maxZoom")]
        public double MaxZoom { get; set; } = 22;

        ///<summary>
        ///The minimum pitch of the map (0-85).
        ///</summary>
        [JsonProperty("minPitch")]
        public double MinPitch { get; set; } = 0;

        ///<summary>
        ///The minimum number of tiles stored in the tile cache for a given source. Larger viewports use more tiles and need larger caches. Larger viewports are more likely to be found on devices with more memory and on pages where the map is more important. If omitted, the cache will be dynamically sized based on the current viewport.
        ///</summary>
        [JsonProperty("minTileCacheSize")]
        public double? MinTileCacheSize { get; set; } = null;

        ///<summary>
        ///The minimum zoom level of the map (0-24).
        ///</summary>
        [JsonProperty("minZoom")]
        public double MinZoom { get; set; } = 0;

        ///<summary>
        ///With terrain on, if true , the map will render for performance priority, which may lead to layer reordering allowing to maximize performance (layers that are draped over terrain will be drawn first, including fill, line, background, hillshade and raster). Otherwise, if set to false , the map will always be drawn for layer order priority.
        ///</summary>
        [JsonProperty("optimizeForTerrain")]
        public bool OptimizeForTerrain { get; set; } = true;

        ///<summary>
        ///If true , mapbox-gl will collect and send performance metrics.
        ///</summary>
        [JsonProperty("performanceMetricsCollection")]
        public bool PerformanceMetricsCollection { get; set; } = true;

        ///<summary>
        ///The initial pitch (tilt) of the map, measured in degrees away from the plane of the screen (0-85). If pitch is not specified in the constructor options, Mapbox GL JS will look for it in the map's style object. If it is not specified in the style, either, it will default to 0 .
        ///</summary>
        [JsonProperty("pitch")]
        public double Pitch { get; set; } = 0;

        ///<summary>
        ///If false , the map's pitch (tilt) control with "drag to rotate" interaction will be disabled.
        ///</summary>
        [JsonProperty("pitchWithRotate")]
        public bool PitchWithRotate { get; set; } = true;

        ///<summary>
        ///If true , the map's canvas can be exported to a PNG using map.getCanvas().toDataURL() . This is false by default as a performance optimization.
        ///</summary>
        [JsonProperty("preserveDrawingBuffer")]
        public bool PreserveDrawingBuffer { get; set; } = false;

        ///<summary>
        ///The projection the map should be rendered in. Supported projections are:
        ///Albers equal-area conic projection as albers
        ///Equal Earth equal-area pseudocylindrical projection as equalEarth
        ///Equirectangular(Plate Carrée/WGS84) as equirectangular
        ///3d Globe as globe
        ///Lambert Conformal Conic as lambertConformalConic
        ///Mercator cylindrical map projection as mercator
        ///Natural Earth pseudocylindrical map projection as naturalEarth
        ///Winkel Tripel azimuthal map projection as winkelTripel Conic projections such as Albers and Lambert have configurable center and parallels properties that allow developers to define the region in which the projection has minimal distortion; see the example for how to configure these properties.
        ///</summary>
        [JsonProperty("projection")]
        public dynamic? Projection { get; set; }

        ///<summary>
        ///If false , the map won't attempt to re-request tiles once they expire per their HTTP cacheControl / expires headers.
        ///</summary>
        [JsonProperty("refreshExpiredTiles")]
        public bool RefreshExpiredTiles { get; set; } = true;

        ///<summary>
        ///If true , multiple copies of the world will be rendered side by side beyond -180 and 180 degrees longitude. If set to false :
        ///When the map is zoomed out far enough that a single representation of the world does not fill the map's entire container, there will be blank space beyond 180 and -180 degrees longitude.
        ///Features that cross 180 and -180 degrees longitude will be cut in two(with one portion on the right edge of the map and the other on the left edge of the map) at every zoom level.
        ///</summary>
        [JsonProperty("renderWorldCopies")]
        public bool RenderWorldCopies { get; set; } = true;

        ///<summary>
        ///If true , the "scroll to zoom" interaction is enabled. An Object value is passed as options to ScrollZoomHandler#enable .
        ///</summary>
        [JsonProperty("scrollZoom")]
        public bool ScrollZoom { get; set; } = true;

        ///<summary>
        ///The map's Mapbox style. This must be an a JSON object conforming to the schema described in the Mapbox Style Specification , or a URL to such JSON. Can accept a null value to allow adding a style manually.
        /// To load a style from the Mapbox API, you can use a URL of the form mapbox://styles/:owner/:style, where :owner is your Mapbox account name and :style is the style ID. You can also use a Mapbox-owned style:
        /// 
        /// mapbox://styles/mapbox/streets-v11
        /// mapbox://styles/mapbox/outdoors-v11
        /// mapbox://styles/mapbox/light-v10
        /// mapbox://styles/mapbox/dark-v10
        /// mapbox://styles/mapbox/satellite-v9
        /// mapbox://styles/mapbox/satellite-streets-v11
        /// mapbox://styles/mapbox/navigation-day-v1
        /// mapbox://styles/mapbox/navigation-night-v1.
        /// Tilesets hosted with Mapbox can be style-optimized if you append ? optimize = true to the end of your style URL, like mapbox://styles/mapbox/streets-v11?optimize=true. Learn more about style-optimized vector tiles in our API documentation.
        /// 
        ///</summary>
        [JsonProperty("style")]
        public string? Style { get; set; }


        ///<summary>
        ///Silences errors and warnings generated due to an invalid accessToken, useful when using the library to write unit tests.
        ///</summary>
        [JsonProperty("testMode")]
        public bool TestMode { get; set; } = false;

        ///<summary>
        ///If true , the "drag to pitch" interaction is enabled. An Object value is passed as options to TouchPitchHandler .
        ///</summary>
        [JsonProperty("touchPitch")]
        public bool TouchPitch { get; set; } = true;

        ///<summary>
        ///If true , the "pinch to rotate and zoom" interaction is enabled. An Object value is passed as options to TouchZoomRotateHandler#enable .
        ///</summary>
        [JsonProperty("touchZoomRotate")]
        public bool TouchZoomRotate { get; set; } = true;

        ///<summary>
        ///If true , the map will automatically resize when the browser window resizes.
        ///</summary>
        [JsonProperty("trackResize")]
        public bool TrackResize { get; set; } = true;

        ///<summary>
        ///A callback run before the Map makes a request for an external URL. The callback can be used to modify the url, set headers, or set the credentials property for cross-origin requests. Expected to return a RequestParameters object with a url property and optionally headers and credentials properties.
        ///</summary>
        [JsonProperty("transformRequest")]
        public dynamic? TransformRequest { get; set; } = null;

        ///<summary>
        ///Sets the map's worldview. A worldview determines the way that certain disputed boundaries are rendered. By default, GL JS will not set a worldview so that the worldview of Mapbox tiles will be determined by the vector tile source's TileJSON. Valid worldview strings must be an ISO alpha-2 country code . Unsupported ISO alpha-2 codes will fall back to the TileJSON's default worldview. Invalid codes will result in a recoverable error.
        ///</summary>
        [JsonProperty("worldview")]
        public string? Worldview { get; set; } = null;

        ///<summary>
        ///The initial zoom level of the map. If zoom is not specified in the constructor options, Mapbox GL JS will look for it in the map's style object. If it is not specified in the style, either, it will default to 0 .///</summary>
        [JsonProperty("zoom")]
        public double Zoom { get; set; } = 0;
        #endregion
    }

}
