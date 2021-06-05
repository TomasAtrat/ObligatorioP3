function initMap() {

    var ubicacion = { lat: 39.8568, lng: -4.02448 };

    map = new google.maps.Map(document.getElementById("map"), {
        center: ubicacion,
        zoom: 10,
        minZoom: 6,
    });
}