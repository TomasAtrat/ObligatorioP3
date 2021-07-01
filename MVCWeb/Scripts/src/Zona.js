var map;
var locations = [];
var markers = [];
var _polygon;

window.onload = load;

function load() {
    initMap();
    map.addListener("rightclick", (mapsMouseEvent) => {
        AddLocation(mapsMouseEvent.latLng.lat(), mapsMouseEvent.latLng.lng())
    });
    map.addListener("dblclick", (mapsMouseEvent) => {
        drawPolygon()
    });
    getZonas();
}

function AddLocation(lat, lng) {
    var location = { lat, lng };
    const icon = "../../Content/IMG/outline_gps_fixed_black_24dp.png";
    const marker = new google.maps.Marker({
        position: location,
        icon: icon,
        draggable: true,
        map: map
    })
    markers.push(marker);
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

function drawPolygon() {
    let puntos = GetLocationsFromMarkers();
    let color = document.getElementById("color").value;
    const polygon = new google.maps.Polygon({
        path: puntos,
        map: map,
        fillColor: color,
    });

    //Las ublicaciones hay que guardarlas en la base de datos y posteriormente eliminarlas de memoria para seguir ingresando
}

function AgregarZona() {
    let nombre = document.getElementById("nombre").value;
    let color = document.getElementById("color").value;   
    let puntos = [];

    for (i in locations) {
        let punto = { lat: locations[i].lat, lng: locations[i].lng };
        puntos.push(punto);
    }

    let zona = { nombre: nombre, color: color, colPuntos: puntos };
        $.ajax({
            type: "POST",
            data: JSON.stringify(zona),
            contentType: "application/json",
            url: "http://localhost:60096/Zona/AgregarZona",
            success: function (respuesta) {
                $("#nombre").val("");
            },
            error: function (respuesta) {

            }
        })
}

function drawPolygons(path, color, name, id) {
    const polygon = new google.maps.Polygon({
        path: path,
        map: map,
        fillColor: color,
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

function AddInfoWindow() {
    contentString = '<h7 style= "font-weight: bold"> ID: </h7>' + id +
        '<h7 style= "font-weight: bold"> Nombre: </h7>' + idCuadrilla +
        '<h7 style= "font-weight: bold"> Estado: </h7>' + estado +
        '<h7 style= "font-weight: bold"> Observaciones: </h7>' + observaciones +
        '<h7 style= "font-weight: bold"> Diferencia en Horas: </h7>' + difHoras;

    infowindow = new google.maps.InfoWindow({
        content: contentString,
        position: location
    });
}