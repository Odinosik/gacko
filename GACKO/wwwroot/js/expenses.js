$(document).ready(function () {
    $(function () {
        $("table tr td")
            .find("div")
            .hide();
        $("table").click(function (event) {
            event.stopPropagation();
            var $target = $(event.target);
            /*    if ( $target.closest("td").attr("colspan") > 1 ) {
                  $target.closest("div.expand").slideUp();
              } else { */
            $target
                .closest("tr")
                .next()
                .find("div")
                .slideToggle();
            /*  }   */
        });
    });
});
