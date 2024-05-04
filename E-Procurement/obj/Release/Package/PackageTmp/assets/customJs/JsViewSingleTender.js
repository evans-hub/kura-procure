'use-strict';
function DowndloadTenderDocument(filename) {
    var TenderObj = {
        "FileName": filename,
        "TenderNumber": $("#tendernoticeNumber").val()
    }
    console.log(JSON.stringify(TenderObj));
    Swal.fire({
        title: "Download Tender Documents",
        text: "Proceed to download the Tender document?",
        type: "warning",
        showCancelButton: true,
        closeOnConfirm: true,
        confirmButtonText: "Yes, Download!",
        confirmButtonClass: "btn-success",
        confirmButtonColor: "#008000",
        position: "center"
    }).then((result) => {
        if (result.value) {
            $.ajax({
                type: "POST",
                url: "/Home/DownloadTenderDocumentsfromSharepoint",               
                data: JSON.stringify(TenderObj),
                contentType: "application/json",
                cache: false,
                processData: false
            }).done(function (status) {
                var registerstatus = status.split('*');
                status = registerstatus[0];
                switch (status) {
                    case "success":
                        Swal.fire
                        ({
                            title: "Tender Files Downloaded!",
                            text: "Tender File Downloded Successfully!",
                            type: "success"
                        }).then(() => {
                            $("#keydocumentsuploadfeedback").css("display", "block");
                            $("#keydocumentsuploadfeedback").css("color", "green");
                            $('#keydocumentsuploadfeedback').attr("class", "alert alert-success");
                            $("#keydocumentsuploadfeedback").html("Selected Tender File has been Downloaded Successfully!");
                            $("#keydocumentsuploadfeedback").css("display", "block");
                            $("#keydocumentsuploadfeedback").css("color", "green");
                        });
                    default:
                        Swal.fire
                        ({
                            title: "Document Download Error!!!",
                            text: "The Document File could not be Downloaded.Kindly Try Again",
                            type: "error"
                        }).then(() => {
                            $("#keydocumentsuploadfeedback").css("display", "block");
                            $("#keydocumentsuploadfeedback").html("Selected Tender File has Could not be Downloaded Successfully!");
                            $("#keydocumentsuploadfeedback").css("color", "red");
                            $('#keydocumentsuploadfeedback').addClass('alert alert-danger');
                        });
                        break;
                }
            })
        }
        else if (result.dismiss === Swal.DismissReason.cancel) {
            Swal.fire(
                'Tender Document Download Cancelled',
                'You cancelled your documents download!',
                'error'
            );
        }
    });
}