



    $(document).ready(function () {

        $(".nav-tabs a").click(function () {
            $(this).tab('show');
        });

        $('.nav-tabs a').on('shown.bs.tab', function (event) {
            var x = $(event.target).text();         // active tab
            var y = $(event.relatedTarget).text();  // previous tab
            $(".act span").text(x);
            $(".prev span").text(y);
        });

        $('#fraseComunesTable').DataTable({
            dom: "<'row itemHeader'<'col-sm-8'<'col-sm-12'l>><'col-sm-4'<'col-sm-12'f>>>rt<p>",
            language: {
                processing: "Procesando...",
                search: "Buscar",
                emptyTable: "No hay datos disponibles.",
                zeroRecords: "No hay coincidencias con la busqueda.",
                decimal: ".",
                lengthMenu: "_MENU_ ",
                paginate: {
                    first: "Primero",
                    previous: "Anterior",
                    next: "Siguiente",
                    last: "Último"
                }
            }
        });

        //$("#fraseComunesTable tbody tr").click(function () {
        //    $("#addFrase").modal("show");
        //});
        $(".csBtnEditarFrase").on("click", function () {
            $("#IdFrase").val($(this).data("id"));
            $("#enun1").val($(this).data("enun1"));
            $("#enun2").val($(this).data("enun2"));
            $("#correcta").val($(this).data("correcta"));
            $("#opcion1").val($(this).data("opcion1"));
            $("#opcion2").val($(this).data("opcion2"));
            $("#opcion3").val($(this).data("opcion3"));
        });

        $(".csBtnBorrarFrase").on("click", function () {
            $("#IdFraseBorrar").val($(this).data("id"));
            $("#TipoFraseBorrar").val($(this).data("tipo"));

        });
    });


    