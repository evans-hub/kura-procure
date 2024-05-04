$(document).ready(function () {
     $(".btnDownloadTender").click(function (event) {
        event.preventDefault();
        //reset to empty
        $("#openTenderfeedback").html("");
        //Set data to be sent    
        var tendNo = $(this).attr("tenderNo");
        var data = { "rfiNumber": tendNo }
        //Swal Message
        Swal.fire({
            title: "Confirm Tender Document Download?",
            text: "Are you sure you would like to proceed with Tender Document Download?",
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
                    url: "/Home/CheckTenderDocumentOnSharepoint",
                    type: "POST",
                    data: JSON.stringify(data),
                    dataType: "json",
                    contentType: "application/json"
                }).done(function (status) {
                    switch (status) {
                        case "filefound":
                            $("#openTenderfeedback").css("display", "block");
                            $("#openTenderfeedback").css("color", "green");
                            $('#openTenderfeedback').attr('class', 'alert alert-success');
                            $("#openTenderfeedback").html("Tender Document Downloaded successfully!");
                            break;
                        case "filenotfound":
                            Swal.fire
                            ({
                                title: "The Tender Document File Download Error!",
                                text: "The Tender Document could not be found.Kindly Contact the KeRRA for more Enquiries!",
                                type: "error"
                            }).then(() => {
                                $("#openTenderfeedback").css("display", "block");
                                $("#openTenderfeedback").css("color", "red");
                                $('#openTenderfeedback').attr('class', 'alert alert-danger');
                                $("#openTenderfeedback").html("The Document you are trying to download is not Availlable.Kindly Contact KeRRA for More Details!");
                            });
                            break;

                    }
                });
            }
        });
     });
     $(".btnDownloadVendorDocuments").click(function (event) {
         event.preventDefault();

        Swal.fire({
            title: "Confirm Document Download?",
            text: "Are you sure you would like to proceed with Documents Download?",
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
                    url: "/Home/DownloadDocumentFrmDocumentLibrary",
                    type: "POST",
                    data: JSON.stringify(data),
                    dataType: "json",
                    contentType: "application/json"
                }).done(function (status) {
                    switch (status) {
                        case "filefound":
                            Swal.fire
                             ({
                                 title: "Document Downloaded Successfully!",
                                 text: "File Uploaded Successfully!",
                                 type: "success"
                             }).then(() => {
                                 $("#openTenderfeedback").css("display", "block");
                                 $("#openTenderfeedback").css("color", "green");
                                 $('#openTenderfeedback').attr('class', 'alert alert-success');
                                 $("#openTenderfeedback").html("Tender Document Downloaded successfully!");
                             });
                            break;
                        case "filenotfound":
                            Swal.fire
                            ({
                                title: "The Document File Download Error!",
                                text: "The  Document could not be found.Kindly Contact the KeRRA for more Enquiries!",
                                type: "error"
                            }).then(() => {
                                $("#openTenderfeedback").css("display", "block");
                                $("#openTenderfeedback").css("color", "red");
                                $('#openTenderfeedback').attr('class', 'alert alert-danger');
                                $("#openTenderfeedback").html("The Document you are trying to download is not Availlable.Kindly Contact KeRRA for More Details!");
                            });
                            break;
                        case "download_danger":
                            Swal.fire
                            ({
                                title: "Sharepoint Server Connection Error!",
                                text: "The Connection to Sharepoint Server could not be established.Kindly Contact the KeRRA for more Enquiries!",
                                type: "error"
                            }).then(() => {
                                $("#openTenderfeedback").css("display", "block");
                                $("#openTenderfeedback").css("color", "red");
                                $('#openTenderfeedback').attr('class', 'alert alert-danger');
                                $("#openTenderfeedback").html("The Document you are trying to download is not Availlable.Kindly Contact KeRRA for More Details!");
                            });
                            break;
                        default:
                            Swal.fire
                            ({
                                title: "Document Download Error!!!",
                                text: uploadsfs[1],
                                type: "error"
                            }).then(() => {
                                $("#keydocumentsuploadfeedback").css("display", "block");
                                $("#keydocumentsuploadfeedback").css("color", "red");
                                $('#keydocumentsuploadfeedback').addClass('alert alert-danger');
                            });
                            break;
                    }
                });
            }
        });
       });
    });