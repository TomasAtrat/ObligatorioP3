window.onload = load;

var map;
var heatMapData = [];
var HeatMap;

var _polygon;
var infowindow;
var actualInfoWindow;

function load() {
    initMap();
    heatMapData = [];
    getZonas();
}

function Termico() {

    var start = document.getElementById("iniciobusqueda").value;
    var end = document.getElementById("finBusqueda").value;
    var dto = { inicio: start, fin: end };

    $.ajax({
        type: "GET",
        data: dto,
        contentType: "application/json",
        url: "ListPunto",
        success: function (mensaje) {
            if (mensaje != null) {
                for (i in mensaje) {
                    let location = new google.maps.LatLng(parseFloat(mensaje[i].lat), parseFloat(mensaje[i].lng));
                    heatMapData.push(location);
                }
                getPoints();
                 document.getElementById("iniciobusqueda").value= "";
                 document.getElementById("finBusqueda").value= "";
            }
        },
        error: function (mensaje) {
        }
    })
}

function getPoints() {

    heatmap = new google.maps.visualization.HeatmapLayer({
        data: heatMapData,
        map: map,
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

function drawPolygons(path, color, name, id, cantidadCuadrillas) {
    var polygon = new google.maps.Polygon({
        path: path,
        map: map,
        strokeWeight: 1,
        fillColor: color,
        fillOpacity: 0.10,
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

function AddInfoWindow(id, Nombre, cantidad, location) {
    contentString = '<h7 style= "font-weight: bold"> ID: </h7>' + id +
        '<h7 style= "font-weight: bold"> Nombre: </h7>' + Nombre +
        '<h7 style= "font-weight: bold"> Cantidad de cuadrillas: </h7>' + cantidad;

    infowindow = new google.maps.InfoWindow({
        content: contentString,
        position: location
    });
}