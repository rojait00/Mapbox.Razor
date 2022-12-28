export function initMap(mapInterfaceRef, mapConfigurationJson) {
    var mapConfiguration = JSON.parse(mapConfigurationJson);

    window.map = new mapboxgl.Map(mapConfiguration);

    window.map.on('load', () => {
        {
            mapInterfaceRef.invokeMethodAsync("HandleOnMapLoadAsync");
        }
    });
}

export function addSource(id, sourceJson) {
    var mapSource = map.getSource(id);

    if (typeof mapSource === 'undefined') {
        window.map.addSource(id, JSON.parse(sourceJson));
    }
}

export function removeSource(id) {
    var mapSource = map.getSource(id);

    if (typeof mapSource !== 'undefined') {
        window.map.removeSource(id);
    }
}

export function addLayer(layerJson) {
    var layerObj = JSON.parse(layerJson);

    var mapLayer = map.getLayer(layerObj.id);

    if (typeof mapLayer === 'undefined') {
        window.map.addLayer(layerObj);
    }
}

export function removeLayer(id) {
    var mapSource = map.getSource(id);

    if (typeof mapSource !== 'undefined') {
        window.map.removeSource(id);
    }
}

export function addControl(type, controlJson) {
    var controlConfig = JSON.parse(controlJson);
    var controlObj;

    switch (type) {
        case 'fullscreen_control_id':
            controlObj = new mapboxgl.FullscreenControl(controlConfig);
            controlObj.container = $(controlConfig.container);
            break;
        case 'geo_locate_control_id':
            controlObj = new mapboxgl.GeolocateControl(controlConfig);
            break;
        case 'navigation_control_id':
            controlObj = new mapboxgl.NavigationControl(controlConfig);
            break;
        case 'scale_control_id':
            controlObj = new mapboxgl.ScaleControl(controlConfig);
            break;
        default:
            return;
    }

    window.mapControls = {};
    window.mapControls[type] = controlObj;
    window.map.addControl(controlObj);
}

export function removeControl(id) {
    var controlObj = window.mapControls[id];
    if (typeof controlObj !== 'undefined') {
        window.map.removeControl(controlObj);
    }
}

export function addEventlistner(onEventId, forLayer, mapInterfaceRef) {
    window.map.on(onEventId, forLayer, () => {
        mapInterfaceRef.invokeMethodAsync("HandleEvent", onEventId, forLayer);
    });
}

export function addOnLayerClickEventlistner(forLayer, mapInterfaceRef) {
    window.map.on(onEventId, forLayer, () => {
        var description = e.features[0].properties.description;
        mapInterfaceRef.invokeMethodAsync("HandleLayerClickEvent", forLayer, e.lngLat.lat, e.lngLat.lng, description);
    });
}

export function addOnMapClickEventlistner(mapInterfaceRef) {
    window.map.on(onEventId, () => {
        var description = e.features[0].properties.description;
        mapInterfaceRef.invokeMethodAsync("HandleMapClickEvent", e.lngLat.lat, e.lngLat.lng, description);
    });
}