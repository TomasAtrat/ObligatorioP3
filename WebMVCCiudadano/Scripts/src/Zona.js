var map;
var locations = [];
var markers = [];
var _polygon;
var infowindow;
var actualInfoWindow;
window.onload = load;

function load() {
    initMap();

    map.addListener("dblclick", (mapsMouseEvent) => {
        drawPolygon()
    });

    getZonas();
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



function Validate() {
    let nombre = document.getElementById("nombre").value;
    if (!(nombre == "" || nombre.length>50 || locations == null || locations == 0)) {
        AgregarZona();
    }
}

function drawPolygons(path, color, name, id, cantidadCuadrillas) {
    var polygon = new google.maps.Polygon({
        path: path,
        map: map,
        fillColor: color,
    });

    polygon.addListener("click", (e) => {
        AddInfoWindow(id, name, cantidadCuadrillas, e.latLng);
        if (actualInfoWindow != null) {
            actualInfoWindow.close();
        }
        infowindow.open({
            
            map,
            shouldFocus: false,
        });
        actualInfoWindow = infowindow;
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
                    drawPolygons(totalPuntos, mensaje[i].color, mensaje[i].nombre, mensaje[i].id, mensaje[i].cantidadCuadrillas);
                }
            }
        },
        error: function (mensaje) {
        }
    })
}

function AddInfoWindow(id, Nombre, cantidad, location) {
    contentString = '<h7 style= "font-weight: bold"> ID: </h7>' + id +
        '<h7 style= "font-weight: bold"> Nombre: </h7>' + Nombre +
        '<h7 style= "font-weight: bold"> Cantidad de cuadrillas: </h7>' + cantidad + "<br />"+
        "<button title= 'Dar de baja' onclick='Baja(\"" + Nombre + "\" "+ "," + id + ")'> Dar de baja </button>" ;

    infowindow = new google.maps.InfoWindow({
        content: contentString,
        position: location
    });
}


function Baja(nombreZona, id) {
    b = confirm("¿Realmente desea dar de baja la zona " + nombreZona + "?");
    if (b) {
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "http://localhost:60096/Zona/Baja/" + id,
            success: function (mensaje) {
                getZonas();
            },
            error: function (mensaje) {
            }
        })
    }
}