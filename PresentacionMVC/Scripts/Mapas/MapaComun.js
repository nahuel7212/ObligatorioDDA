// <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCvMdxTAgkFIhI8MqCR8bE_CRHpNABl0L0&sensor=false"></script>


window.onload = load;

function load() {
    x();
}

function x() {
    //alert("testing");
    Mapatest();
}


var markerUsed = 0;
var lat = 0;
var lng = 0;


var markers = [];
var uniqueId = 1;

function Mapatest() {
    var mapOptions = {
        center: new google.maps.LatLng(39.79734421136086, -4.026510988152807),
        zoom: 7,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    var map = new google.maps.Map(document.getElementById("dvMap"), mapOptions);

    //Attach click event handler to the map.
    google.maps.event.addListener(map, 'click', function (e) {

        if (markerUsed == "0") {
            //Determine the location where the user has clicked.
            var location = e.latLng;

            document.getElementById("campoLatitud").value = location.lat();
            document.getElementById("campoLongitud").value = location.lng();

            //Create a marker and placed it on the map.
            var marker = new google.maps.Marker({
                position: location,
                map: map
            });

            //Set unique id
            marker.id = uniqueId;
            uniqueId++;

            //Add marker to the array.
            markers.push(marker);

            markerUsed = 1;


        }
    });
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

            document.getElementById("campoLatitud").value = "";
            document.getElementById("campoLongitud").value = "";
            return;
        }
    }
};


