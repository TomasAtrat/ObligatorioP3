    window.onload = load;

    var map;
    var markers = [];
    var actualInfoWindow;

var infowindow;

    function load()
    {
      initMap();
        
    }

        var puntosCard = {
                          "lat": "",
                          "long":""
                         }

                        

   function Termico()
   {
       var Fechainicio = document.getElementById("iniciobusqueda").value;
       var FechaFin = document.getElementById("finBusqueda").value;
       $.ajax({
           type: "POST",
           data: Inicio = Fechainicio , Fin = FechaFin,
           contentType: "application/json",
           url: "http://localhost:60096/MapaTermico/ListPunto",
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




       function getPoints() {
           return [
               new google.maps.LatLng(37.782551, -122.445368)
           ];
               }

   }