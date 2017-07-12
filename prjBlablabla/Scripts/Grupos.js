
$(document).ready(function () {

    $("#addModalbtn").click(function () {
        $("#addGrupo").modal("show");
    });

    $(".csBtnBorrarGrupo").on("click", function () {
        $("#IdGrupoBorrar").val($(this).data("id"));
    });

    $(".csBtnEditarGrupo").on("click", function () {
        $("#IdGrupo").val($(this).data("id"));
        $("#nombre").val($(this).data("nombre"));
    });

});