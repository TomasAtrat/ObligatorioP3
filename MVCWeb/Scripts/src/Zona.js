var map;
var locations = [];
var markers = [];

window.onload = load;

function load() {
    initMap();
    map.addListener("rightclick", (mapsMouseEvent) => {
        AddLocation(mapsMouseEvent.latLng.lat(), mapsMouseEvent.latLng.lng())
    });
    map.addListener("dblclick", (mapsMouseEvent) => {
        drawPolygon()
    });
}

function AddLocation(lat, lng) {
    var location = { lat, lng };
    const icon = "../IMG/outline_gps_fixed_black_24dp.png";
    const marker = new google.maps.Marker({
        position: location,
        icon: icon,
        draggable: true,
        map: map
    })
    markers.push(marker);
}

function drawPolygon() {
    const polygon = new google.maps.Polygon({
        path: GetLocationsFromMarkers(),
        map: map,
        fillColor: document.getElementById("ColorPicker").value,
    });
    
    //Las ublicaciones hay que guardarlas en la base de datos y posteriormente eliminarlas de memoria para seguir ingresando
}

function submit() {
    clearFields()
}

function clearFields() {
    $("#nombreZona").val("");
    for (i in markers) {
        markers[i].setMap(null);
    }
}

function GetLocationsFromMarkers() {
    for (marker in markers) {
        var lat = markers[marker].getPosition().lat();
        var lng = markers[marker].getPosition().lng();
        var location = { lat, lng };
        locations.push(location);
    }
    return locations;
}