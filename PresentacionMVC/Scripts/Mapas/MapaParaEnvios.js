window.onload = load;

function load() {
    x();
}

function x() {
    //alert("testing"); 
    ConseguirValoresAjax();
}

// ---------------------------------------------------------MAPA AGREGAR PUNTOS VALIDANDO ZONA----------------------------------------------------------------------------
var markerUsed = 0;
var lat = 0;
var lng = 0;
var entro = false;

var markers = [];
var uniqueId = 1;

function Mapatest(outerCoords) {
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

function cargarColor() {
    document.getElementById("color").value = document.getElementById("colorElegido").value;
    colorDePoligono = document.getElementById("colorElegido").value;
}
var colorDePoligono = "#000000";

// ---------------------------------------------------------VALORES ZONA----------------------------------------------------------------------------

var coloresZona = [];
var numerosDeZonas = [];

function ConseguirValoresAjax() {
    /*
    var arrayListWithinList = [];
    var arrayList = [];
    var t1 = 0;
    var t2 = 0;
    $.ajax({
        url: 'CargarMapaZona',
        type: 'GET',
        success: function (result) {

            var auxNumeroZona = result[0].numeroZona

            //var t = result[i].numeroZona;

            for (var i = 0; i < result.length; i++) {



                while (auxNumeroZona == result[i].numeroZona) {

                    if (result[i + 1] != null) {
                        t1 = parseFloat(result[i].puntosGPS);
                        t2 = parseFloat(result[i + 1].puntosGPS);
                        const array1 = { lat: t1, lng: t2 };
                        arrayList.push(array1)
                    }

                    t1 = 0;
                    t2 = 0;

                    if (i == result.length - 1)
                        break;
                    else if (i + 2 >= result.length - 1)
                        break;
                    else
                        i += 2;
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
            //colorZona(arrayListWithinList);
        }
    });
    */

    //Simular lo que vendria de base
    var arrayListWithinList = [];

    var obj1 = { lat: -0.2807705373192177, lng: 37.671588591460676 };
    var obj2 = { lat: -0.14893555582027945, lng: 39.495319060210676 };
    var obj3 = { lat: -1.0497558937240812, lng: 39.517291716460676 };
    var obj4 = { lat: -1.1815668096406249, lng: 37.759479216460676 };

    var arrayList = [];
    arrayList.push(obj1);
    arrayList.push(obj2);
    arrayList.push(obj3);
    arrayList.push(obj4);

    arrayListWithinList.push(arrayList);

    Mapatest(arrayListWithinList);
}


function colorZona(arrayListWithinList) {
    var json = { numeroZonaList: numerosDeZonas };

    $.ajax({
        url: 'ColorZona',
        type: 'POST',
        data: json,
        success: function (result) {
            var x = result;
            for (var i = 0; i < x.length; i++) {
                coloresZona.push(x[i]);
            }
            Mapatest(arrayListWithinList);

        }

    });
}
