

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
        GetResults(idEscuela, idJuego, idNivel, initDate, endDate); 
    });


    //Listener Filtro Escuelas
    $("#ddListEscuelas").change(function () {
        idEscuela = $("#ddListEscuelas option:selected").val();
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



    //loadChart(chartlabels, aciertos, errores);
});


function GetResults(escuelaID, juegoId, nivelID, fechaIni, fechaFin) {
    try {
        console.log("obteniendo resultados..");
        $.ajax({
            type: 'POST',
            async: false,
            url: './index.aspx/GetEscuelaRes_By_EscuelaJuegoNivel',
            data: '{idEscuela:"' + escuelaID + '" , idJuego:"' + juegoId + '" , nivel:"' + nivelID + '",fechaIni:"' + fechaIni + '",fechaFin:"' + fechaFin + '"}',
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
                title:{
                    display: true,
                    text:'Resultados'
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