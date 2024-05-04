'use-strict';
function Respond(url, uniquetenderno) {
    var TenderNoticeNo = $('#tendernotice').val();
    var RespondWizardForm = '@Url.Action("RespondTenderWizard", "Home")';
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
                           title: "Tender Response Submitted!",
                           text: "Your Tender Response have been successfully submitted.Kindly Proceed to fill in more Details!",
                           type: "success"
                       }).then(() => {
                           $("#responsesfeedback").css("display", "block");
                           $("#responsesfeedback").css("color", "green");
                           $('#responsesfeedback').attr("class", "alert alert-success");
                           $("#responsesfeedback").html("Your Tender Response have been successfully submitted.Kindly Proceed to fill in more Details!");
                           $("#responsesfeedback").css("display", "block");
                           $("#responsesfeedback").css("color", "green");
                           $("#responsesfeedback").html("Your Tender Response have been successfully submitted.Kindly Proceed to fill in more Details!");
                           window.location.href = RespondWizardForm;
                       });

                        break;
                    case "found":
                        Swal.fire
                       ({
                           title: "Tender Response already Submitted!",
                           text: "Your Tender Response had already been successfully submitted.Kindly Proceed to fill in more Details!",
                           type: "success"
                       }).then(() => {
                           $("#responsesfeedback").css("display", "block");
                           $("#responsesfeedback").css("color", "green");
                           $('#responsesfeedback').attr("class", "alert alert-success");
                           $("#responsesfeedback").html("Your Tender Response had been successfully submitted.Kindly Proceed to fill in more Details!");
                           $("#responsesfeedback").css("display", "block");
                           $("#responsesfeedback").css("color", "green");
                           $("#responsesfeedback").html("Your Tender Response had been successfully submitted.Kindly Proceed to fill in more Details!");
                           window.location.href = RespondWizardForm;
                       });

                        break;
                    default:
                        Swal.fire
                        ({
                            title: "Tender Response Error!!!",
                            text: status,
                            type: "error"
                        }).then(() => {
                            $("#responsesfeedback").css("display", "block");
                            $("#responsesfeedback").css("color", "red");
                            $('#responsesfeedback').addClass('alert alert-danger');
                            $("#responsesfeedback").html("Your Tender Response Details  could not submitted.Kindly try Again!" + status + "");
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