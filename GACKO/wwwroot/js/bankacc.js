//$(".toggle").on("click", function () {
//    $(".newbankacc-container")
//        .stop()
//        .addClass("active");
//});

//$(".close").on("click", function () {
//    $(".newbankacc-container")
//        .stop()
//        .removeClass("active");
//});


$(".toggle").click(function(event) {
    $(`#${event.target.id}.editbankacc-container`)
        .stop()
        .addClass("active");
    $(`#${event.target.id}.newbankacc-container`)
        .stop()
        .addClass("active");
});

$(".close").click(function (event) {
    $(`#${event.target.id}.editbankacc-container`)
        .stop()
        .removeClass("active");
    $(`#${event.target.id}.newbankacc-container`)
        .stop()
        .removeClass("active");
});

$('input').inputfit();