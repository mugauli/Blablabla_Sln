
$(document).ready(function () {

    $('#gamesList li').on('click', function () {
        $('#gameId').val($(this).text());
        $('#hddGame').val($(this).data("id"));
    });

    $('#levelList li').on('click', function () {
        $('#levelId').val($(this).text());
    });
});