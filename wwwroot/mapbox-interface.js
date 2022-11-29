export function initMap(mapInterfaceRef, mapConfigurationJson) {
    mapConfiguration = JSON.parse(sourceJson);

    mapboxgl.accessToken = mapConfiguration.acessToken;
    const map = new mapboxgl.Map({
        container: containerId,
        style: styleUrl,
        center: [startingPositionLong, startingPositionLat],
        zoom: startingZoom
    });

    map.on('load', () => {
        {
            mapInterfaceRef.invokeMethodeAsync("HandleOnMapLoad");
        }
    });
}

export function addSource(id, sourceJson) {
    map.addSource(id, JSON.parse(sourceJson));
}

export function addLayer(layerJson) {
    map.addLayer(JSON.parse(layerJson));
}

export function removeSource(id) {
    map.removeSource(id);
}

export function removeLayer(id) {
    map.removeLayer(id);
}

export function addEventlistner(onEventId, forLayer, mapInterfaceRef) {
    map.on(onEventId, forLayer, () => {
        mapInterfaceRef.invokeMethodeAsync("HandleEvent", onEventId, forLayer);
    });
}

export function addOnLayerClickEventlistner(forLayer, mapInterfaceRef) {
    map.on(onEventId, forLayer, () => {
        var description = e.features[0].properties.description;
        mapInterfaceRef.invokeMethodeAsync("HandleLayerClickEvent", forLayer, e.lngLat.lat, e.lngLat.lng, description);
    });
}

export function addOnMapClickEventlistner(mapInterfaceRef) {
    map.on(onEventId, () => {
        var description = e.features[0].properties.description;
        mapInterfaceRef.invokeMethodeAsync("HandleMapClickEvent", e.lngLat.lat, e.lngLat.lng, description);
    });
}