var map, infoWindow;
var heatMapData = [];
var heatmap;
window.onload = load;

function load() {
    initMap();
    GetCurrentPosition()
}

function initMap() {

    var ubicacion = { lat: 39.8668777, lng: -4.0277369 };

    map = new google.maps.Map(document.getElementById("map"), {
        center: ubicacion,
        zoom: 14,
        minZoom: 23
        //mapTypeControl: true,
    });

    map.addListener("dblclick", (mapsMouseEvent) => {
        AddMarker(mapsMouseEvent.latLng.lat(), mapsMouseEvent.latLng.lng())
    });

    heatmap = new google.maps.visualization.HeatmapLayer({
        data: heatMapData,
        map:map,
    });

    DefMapTypes();
}

function DefMapTypes() {
    const Default = document.createElement("button");
    Default.textContent = "Mapa";
    Default.classList.add("custom-map-control-button");
    map.controls[google.maps.ControlPosition.TOP_LEFT].push(Default);
    Default.addEventListener("click", () => {
        map.setMapTypeId('roadmap');
    });

    const Satellite = document.createElement("button");
    Satellite.textContent = "Satélite";
    Satellite.classList.add("custom-map-control-button");
    map.controls[google.maps.ControlPosition.TOP_LEFT].push(Satellite);
    Satellite.addEventListener("click", () => {
        map.setMapTypeId('satellite');
        map.setTilt(45);
    });
}

function AddMarker(lat, longitud) {
    let ubicacion = { lat: lat, lng: longitud };
    let marcador = new google.maps.Marker({
        position: ubicacion,
        map:map,
    });
    heatmap.setMap(map);
    heatMapData.push(marcador.getPosition());

    marcador.addListener("rightclick", (mapsMouseEvent) => {
        marcador.setMap(null);
        heatMapData.splice(heatMapData.indexOf(marcador.getPosition()), 1);
        if (heatMapData.length == 0) {
            heatmap.setMap(null);
        }
    });
}

function GetCurrentPosition() {
    infoWindow = new google.maps.InfoWindow;
    const locationButton = document.createElement("button");
    locationButton.textContent = "Dar ubicación";
    locationButton.classList.add("custom-map-control-button");
    map.controls[google.maps.ControlPosition.TOP_CENTER].push(locationButton);
    locationButton.addEventListener("click", () => {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(
                (position) => {
                    const pos = { lat: position.coords.latitude, lng: position.coords.longitude, };
                    AddMarker(pos.lat, pos.lng);
                    infoWindow.setPosition(pos);
                    infoWindow.setContent("Location found.");
                    infoWindow.open(map);
                    map.setCenter(pos);
                },
                () => {
                    handleLocationError(true, infoWindow, map.getCenter());
                }
            );
        } else {
            // Browser doesn't support Geolocation
            handleLocationError(false, infoWindow, map.getCenter());
        }
    });
}

function handleLocationError(browserHasGeolocation, infoWindow, pos) {
    infoWindow.setPosition(pos);
    infoWindow.setContent(
        browserHasGeolocation
            ? "Error: The Geolocation service failed."
            : "Error: Your browser doesn't support geolocation."
    );
    infoWindow.open(map);
}







// Aparecer y desaparecer div's
function VerReclamos()
{

	document.getElementById("DivisarReclamos").style.display="block";
    document.getElementById("map").style.display="none";
    document.getElementById("tabla_de_Reclamos").style.display="none";
    

}

function AgregarReclamos_Div()
{
    document.getElementById("DivisarReclamos").style.display="none";
    document.getElementById("map").style.display="block";
    document.getElementById("tabla_de_Reclamos").style.display="block";
}


