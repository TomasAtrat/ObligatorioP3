window.onload = load;

var map;
var markers = [];
var actualInfoWindow;
var heatMapData = [];
var infowindow;
var HeatMap;

function load() {
    initMap();
    heatMapData = [];
}

var puntosCard = {
    "lat": "",
    "long": ""
}



function Termico() {

    var start = document.getElementById("iniciobusqueda").value;
    var end = document.getElementById("finBusqueda").value;
    var dto = { inicio: start, fin: end };

    $.ajax({
        type: "GET",
        data: dto,
        contentType: "application/json",
        url: "http://localhost:60096/MapaTermico/ListPunto",
        success: function (mensaje) {
            if (mensaje != null) {
                for (i in mensaje) {
                    let location = new google.maps.LatLng(parseFloat(mensaje[i].lat), parseFloat(mensaje[i].lng));
                    heatMapData.push(location);
                }
                getPoints();
            }
        },
        error: function (mensaje) {
        }
    })

    



    function getPoints() {

        heatmap = new google.maps.visualization.HeatmapLayer({
            data: heatMapData,
            map: map,
        });

    }

}