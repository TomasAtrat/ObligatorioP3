window.onload = load;

var map;
var markers = [];
var actualInfoWindow;

var infowindow;
    
function load() {
    initMap();
    getReclamos();
}



function getReclamos() {

    $.ajax({
        type: "GET",
        contentType: "application/json",
        url: "http://localhost:60096/Reclamo/getReclamos",
        success: function (mensaje) {
            if (mensaje != null) {
                for (i in mensaje) {
                    AddLocation(mensaje[i].Latitud, mensaje[i].Longitud, mensaje[i].difHoras, mensaje[i].IDCuadrilla, mensaje[i].ID, mensaje[i].Estado, mensaje[i].Observaciones);
                }
            }
        },
        error: function (mensaje) {
        }
    })

}

function AddLocation(lat, lng, difHoras, idCuadrilla, id, estado, observaciones) {

    var location = { lat, lng };
    var marker = new google.maps.Marker({
        position: location,
        map: map
    })

    if (difHoras <= 24) {
        marker.setIcon("../../Content/IMG/green-dot.png");
    } else if (difHoras > 24 && difHoras <= 32) {
        marker.setIcon("../../Content/IMG/yellow-dot.png");
    }

    marker.addListener("click", () => {
        AddInfoWindow(location, idCuadrilla, id, estado, difHoras, observaciones);
        if (actualInfoWindow != null) {
            actualInfoWindow.close();
        }
        infowindow.open({
            anchor: marker,
            map,
            shouldFocus: false,
        });
        actualInfoWindow = infowindow;
    });

    markers.push(marker);

}

function AddInfoWindow(location, idCuadrilla, id, estado, difHoras, observaciones) {
    contentString = '<h7 style= "font-weight: bold"> ID: </h7>' + id +
        '<h7 style= "font-weight: bold"> ID Cuadrilla: </h7>' + idCuadrilla +
        '<h7 style= "font-weight: bold"> Estado: </h7>' + estado +
        '<h7 style= "font-weight: bold"> Observaciones: </h7>' + observaciones +
        '<h7 style= "font-weight: bold"> Diferencia en Horas: </h7>' + difHoras;
                    
    infowindow = new google.maps.InfoWindow({
        content: contentString,
        position: location
    });
}