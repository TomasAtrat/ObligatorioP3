var map, _marker;
var zonas= [];

window.onload = load;

function load() {
    initMap();
    map.addListener("rightclick", (mapsMouseEvent) => {
        addMarker(mapsMouseEvent.latLng.lat(), mapsMouseEvent.latLng.lng())
        document.getElementById("IDZona").value = "-1";
    });

    getZonas();
}

function drawPolygons(path, color, name, id) {
    const polygon = new google.maps.Polygon({
        path: path,
        map: map,
        fillColor: color,
    });
    polygon.addListener("rightclick", (mapsMouseEvent) => {
        addMarker(mapsMouseEvent.latLng.lat(), mapsMouseEvent.latLng.lng()),
            document.getElementById("IDZona").value = id
    });
}

function getZonas() {
    $.ajax({
        type: "GET",
        contentType: "application/json",
        url: "http://localhost:60096/Zona/getZonas",
        success: function (mensaje) {
            if (mensaje != null) {
                for (i in mensaje) {
                    var colPuntos = mensaje[i].colPuntos;
                    let totalPuntos = [];
                    for (j in colPuntos) {
                        let puntos = { lat: parseFloat(colPuntos[j].lat), lng: parseFloat(colPuntos[j].lng) };
                        totalPuntos.push(puntos);
                    }
                    drawPolygons(totalPuntos, mensaje[i].color, mensaje[i].nombre, mensaje[i].id);
                }
            }
        },
        error: function (mensaje) {
        }
    })
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