function CalculoPrecioTotal() {
    var ClienteDestinatarioId = document.getElementById("ClienteDestinatarioId").value;
    var Latitud = document.getElementById("campoLatitud").value;
    var Longitud = document.getElementById("campoLongitud").value;
    var PesoTotal = document.getElementById("PesoTotal").value;

    var datosEnvio = { ClienteDestinatarioId: ClienteDestinatarioId, PesoTotal: PesoTotal, Latitud: Latitud, Longitud: Longitud }

    if (ClienteDestinatarioId == "" || PesoTotal == "") {
        $("#errorCalculoPrecioTotal").html("Se necesita el destinatario, remitente y peso total para calcular el precio total")
    }
    else {
        $("#errorCalculoPrecioTotal").html("");
        $.ajax({
            url: 'GetPrecioTotal',
            type: 'POST',
            data: datosEnvio,
            success: function (result) {
                document.getElementById("precioTotal").value = result;
            }
        });
    }
}