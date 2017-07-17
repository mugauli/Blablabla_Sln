
$(document).ready(function () {

    $('#gamesList li').on('click', function () {
        $('#gameId').val($(this).text());
    });

    $('#levelList li').on('click', function () {
        $('#levelId').val($(this).text());
    });
});