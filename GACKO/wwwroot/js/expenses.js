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

function addexpense() {
    var url = "/VirtualAccount/Expense/Create";

    $.post(url, {
        VirtualAccountId: document.getElementById("addexpense-virtualaccid").value,
        Name: document.getElementById("addexpense-name").value,
        Amount: document.getElementById("addexpense-amount").value,
        ExpenseCategory: document.getElementById("addexpense-category").value,
        ExpenseDate: document.getElementById("addexpense-date").value
    })
        .done(function (response) {
            $("#expense-list").html(response);
        });
};