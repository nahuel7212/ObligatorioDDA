window.onload = load;

function load() {
    LogicaMapa();
}

function LogicaMapa() {
    ConseguirValoresAjax();
}

// ---------------------------------------------------------MAPA AGREGAR PUNTOS VALIDANDO ZONA----------------------------------------------------------------------------
var markerUsed = 0;
var lat = 0;
var lng = 0;
var entro = false;

var markers = [];
var uniqueId = 1;

function ValoresMapa(outerCoords) {
    markerUsed = 0;
    var q = 0;
    var x = "x";

    const map = new google.maps.Map(document.getElementById("dvMap"), {
        zoom: 7,
        center: new google.maps.LatLng(-0.023559, 37.906193),
    });
    // Define the LatLng coordinates for the outer path.
    const aux = [];

    //var auxNumeroColor = numerosDeZonas[0];

    //var w = 0;
    for (var i = 0; i < outerCoords.length; i++) {

        var auxNumeroZona = numerosDeZonas[i]

        //if (auxNumeroColor != auxNumeroZona) {
        //    w += 1;
        //    auxNumeroColor = auxNumeroZona
        //}

        var testingZ = outerCoords[i];

        const zona = new google.maps.Polygon({
            paths: testingZ, map: map, clickable: false, strokeOpacity: 0.8, strokeWeight: 2, fillColor: 1, fillOpacity: 0.50,
        });

        google.maps.event.addListener(map, "click", (e) => {
            const adentro = google.maps.geometry.poly.containsLocation(
                e.latLng,
                zona,
            )
                ? x = zona
                : console.log("Afuera")
            if (x == zona && entro == false) {
                var vertices = adentro.getPath();
                var xy = vertices.getAt(0);
                var r = xy.lat()
                document.getElementById("latitudZonaAdentro").value = r;
                entro = true;
            }

            if (markerUsed == "0" && document.getElementById("latitudZonaAdentro").value != "") {
                //Determine the location where the user has clicked.
                var location = e.latLng;

                document.getElementById("campoLatitud").value = location.lat();
                document.getElementById("campoLongitud").value = location.lng();

                //Create a marker and placed it on the map.
                const marker = new google.maps.Marker({
                    position: location,
                    map: map,
                });

                google.maps.event.addListener(marker, "click", function (e) {
                    var content = "<input type = 'button' va;ue = 'Delete' onclick = 'DeleteMarker(" + marker.id + ");' value = 'Delete' />";
                    var infoWindow = new google.maps.InfoWindow({
                        content: "<p>Latitud: " + location.lat() + "</p>" + "<p>Longitud: " + location.lng() + "</p>" + content
                    });
                    infoWindow.open(map, marker);
                });

                markers.push(marker);

                markerUsed = 1;
            }
        });
    }
};

function DeleteMarker(id) {
    //Find and remove the marker from the Array
    for (var i = 0; i < markers.length; i++) {
        if (markers[i].id == id) {
            //Remove the marker from Map                  
            markers[i].setMap(null);

            //Remove the marker from array.
            markers.splice(i, 1);

            markerUsed = 0;
            entro = false;
            document.getElementById("campoLatitud").value = "";
            document.getElementById("campoLongitud").value = "";
            document.getElementById("latitudZonaAdentro").value = "";
            ConseguirValoresAjax();

            return;
        }
    }
};

// ---------------------------------------------------------VALORES ZONA----------------------------------------------------------------------------

var coloresZona = [];
var numerosDeZonas = [];

function ConseguirValoresAjax() {
    var arrayListWithinList = [];
    var arrayList = [];
    var t1 = 0;
    var t2 = 0;
    $.ajax({
        url: 'CargarMapaZona',
        type: 'GET',
        success: function (result) {

            var auxNumeroZona = result[0].NumeroZona

            for (var i = 0; i < result.length; i++) {

                while (auxNumeroZona == result[i].NumeroZona) {
                    t1 = 0;
                    t2 = 0;

                    if (result[i] != null) {
                        t1 = parseFloat(result[i].Latitud);
                        t2 = parseFloat(result[i].Longitud);
                        const array1 = { lat: t1, lng: t2 };
                        arrayList.push(array1)
                    }

                    if (i == result.length)
                        break;
                    else if (i + 1 >= result.length)
                        break;
                    else
                        i++;
                }
                arrayListWithinList.push(arrayList);
                arrayList = [];
                numerosDeZonas.push(auxNumeroZona);
                auxNumeroZona = result[i].numeroZona;
                if (i + 2 == result.length)
                    break;
                else if (i != result.length - 1)
                    i--;
            }
            ValoresMapa(arrayListWithinList);
        }
    });
}
