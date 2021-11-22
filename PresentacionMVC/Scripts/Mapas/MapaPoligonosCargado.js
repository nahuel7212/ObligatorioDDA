window.onload = load;

function load() {
    x();
}

function x() {
    //alert("testing"); 
    ConseguirValoresAjax();
}

// ---------------------------------------------------------MAPA AGREGAR PUNTOS PARA ZONA----------------------------------------------------------------------------


function Mapatest(outerCoords) {
    const map = new google.maps.Map(document.getElementById("dvMapZona"), {
        zoom: 7,
        center: new google.maps.LatLng(39.79734421136086, -4.026510988152807),
    });
    // Define the LatLng coordinates for the outer path.
    const aux = [];

    var w = 0;
    var auxNumeroColor = numerosDeZonas[0];

    for (var i = 0; i < outerCoords.length; i++) {

        var auxNumeroZona = numerosDeZonas[i]

        if (auxNumeroColor != auxNumeroZona) {
            w += 1;
            auxNumeroColor = auxNumeroZona
        }

        var testingZ = outerCoords[i];
        map.data.add({
            geometry: new google.maps.Data.Polygon([
                testingZ
            ]),
        });
        const zona = new google.maps.Polygon({
            paths: outerCoords[i],
            strokeOpacity: 0.8,
            strokeWeight: 2,
            fillColor: coloresZona[w],
            fillOpacity: 0.50,
        });
        zona.setMap(map);
    }
};

function cargarColor() {
    document.getElementById("color").value = document.getElementById("colorElegido").value;
    colorDePoligono = document.getElementById("colorElegido").value;
}
var colorDePoligono = "#000000";

// ---------------------------------------------------------MAPA ZONA----------------------------------------------------------------------------

var coloresZona = [];
var numerosDeZonas = [];

function ConseguirValoresAjax() {
    var arrayListWithinList = [];
    var arrayList = [];
    var t1 = 0;
    var t2 = 0;

    $.ajax({
        url: 'CargarMapa',
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
            colorZona(arrayListWithinList);
        }
    });
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
