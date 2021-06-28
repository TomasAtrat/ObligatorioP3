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
    const icon = "../../Content/IMG/outline_gps_fixed_black_24dp.png";
    const marker = new google.maps.Marker({
        position: location,
        icon: icon,
        draggable: true,
        map: map
    })
    markers.push(marker);
}

function drawPolygon() {
    locations = GetLocationsFromMarkers();
    const polygon = new google.maps.Polygon({
        path: locations,
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

function getZonas() {
    $.ajax({
        type: "GET",
        contentType: "application/json",
        url: "http://localhost:44383/Zona/getZonas",
        success: function (mensaje) {
            if (mensaje != null) {
                for (i in mensaje) {
                    for (j in i.colPuntos) {
                        let puntos = { lat: j.lat, lng: j.lng };
                        drawPolygon(puntos, i.color);
                    }
                }
            }
        },
        error: function (mensaje) {

        }
    })
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
                ListarParticipantes();
                $("#nombre").val("");
            },
            error: function (respuesta) {

            }
        })
  
    
}