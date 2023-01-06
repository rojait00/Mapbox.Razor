export function initMap(mapInterfaceRef, mapConfigurationJson) {
    var mapConfiguration = JSON.parse(mapConfigurationJson);

    window.map = new mapboxgl.Map(mapConfiguration);

    window.map.on('load', () => {
        {
            mapInterfaceRef.invokeMethodAsync("HandleOnMapLoadAsync");
        }
    });

    if (mapConfiguration.bounds?.length) {
        window.map.fitBounds(mapConfiguration.bounds, {
            padding: { top: 50, bottom: 50, left: 50, right: 50 }
        });
    }
}

export function addImage(id, url) {
    window.map.loadImage(url, (error, image) => {
        if (error) {
            throw error;
        }
        if (!map.hasImage(id)) {
            window.map.addImage(id, image);
        }
    });
}

export function removeImage(id) {
    if (map.hasImage(id)) {
        map.removeImage(id);
    }
}

export function addSource(id, sourceJson) {
    var mapSource = window.map.getSource(id);

    if (typeof mapSource === 'undefined') {
        window.map.addSource(id, JSON.parse(sourceJson));
    }
}

export function removeSource(id) {
    var mapSource = window.map.getSource(id);

    if (typeof mapSource !== 'undefined') {
        window.map.removeSource(id);
    }
}

export function addLayer(layerJson) {
    var layerObj = JSON.parse(layerJson);

    var mapLayer = window.map.getLayer(layerObj.id);

    if (typeof mapLayer === 'undefined') {
        window.map.addLayer(layerObj);
    }
}

export function removeLayer(id) {
    var mapSource = window.map.getSource(id);

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
    window.map.on('click', forLayer, (e) => {

        const coordinates = e.features[0].geometry.coordinates.slice();
        const properties = e.features[0].properties;

        while (Math.abs(e.lngLat.lng - coordinates[0]) > 180) {
            coordinates[0] += e.lngLat.lng > coordinates[0] ? 360 : -360;
        }

        mapInterfaceRef.invokeMethodAsync("HandleLayerClickEvent", forLayer, e.lngLat.lat, e.lngLat.lng, properties);
    });
}

export function addOnMapClickEventlistner(mapInterfaceRef) {
    window.map.on(onEventId, (e) => {
        mapInterfaceRef.invokeMethodAsync("HandleMapClickEvent", e.lngLat.lat, e.lngLat.lng);
    });
}