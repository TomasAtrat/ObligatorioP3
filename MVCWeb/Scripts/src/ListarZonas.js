window.onload = load;

function load() {
    getZonas();
}

function drawPolygons(path, color) {
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
                    drawPolygons(totalPuntos, mensaje[i].color);
                }
            }
        },
        error: function (mensaje) {
        }
    })
}