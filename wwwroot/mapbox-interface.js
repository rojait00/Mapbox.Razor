var initState = undefined;

function fitBoundsInt(bounds) {
    window.map.fitBounds(bounds, {
        padding: { top: 50, bottom: 50, left: 50, right: 50 }
    });
}

export function initMap(mapInterfaceRef, mapConfigurationJson) {
    var mapConfiguration = JSON.parse(mapConfigurationJson);

    if (initState === undefined) {
        initState = "In Progress";
        window.map = new mapboxgl.Map(mapConfiguration);
        window.mapControls = {};
        window.layerStartTimes = {};

        window.map.on('load', () => {
            {
                mapInterfaceRef.invokeMethodAsync("HandleOnMapLoadAsync");
                initState = "Finished";
            }
        });
    }
    else if (initState === "Finished") {
        mapInterfaceRef.invokeMethodAsync("HandleOnMapLoadAsync");
    }

    if (mapConfiguration.bounds?.length) {
        fitBoundsInt(mapConfiguration.bounds);
    }
}

export function remove() {
    if (window.map !== undefined) {
        window.map.remove();
    }
    initState = undefined
    window.map = undefined;
    window.mapControls = undefined;
}
export function updateMapStyle(mapStyleUrl) {
    window.map.setStyle(mapStyleUrl);
}

export function fitBounds(boundsJson) {
    fitBoundsInt(JSON.parse(boundsJson));
}

export function addImage(id, url) {
    window.map.loadImage(url, (error, image) => {
        if (error) {
            throw error;
        }
        if (!window.map.hasImage(id)) {
            window.map.addImage(id, image);
        }
    });
}

export function removeImage(id) {
    if (window.map.hasImage(id)) {
        window.map.removeImage(id);
    }
}

export function addSource(id, sourceJson) {
    var mapSource = window.map.getSource(id);
    var source = JSON.parse(sourceJson);

    if (typeof mapSource === 'undefined') {
        window.map.addSource(id, source);
    }
    else {
        updateSource(id, JSON.stringify(source.data));
    }
}

export function updateSource(id, geoJson) {
    var mapSource = window.map.getSource(id);

    if (typeof mapSource !== 'undefined') {
        var data = JSON.parse(geoJson);
        mapSource.setData(data);
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

        if (layerObj.dashArraySequence !== undefined) {
            let step = 0;
            let startTime = new Date().getTime();

            window.layerStartTimes[`${layerObj.id}`] = startTime;
            function animateDashArray(timestamp) {
                if (window.layerStartTimes[`${layerObj.id}`] > startTime) {
                    return;
                }

                if (window.map === undefined) {
                    // This may happen once. Request the next frame of the animation.
                    requestAnimationFrame(animateDashArray);
                    return;
                }

                var layerToAnimate = window.map.getLayer(layerObj.id);
                if (typeof layerToAnimate !== 'undefined') {
                    step = (step + 1) % layerObj.dashArraySequence.length;
                    window.map.setPaintProperty(
                        layerObj.id,
                        'line-dasharray',
                        layerObj.dashArraySequence[step]
                    );

                    // Request the next frame of the animation.
                    requestAnimationFrame(animateDashArray);
                }
            }

            // start the animation
            animateDashArray(0);
        }
    }
}

export function removeLayer(id) {
    var layer = window.map.getLayer(id);

    if (typeof layer !== 'undefined') {
        window.map.removeLayer(id);
    }
}

export function addControl(type, controlJson) {
    if (!window.mapControls || window.mapControls[type] === undefined) {
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

        if (!window.mapControls) {
            window.mapControls = {};
        }
        window.mapControls[type] = controlObj;
        window.map.addControl(controlObj);
    }
}

export function removeControl(id) {
    if (window.mapControls[type] === undefined) {
        window.map.removeControl(controlObj);
        delete window.mapControls[id];
    }
}

export function addLayerEventlistner(onEventId, forLayer, mapInterfaceRef) {
    window.map.on(onEventId, forLayer, (e) => {
        mapInterfaceRef.invokeMethodAsync("HandleLayerEvent", onEventId, forLayer);
    });
}

export function addMapEventlistner(onEventId, mapInterfaceRef) {

    window.map.on(onEventId, () => {
        const coordinateList = window.map.getBounds();
        const southLat = coordinateList._sw.lat;
        const westLng = coordinateList._sw.lng;
        const northLat = coordinateList._ne.lat;
        const eastLng = coordinateList._ne.lng;

        mapInterfaceRef.invokeMethodAsync("HandleMapEvent", onEventId, southLat, westLng, northLat, eastLng);
    });
}

export function addOnLayerClickEventlistner(forLayer, mapInterfaceRef, changeCursorOnHover) {
    window.map.on('click', forLayer, (e) => {
        e.clickOnLayer = true;

        const coordinates = e.features[0].geometry.coordinates.slice();
        const properties = e.features[0].properties;

        while (Math.abs(e.lngLat.lng - coordinates[0]) > 180) {
            coordinates[0] += e.lngLat.lng > coordinates[0] ? 360 : -360;
        }

        mapInterfaceRef.invokeMethodAsync("HandleLayerClickEvent", forLayer, e.lngLat.lat, e.lngLat.lng, properties);
    });

    if (changeCursorOnHover) {
        map.on('mouseenter', forLayer, (e) => {
            // Change the cursor style as a UI indicator.
            map.getCanvas().style.cursor = 'pointer';
        });

        map.on('mouseleave', forLayer, () => {
            map.getCanvas().style.cursor = '';
        });
    }
}

export function addOnMapClickEventlistner(mapInterfaceRef) {
    window.map.on('click', (e) => {
        if (!e.clickOnLayer) {
            mapInterfaceRef.invokeMethodAsync("HandleMapClickEvent", e.lngLat.lat, e.lngLat.lng);
        }
    });
}