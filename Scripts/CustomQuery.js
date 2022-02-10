$(document).ready(function () {
    var $rows = $('#myTable tr');

    $('#myInput').keyup(function () {
        var val = $.trim($(this).val()).replace(/ +/g, ' ').toLowerCase();

        $rows.show().filter(function () {
            var text = $(this).text().replace(/\s+/g, ' ').toLowerCase();
            return !~text.indexOf(val);
        }).hide();
    });



});

$(function () {
    $(".checkbox").click(function () {
        $('.delete').prop('disabled', $('input.checkbox:checked').length == 0);
    });
});



