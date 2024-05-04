'use-strict';
function TenderRespond(url, uniquetenderno) {
    var TenderNoticeNo = $('#tendernotice').val();
    Swal.fire({
        title: "Confirm Tender Response?",
        text: "Are you sure you would like to Respond to this Tender?",
        type: "warning",
        showCancelButton: true,
        closeOnConfirm: true,
        confirmButtonText: "Yes, Proceed!",
        confirmButtonClass: "btn-success",
        confirmButtonColor: "#008000",
        position: "center"
    }).then((result) => {
        console.log("Execute this?")
        $("#divLoader").show();
        console.log("How about this?")
        if (result.value) {
            $.ajax({
                cache: false,
                type: 'GET',
                url: url,
                cache: false,
                processData: false,
            }).done(function (status) {
                var tendersponse = status.split('*');
                status = tendersponse[0];
                switch (status) {                    
                    case "success":
                        $("#divLoader").hide();
                        Swal.fire
                       ({
                           title: "Tender Response has been created!",
                           text: "Submitting Tender Response,Kindly Wait!",
                           type: "success"
                       }).then(() => {
                           $("#responsesfeedback").css("display", "block");
                           $("#responsesfeedback").css("color", "green");
                           $('#responsesfeedback').attr("class", "alert alert-success");
                           $("#responsesfeedback").html("Tender Response has been created,Proceed and Fill in the details!");
                           $("#responsesfeedback").css("display", "block");
                           $("#responsesfeedback").css("color", "green");
                           $("#responsesfeedback").html("Tender Response has been created,Proceed and Fill in the details!");
                           window.location.href = "/Home/RespondTenderWizard?respondtendernumber=" + TenderNoticeNo;
                       });

                        break;
                    case "found":
                        $("#divLoader").hide();
                        Swal.fire
                       ({
                           title: "Tender Response has been created!",
                           text: "Tender Response has been created,Proceed and Fill in the details!",
                           type: "success"
                       }).then(() => {
                           $("#responsesfeedback").css("display", "block");
                           $("#responsesfeedback").css("color", "green");
                           $('#responsesfeedback').attr("class", "alert alert-success");
                           $("#responsesfeedback").html("Tender Response has been created,Proceed and Fill in the details!");
                           $("#responsesfeedback").css("display", "block");
                           $("#responsesfeedback").css("color", "green");
                           $("#responsesfeedback").html("Tender Response has been created,Proceed and Fill in the details!");
                           window.location.href = "/Home/RespondTenderWizard?respondtendernumber=" + TenderNoticeNo;
                       });

                        break;
                    default:
                        $("#divLoader").hide();
                        Swal.fire
                        ({
                            title: "Tender Response Error!!!",
                            text: tendersponse[1],
                            type: "error"
                        }).then(() => {
                            $("#responsesfeedback").css("display", "block");
                            $("#responsesfeedback").css("color", "red");
                            $('#responsesfeedback').addClass('alert alert-danger');
                            $("#responsesfeedback").html("Your Tender Response Details  could not submitted.Kindly try Again!" + tendersponse[1]+ "");
                        });
                        break;
                }
            }
        );
        } else if (result.dismiss === Swal.DismissReason.cancel) {
            $("#divLoader").hide();
            Swal.fire(
                'Tender Response Cancelled',
                'You cancelled your tender Response submission details!',
                'error'
            );
        }
    });

};
function TenderUpdate(url, uniquetenderno) {
    var TenderNoticeNo = $('#tendernotice').val();
    Swal.fire({
        title: "Confirm Tender Response?",
        text: " are you sure you would like to update this tender?",
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
                cache: false,
                type: 'GET',
                url: url,
                cache: false,
                processData: false,
            }).done(function (status) {
                var tendersponse = status.split('*');
                status = tendersponse[0];
                switch (status) {
                    case "success":
                        Swal.fire
                       ({
                           title: "Tender Response has been created!",
                           text: "Tender Response has been created,Proceed and Fill in the details!",
                           type: "success"
                       }).then(() => {
                           $("#responsesfeedback").css("display", "block");
                           $("#responsesfeedback").css("color", "green");
                           $('#responsesfeedback').attr("class", "alert alert-success");
                           $("#responsesfeedback").html("Your Tender Response have been successfully Updated.Kindly Proceed to update!");
                           $("#responsesfeedback").css("display", "block");
                           $("#responsesfeedback").css("color", "green");
                           $("#responsesfeedback").html("Your Tender Response have been successfully Updated.Kindly Proceed to update!");
                           window.location.href = "/Home/RespondTenderWizard?respondtendernumber=" + TenderNoticeNo;
                       });

                        break;
                    case "found":
                        Swal.fire
                       ({
                           title: "Tender Response has been created!",
                           text: "Tender Response has been created,Proceed and Fill in the details!",
                           type: "success"
                       }).then(() => {
                           $("#responsesfeedback").css("display", "block");
                           $("#responsesfeedback").css("color", "green");
                           $('#responsesfeedback').attr("class", "alert alert-success");
                           $("#responsesfeedback").html("Your Tender Response have been successfully Updated.Kindly Proceed to update!");
                           $("#responsesfeedback").css("display", "block");
                           $("#responsesfeedback").css("color", "green");
                           $("#responsesfeedback").html("Your Tender Response have been successfully Updated.Kindly Proceed to update!");
                           window.location.href = "/Home/RespondTenderWizard?respondtendernumber=" + TenderNoticeNo;
                       });

                        break;
                    default:
                        Swal.fire
                        ({
                            title: "Tender Response Error!!!",
                            text: tendersponse[1],
                            type: "error"
                        }).then(() => {
                            $("#responsesfeedback").css("display", "block");
                            $("#responsesfeedback").css("color", "red");
                            $('#responsesfeedback').addClass('alert alert-danger');
                            $("#responsesfeedback").html("Your Tender Response Details  could not updated.Kindly try Again!" + tendersponse[1] + "");
                        });
                        break;
                }
            }
        );
        } else if (result.dismiss === Swal.DismissReason.cancel) {
            Swal.fire(
                'Tender Response Cancelled',
                'You cancelled your tender Response submission details!',
                'error'
            );
        }
    });

};
function RespondRFQ(url, uniquetenderno) {
    var TenderNoticeNo = $('#tendernotice').val();
    Swal.fire({
        title: "Confirm RFQ Response?",
        text: "Are you sure you would like to Respond to this RFQ?",
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
                cache: false,
                type: 'GET',
                url: url,
                cache: false,
                processData: false,
            }).done(function (status) {
                var tendersponse = status.split('*');
                status = tendersponse[0];
                switch (status) {
                    case "success":
                        Swal.fire
                       ({
                           title: "RFQ Response Saved Successfully",
                           text: "Your RFQ Response has been saved.Kindly Proceed to fill in more Details!",
                           type: "success"
                       }).then(() => {
                           $("#responsesfeedback").css("display", "block");
                           $("#responsesfeedback").css("color", "green");
                           $('#responsesfeedback').attr("class", "alert alert-success");
                           $("#responsesfeedback").html("Your RFQ Response has been successfully saved.Kindly Proceed to fill in more Details!");
                           $("#responsesfeedback").css("display", "block");
                           $("#responsesfeedback").css("color", "green");
                           $("#responsesfeedback").html("Your RFQ Response have been successfully saved.Kindly Proceed to fill in more Details!");
                           window.location.href = "/Home/RespondQuotationWizard";
                       });

                        break;
                    case "found":
                        Swal.fire
                       ({
                           title: "RFQ Response Saved Successfully!",
                           text: "Your RFQ Response has already been saved.Kindly Proceed to fill in more Details!",
                           type: "success"
                       }).then(() => {
                           $("#responsesfeedback").css("display", "block");
                           $("#responsesfeedback").css("color", "green");
                           $('#responsesfeedback').attr("class", "alert alert-success");
                           $("#responsesfeedback").html("Your RFQ Response had been successfully submitted.Kindly Proceed to fill in more Details!");
                           $("#responsesfeedback").css("display", "block");
                           $("#responsesfeedback").css("color", "green");
                           $("#responsesfeedback").html("Your RFQ Response had been successfully submitted.Kindly Proceed to fill in more Details!");
                           window.location.href = "/Home/RespondQuotationWizard";
                       });

                        break;
                    default:
                        Swal.fire
                        ({
                            title: "RFQ Response Error!!!",
                            text: tendersponse[1],
                            type: "error"
                        }).then(() => {
                            $("#responsesfeedback").css("display", "block");
                            $("#responsesfeedback").css("color", "red");
                            $('#responsesfeedback').addClass('alert alert-danger');
                            $("#responsesfeedback").html("Your RFQ Response Details  could not submitted.Kindly try Again!" + tendersponse[1] + "");
                        });
                        break;
                }
            }
        );
        } else if (result.dismiss === Swal.DismissReason.cancel) {
            Swal.fire(
                'RFQ Response Cancelled',
                'You cancelled your RFQ Response submission details!',
                'error'
            );
        }
    });

};
function UpdateRFQ(url, uniquetenderno) {
    var TenderNoticeNo = $('#tendernotice').val();
    Swal.fire({
        title: "Confirm RFQ Response?",
        text: "are you sure you would like to update this RFQ?",
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
                cache: false,
                type: 'GET',
                url: url,
                cache: false,
                processData: false,
            }).done(function (status) {
                var tendersponse = status.split('*');
                status = tendersponse[0];
                switch (status) {
                    case "success":
                        Swal.fire
                       ({
                           title: "RFQ Response Updated Successfully",
                           text: "Your RFQ Response has been updated.Kindly Proceed to update in more Details!",
                           type: "success"
                       }).then(() => {
                           $("#responsesfeedback").css("display", "block");
                           $("#responsesfeedback").css("color", "green");
                           $('#responsesfeedback').attr("class", "alert alert-success");
                           $("#responsesfeedback").html("Your RFQ Response has been updated.Kindly Proceed to update in more Details!");
                           $("#responsesfeedback").css("display", "block");
                           $("#responsesfeedback").css("color", "green");
                           $("#responsesfeedback").html("Your RFQ Response has been updated.Kindly Proceed to update in more Details!");
                           window.location.href = "/Home/RespondQuotationWizard";
                       });

                        break;
                    case "found":
                        Swal.fire
                       ({
                           title: "RFQ Response updated Successfully!",
                           text: "Your RFQ Response has been updated.Kindly Proceed to update in more Details!",
                           type: "success"
                       }).then(() => {
                           $("#responsesfeedback").css("display", "block");
                           $("#responsesfeedback").css("color", "green");
                           $('#responsesfeedback').attr("class", "alert alert-success");
                           $("#responsesfeedback").html("Your RFQ Response has been updated.Kindly Proceed to update in more Details!");
                           $("#responsesfeedback").css("display", "block");
                           $("#responsesfeedback").css("color", "green");
                           $("#responsesfeedback").html("Your RFQ Response has been updated.Kindly Proceed to update in more Details!");
                           window.location.href = "/Home/RespondQuotationWizard";
                       });

                        break;
                    default:
                        Swal.fire
                        ({
                            title: "RFQ Response Error!!!",
                            text: tendersponse[1],
                            type: "error"
                        }).then(() => {
                            $("#responsesfeedback").css("display", "block");
                            $("#responsesfeedback").css("color", "red");
                            $('#responsesfeedback').addClass('alert alert-danger');
                            $("#responsesfeedback").html("Your RFQ Response Details  could not Updated.Kindly try Again!" + tendersponse[1] + "");
                        });
                        break;
                }
            }
        );
        } else if (result.dismiss === Swal.DismissReason.cancel) {
            Swal.fire(
                'RFQ Response Cancelled',
                'You cancelled your RFQ Response submission details!',
                'error'
            );
        }
    });

};