
$(document).ready(function () {

    $("#addModalbtn").click(function () {
        $("#addEscuela").modal("show");
    });

    $("#GuardarProyecto").click(function () {
        $("#frIdEmpresa").val($("#sltEmpresa").val());

        //alert($("#fnGuardarProyecto").serialize());

        if (validarGuardarEscuela()) {

            $.ajax({
                type: 'POST',
                url: '/Gestion/GuardarProyecto',
                data: $("#fnGuardarProyecto").serialize(),
                success: function (response) {
                    if (response.success) {
                        limpiarModal();
                        table.draw();
                        $("#addProyecto").modal("hide");
                    }
                    else
                        alert(response.message);
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    var mensaje = 'Error al guardar asignación:' + thrownError;
                    alert(mensaje);
                }
            });
        }

        var validarGuardarEscuela = function () {

            var correcto = true;

            if ($("#Nombre").val() == '') {
                $("#fnEscuela .errorMsg").html('Debe agregar un nombre válido.');
               
                correcto = false;
            } else {
                $("#fnCostoMoneda .errorMsg").html('');
                $("#Costo").removeClass("inputError");
            }

            if ($("#Direccion").val() == '') {
                $("#fnEscuela .errorMsg2").html("Debe agregar una dirección válida.");
                $("#CantidadFacturas").addClass("inputError");
                correcto = false;
            } else {
                $("#fnEscuela .errorMsg2").html('');
                $("#CantidadFacturas").removeClass("inputError");
            }

           

            return correcto;

        }
    });

    $(".csBtnBorrarEscuela").on("click", function () {
        $("#IdEscuelaBorrar").val($(this).data("id"));
    });

    $(".csBtnEditarEscuela").on("click", function () {
        $("#IdEscuela").val($(this).data("id"));
        $("#nombre").val($(this).data("nombre"));
        $("#direccion").val($(this).data("direccion"));
    });

    $(".csBtnGrupos").on("click", function () {
        $("#IdEscuela").val($(this).data("id"));
        location.href = "/Grupos.aspx?idEscuela=" + $(this).data("id");
    });
});