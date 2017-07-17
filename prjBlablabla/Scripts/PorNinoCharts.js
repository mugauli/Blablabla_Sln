$(document).ready(function () {

    var idEscuela = 0;
    var idJuego = 0;
    var idNivel = 0;
    var initDate = "";
    var endDate = "";

    var chartlabels = ["1/1", "2/1", "1/2", "2/2", "1/3", "2/3", "1/4"];
    var aciertos = [70, 60, 50, 40, 30, 20, 10];
    var errores = [1, 2, 3, 4, 5, 6, 7];

    $("#filterAply").click(function () {
        
        GetResults(idEscuela, $("#group option:selected").val(),idJuego, idNivel, initDate, endDate);
    });


    //Listener Filtro Escuelas
    $("#ddListEscuelas").change(function () {
        idEscuela = $("#ddListEscuelas option:selected").val();
        GetGruops(idEscuela);
    });

    //Listener Filtro Escuelas
    $("#game").change(function () {
        idJuego = $("#game option:selected").val();
    });

    //Listener Filtro Escuelas
    $("#level").change(function () {
        idNivel = $("#level option:selected").val();
    });

    //Listener Filtro Fechas
    $('#reportrange').on('apply.daterangepicker', function (ev, picker) {
        //initDate = picker.startDate.format('DD/MM/YYYY');
        //endDate = picker.endDate.format('DD/MM/YYYY');

        initDate = '01/01/2017';
        endDate = '31/03/2017';
    });

    GetGruops($("#ddListEscuelas option:selected").val());


    //loadChart(chartlabels, aciertos, errores);
});

function GetGruops(escuelaID) {
    try {
        console.log("obteniendo resultados.." + escuelaID);
        $.ajax({
            type: 'POST',
            async: false,
            url: './PorNino.aspx/GetGruposByEscuela',
            data: '{idEscuela:"' + escuelaID+'"}',
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (response) {
                console.log("success");
                Obj = response;
                var r = parseJSON(Obj.d);                
                if (r.success == true) {
                    $('#group').empty();
                    r.grupos.forEach(function (arrayItem) {
                        $('#group').append($('<option>', {
                            value: arrayItem,
                            text: arrayItem
                        }));
                    });
                } else
                    alert("Error al cargar grupos:" + r.grupos[0]);


            },
            error: function (xhr, ajaxOptions, thrownError) {
                console.log(thrownError);
            }
        });
    } catch (err) {
        alert("Error al cargar grupos:" + err.message);
    }
}

function GetResults(escuelaID, gradoGrupo, juegoId, nivelID, fechaIni, fechaFin) {
    try {
        console.log("obteniendo resultados..");
        console.log(escuelaID + "-" + gradoGrupo + "-"+juegoId + "-"+nivelID + "-"+fechaIni + "-"+fechaFin + "-");
        $.ajax({
            type: 'POST',
            async: false,
            url: './PorNino.aspx/GetNinoRes_By_EscuelaJuegoNivelGrupo',
            data: '{idEscuela:"' + escuelaID + '" , gradoGrupo:"' + gradoGrupo+ '" , juego:"' + juegoId + '" , nivel:"' + nivelID + '",fechaIni:"' + fechaIni + '",fechaFin:"' + fechaFin + '"}',
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (response) {
                console.log("success");
                Obj = response;
                var r = parseJSON(Obj.d);
                console.log(r);
                if (r.success == true) {
                    debugger;
                    $("#tblPorNinoResults tr.result").remove();
                    var filas = r.result.length;

                    for (i = 0; i < filas; i++) { //cuenta la cantidad de registros
                        var nuevafila = "<tr><td>" +
                            r.result[i].Grado + "</td><td>" +
                            r.result[i].Edad + "</td><td>" +
                            r.result[i].Sexo + "</td><td>" +
                            "Periodo" + "</td><td>" +
                            r.result[i].Juego + "</td><td>" +
                            r.result[i].Nivel + "</td><td>" +
                            r.result[i].TotalEnsayos + "</td><td>" +
                            r.result[i].Aciertos_x100 + "</td><td>" +
                            r.result[i].Errores_x100 + "</td><td>" +
                            r.result[i].Teimpo_reaccion + "</td><td>" +
                            100 + "</td><td>" +
                            1.2 + "</td></tr>";

                            $("#tblPorNinoResults").append(nuevafila)
                    }
                }


            },
            error: function (xhr, ajaxOptions, thrownError) {
                console.log(thrownError);
            }
        });
    } catch (err) {
        alert("Error solicitar captcha:" + err.message);
    }
}

function parseJSON(data) {
    return window.JSON && window.JSON.parse ? window.JSON.parse(data) : (new Function("return " + data))();
}