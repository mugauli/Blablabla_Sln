var idEscuela = $("#ddListEscuelas option:selected").val();
var initDate = '01/01/2017';
var endDate = '31/03/2017';


$(document).ready(function () {    
    $("#filterAply").click(function () {
        GetResults($("#ddListEscuelas option:selected").val(), $("#group option:selected").val(), initDate, endDate);
    });


    //Listener Filtro Escuelas
    $("#ddListEscuelas").change(function () {
        idEscuela = $("#ddListEscuelas option:selected").val();
        GetGruops(idEscuela);
    });

    //Listener Filtro Fechas
    $('#reportrange').on('apply.daterangepicker', function (ev, picker) {
        initDate = picker.startDate.format('DD/MM/YYYY');
        endDate = picker.endDate.format('DD/MM/YYYY');
    });

    GetGruops($("#ddListEscuelas option:selected").val());
    
});

function GetGruops(escuelaID) {
    try {
        
        console.log("obteniendo resultados..");
        $.ajax({
            type: 'POST',
            async: false,
            url: './PorGrupo.aspx/GetGruposByEscuela',
            data: '{idEscuela:"' + escuelaID + '"}',
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (response) {
                console.log("success GetGruops");
                Obj = response;
                var res = parseJSON(Obj.d);
                if (res.Code != 0) {
                    alert("Error:" + r.Message);
                } else {
                    $('#group').empty();
                    res.Result.grupos.forEach(function (arrayItem) {
                        $('#group').append($('<option>', {
                            value: arrayItem,
                            text: arrayItem
                        }));
                    });


                    //Se obtienen los resultados
                    if ($("#group option:selected").val().length <= 3)//validación cuando no se tengan grupos disponibles
                        GetResults($("#ddListEscuelas option:selected").val(), $("#group option:selected").val(), initDate, endDate);
                }
            },
            error: function (xhr, ajaxOptions, thrownError) {
                console.log(thrownError);
            }
        });
    } catch (err) {
        alert("Error al cargar grupos:" + err.message);
    }
}

function GetResults(escuelaID, gradoGrupo, fechaIni, fechaFin) {
    try {
        console.log("obteniendo resultados..");
        debugger;
        $.ajax({
            type: 'POST',
            async: false,
            url: './PorGrupo.aspx/ResultadosPor_EscuelaGrado',
            data: '{idEscuela:"' + escuelaID + '" , gradoGrupo:"' + gradoGrupo + '",fechaIni:"' + fechaIni + '",fechaFin:"' + fechaFin + '"}',
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (response) {
                console.log("success");
                Obj = response;
                var r = parseJSON(Obj.d);
                console.log(r);
                if (r.success == true) {
                    debugger;

                    loadChart(r.periodos, r.aciertos, r.errores);

                    $("#tblPorGrupoResults tr.result").remove();
                    var filas = r.result.length;

                    for (i = 0; i < filas; i++) { //cuenta la cantidad de registros
                        var nuevafila = "<tr class='result'><td>" +
                            r.result[i].Grado + "</td><td>" +
                            (r.result[i].Masculino + r.result[i].Femenino) + "</td><td>" +
                            r.result[i].Masculino + "</td><td>" +
                            r.result[i].Femenino + "</td><td>" +
                            r.result[i].SemanaMes + "</td><td>" +
                            r.result[i].Juego + "</td><td>" +
                            r.result[i].Nivel + "</td><td>" +
                            r.result[i].PromedioAciertos + "</td><td>" +
                            r.result[i].PromedioAciertos + "</td><td>" +
                            r.result[i].PromedioErrores + "</td><td>" +
                            r.result[i].PromedioErrores + "</td><td>" ;

                        $("#tblPorGrupoResults").append(nuevafila)
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

function loadChart(labels_, aciertos_, errores_) {
    debugger;
    var lineChartData = {
        labels: labels_,
        datasets: [{
            label: "Aciertos",
            borderColor: "rgba(255, 0, 229, 0.38)",
            backgroundColor: "rgba(255, 0, 229, 0.38)",
            fill: false,
            data: aciertos_,
            yAxisID: "y-axis-1",
        }, {
            label: "Errores",
            borderColor: "rgba(4, 156, 206, 0.38)",
            backgroundColor: "rgba(4, 156, 206, 0.38)",
            fill: false,
            data: errores_,
            yAxisID: "y-axis-2"
        }]
    };

    var ctx = document.getElementById("canvas").getContext("2d");
    window.myLine = Chart.Line(ctx, {
        data: lineChartData,
        options: {
            responsive: true,
            hoverMode: 'index',
            stacked: false,
            title: {
                display: true,
                text: 'Resultados'
            },
            scales: {
                yAxes: [{
                    type: "linear",
                    display: true,
                    position: "left",
                    id: "y-axis-1",
                }, {
                    type: "linear",
                    display: true,
                    position: "right",
                    id: "y-axis-2",

                    gridLines: {
                        drawOnChartArea: false,
                    },
                }],
            }
        }
    });

    //DRAW
    window.myLine.update();
}

function parseJSON(data) {
    return window.JSON && window.JSON.parse ? window.JSON.parse(data) : (new Function("return " + data))();
}