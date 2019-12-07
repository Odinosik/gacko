$(document).ready(function () {

    $('#notification').popover({
        html: true,
        content: function () {
            return $('.not').html();
        },
        title: $('#notification').attr("popover-title")
    })


})