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

function uploadfile(id) {
    var url = "/VirtualAccount/SalesDocument/Upload";
    var request = new FormData();
    request.append("fileForm", $(`#uploaddoc-fileform-${id}`).prop('files')[0]);
    request.append("expenseId", document.getElementById(`uploaddoc-expenseid-${id}`).value);
    request.append("fileName", document.getElementById(`uploaddoc-filename-${id}`).value);
    $.ajax({
        url: url,
        type: "POST",
        data: request,
        processData: false,
        contentType: false,
        success: function (response) {
            $("#expense-list").html(response);
            $("table tr td")
                .find("div")
                .hide();
        }
    });
};

function addsubscription() {
    var url = "/VirtualAccount/Subscription/Create";

    $.post(url, {
        VirtualAccountId: document.getElementById("addsubscription-virtualaccid").value,
        Name: document.getElementById("addsubscription-name").value,
        Amount: document.getElementById("addsubscription-amount").value,
        ExpirationDate: document.getElementById("addsubscription-expirationdate").value,
        FrequncyMonth: document.getElementById("addsubscription-frequncymonth").value
    })
        .done(function (response) {
            $("#subscription-list").html(response);
        });
};