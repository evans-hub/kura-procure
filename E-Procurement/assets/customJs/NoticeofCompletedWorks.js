$(document).ready(function () {
    $(".btn_noticeof_completed_works").click(function () {
        //var WorksObj = {
        //    "Contractor_No": $("#contractno").val(),
        //    "Region_ID": $("#dropdownRegionsList").val(),
        //    "Description": $("#projecttitle").val(),
        //    "Road_Class_ID": $("#roadclass").val(),
        //    "Funding_Source": $("#ddfundingsource").val(),
        //    "Project_Start_Date": $("#projectstartdate").val(),
        //    "Project_End_Date": $("#projectenddate").val(),
        //    "Person_Responsible": $("#projectaccountant").val(),
        //    "Project_Manager": $("#residentengineer").val()
        //}

        //Swal Message
        Swal.fire({
            title: "Confirm Submission of Notice?",
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
                    url: "/Contractor/RegisterWorkExecutionPlan",
                    type: "POST",
                    data: JSON.stringify(WorksObj),
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
                                title: "Notice of Completed Works Details Submitted!",
                                text: status,
                                type: "success"
                            }).then(() => {
                                $("#workexecutionplanfeedback").css("display", "block");
                                $("#workexecutionplanfeedback").css("color", "green");
                                $('#workexecutionplanfeedback').attr("class", "alert alert-success");
                                $("#workexecutionplanfeedback").html("Your Notice of Completed Works Details have been successfully submitted.Kindly Try Again!");
                                $("#workexecutionplanfeedback").css("display", "block");
                                $("#workexecutionplanfeedback").css("color", "green");
                                $("#workexecutionplanfeedback").html("Your Notice of Completed Works Details have been successfully submitted.Kindly Try Again!");
                            });
                            // vendorbankaccounts.init();

                            break;
                        default:
                            Swal.fire
                            ({
                                title: "Notice of Completed Works Details Submission Error!!!",
                                text: status,
                                type: "error"
                            }).then(() => {
                                $("#workexecutionplanfeedback").css("display", "block");
                                $("#workexecutionplanfeedback").css("color", "red");
                                $('#workexecutionplanfeedback').addClass('alert alert-danger');
                                $("#workexecutionplanfeedback").html("Your Notice of Completed Works Details could not be submitted.Kindly Try Again!");
                            });
                            break;

                    }
                }
                );
            } else if (result.dismiss === Swal.DismissReason.cancel) {
                Swal.fire(
                    'Notice of Completed Works Details Cancelled',
                    'You cancelled your notice of completed works submission details!',
                    'error'
                );
            }
        });

    });
})