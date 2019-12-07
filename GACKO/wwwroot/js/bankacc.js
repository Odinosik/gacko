$(".toggle").on("click", function () {
    $(".newbankacc-container")
        .stop()
        .addClass("active");
});

$(".close").on("click", function () {
    $(".newbankacc-container")
        .stop()
        .removeClass("active");
});
