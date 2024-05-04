$("body").on("click", "#btnSaveRFQ", function () {
    //Loop through the Table rows and build a JSON array.
    var DocumentNo = $("#bidnumber").val();
    var financials = new Array();
    $("#tbl_bidpricing_details TBODY TR").each(function () {
        var row = $(this);
        var finance = {};
        finance.billNo = row.find('td:eq(2)').text().trim();
        finance.price = row.find("TD input").eq(0).val();
        //finance.quantity = row.find("TD input").eq(0).val();
        finance.documentNo = DocumentNo;
        financials.push(finance);
    });
    console.log(JSON.stringify(financials))
    Swal.fire({
        title: "Confirm Financial Response Submission?",
        text: "Are you sure you would like to proceed with submission?",
        type: "warning",
        showCancelButton: true,
        closeOnConfirm: true,
        confirmButtonText: "Yes, Proceed!",
        confirmButtonClass: "btn-success",
        confirmButtonColor: "#008000",
        position: "center"
    }).then((result) => {
        if (result.value) {
            $.ajax({
                type: "POST",
                url: "/Home/RFQFinancialResponse",
                data: '{finance: ' + JSON.stringify(financials) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                cache: false,
                processData: false
            }).done(function (status) {
                switch (status) {
                    case "success":
                        Swal.fire
                           ({
                               title: "Financial Response Details Submitted!",
                               text: "Your Financials Details were successfully submitted.",
                               type: "success"
                           }).then(() => {
                               $("#feedback1").css("display", "block");
                               $("#feedback1").css("color", "green");
                               $('#feedback1').attr("class", "alert alert-success");
                               $("#feedback1").html("Your Financials Details were successfully submitted");
                               //location.reload(true);
                           });
                        break;
                    default:
                        Swal.fire
                                ({
                                    title: "Financial Response Error!!!",
                                    text: "Error Occured when submmitting your financial response.Kindly Try Again",
                                    type: "error"
                                }).then(() => {
                                    $("#feedback1").css("display", "block");
                                    $("#feedback1").css("color", "red");
                                    $('#feedback1').addClass('alert alert-danger');
                                    $("#feedback1").html(status.d);
                                });
                        break;
                }

            });
        }
    });
});
function showDiv(divId, element) {
    document.getElementById(divId).style.display = element.value == "1" ? 'block' : 'none';
}