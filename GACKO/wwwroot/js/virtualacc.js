$(".toggle").on("click", function () {
    $(".newvirtualacc-container")
        .stop()
        .addClass("active");
});

$(".close").on("click", function () {
    $(".newvirtualacc-container")
        .stop()
        .removeClass("active");
});