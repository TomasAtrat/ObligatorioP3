var map, _marker;
var zonas= [];

window.onload = load;

function load() {
    initMap();
    map.addListener("rightclick", (mapsMouseEvent) => {
        addMarker(mapsMouseEvent.latLng.lat(), mapsMouseEvent.latLng.lng())
    });
}

function addMarker(lat, lng) {
    deleteMarker();
    var location = { lat, lng };
    const marker = new google.maps.Marker({
        position: location,
        map: map
    })
    _marker = marker;

    document.getElementById("Latitud").value = lat;
    document.getElementById("Longitud").value = lng;
}

function deleteMarker() {
    if (_marker != null) {
        _marker.setMap(null);
    }
}