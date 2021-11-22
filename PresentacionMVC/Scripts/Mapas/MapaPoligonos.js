window.onload = load;

function load() {
    x();
}

function x() {
    //alert("testing");
    Mapatest();
}

// ---------------------------------------------------------MAPA AGREGAR PUNTOS PARA ZONA----------------------------------------------------------------------------

var lat = 0;
var lng = 0;
var markers = [];
var uniqueId = 1;
var arrayPuntosGPS = [];

function Mapatest() {
    var mapOptions = {
        center: new google.maps.LatLng(39.79734421136086, -4.026510988152807),
        zoom: 7,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    var map = new google.maps.Map(document.getElementById("dvMap"), mapOptions);

    //Attach click event handler to the map.
    google.maps.event.addListener(map, 'click', function (e) {

        //Determine the location where the user has clicked.
        var location = e.latLng;

        arrayPuntosGPS.push(location.lat());
        arrayPuntosGPS.push(location.lng());

        document.getElementById("color").value = document.getElementById("colorElegido").value;

        //Create a marker and placed it on the map.
        var marker = new google.maps.Marker({
            position: location,
            map: map
        });

        if (arrayPuntosGPS.length >= 6)
            initMap(arrayPuntosGPS);

        //Set unique id
        marker.id = uniqueId;
        uniqueId++;

        //Attach click event handler to the marker.
        google.maps.event.addListener(marker, "click", function (e) {
            var lat = location.lat();
            var lng = location.lng();

            var content = 'Latitude: ' + location.lat() + '<br />Longitude: ' + location.lng();
            var infoWindow = new google.maps.InfoWindow({
                content: content
            });
            infoWindow.open(map, marker);
        });

        //Add marker to the array.
        markers.push(marker);
    });
};

function cargarColor() {
    document.getElementById("color").value = document.getElementById("colorElegido").value;
    colorDePoligono = document.getElementById("colorElegido").value;
}
var colorDePoligono = "#000000";

// ---------------------------------------------------------MAPA ZONA----------------------------------------------------------------------------
var zona = 1;
var puntosAjax = [];

function initMap(puntosArray) {
    const map = new google.maps.Map(document.getElementById("dvMapZona"), {
        zoom: 7,
        center: { lat: 39.797, lng: -4.026 },
    });


    const outerCoords = [];

    for (var i = 0; i < arrayPuntosGPS.length; i++) {
        outerCoords.push({ lat: puntosArray[i], lng: puntosArray[i + 1] },)
        i++;
    }
    puntosAjax = outerCoords;
    /*
    const outerCoords = [
        { lat: -32.364, lng: 153.207 },
        { lat: -35.364, lng: 153.207 },
        { lat: -35.364, lng: 158.207 },
        { lat: -32.364, lng: 158.207 },
    ];
    */
    map.data.add({
        geometry: new google.maps.Data.Polygon([
            outerCoords
        ]),
    });



    const zona = new google.maps.Polygon({
        paths: outerCoords,
        strokeColor: colorDePoligono,
        strokeOpacity: 0.8,
        strokeWeight: 2,
        fillColor: colorDePoligono,
        fillOpacity: 0.35,
    });
    zona.setMap(map);

    google.maps.event.addListener(map, "click", (e) => {
        const adentro = google.maps.geometry.poly.containsLocation(
            e.latLng,
            zona
        )
            ? console.log("Si")
            : console.log("No")
    });

}


function MandarValoresAjax() {
    var x = "testing"

    var listaLat = [];
    var listaLng = [];
    var listaFinal = []

    for (var i = 0; i < puntosAjax.length; i++) {
        listaLat.push(puntosAjax[i].lat);
    };

    for (var i = 0; i < puntosAjax.length; i++) {
        listaLng.push(puntosAjax[i].lng);
    };

    for (var i = 0; i < listaLng.length; i++) {
        listaFinal.push(listaLat[i]);
        listaFinal.push(listaLng[i]);
    }

    var nombreZona = document.getElementById("nombre").value
    var colorZona = document.getElementById("colorElegido").value

    var json = { color: colorZona, nombre: nombreZona, ListaPuntos: listaFinal };

    ValidacionesBasicas(listaFinal);

    if (erroresDeValidacion == false) {
        $("#erroresDiv").html("")
        $("#successDiv").html("Zona registrada");
        $.ajax({
            url: 'AgregarNuevaZona',
            type: 'POST',
            data: json,
            success: function (result) {
            }
        });
    }

}



var erroresDeValidacion = false;
function ValidacionesBasicas(listaFinal) //Validaciones basicas hechas en javascript (las MVC/C# no sirven con ajax)
{
    erroresDeValidacion = false;
    if (document.getElementById("nombre").value == "") {
        $("#erroresDiv").html("Nombre requerido");
        erroresDeValidacion = true;
    }
    else if (document.getElementById("nombre").value.length > 25) {
        $("#erroresDiv").html("Nombre no puede tener mas de 25 caracteres");
        erroresDeValidacion = true;
    }
    else if (listaFinal.length < 3) {
        $("#erroresDiv").html("En necesario que marque minimo 3 puntos en el mapa");
        erroresDeValidacion = true;
    }
}
