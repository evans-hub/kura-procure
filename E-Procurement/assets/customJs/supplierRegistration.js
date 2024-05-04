$(document).ready(function () {
    //Supplier Registration Function
    $(".btn_supplierregister").click(function () {     
        //Set data to be sent
        var data = {
            "VendorName": $("#supplierbusinessname").val(),
            "Phonenumber": $("#phonenumber").val(),
            "Email": $("#supplieremailaddress").val(),
            "KraPin": $("#taxregistration").val(),
            "ContactName": $("#contactperson").val(),
            //"tterms": $("invalidCheck[type='checkbox']").val()
        }
        //Swal Message
        Swal.fire({
            title: "Confirm Registration?",
            text: "Are you sure you would like to proceed with the submission?",
            type: "warning",
            showCancelButton: true,
            closeOnConfirm: true,
            confirmButtonText: "Yes, Proceed!",
            confirmButtonClass: "btn-success",
            confirmButtonColor: "#008000",
            position: "center"
           
        }).then((result) => {
            if (result.value) {
                $("#divLoader").show();
                $.ajax({
                    url: "/Home/SupplierFirstRegistration",                    
                    type: "POST",
                    data: JSON.stringify(data),
                    contentType: "application/json",
                    cache: false,
                    async: true,
                    processData: false
                }).done(function (status) {
                    var registerstatus = status.split('*');
                    status = registerstatus[0];
                    switch (status) {
                        case "success":
                            $("#divLoader").hide();
                            Swal.fire
                            ({
                                title: "Registration Submitted Successfully",
                                text: "Your Account Creation Request have been successfully submitted.Kindly Check your Email Account for More Details",
                                type: "success"
                            });
                            break;
                        default:
                            $("#divLoader").hide();
                            Swal.fire
                            ({
                                title: "Registration Error!!!",
                                text: "Your Account Creation Request could not been successfully submitted" +" "+ registerstatus[1],
                                type: "error"
                            }).then(() => {
                                $("#feedback").css("display", "block");
                                $("#feedback").css("color", "red");
                                $('#feedback').addClass('alert alert-danger');
                                $("#feedback").html("Your Account Creation Request could not been successfully submitted" + " " + registerstatus[1]);
                               
                            });
                            break;
                    }
                }
                );
            } else if (result.dismiss === Swal.DismissReason.cancel) {
                $("#divLoader").hide();
                Swal.fire(
                     
                    'Registration Cancelled',
                    'You cancelled your supplier registration submission details!',
                    'error'
                );
            }
        });

    });
})