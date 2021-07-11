window.onload = load;

var map;
var markers = [];
var actualInfoWindow;
var infowindow;
    
function load() {
    initMap();
    getReclamos();
    OpenLegend();
}

function OpenLegend() {
    const legend = document.getElementById("legend");
    legend.style = "font-family: Arial, sans - serif; background: #fff; padding: 10px; margin: 5px; border: 3px solid #000; width: 30%";
    const div = document.createElement("div");
    const div2 = document.createElement("div");
    const div3 = document.createElement("div");
    const title = document.createElement("div");
    title.innerHTML = "<h6> Retraso en horas </h6>";
    legend.appendChild(title);
    div.innerHTML = '<img src="../../Content/IMG/green-dot.png"> Menor o igual a 24';
    legend.appendChild(div);
    div2.innerHTML = '<img src="../../Content/IMG/yellow-dot.png"> Mayor a 24 y menor o igual a 32';
    legend.appendChild(div2);
    div3.innerHTML = '<img src="../../Content/IMG/red-dot.png"> Mayor a 32';
    legend.appendChild(div3);
    map.controls[google.maps.ControlPosition.RIGHT_TOP].push(legend);
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