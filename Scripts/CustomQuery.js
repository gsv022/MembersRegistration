$(function () {
    var $rows = $('#myTable tr').slice(1);
    $('#myInput').keyup(function ()
    {
        var val = $.trim($(this).val()).replace(/ +/g, ' ').toLowerCase();
        $rows.show().filter(function ()
        {
            var text = $(this).text().replace(/\s+/g, ' ').toLowerCase();
            return !~text.indexOf(val);
        }).hide();
    });
}); $(function () {
    $(".checkbox").click(function () {
        $('.delete').prop('disabled', $('input.checkbox:checked').length == 0);
    });
});
var applicationIds = new Array(); $(function () {
    $("#btn-approve").on("click", function () {
        $("input:checkbox").each(function () {
            if ($(this).is(":checked")) {
                applicationIds.push($(this).attr("value"));
            }
        }); $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/ProfileCreations/Post",
            data: JSON.stringify({ 'applicationIds': applicationIds }),
            dataType: "json",
            success: function (data) {
                alert("The selected applications are approved");
            },
            error: function (xhr, err) {
                alert(err);
            }
        })
    });
});

