function CalculoPrecioTotal() {
    var RemitenteId = document.getElementById("RemitenteId").value;
    var ClienteDestinatarioId = document.getElementById("ClienteDestinatarioId").value;
    var Latitud = document.getElementById("campoLatitud").value;
    var Longitud = document.getElementById("campoLongitud").value;
    var PesoTotal = document.getElementById("PesoTotal").value;

    var datosEnvio = { RemitenteId: RemitenteId, ClienteDestinatarioId: ClienteDestinatarioId, PesoTotal: PesoTotal, Latitud: Latitud, Longitud: Longitud }

    if (RemitenteId == "" || ClienteDestinatarioId == "" || PesoTotal == "") {
        $("#errorCalculoPrecioTotal").html("Se necesita el remitente, destinatario y peso total para calcular el precio total")
    }
    else {
        $("#errorCalculoPrecioTotal").html("");
        $.ajax({
            url: 'GetPrecioTotal',
            type: 'POST',
            data: datosEnvio,
            success: function (result) {
                if (result == 0) {
                    document.getElementById("precioTotal").value = "Datos erroneos";
                }
                else {
                    document.getElementById("precioTotal").value = result;
                }
            }
        });
    }
}