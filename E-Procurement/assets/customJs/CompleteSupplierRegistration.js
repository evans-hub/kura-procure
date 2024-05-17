
$(document).ready(function () {   
    //Supplier Registration Function
    $(".btn_suppliercompleteregister").click(function () {
        var supplierObj = {
            "IndustryGroup": $("#dropdownsupplierCategory").val(),
            "CompanySize": $("#dropDownCompanysize").val(),
            "NominalCap": $("#nominalcapital").val(),
            "Dealer_Type": $("#txtDealertype").val(),
            "Vision": $("#companyvission").val(),
            "Mision": $("#companymission").val(),
            "PhysicalLocation": $("#physicallocation").val(),
            "MaxBizValue": $("#maxibizvalues").val(),
            "MobileNo": $("#mobilenumber").val(),
            "NatureofBz": $("#natureofbusiness").val(),
        }
        console.log(JSON.stringify(supplierObj));
        //Swal Message
        Swal.fire({
            title: "Confirm Business Details?",
            text: "Are you sure you would like to save your details?",
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
                    url: "/Home/BusinessProfile",
                    type: "POST",
                    data: JSON.stringify(supplierObj),
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
                                title: "Registration Submitted!",
                                text: "Your Profile Details have been successfully saved",
                                type: "success"
                            }).then(() => {
                                $("#feedback").css("display", "block");
                                $("#feedback").css("color", "green");
                                $('#feedback').attr("class", "alert alert-success");
                                $("#feedback").html("Your Profile Details have been successfully saved.Kindly Proceed to fill in the rest details!");
                                $("#uploadsMsg").css("display", "block");
                                $("#uploadsMsg").css("color", "green");
                                $("#uploadsMsg").html("Your Profile Details have been successfully saved.Kindly Proceed to fill in the rest details!");
                                $("#preqappl_form").reset();
                            });
                            $("button#nextBtn").css("display", "block");
                            break;
                        default:
                            Swal.fire
                            ({
                                title: "Registration Error!!!",
                                text: "Your Profile Details could not be saved" + " " + registerstatus[1],
                                type: "error"
                            }).then(() => {
                                $("#feedback").css("display", "block");
                                $("#feedback").css("color", "red");
                                $('#feedback').addClass('alert alert-danger');
                                $("#feedback").html("Your Profile Details could not be saved.Kindly Proceed to fill in the rest details!" + " " + registerstatus[1]);
                            });
                            break;
                    }
                }
                );
            } else if (result.dismiss === Swal.DismissReason.cancel) {
                Swal.fire(
                    'Registration Cancelled',
                    'You cancelled your supplier registration!',
                    'error'
                );
            }
        });

    });
    $(".saveGeneralDeatils").click(function () {
        var supplierObj = {
            "BusinessType": $("#dropBusinesstype").val(),
            "VendorType": $("#vendortype").val(),
            "OwnerType": $("#ownershiptype").val(),            
            "CertofIncorporation": $("#certificateofincorporation").val(),
            "DateofIncorporation": $("#dateofincoperation").val(),
            "LanguageCode": $("#dropdownlanguagecodes").val(),
            "OpsDate": $("#startdateoperations").val(),
            "Haveagpo": $("#disabled").val(),
            //special group
            "Certifcate_No": $("#certificateno").val(),
            "Registered_Specia_Group": $("#dropdownspecialgoupCategory").val(),
            "Products_Service_Category": $("#dropdownsupplierCategory").val(),
            //"Products_Service_Category": $("#servicecategory").val(),
            "Certificate_Effective_Date": $("#effectivedates").val(),
            "Certificate_Expiry_Date": $("#expirydates").val()
           
        }
       

        console.log(JSON.stringify(supplierObj));
        //Swal Message
        Swal.fire({
            title: "Confirm General Details?",
            text: "Are you sure you would like to save your details?",
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
                    url: "/Home/RegisterSupplier",
                    type: "POST",
                    data: JSON.stringify(supplierObj),
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
                                title: "Details Submitted!",
                                text: "Your Profile Details have been successfully saved",
                                type: "success"
                            }).then(() => {
                                $("#feedback").css("display", "block");
                                $("#feedback").css("color", "green");
                                $('#feedback').attr("class", "alert alert-success");
                                $("#feedback").html("Your Profile Details have been successfully saved.Kindly Proceed to fill in the rest details!");
                                $("#uploadsMsg").css("display", "block");
                                $("#uploadsMsg").css("color", "green");
                                $("#uploadsMsg").html("Your Profile Details have been successfully saved.Kindly Proceed to fill in the rest details!");
                                $("#preqappl_form").reset();
                            });
                            $("button#nextBtn").css("display", "block");
                            break;
                        default:
                            Swal.fire
                            ({
                                title: "Registration Error!!!",
                                text: "Your Profile Details could not be saved" + " " + registerstatus[1],
                                type: "error"
                            }).then(() => {
                                $("#feedback").css("display", "block");
                                $("#feedback").css("color", "red");
                                $('#feedback').addClass('alert alert-danger');
                                $("#feedback").html("Your Profile Details could not be saved.Kindly Proceed to fill in the rest details!" + " " + registerstatus[1]);
                            });
                            break;
                    }
                }
                );
            } else if (result.dismiss === Swal.DismissReason.cancel) {
                Swal.fire(
                    'Registration Cancelled',
                    'You cancelled your supplier registration!',
                    'error'
                );
            }
        });

    });
    $(".saveCommunicationDetails").click(function () {
        var supplierObj = {
            "PoBox": $("#poboxaddress").val(),
            "PostaCode": $("#dropdownallpostacodes30").val(),
             "HouseNo": $("#housenumber").val(),
            "FloorNo": $("#floornumber").val(),
            "PlotNo": $("#plotnumber").val(),            
            "StreetorRoad": $("#streetnumber").val(),
            "PostaCity": $("#postcity").val(),
            "CountryofOrigin": $("#dropdownCountries").val(),
            "WebUrl": $("#weburl").val(),
            "TelephoneNo": $("#telephonenumber").val(),
            "Fax": $("#faxnumber").val(),

           

        }
        console.log(JSON.stringify(supplierObj));
        //Swal Message
        Swal.fire({
            title: "Confirm Communication Details?",
            text: "Are you sure you would like to save your details?",
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
                    url: "/Home/CommunicationDetails",
                    type: "POST",
                    data: JSON.stringify(supplierObj),
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
                                title: "Communication Details Submitted!",
                                text: "Your Profile Details have been successfully saved",
                                type: "success"
                            }).then(() => {
                                $("#feedback").css("display", "block");
                                $("#feedback").css("color", "green");
                                $('#feedback').attr("class", "alert alert-success");
                                $("#feedback").html("Your Profile Details have been successfully saved.Kindly Proceed to fill in the rest details!");
                                $("#uploadsMsg").css("display", "block");
                                $("#uploadsMsg").css("color", "green");
                                $("#uploadsMsg").html("Your Profile Details have been successfully saved.Kindly Proceed to fill in the rest details!");
                                $("#preqappl_form").reset();
                            });
                            $("button#nextBtn").css("display", "block");
                            break;
                        default:
                            Swal.fire
                            ({
                                title: "Registration Error!!!",
                                text: "Your Profile Details could not be saved" + " " + registerstatus[1],
                                type: "error"
                            }).then(() => {
                                $("#feedback").css("display", "block");
                                $("#feedback").css("color", "red");
                                $('#feedback').addClass('alert alert-danger');
                                $("#feedback").html("Your Profile Details could not be saved.Kindly Proceed to fill in the rest details!" + " " + registerstatus[1]);
                            });
                            break;
                    }
                }
                );
            } else if (result.dismiss === Swal.DismissReason.cancel) {
                Swal.fire(
                    'Registration Cancelled',
                    'You cancelled your supplier registration!',
                    'error'
                );
            }
        });

    });
    //Supplier Registration Function
    $(".btn_submitVendorBanks").click(function () {
        var bankObj = {
            "BankCode": $("#bankcode").val(),
            "BankName": $("#bankname").val(),
            "BankAccountNo": $("#bankaccountno").val(),
            "CurrencyCode": $("#dropdownCurrencycodes").val(),
            "Phone_No": $("#phonenumber").val(),
            "Bank_Branch_No": $("#bankBranchName").val(),
            "CountryCode": $("#vendordropdownCountries").val(),
            "Post_Code": $("#ddlbankcodes").val(),
        }

        //Swal Message
          console.log(JSON.stringify(bankObj))
        Swal.fire({
            title: "Confirm Bank Details Submission?",
            text: "Are you sure you would like to save your details?",
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
                    url: "/Home/RegisterSupplierBankDetails",
                    type: "POST",
                    data: JSON.stringify(bankObj),
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
                                title: "Banks Details Saved!",
                                text: status,
                                type: "success"
                            }).then(() => {
                                $("#banksfeedback").css("display", "block");
                                $("#banksfeedback").css("color", "green");
                                $('#banksfeedback').attr("class", "alert alert-success");
                                $("#banksfeedback").html("Your Bank Details have been successfully Saved.Kindly Proceed to fill in the rest details!");
                                $("#banksfeedback").css("display", "block");
                                $("#banksfeedback").css("color", "green");
                                $("#banksfeedback").html("Your Bank Details have been successfully Saved.Kindly Proceed to fill in the rest details!");
                            });
                            vendorbankaccounts.init();
                            //$("#tbl_vendor_banks").ajax.reload();
                            $('#add_banks').modal('hide');
                            break;
                        default:
                            Swal.fire
                            ({
                                title: "Bank Details Submission Error!!!",
                                text: "Your Banks Details could not be Saved.Kindly Proceed to fill in the rest details!" + " " + registerstatus[1],
                                type: "error"
                            }).then(() => {
                                $("#banksfeedback").css("display", "block");
                                $("#banksfeedback").css("color", "red");
                                $('#banksfeedback').addClass('alert alert-danger');
                                $("#banksfeedback").html("Your Banks Details could not be Saved.Kindly Proceed to fill in the rest details!" + " " + registerstatus[1]);
                            });
                            vendorbankaccounts.init();
                            $('#add_banks').modal('hide');
                            break;

                    }
                }
                );
            } else if (result.dismiss === Swal.DismissReason.cancel) {
                Swal.fire(
                    'Bank Details Registration Cancelled',
                    'You cancelled your supplier bank registration!',
                    'error'
                );
            }
        });

    });
    $(document).ready(function () {
        $("#bankDropdown").on('change', function () {
            var selectedValue = $(this).val();
            $.ajax({
                type: 'GET',
                url: '/Home/viewBankBranches',
                data: { bankCode: selectedValue },
                success: function (result) {
                    var branches = $("#bankBranchName");
                    branches.empty();
                    $.each(data, function (index, item) {
                        result.append($("<option></option>").val(item.BankCode).html(item.BankName));
                    });

                },
                error: function (error) {
                    console.log("Error : " + error);
                }
            })
        })
    })


    //Supplier Shareholders Details Function
    $(".btn_submitShareholders_Details").click(function () {
        var ShareholderObj = {
            "Name": $("#directorname").val(),
            "ID_Passport_No": $("#idnumbers").val(),
            "Citizenship_Type": $("#citizenship").val(),
            "Nationality_ID": $("#nationality").val(),
            "Entity_Ownership": $("#ownershippercentage").val(),
            "Phone_No": $("#phonenumbers").val(),
            "Address": $("#shareholderaddress").val(),
            "E_Mail": $("#emailaddress").val(),
            "shareholdersDetails": $("#shareholdertype").val(),
            "registrationNumber": $("#registrationNo").val(),
            "kraPin": $("#kraPin").val(),
            "entityType": $("#dropdownEntityType").val(),
            "Company_Type": $("#companytype").val(),
        }

        //Swal Message
        Swal.fire({
            title: "Confirm Shareholders Details Submission?",
            text: "Are you sure you would like to save Your details?",
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
                    url: "/Home/RegisterSupplierShareholderDetails",
                    type: "POST",
                    data: JSON.stringify(ShareholderObj),
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
                                title: "Shareholders Details Saved!",
                                text: status,
                                type: "success"
                            }).then(() => {
                                $("#shareholdersfeedback").css("display", "block");
                                $("#shareholdersfeedback").css("color", "green");
                                $('#shareholdersfeedback').attr("class", "alert alert-success");
                                $("#shareholdersfeedback").html("Your Shareholders Details have been successfully Saved.Kindly Proceed to fill in the rest details!");
                                $("#shareholdersfeedback").css("display", "block");
                                $("#shareholdersfeedback").css("color", "green");
                                $("#shareholdersfeedback").html("Your Shareholders Details have been successfully Saved.Kindly Proceed to fill in the rest details!");
                            });
                            VendorshareholderDetails.init();
                            $('#add_shareholders').modal('hide');
                            break;
                        default:
                            Swal.fire
                            ({
                                title: "Shareholders Details Submission Error!!!",
                                text: status,
                                type: "error"
                            }).then(() => {
                                $("#shareholdersfeedback").css("display", "block");
                                $("#shareholdersfeedback").css("color", "red");
                                $('#shareholdersfeedback').addClass('alert alert-danger');
                                $("#shareholdersfeedback").html("Your Shareholders Details could not be Saved.Kindly Proceed to fill in the rest details!" + " " + registerstatus[1]);
                            });
                            VendorshareholderDetails.init();
                            $('#add_shareholders').modal('hide');
                            break;
                    }
                }
                );
            } else if (result.dismiss === Swal.DismissReason.cancel) {
                Swal.fire(
                    'Shareholders Details Registration Cancelled',
                    'You cancelled your supplier Shareholders registration!',
                    'error'
                );
                VendorShareholderDetails.init();
            }
        });

    });



    //Supplier Beneficiaries Details Function
    $(".btn_submitBeneficiaries_Details").click(function () {
        var ShareholderObj = {
            "Name": $("#beneficiaryname").val(),
            "idpassportNumber": $("#beneficiaryidnumbers").val(),
            "idType": $("#IdType").val(),           
            "Phonenumber": $("#beneficiaryPhoneNumber").val(),
            "AllocatedShares": $("#allocatedShares").val(),
            "Email": $("#beneficiaryemailaddress").val(),
            "BeneficiaryType": $("#beneficiarytype").val()
        }

        //Swal Message
        Swal.fire({
            title: "Confirm Beneficiary Details Submission?",
            text: "Are you sure you would like to save Your details?",
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
                    url: "/Home/RegisterSupplierBeneficiaries",
                    type: "POST",
                    data: JSON.stringify(ShareholderObj),
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
                                title: "Beneficiaries Details Saved!",
                                text: status,
                                type: "success"
                            }).then(() => {
                                $("#shareholdersfeedback").css("display", "block");
                                $("#shareholdersfeedback").css("color", "green");
                                $('#shareholdersfeedback').attr("class", "alert alert-success");
                                $("#shareholdersfeedback").html("Your Shareholders Details have been successfully Saved.Kindly Proceed to fill in the rest details!");
                                $("#shareholdersfeedback").css("display", "block");
                                $("#shareholdersfeedback").css("color", "green");
                                $("#shareholdersfeedback").html("Your Beneficiaries Details have been successfully Saved.Kindly Proceed to fill in the rest details!");
                            });
                            VendorbeneficiaryDetails.init();
                            $('#add_beneficiaries').modal('hide');
                            break;
                        default:
                            Swal.fire
                            ({
                                title: "Beneficiaries Details Submission Error!!!",
                                text: status,
                                type: "error"
                            }).then(() => {
                                $("#shareholdersfeedback").css("display", "block");
                                $("#shareholdersfeedback").css("color", "red");
                                $('#shareholdersfeedback').addClass('alert alert-danger');
                                $("#shareholdersfeedback").html("Your Beneficiaries Details could not be Saved.Kindly Proceed to fill in the rest details!" + " " + registerstatus[1]);
                            });
                            $('#add_shareholders').modal('hide');
                            break;
                    }
                }
                );
            } else if (result.dismiss === Swal.DismissReason.cancel) {
                Swal.fire(
                    'Beneficiaries Details Registration Cancelled',
                    'You cancelled your supplier Beneficiaries registration!',
                    'error'
                );
            }
        });

    });

    //Supplier Litigation History Details Function
    $(".btn_litigation_history").click(function () {
        var LitigationObj = {
            "DisputeDescription": $("#disputedescription").val(),
            "CategoryofDispute": $("#disputecategory").val(),
            "Year": $("#litigationyear").val(),
            "TheotherDisputeparty": $("#disputeparties").val(),
            "DisputeAmounts": $("#disputeamounts").val(),
            "AwardType": $("#awardtype").val(),
            "docNo": $("#inviteNO").val(),
        }
        //Swal Message
        Swal.fire({
            title: "Confirm Litigation Details Submission?",
            text: "Are you sure you would like to Save your details?",
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
                    url: "/Home/RegisterLitigationHistoryDetails",
                    type: "POST",
                    data: JSON.stringify(LitigationObj),
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
                                title: "Litigation Details Saved!",
                                text: status,
                                type: "success"
                            }).then(() => {
                                $("#litigationfeedback").css("display", "block");
                                $("#litigationfeedback").css("color", "green");
                                $('#litigationfeedback').attr("class", "alert alert-success");
                                $("#litigationfeedback").html("Your Litigation Details have been successfully Saved.Kindly Proceed to fill in the rest details!");
                                $("#litigationfeedback").css("display", "block");
                                $("#litigationfeedback").css("color", "green");
                                $("#litigationfeedback").html("Your Litigation Details have been successfully Saved.Kindly Proceed to fill in the rest details!");
                            });
                            VendorLitigationDetails.init();
                            $('#add_litigation').modal('hide');
                            break;
                        default:
                            Swal.fire
                            ({
                                title: "Litigation Details Submission Error!!!",
                                text: "Your Litigation Details could not be Saved.Kindly Proceed to fill in the rest details!" + " " + registerstatus[1],
                                type: "error"
                            }).then(() => {
                                $("#litigationfeedback").css("display", "block");
                                $("#litigationfeedback").css("color", "red");
                                $('#litigationfeedback').addClass('alert alert-danger');
                                $("#litigationfeedback").html("Your Litigation Details could not be Saved.Kindly Proceed to fill in the rest details!" + " " + registerstatus[1]);
                            });
                            break;
                    }
                });
            } else if (result.dismiss === Swal.DismissReason.cancel) {
                Swal.fire(
                    'Litigation Details Registration Cancelled',
                    'You cancelled your supplier Litigation registration!',
                    'error'
                );
                VendorLitigationDetails.init();

            }
        });

    });

    //Supplier Past Experience Details Function
    $(".btn_past_experience").click(function () {
        var ExperienceObj = {
            "Client_Name": $("#clientname").val(),
            "Address": $("#experienceaddress").val(),
            "Assignment_Project_Name": $("#projectassignment").val(),
            "Project_Scope_Summary": $("#projectscopes").val(),
            "Assignment_Start_Date": $("#projectstartdate").val(),
            "Assignment_End_Date": $("#projectenddate").val(),
            "Assignment_Value_LCY": $("#projectvalue").val(),
        }
        console.log(JSON.stringify(ExperienceObj))
        //Swal Message
        Swal.fire({
            title: "Confirm Past Experience Details Submission?",
            text: "Are you sure you would like to save your details?",
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
                    url: "/Home/RegisterPastExperienceDetails",
                    type: "POST",
                    data: JSON.stringify(ExperienceObj),
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
                                title: "Past Experience Details saved!",
                                text: status,
                                type: "success"
                            }).then(() => {
                                $("#pastexperiencefeedback").css("display", "block");
                                $("#pastexperiencefeedback").css("color", "green");
                                $('#pastexperiencefeedback').attr("class", "alert alert-success");
                                $("#pastexperiencefeedback").html("Your Past Experience Details have been successfully saved.Kindly Proceed to fill in the rest details!");
                                $("#pastexperiencefeedback").css("display", "block");
                                $("#pastexperiencefeedback").css("color", "green");
                                $("#pastexperiencefeedback").html("Your Past Experience Details have been successfully saved.Kindly Proceed to fill in the rest details!");
                            });
                            VendorPastExperienceDetails.init();
                            $('#add_pastexperience').modal('hide');
                            break;
                        default:
                            Swal.fire
                            ({
                                title: "Past Experience Details Submission Error!!!",
                                text: "Your Past Experience Details could not be saved.Kindly Proceed to fill in the rest details!" + " " + registerstatus[1],
                                type: "error"
                            }).then(() => {
                                $("#pastexperiencefeedback").css("display", "block");
                                $("#pastexperiencefeedback").css("color", "red");
                                $('#pastexperiencefeedback').addClass('alert alert-danger');
                                $("#pastexperiencefeedback").html("Your Past Experience Details could not be Saved.Kindly Proceed to fill in the rest details!" + " " + registerstatus[1]);
                            });
                            break;
                    }
                }
                );
            } else if (result.dismiss === Swal.DismissReason.cancel) {
                Swal.fire(
                    'Past Experience Details Registration Cancelled',
                    'You cancelled your supplier Past Experience registration!',
                    'error'
                );
            }
        });

    });

    //Supplier Balance Sheet Details Function
    $(".btn_balancesheet_details").click(function () {
        var BalanceSheetObj = {
            "Audit_Year_Code_Reference": $("#ddlyearcodes").val(),
            "Total_Assets_LCY": $("#totalcurrentassets").val(),
            "Fixed_Assets_LCY": $("#totalfixedassets").val(),
            "Current_Liabilities_LCY": $("#totalcurrentliabilities").val(),
            "Long_term_Liabilities_LCY": $("#totallongtermliabilities").val(),
            "Owners_Equity_LCY": $("#totalownersequity").val(),
        }
        console.log(JSON.stringify(BalanceSheetObj))
        //Swal Message
        Swal.fire({
            title: "Confirm Balance Sheet Details Submission?",
            text: "Are you sure you would like to save your details?",
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
                    url: "/Home/RegisterBalanceSheetDetails",
                    type: "POST",
                    data: JSON.stringify(BalanceSheetObj),
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
                                title: "Balance Sheet Details saved!",
                                text: status,
                                type: "success"
                            }).then(() => {
                                $("#balancesheetfeedback").css("display", "block");
                                $("#balancesheetfeedback").css("color", "green");
                                $('#balancesheetfeedback').attr("class", "alert alert-success");
                                $("#balancesheetfeedback").html("Your Balance Sheet Details have been successfully saved.Kindly Proceed to fill in the rest details!");
                                $("#balancesheetfeedback").css("display", "block");
                                $("#balancesheetfeedback").css("color", "green");
                                $("#balancesheetfeedback").html("Your Balance Sheet Details have been successfully saved.Kindly Proceed to fill in the rest details!");
                            });
                            VendorBalanceSheetDetails.init();
                            break;
                        default:
                            Swal.fire
                            ({
                                title: "Balance Sheet Details Submission Error!!!",
                                text: "Your Balance Sheet Details could not be saved" + registerstatus[1],
                                type: "error"
                            }).then(() => {
                                $("#balancesheetfeedback").css("display", "block");
                                $("#balancesheetfeedback").css("color", "red");
                                $('#balancesheetfeedback').addClass('alert alert-danger');
                                $("#balancesheetfeedback").html("Your Balance Sheet Details could not be saved" + registerstatus[1] + ".Kindly Proceed to fill in the rest details!");
                            });
                            break;
                    }
                }
                );
            } else if (result.dismiss === Swal.DismissReason.cancel) {
                Swal.fire(
                    'Balance Sheet Details Registration Cancelled',
                    'You cancelled your supplier Balance Sheet registration!',
                    'error'
                );
            }
        });

    });
    //Supplier Balance Sheet Details Function
    $(".editbtn_balancesheet_details").click(function () {
        var BalanceSheetObj = {
            "Audit_Year_Code_Reference": $("#editbaldropdownyearcodeslists").val(),
            "Total_Assets_LCY": $("#edittotalcurrentassets").val(),
            "Fixed_Assets_LCY": $("#edittotalfixedassets").val(),
            "Current_Liabilities_LCY": $("#edittotalcurrentliabilities").val(),
            "Long_term_Liabilities_LCY": $("#edittotallongtermliabilities").val(),
            "Owners_Equity_LCY": $("#edittotalownersequity").val(),
        }
        console.log(JSON.stringify(BalanceSheetObj))
        //Swal Message
        Swal.fire({
            title: "Confirm Balance Sheet Details Submission?",
            text: "Are you sure you would like to save your details?",
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
                    url: "/Home/RegisterBalanceSheetDetails",
                    type: "POST",
                    data: JSON.stringify(BalanceSheetObj),
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
                                title: "Balance Sheet Details saved!",
                                text: "Your Balance Sheet Details have been successfully submitted",
                                type: "success"
                            }).then(() => {
                                $("#balancesheetfeedback").css("display", "block");
                                $("#balancesheetfeedback").css("color", "green");
                                $('#balancesheetfeedback').attr("class", "alert alert-success");
                                $("#balancesheetfeedback").html("Your Balance Sheet Details have been successfully saved.Kindly Proceed to fill in the rest details!");
                                $("#balancesheetfeedback").css("display", "block");
                                $("#balancesheetfeedback").css("color", "green");
                                $("#balancesheetfeedback").html("Your Balance Sheet Details have been successfully saved.Kindly Proceed to fill in the rest details!");
                            });
                            VendorBalanceSheetDetails.init();
                            $('#edit_balance_sheet_details').modal('hide');                            
                            break;
                        default:
                            Swal.fire
                            ({
                                title: "Balance Sheet Details Submission Error!!!",
                                text: "Your Balance Sheet Details could not be saved" + registerstatus[1],
                                type: "error"
                            }).then(() => {
                                $("#balancesheetfeedback").css("display", "block");
                                $("#balancesheetfeedback").css("color", "red");
                                $('#balancesheetfeedback').addClass('alert alert-danger');
                                $("#balancesheetfeedback").html("Your Balance Sheet Details could not be saved" + registerstatus[1] + ".Kindly Proceed to fill in the rest details!");
                            });
                            break;
                    }
                }
                );
            } else if (result.dismiss === Swal.DismissReason.cancel) {
                Swal.fire(
                    'Balance Sheet Details Registration Cancelled',
                    'You cancelled your supplier Balance Sheet registration!',
                    'error'
                );
            }
        });

    });
    //Supplier Income Statement Details Function
    $(".btn_incomestatement_details").click(function () {
        var IncomeSatetemtnObj = {
            "Audit_Year_Code_Reference": $("#dropdownyearcodeslists").val(),
            "Total_Revenue_LCY": $("#totalrevenue").val(),
            "Total_COGS_LCY": $("#totalcogs").val(),
            "Total_Operating_Expenses_LCY": $("#totaloperatingexpenses").val(),
            "Other_Non_operating_Re_Exp_LCY": $("#othernonoperatingexpenses").val(),
            "Interest_Expense_LCY": $("#interstexpense").val(),
        }
        //Swal Message
        Swal.fire({
            title: "Confirm Income Statement Details Submission?",
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
                    url: "/Home/RegisterIncomeStatementDetails",
                    type: "POST",
                    data: JSON.stringify(IncomeSatetemtnObj),
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
                                title: "Income Statement Details Submitted!",
                                text: status,
                                type: "success"
                            }).then(() => {
                                $("#incometstatementfeedback").css("display", "block");
                                $("#incometstatementfeedback").css("color", "green");
                                $('#incometstatementfeedback').attr("class", "alert alert-success");
                                $("#incometstatementfeedback").html("Your Income Statement Details have been successfully submitted.Kindly Proceed to fill in the rest details!");
                                $("#incometstatementfeedback").css("display", "block");
                                $("#incometstatementfeedback").css("color", "green");
                                $("#incometstatementfeedback").html("Your Income Statement Details have been successfully submitted.Kindly Proceed to fill in the rest details!");
                            });
                            VendorIncomeStatementDetails.init();
                            $('#edit_incomestatement_details').modal('hide');
                            break;
                        default:
                            Swal.fire
                            ({
                                title: "Income Statement Details Submission Error!!!",
                                text: "Your Income Statement Details could not be submitted" + registerstatus[1],
                                type: "error"
                            }).then(() => {
                                $("#incometstatementfeedback").css("display", "block");
                                $("#incometstatementfeedback").css("color", "red");
                                $('#incometstatementfeedback').addClass('alert alert-danger');
                                $("#incometstatementfeedback").html("Your Income Statement Details could not be submitted" + registerstatus[1] + ".Kindly Proceed to fill in the rest details!");
                            });
                            break;
                    }
                }
                );
            } else if (result.dismiss === Swal.DismissReason.cancel) {
                Swal.fire(
                    'Income StatementDetails Registration Cancelled',
                    'You cancelled your supplier Income Statement registration submission details!',
                    'error'
                );
            }
        });

    });
    //Supplier Income Statement Details Function
    $(".editbtn_incomestatement_details").click(function () {
        var IncomeSatetemtnObj = {
            "Audit_Year_Code_Reference": $("#editdropdownyearcodeslists").val(),
            "Total_Revenue_LCY": $("#edittotalrevenue").val(),
            "Total_COGS_LCY": $("#edittotalcogs").val(),
            "Total_Operating_Expenses_LCY": $("#edittotaloperatingexpenses").val(),
            "Other_Non_operating_Re_Exp_LCY": $("#editothernonoperatingexpenses").val(),
            "Interest_Expense_LCY": $("#editinterstexpense").val(),
        }
        //Swal Message
        Swal.fire({
            title: "Confirm Income Statement Details Submission?",
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
                    url: "/Home/RegisterIncomeStatementDetails",
                    type: "POST",
                    data: JSON.stringify(IncomeSatetemtnObj),
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
                                title: "Income Statement Details Submitted!",
                                text: "Your Income Statement Details have been successfully submitted",
                                type: "success"
                            }).then(() => {
                                $("#incometstatementfeedback").css("display", "block");
                                $("#incometstatementfeedback").css("color", "green");
                                $('#incometstatementfeedback').attr("class", "alert alert-success");
                                $("#incometstatementfeedback").html("Your Income Statement Details have been successfully submitted.Kindly Proceed to fill in the rest details!");
                                $("#incometstatementfeedback").css("display", "block");
                                $("#incometstatementfeedback").css("color", "green");
                                $("#incometstatementfeedback").html("Your Income Statement Details have been successfully submitted.Kindly Proceed to fill in the rest details!");
                            });
                            VendorIncomeStatementDetails.init();
                            break;
                        default:
                            Swal.fire
                            ({
                                title: "Income Statement Details Submission Error!!!",
                                text: "Your Income Statement Details could not be submitted" + registerstatus[1] ,
                                type: "error"
                            }).then(() => {
                                $("#incometstatementfeedback").css("display", "block");
                                $("#incometstatementfeedback").css("color", "red");
                                $('#incometstatementfeedback').addClass('alert alert-danger');
                                $("#incometstatementfeedback").html("Your Income Statement Details could not be submitted" + registerstatus[1] + ".Kindly Proceed to fill in the rest details!");
                            });
                            break;
                    }
                }
                );
            } else if (result.dismiss === Swal.DismissReason.cancel) {
                Swal.fire(
                    'Income StatementDetails Registration Cancelled',
                    'You cancelled your supplier Income Statement registration submission details!',
                    'error'
                );
            }
        });

    });
    //Supplier Income Statement Details Function
    $(".btn_supplierSpecial_GroupRegister").click(function () {
        var SpeicalGroupObj = {
            "Certifcate_No": $("#certificateno").val(),
            "Registered_Specia_Group": $("#dropdownspecialgoupCategory").val(),
            "Products_Service_Category": $("#dropdownsupplierCategory").val(),
            //"Products_Service_Category": $("#servicecategory").val(),
            "Certificate_Effective_Date": $("#effectivedates").val(),
            "Certificate_Expiry_Date": $("#expirydates").val()
        }
        //Swal Message
        Swal.fire({
            title: "Confirm Special Group Details Submission?",
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
                    url: "/Home/RegisterSpecialGroupDetails",
                    type: "POST",
                    data: JSON.stringify(SpeicalGroupObj),
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
                                title: "Special Group Details Submitted!",
                                text: status,
                                type: "success"
                            }).then(() => {
                                $("#specialgroupfeedback").css("display", "block");
                                $("#specialgroupfeedback").css("color", "green");
                                $('#specialgroupfeedback').attr("class", "alert alert-success");
                                $("#specialgroupfeedback").html("Your Special Group Details have been successfully submitted.Kindly Proceed to fill in the rest details!");
                                $("#specialgroupfeedback").css("display", "block");
                                $("#specialgroupfeedback").css("color", "green");
                                $("#specialgroupfeedback").html("Your Special Group Details have been successfully submitted.Kindly Proceed to fill in the rest details!");
                            });
                            VendorIncomeStatementDetails.init();
                            break;
                        default:
                            Swal.fire
                            ({
                                title: "Special Group Details Submission Error!!!",
                                text: "Your Special Group Details could not be submitted" + registerstatus[1],
                                type: "error"
                            }).then(() => {
                                $("#specialgroupfeedback").css("display", "block");
                                $("#specialgroupfeedback").css("color", "red");
                                $('#specialgroupfeedback').addClass('alert alert-danger');
                                $("#specialgroupfeedback").html("Your Special Group Details could not be submitted" + registerstatus[1] + ".Kindly Proceed to fill in the rest details!");
                            });
                            break;
                    }
                }
                );
            } else if (result.dismiss === Swal.DismissReason.cancel) {
                Swal.fire(
                    'Special Group Details Registration Cancelled',
                    'You cancelled your supplier Special Group registration  details!',
                    'error'
                );
            }
        });

    });
    //SupplierKey Staff Personnel Details Function
    $(".btn_keypersonnel_Details").click(function () {
        var personnelsObj = {
            "StaffName": $("#keystaffname").val(),
            "StaffProfession": $("#staffprofession").val(),
            "StaffDesignation": $("#currentDesignation").val(),
            "StaffPhonenumber": $("#personnelphonenumber").val(),
            "StaffDateofBirth": $("#personnneldob").val(),
            "StaffNationality": $("#dropdownKeyCountries").val(),
            "StaffEmail": $("#personnelemailaddress").val(),
            "StaffJoiningDate": $("#personneljoiningDate").val(),
            "StaffYearswithfirm": $("#yearswithfarm").val(),
            "StaffNumber": $("#staffnumber").val(),
            "employmentType": $("#emplymentType").val(),
        }
        console.log(JSON.stringify(personnelsObj))
        //Swal Message
        Swal.fire({
            title: "Confirm Key Proffesional Staff Details Submission?",
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
                    url: "/Home/RegisterKeyPersonnelDetails",
                    type: "POST",
                    data: JSON.stringify(personnelsObj),
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
                                title: "Key Proffesional Staff Details Submitted!",
                                text: "Your Key Proffesional Staff Details have been successfully submitted ",
                                type: "success"
                            }).then(() => {
                                $("#keyprofessionalfeedback").css("display", "block");
                                $("#keyprofessionalfeedback").css("color", "green");
                                $('#keyprofessionalfeedback').attr("class", "alert alert-success");
                                $("#keyprofessionalfeedback").html("Your Key Proffesional Staff Details have been successfully submitted.Kindly Proceed to fill in the rest details!");
                                $("#keyprofessionalfeedback").css("display", "block");
                                $("#keyprofessionalfeedback").css("color", "green");
                                $("#keyprofessionalfeedback").html("Your Key Proffesional Staff Details have been successfully submitted.Kindly Proceed to fill in the rest details!");
                            });
                            vendorKeyProffessionalStaff.init();
                            $("button#nextBtn").css("display", "block");
                            break;
                        default:
                            Swal.fire
                            ({
                                title: "Key Proffesional Staff Details Submission Error!!!",
                                text: "Your Key Proffesional Staff Details could not be submitted"+" "+registerstatus[1],
                                type: "error"
                            }).then(() => {
                                $("#keyprofessionalfeedback").css("display", "block");
                                $("#keyprofessionalfeedback").css("color", "red");
                                $('#keyprofessionalfeedback').addClass('alert alert-danger');
                                $("#keyprofessionalfeedback").html("Your Key Proffesional Staff Details could not be submitted" + registerstatus[1] + ".Kindly Proceed to fill in the rest details!");
                            });
                            break;
                    }
                }
                );
            } else if (result.dismiss === Swal.DismissReason.cancel) {
                Swal.fire(
                    'Key Proffesional Staff Details Registration Cancelled',
                    'You cancelled your supplier Key Proffesional Staff registration submission details!',
                    'error'
                );
            }
        });

    });
    //Supplier PastExperience Details Function
    $(".btn_submit_pastexperience").click(function () {
        var VendorPastExperiencenObj = {
            "Client_Name": $("#clientname").val(),
            "Address": $("#clientaddress").val(),
            "Assignment_Project_Name": $("#projectname").val(),
            "Project_Scope_Summary": $("#projectscope").val(),
            "Assignment_Start_Date": $("#assignmentsendstartdate").val(),
            "Assignment_End_Date": $("#assignmentsenddate").val(),
            "Assignment_Value_LCY": $("#assignmentvalue").val(),
            "Engangement_Type": $("#engagementtype").val(),
            "Main_Contractor": $("#maincontractor").val()
        }
        var No = $("#bidnumber").val();
        var Client_Name = $("#clientname").val();
        var Address = $("#clientaddress").val();
        var Assignment_Project_Name = $("#projectname").val();
        var Project_Scope_Summary = $("#projectscope").val();
        var Assignment_Start_Date = $("#assignmentsendstartdate").val();
        var Assignment_End_Date = $("#assignmentsenddate").val();
        var Assignment_Value_LCY = $("#assignmentvalue").val();
        var Engangement_Type = $("#engagementtype").val();
        var  Main_Contractor =  $("#maincontractor").val()
        var browsedDoc = document.getElementById('inputFileselectorpast').files[0];


        var formDt = new FormData();
        formDt.append("No", No);
        formDt.append("Client_Name", Client_Name);
        formDt.append("Address", Address);
        formDt.append("Assignment_Project_Name", Assignment_Project_Name);
        formDt.append("Project_Scope_Summary", Project_Scope_Summary);
        formDt.append("Assignment_Start_Date", Assignment_Start_Date);
        formDt.append("Assignment_End_Date", Assignment_End_Date);
        formDt.append("Assignment_Value_LCY", Assignment_Value_LCY);
        formDt.append("Engangement_Type", Engangement_Type);
        formDt.append("Main_Contractor", Main_Contractor);       
        formDt.append("browsedfile", browsedDoc);
        console.log(JSON.stringify({ formdata: formDt }));       
        //Swal Message
        Swal.fire({
            title: "Confirm Past Experience Details Submission?",
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
                    url: "/Home/RegisterPastExperienceDetails",
                    type: "POST",
                    data: JSON.stringify(PastExperiencenObj),
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
                                title: "Past Experience Details Submitted!",
                                text: "Your Past Experience Details have been successfully submitted",
                                type: "success"
                            }).then(() => {
                                $("#pastexperiencefeedback").css("display", "block");
                                $("#pastexperiencefeedback").css("color", "green");
                                $('#pastexperiencefeedback').attr("class", "alert alert-success");
                                $("#pastexperiencefeedback").html("Your Past Experience Details have been successfully submitted.Kindly Proceed to fill in the rest details!");
                                $("#pastexperiencefeedback").css("display", "block");
                                $("#pastexperiencefeedback").css("color", "green");
                                $("#pastexperiencefeedback").html("Your Past Experience Details have been successfully submitted.Kindly Proceed to fill in the rest details!");

                            });
                            VendorBidPastExperienceDetails.init();
                            $('#past_experience').modal('hide');
                            break;
                        default:
                            Swal.fire
                            ({
                                title: "Past Experience Details Submission Error!!!"+ registerstatus[1],
                                text: "Your Past Experience Details could not be submitted" + registerstatus[1],
                                type: "error"
                            }).then(() => {
                                $("#pastexperiencefeedback").css("display", "block");
                                $("#pastexperiencefeedback").css("color", "red");
                                $('#pastexperiencefeedback').addClass('alert alert-danger');
                                $("#pastexperiencefeedback").html("Your Past Experience Details could not be submitted" + registerstatus[1] + ".Kindly Proceed to fill in the rest details!");
                            });
                            break;
                    }
                }
                );
            } else if (result.dismiss === Swal.DismissReason.cancel) {
                Swal.fire(
                    'Past Experience Details Cancelled',
                    'You cancelled your Past Experience submission details!',
                    'error'
                );
            }
        });

    });
    var BidResponseNumber = $("#bidnumber").val();
    var vendorNo = $("#vendorno").val();
    //Get All Past Experience  Details
    var VendorBidPastExperienceDetails = function () {
        var bidpastexperienceDetails = function () {
            var PastExperienceTable = $("#tbl_past_experience"),
                l = PastExperienceTable.dataTable({
                    lengthMenu: [[5, 15, 20, -1], [5, 15, 20, "All"]],
                    pageLength: 5,
                    language: { lengthMenu: " _MENU_ records" },
                    columnDefs: [
                        {
                            orderable: !0,
                            defaultContent: "-",
                            targets: "_all"
                        },
                        {
                            searchable: !0,
                            targets: "_all"
                        }
                    ],
                    order: [
                        [0, "asc"]
                    ],

                    bDestroy: true,
                    info: false,
                    processing: true,
                    retrieve: true
                });
            console.log("Saw this? ", BidResponseNumber)

            

            $.ajaxSetup({
                global: false,
                type: "POST",
                url: "/Home/GetVendorBideResponsPastExperience",
            });
            console.log("How about this? ", BidResponseNumber)
            $.ajax({
                data: JSON.stringify(BidResponseNumber)
            }).done(function (json) {
                l.fnClearTable();
                var o = 1;
                for (var i = 0; i < json.length; i++) {
                    l.fnAddData([
                        o++,
                        json[i].Client_Name,
                        json[i].Address,
                        json[i].Phone_No,
                        json[i].Country_Region_Code,
                        json[i].Contract_Ref_No,
                        json[i].Assignment_Value_LCY,
                        json[i].Assignment_Status,
                        '<a class="btn btn-success edit_past_experience_details"><i class="fa fa-edit m-r-10"></i>Edit</a>',
                        '<a class="btn btn-danger  delete_pastexperience_details"><i class="fa fa-trash m-r-10">Delete</a>'
                    ]);
                }
            });
            PastExperienceTable.on("click",
        ".edit_past_experience_details",
          function (e) {
              if (e.preventDefault()) {
                  var t = $(this).parents("tr")[0];
                  l.fnDeleteRow(t),
                  //put editing code here below
                  $('#add_pastexperience').modal('show');
                  //end delete code
              }
          })
            PastExperienceTable.on("click",
              ".delete_pastexperience_details",
              function (PastExperienceTable) {
                  PastExperienceTable.preventDefault();
                  var i = $(this).parents("tr")[0];
                  //alert("record to be deleted: " + i.cells[1].innerHTML);
                  BidRespNumber = $("#bidnumber").val(),
                  yearCode = i.cells[1].innerHTML
                  Swal.fire({
                      title: "Confirm Deleting Past Experience",
                      text: "Sure you'd like to proceed with deletion?",
                      type: "warning",
                      showCancelButton: true,
                      closeOnConfirm: true,
                      confirmButtonText: "Yes, Delete Past Experience!",
                      confirmButtonClass: "btn-success",
                      confirmButtonColor: "#008000",
                      position: "center"
                  }).then((result) => {
                      if (result.value) {
                          //global loader spinner;
                          $.ajaxSetup({
                              global: false,
                              type: "POST",
                              url: "/Home/DeletePastExperienceDetailsDetails",
                          });
                          $.ajax({
                              data: "{'BidRespNumber':'" + BidRespNumber + "'}",
                              contentType: "application/json",
                              cache: false,
                              processData: false
                          }).done(function (status) {
                              var registerstatus = status.split('*');
                              status = registerstatus[0];
                              console.log(JSON.stringify(status))
                              switch (status) {
                                  case "success":
                                      Swal.fire
                                      ({
                                          title: "Past Experience Details Deleted!",
                                          text: "Past Experience Details Deleted Successfully!",
                                          type: "success"
                                      }).then(() => {
                                          $("#pastexperiencefeedback").css("display", "block");
                                          $("#pastexperiencefeedback").css("color", "green");
                                          $('#pastexperiencefeedback').attr("class", "alert alert-success");
                                          $("#pastexperiencefeedback").html("Your Past Experience Details have been successfully Deleted.Kindly Proceed to fill in the rest details!");
                                          $("#pastexperiencefeedback").css("display", "block");
                                          $("#pastexperiencefeedback").css("color", "green");
                                          $("#pastexperiencefeedback").html("Your Past Experience Details have been successfully Deleted.Kindly Proceed to fill in the rest details!");
                                      });
                                      VendorBidPastExperienceDetails.init();
                                      break;
                                  default:
                                      Swal.fire
                                         ({
                                             title: "Past Experience Details Deletion Error!!!",
                                             text: status,
                                             type: "error"
                                         }).then(() => {
                                             $("#pastexperiencefeedback").css("display", "block");
                                             $("#pastexperiencefeedback").css("color", "red");
                                             $('#pastexperiencefeedback').addClass('alert alert-danger');
                                             $("#pastexperiencefeedback").html("Your Past Experience Details could not be Deleted.KindlyTy Again!");
                                         });
                              }
                          });
                      } else if (result.dismiss === Swal.DismissReason.cancel) {
                          Swal.fire(
                              'Past Experience Deletion Cancelled',
                              'You cancelled your Past Experience deletion Request!',
                              'error'
                          );
                      }
                  });

              })
        }
        return {
            init: function () {
                bidpastexperienceDetails();
            }
        }
    }();
    var vendorKeyProffessionalStaff = function () {
        var keyprofessionalstaff = function () {
            var KeyProfessionalStaffTable = $("#tbl_keystaff_details"),
                l = KeyProfessionalStaffTable.dataTable({
                    lengthMenu: [[5, 15, 20, -1], [5, 15, 20, "All"]],
                    pageLength: 5,
                    language: { lengthMenu: " _MENU_ records" },
                    columnDefs: [
                        {
                            orderable: !0,
                            defaultContent: "-",
                            targets: "_all"
                        },
                        {
                            searchable: !0,
                            targets: "_all"
                        }
                    ],
                    order: [
                        [0, "asc"]
                    ],

                    bDestroy: true,
                    info: false,
                    processing: true,
                    retrieve: true
                });
            $.ajaxSetup({
                global: false,
                type: "POST",
                url: "/Home/GetVendorKeyProffessionalStaffDetails",
            });
            $.ajax({
                data: ""
            }).done(function (json) {
                l.fnClearTable();
                //console.log(JSON.stringify({ vendorTestdata: json }));
                var o = 1;
                for (var i = 0; i < json.length; i++) {
                    l.fnAddData([
                        o++,
                        json[i].StaffNumber,
                        json[i].StaffName,
                        json[i].StaffDateofBirth,
                        json[i].StaffPhonenumber,
                        json[i].Country_Region_Code,
                        json[i].StaffEmail,
                        json[i].Years_With_the_Firm,
                        '<a class="btn btn-success edit_professionalstaff_details" id="edit_professionalstaff_details"><i class="fa fa-edit m-r-10"></i>Edit</a>',
                        '<a class="btn btn-danger delete_professionalstaff_details"><i class="fa fa-trash m-r-10">Delete</a>'
                    ]);
                }
            });
            KeyProfessionalStaffTable.on("click",
               ".edit_professionalstaff_details",
               function (KeyProfessionalStaffTable) {
                   KeyProfessionalStaffTable.preventDefault();
                   var i = $(this).parents("tr")[0];
                   // alert("record to be deleted: " + i.cells[1].innerHTML);
                   $("#editstaffnumber").val(i.cells[1].innerHTML);
                   $("#editkeystaffname").val(i.cells[2].innerHTML);
                   $("#editstaffprofession").val();
                   $("#editcurrentDesignation").val();
                   $("#editpersonneljoiningDate").val();
                   $("#edityearswithfarm").val();
                   $("#editpersonnelphonenumber").val(i.cells[4].innerHTML);
                   $("#edit_professionalkeystaff_details").modal();

               });
            KeyProfessionalStaffTable.on("click",
              ".delete_professionalstaff_details",
              function (KeyProfessionalStaffTable) {
                  KeyProfessionalStaffTable.preventDefault();
                  var i = $(this).parents("tr")[0];
                  //alert("record to be deleted: " + i.cells[1].innerHTML);
                  Swal.fire({
                      title: "Confirm Deleting Staff",
                      text: "Sure you'd like to proceed with deletion?",
                      type: "warning",
                      showCancelButton: true,
                      closeOnConfirm: true,
                      confirmButtonText: "Yes, Delete Staff!",
                      confirmButtonClass: "btn-success",
                      confirmButtonColor: "#008000",
                      position: "center"
                  }).then((result) => {
                      if (result.value) {
                          //global loader spinner;
                          $.ajaxSetup({
                              global: false,
                              type: "POST",
                              url: "/Home/DeleteKeyProffessionalStaffDetails?staffnumber=" + i.cells[1].innerHTML
                          });
                          $.ajax({
                              data: '',
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
                                          title:"Proffessional Staff Details Deleted!",
                                          text: "Proffessional Staff Details Deleted Successfully!",
                                          type: "success"
                                      }).then(() => {
                                          $("#keyprofessionalfeedback").css("display", "block");
                                          $("#keyprofessionalfeedback").css("color", "green");
                                          $('#keyprofessionalfeedback').attr("class", "alert alert-success");
                                          $("#keyprofessionalfeedback").html("Your Proffessional Staff Details have been successfully Deleted.Kindly Proceed to fill in the rest details!");
                                          $("#keyprofessionalfeedback").css("display", "block");
                                          $("#keyprofessionalfeedback").css("color", "green");
                                          $("#keyprofessionalfeedback").html("Your Proffessional Staff Details have been successfully Deleted.Kindly Proceed to fill in the rest details!");
                                      });
                                      vendorKeyProffessionalStaff.init();
                                      break;
                                  default:
                                      Swal.fire
                                         ({
                                             title:"Proffessional Staff Details Deletion Error!!!",
                                             text: status,
                                             type:"error"
                                         }).then(() => {
                                             $("#keyprofessionalfeedback").css("display", "block");
                                             $("#keyprofessionalfeedback").css("color", "red");
                                             $('#keyprofessionalfeedback').addClass('alert alert-danger');
                                             $("#keyprofessionalfeedback").html("Your Proffessional Staff Details could not be Deleted.Kindly Try Again!" + registerstatus[1]);
                                         });
                              }
                          });
                      } else if (result.dismiss === Swal.DismissReason.cancel) {
                          Swal.fire(
                              'Proffessional Staff Deletion Cancelled',
                              'You cancelled your Proffessional Staff deletion Request!',
                              'error'
                          );
                      }
                  });

              });
        }
        return {
            init: function () {
                keyprofessionalstaff();
            }
        }
    }();
    //Get All BankAccounts  Details
    var vendorbankaccounts = function () {
        var bankaccount = function () {
            var vendorBanksTable = $("#tbl_vendor_banks"),
                l = vendorBanksTable.dataTable({
                    lengthMenu: [[5, 15, 20, -1], [5, 15, 20, "All"]],
                    pageLength: 5,
                    language: { lengthMenu: " _MENU_ records" },
                    columnDefs: [
                        {
                            orderable: !0,
                            defaultContent: "-",
                            targets: "_all"
                        },
                        {
                            searchable: !0,
                            targets: "_all"
                        }
                    ],
                    order: [
                        [0, "asc"]
                    ],

                    bDestroy: true,
                    info: false,
                    processing: true,
                    retrieve: true
                });
            $.ajaxSetup({
                global: false,
                type: "POST",
                url: "/Home/GetVendorBankAccounts",
            });
            $.ajax({
                data: ""
            }).done(function (json) {
                l.fnClearTable();
                console.log(JSON.stringify({ vendorTestdata: json }));
                var o = 1;
                for (var i = 0; i < json.length; i++) {
                    l.fnAddData([
                        o++,                        
                        json[i].BankCode,
                        json[i].BankName,
                        json[i].BankAccountNo,
                        json[i].Bank_Branch_No,
                        json[i].bankBranchName,
                        json[i].CurrencyCode,                       
                        '<a class="btn btn-danger delete_bank_details"><i class="fa fa-trash m-r-10">Delete</a>'
                    ]);
                }
            });
            vendorBanksTable.on("click",
               ".edit_banks_details",
               function (vendorBanksTable) {
                   vendorBanksTable.preventDefault();
                   var i = $(this).parents("tr")[0];
                   // alert("record to be deleted: " + i.cells[1].innerHTML);
                   $("#bankcode").val(i.cells[1].innerHTML);
                   $("#bankname").val(i.cells[2].innerHTML);
                   $("#dropdownCountries").val(i.cells[3].innerHTML);
                   $("#bankaccountno").val(i.cells[5].innerHTML);
                   $("#currencyCode").val(i.cells[4].innerHTML);
                   $("#bankbranchno").val(i.cells[5].innerHTML);
                   $("#phonenumber").val("");
                   $("#ddlbankcodes").val(i.cells[6].innerHTML);
                   $("#add_banks").modal();

               });
            vendorBanksTable.on("click",
              ".delete_bank_details",
              function (vendorBanksTable) {
                  vendorBanksTable.preventDefault();
                  var i = $(this).parents("tr")[0];
                  //alert("record to be deleted: " + i.cells[1].innerHTML);
                  Swal.fire({
                      title: "Confirm Deleting Bank",
                      text: "Sure you'd like to proceed with deletion?",
                      type: "warning",
                      showCancelButton: true,
                      closeOnConfirm: true,
                      confirmButtonText: "Yes, Delete Bank!",
                      confirmButtonClass: "btn-success",
                      confirmButtonColor: "#008000",
                      position: "center"
                  }).then((result) => {
                      if (result.value) {
                          //global loader spinner;
                          $.ajaxSetup({
                              global: false,
                              type: "POST",
                              url: "/Home/DeleteBankDetails?bankcode=" + i.cells[1].innerHTML
                          });
                          $.ajax({
                              data: '',
                              contentType: "application/json",
                              cache: false,
                              processData: false
                          }).done(function (status) {
                              var registerstatus = status.split('*');
                              status = registerstatus[0];
                              console.log(JSON.stringify(status))
                              switch (status) {
                                  case "success":
                                      Swal.fire
                                      ({
                                          title: "Bank Details Deleted!",
                                          text: "Bank Details Deleted Successfully!",
                                          type: "success"
                                      }).then(() => {
                                          $("#banksfeedback").css("display", "block");
                                          $("#banksfeedback").css("color", "green");
                                          $('#banksfeedback').attr("class", "alert alert-success");
                                          $("#banksfeedback").html("Your Bank Details have been successfully Deleted.Kindly Proceed to fill in the rest details!");
                                          $("#banksfeedback").css("display", "block");
                                          $("#banksfeedback").css("color", "green");
                                          $("#banksfeedback").html("Your Bank Details have been successfully Deleted.Kindly Proceed to fill in the rest details!");
                                      });
                                      vendorbankaccounts.init();
                                      break;
                                  default:
                                      Swal.fire
                                         ({
                                             title: "Bank Details Deletion Error!!!",
                                             text: status,
                                             type: "error"
                                         }).then(() => {
                                             $("#banksfeedback").css("display", "block");
                                             $("#banksfeedback").css("color", "red");
                                             $('#banksfeedback').addClass('alert alert-danger');
                                             $("#banksfeedback").html("Your Banks Details could not be Deleted.KindlyTy Again!");
                                         });
                              }
                          });
                      } else if (result.dismiss === Swal.DismissReason.cancel) {
                          Swal.fire(
                              'Bank Deletion Cancelled',
                              'You cancelled your bank deletion Request!',
                              'error'
                          );
                      }
                  });

              });
        }
        return {
            init: function () {
                bankaccount();
            }
        }
    }();
    function EditBankDetails(bankcode, bankname, countries, bankaccountno, currencyCode, bankbranchno, phonenumber, postcode) {
        $("#bankcode").val(bankcode);
        $("#bankname").val(bankname);
        $("#dropdownCountries").val(countries);
        $("#bankaccountno").val(bankaccountno);
        $("#currencyCode").val(currencyCode);
        $("#bankbranchno").val(bankbranchno);
        $("#phonenumber").val(phonenumber);
        $("#dropdownallpostacodes30").val(postcode);
        $("#add_banks").modal();
    }
    //Get All Shareholder  Details
    var VendorshareholderDetails = function () {
        var shareholders = function () {
            var shareholdersTable = $("#tbl_shareholder_Details"),
                l = shareholdersTable.dataTable({
                    lengthMenu: [[5, 15, 20, -1], [5, 15, 20, "All"]],
                    pageLength: 5,
                    language: { lengthMenu: " _MENU_ records" },
                    columnDefs: [
                        {
                            orderable: !0,
                            defaultContent: "-",
                            targets: "_all"
                        },
                        {
                            searchable: !0,
                            targets: "_all"
                        }
                    ],
                    order: [
                        [0, "asc"]
                    ],

                    bDestroy: true,
                    info: false,
                    processing: true,
                    retrieve: true
                });
            $.ajaxSetup({
                global: false,
                type: "POST",
                url: "/Home/GetShareholders",
            });
            console.log("Testing here!")
            $.ajax({
                data: ""
            }).done(function (json) {
                l.fnClearTable();
                var o = 1;
                for (var i = 0; i < json.length; i++) {
                    l.fnAddData([
                        o++,
                        json[i].Entry_No,
                        json[i].Fullname,
                        json[i].Nationality,
                        json[i].CitizenshipType,
                        json[i].OwnershipPercentage,
                        json[i].Phonenumber,
                        '<a class="btn btn-success edit_shareholders" href=""><i class="fa fa-edit  m-r-10"></i>Edit</a>',
                        '<a class="btn btn-danger  delete_shareholder"><i class="fa fa-trash  m-r-10">Delete</a>'
                    ]);
                }
            });
            shareholdersTable.on("click",
            ".edit_shareholders",
            function (shareholdersTable) {
                shareholdersTable.preventDefault();
                var i = $(this).parents("tr")[0];
                // alert("record to be deleted: " + i.cells[1].innerHTML);
                $("#directorname").val(i.cells[1].innerHTML);
                $("#idnumbers").val("");
                $("#citizenship").val(i.cells[3].innerHTML);
                $("#ownershippercentage").val(i.cells[4].innerHTML);
                $("#phonenumbers").val(i.cells[5].innerHTML);
                $("#shareholderaddress").val(i.cells[6].innerHTML);
                $("#add_shareholders").modal();

            });
            shareholdersTable.on("click",
           ".delete_shareholder",
           function (shareholdersTable) {
               shareholdersTable.preventDefault();
               var i = $(this).parents("tr")[0];
               //alert("record to be deleted: " + i.cells[1].innerHTML);
               Swal.fire({
                   title: "Confirm Deleting Shareholder",
                   text: "Sure you'd like to proceed with deletion?",
                   type: "warning",
                   showCancelButton: true,
                   closeOnConfirm: true,
                   confirmButtonText: "Yes, Delete Shareholder!",
                   confirmButtonClass: "btn-success",
                   confirmButtonColor: "#008000",
                   position: "center"
               }).then((result) => {
                   if (result.value) {
                       //global loader spinner;
                       $.ajaxSetup({
                           global: false,
                           type: "POST",
                           url: "/Home/DeleteShareholdersDetails?shareholderCode=" + i.cells[1].innerHTML
                       });
                       $.ajax({
                           data: '',
                           contentType: "application/json",
                           cache: false,
                           processData: false
                       }).done(function (status) {
                           var registerstatus = status.split('*');
                           status = registerstatus[0];
                           console.log(JSON.stringify(status))
                           switch (status) {
                               case "success":
                                   Swal.fire
                                   ({
                                       title: "Shareholder Details Deleted!",
                                       text: "Shareholder Deleted Successfully Deleted!",
                                       type: "success"
                                   }).then(() => {
                                       $("#shareholdersfeedback").css("display", "block");
                                       $("#shareholdersfeedback").css("color", "green");
                                       $('#shareholdersfeedback').attr("class", "alert alert-success");
                                       $("#shareholdersfeedback").html("Your Shareholders Details have been successfully Deleted.Kindly Proceed to fill in the rest details!");
                                       $("#shareholdersfeedback").css("display", "block");
                                       $("#shareholdersfeedback").css("color", "green");
                                       $("#shareholdersfeedback").html("Your Shareholders Details have been successfully Deleted.Kindly Proceed to fill in the rest details!");
                                   });
                                   VendorshareholderDetails.init();
                                   break;
                               default:
                                   Swal.fire
                                      ({
                                          title: "Shareholder Details Deletion Error!!!",
                                          text: status,
                                          type: "error"
                                      }).then(() => {
                                          $("#shareholdersfeedback").css("display", "block");
                                          $("#shareholdersfeedback").css("color", "red");
                                          $('#shareholdersfeedback').addClass('alert alert-danger');
                                          $("#shareholdersfeedback").html("Your Shareholder Details could not be Deleted.Kindly Try Again!");
                                      });
                           }
                       });
                   } else if (result.dismiss === Swal.DismissReason.cancel) {
                       Swal.fire(
                           'Shareholder Details Deletion Cancelled',
                           'You cancelled your shareholder details deletion Request!',
                           'error'
                       );
                       VendorshareholderDetails.init();
                   }
               });

           });
        }
        return {
            init: function () {
                shareholders();
            }
        }
    }();

    //Get All Beneficiaries  Details
    var VendorbeneficiaryDetails = function () {
        var beneficiaries = function () {
            var beneficiariesTable = $("#tbl_Beneficiary_Details"),
                l = beneficiariesTable.dataTable({
                    lengthMenu: [[5, 15, 20, -1], [5, 15, 20, "All"]],
                    pageLength: 5,
                    language: { lengthMenu: " _MENU_ records" },
                    columnDefs: [
                        {
                            orderable: !0,
                            defaultContent: "-",
                            targets: "_all"
                        },
                        {
                            searchable: !0,
                            targets: "_all"
                        }
                    ],
                    order: [
                        [0, "asc"]
                    ],

                    bDestroy: true,
                    info: false,
                    processing: true,
                    retrieve: true
                });
            $.ajaxSetup({
                global: false,
                type: "POST",
                url: "/Home/GetBeneficiaryDetails",
            });
            $.ajax({
                data: ""
            }).done(function (json) {
                l.fnClearTable();
                var o = 1;
                for (var i = 0; i < json.length; i++) {
                    l.fnAddData([
                        o++,
                        //json[i].Entry_No,
                        json[i].Name,
                        json[i].BeneficiaryType,
                        json[i].idpassportNumber,
                        json[i].Phonenumber,
                        json[i].Email,
                        json[i].AllocatedShares,
                        '<a class="btn btn-success edit_beneficiaries" href=""><i class="fa fa-edit  m-r-10"></i>Edit</a>',
                        '<a class="btn btn-danger  delete_beneficiarie"><i class="fa fa-trash  m-r-10">Delete</a>'
                    ]);
                }
            });
            beneficiariesTable.on("click",
            ".edit_beneficiaries",
            function (beneficiariesTable) {
                beneficiariesTable.preventDefault();
                var i = $(this).parents("tr")[0];
                // alert("record to be deleted: " + i.cells[1].innerHTML);
                $("#beneficiaryname").val(i.cells[1].innerHTML);
                $("#beneficiarytype").val(i.cells[2].innerHTML);
                $("#beneficiaryidnumbers").val(i.cells[3].innerHTML);
                $("#beneficiaryPhoneNumber").val(i.cells[4].innerHTML);
                $("#beneficiaryemailaddress").val(i.cells[5].innerHTML);
                $("#allocatedShares").val(i.cells[6].innerHTML);
                $("#add_beneficiaries").modal();

            });
            beneficiariesTable.on("click",
           ".delete_beneficiary",
           function (beneficiariesTable) {
               beneficiariesTable.preventDefault();
               var i = $(this).parents("tr")[0];
               //alert("record to be deleted: " + i.cells[1].innerHTML);
               Swal.fire({
                   title: "Confirm Deleting Beneficiary",
                   text: "Sure you'd like to proceed with deletion?",
                   type: "warning",
                   showCancelButton: true,
                   closeOnConfirm: true,
                   confirmButtonText: "Yes, Delete Shareholder!",
                   confirmButtonClass: "btn-success",
                   confirmButtonColor: "#008000",
                   position: "center"
               }).then((result) => {
                   if (result.value) {
                       //global loader spinner;
                       $.ajaxSetup({
                           global: false,
                           type: "POST",
                           url: "/Home/DeleteBeneficiaryDetails?beneficiaryCode=" + i.cells[1].innerHTML
                       });
                       $.ajax({
                           data: '',
                           contentType: "application/json",
                           cache: false,
                           processData: false
                       }).done(function (status) {
                           var registerstatus = status.split('*');
                           status = registerstatus[0];
                           console.log(JSON.stringify(status))
                           switch (status) {
                               case "success":
                                   Swal.fire
                                   ({
                                       title: "Beneficiary Details Deleted!",
                                       text: "Beneficiary Deleted Successfully Deleted!",
                                       type: "success"
                                   }).then(() => {
                                       $("#shareholdersfeedback").css("display", "block");
                                       $("#shareholdersfeedback").css("color", "green");
                                       $('#shareholdersfeedback').attr("class", "alert alert-success");
                                       $("#shareholdersfeedback").html("Your Beneficiary Details have been successfully Deleted.Kindly Proceed to fill in the rest details!");
                                       $("#shareholdersfeedback").css("display", "block");
                                       $("#shareholdersfeedback").css("color", "green");
                                       $("#shareholdersfeedback").html("Your Beneficiary Details have been successfully Deleted.Kindly Proceed to fill in the rest details!");
                                   });
                                   VendorshareholderDetails.init();
                                   break;
                               default:
                                   Swal.fire
                                      ({
                                          title: "Beneficiary Details Deletion Error!!!",
                                          text: status,
                                          type: "error"
                                      }).then(() => {
                                          $("#shareholdersfeedback").css("display", "block");
                                          $("#shareholdersfeedback").css("color", "red");
                                          $('#shareholdersfeedback').addClass('alert alert-danger');
                                          $("#shareholdersfeedback").html("Your Beneficiary Details could not be Deleted.Kindly Try Again!");
                                      });
                           }
                       });
                   } else if (result.dismiss === Swal.DismissReason.cancel) {
                       Swal.fire(
                           'Beneficiary Details Deletion Cancelled',
                           'You cancelled your Beneficiary details deletion Request!',
                           'error'
                       );
                   }
               });

           });
        }
        return {
            init: function () {
                beneficiaries();
            }
        }
    }();
    //Get All Litigation History  Details
    var VendorLitigationDetails = function () {
        var litigationhistory = function () {
            var litigationTable = $("#tbl_litigation_history"),
                l = litigationTable.dataTable({
                    lengthMenu: [[5, 15, 20, -1], [5, 15, 20, "All"]],
                    pageLength: 5,
                    language: { lengthMenu: " _MENU_ records" },
                    columnDefs: [
                        {
                            orderable: !0,
                            defaultContent: "-",
                            targets: "_all"
                        },
                        {
                            searchable: !0,
                            targets: "_all"
                        }
                    ],
                    order: [
                        [0, "asc"]
                    ],

                    bDestroy: true,
                    info: false,
                    processing: true,
                    retrieve: true
                });
            $.ajaxSetup({
                global: false,
                type: "POST",
                url: "/Home/GetVendorLitigationHistory",
            });
            $.ajax({
                data: ""
            }).done(function (json) {
                l.fnClearTable();
                var o = 1;
                for (var i = 0; i < json.length; i++) {
                    l.fnAddData([
                        //o++,
                        json[i].Entry_No,
                        json[i].CategoryofDispute,
                        json[i].DisputeDescription,
                        json[i].TheotherDisputeparty,
                        json[i].DisputeAmount,
                        json[i].Year,
                        json[i].AwardType,
                        '<a class="btn btn-success edit_litigation"><i class="fa fa-edit m-r-10"></i>Edit</a>',
                        '<a class="btn btn-danger delete_litigation"><i class="fa fa-trash m-r-10">Delete</a>'
                    ]);
                }
            });
            litigationTable.on("click",
           ".edit_litigation",
           function (litigationTable) {
               litigationTable.preventDefault();
               var i = $(this).parents("tr")[0];
               // alert("record to be deleted: " + i.cells[1].innerHTML);
               $("#disputecategory").val(i.cells[1].innerHTML);
               $("#disputedescription").val(i.cells[2].innerHTML);
               $("#disputeamounts").val(i.cells[4].innerHTML);
               $("#disputeparties").val(i.cells[3].innerHTML);
               $("#litigationyear").val(i.cells[5].innerHTML);
               $("#awardtype").val(i.cells[6].innerHTML);
               $("#add_litigation").modal();
           });
            litigationTable.on("click",
         ".delete_litigation",
         function (litigationTable) {
             litigationTable.preventDefault();
             var i = $(this).parents("tr")[0];
             //alert("record to be deleted: " + i.cells[1].innerHTML);
             Swal.fire({
                 title: "Confirm Deleting Litigation History",
                 text: "Sure you'd like to proceed with deletion?",
                 type: "warning",
                 showCancelButton: true,
                 closeOnConfirm: true,
                 confirmButtonText: "Yes, Delete Litigation History!",
                 confirmButtonClass: "btn-success",
                 confirmButtonColor: "#008000",
                 position: "center"
             }).then((result) => {
                 if (result.value) {
                     //global loader spinner;
                     $.ajaxSetup({
                         global: false,
                         type: "POST",
                         url: "/Home/DeleteLitigationHistoryDetails?litigationCode=" + i.cells[0].innerHTML
                     });
                     $.ajax({
                         data: '',
                         contentType: "application/json",
                         cache: false,
                         processData: false
                     }).done(function (status) {
                         var registerstatus = status.split('*');
                         status = registerstatus[0];
                         console.log(JSON.stringify(status))
                         switch (status) {
                             case "success":
                                 Swal.fire
                                 ({
                                     title: "Litigation History Details Deleted!",
                                     text: "Litigation History Deleted Successfully!",
                                     type: "success"
                                 }).then(() => {
                                     $("#litigationfeedback").css("display", "block");
                                     $("#litigationfeedback").css("color", "green");
                                     $('#litigationfeedback').attr("class", "alert alert-success");
                                     $("#litigationfeedback").html("Your Litigation History Details have been successfully Deleted.Kindly Proceed to fill in the rest details!");
                                     $("#litigationfeedback").css("display", "block");
                                     $("#litigationfeedback").css("color", "green");
                                     $("#litigationfeedback").html("Your Litigation History Details have been successfully Deleted.Kindly Proceed to fill in the rest details!");
                                 });
                                 VendorLitigationDetails.init();
                                 break;
                             default:
                                 Swal.fire
                                    ({
                                        title: "Litigation History Details Deletion Error!!!",
                                        text: status,
                                        type: "error"
                                    }).then(() => {
                                        $("#litigationfeedback").css("display", "block");
                                        $("#litigationfeedback").css("color", "red");
                                        $('#litigationfeedback').addClass('alert alert-danger');
                                        $("#litigationfeedback").html("Your Litigation History Details could not be Deleted.Kindly Try Again!");
                                    });
                         }
                     });
                 } else if (result.dismiss === Swal.DismissReason.cancel) {
                     Swal.fire(
                         'Litigation History Details Deletion Cancelled',
                         'You cancelled your Litigation History details deletion Request!',
                         'error'
                     );
                 }
             });

         });
        }
        return {
            init: function () {
                litigationhistory();
            }
        }
    }();
    //Get All Past Experience  Details
    var VendorPastExperienceDetails = function () {
        var pastexperienceDetails = function () {
            var PastExperienceTable = $("#tbl_past_Experience"),
                l = PastExperienceTable.dataTable({
                    lengthMenu: [[5, 15, 20, -1], [5, 15, 20, "All"]],
                    pageLength: 5,
                    language: { lengthMenu: " _MENU_ records" },
                    columnDefs: [
                        {
                            orderable: !0,
                            defaultContent: "-",
                            targets: "_all"
                        },
                        {
                            searchable: !0,
                            targets: "_all"
                        }
                    ],
                    order: [
                        [0, "asc"]
                    ],

                    bDestroy: true,
                    info: false,
                    processing: true,
                    retrieve: true
                });
            PastExperienceTable.on("click",
           ".edit_past_epexrience",
       function (e) {
           if (e.preventDefault()) {
               var t = $(this).parents("tr")[0];
               l.fnDeleteRow(t),
               //put editing code here below
               $('#add_pastexperience').modal('show');
               //end delete code
           }
       })
            PastExperienceTable.on("click",
               ".delete_pastexperience",
           function (e) {
               if (e.preventDefault()) {
                   var t = $(this).parents("tr")[0];
                   l.fnDeleteRow(t),
                   //put editing code here below
                   $('#delete_pastexperience_modal').modal('show');
                   //end delete code
               }
           })
            $.ajaxSetup({
                global: false,
                type: "POST",
                url: "/Home/GetVendorPastExperience",
            });
            console.log("Testing ...")
            $.ajax({
                data: ""
            }).done(function (json) {
                l.fnClearTable();
                console.log(JSON.stringify({ vendorTestdata: json }));
                var o = 1;
                for (var i = 0; i < json.length; i++) {
                    l.fnAddData([
                      //  o++,
                        json[i].Entry_No,
                        json[i].Client_Name,
                        json[i].Address,
                        json[i].Assignment_Project_Name,
                        json[i].Assignment_Start_Date,
                        json[i].Assignment_End_Date,
                        '<a class="btn btn-success edit_past_epexrience"><i class="fa fa-edit m-r-10"></i>Edit</a>',
                        '<a class="btn btn-danger  delete_pastexperience"><i class="fa fa-trash m-r-10">Delete</a>'
                    ]);
                }
            });
            PastExperienceTable.on("click",
           ".edit_past_epexrience",
          function (PastExperienceTable) {
              PastExperienceTable.preventDefault();
              var i = $(this).parents("tr")[0];
              // alert("record to be deleted: " + i.cells[1].innerHTML);
              $("#clientname").val(i.cells[2].innerHTML);
              $("#projectassignment").val(i.cells[4].innerHTML);
              $("#projectstartdate").val(i.cells[5].innerHTML);
              $("#experienceaddress").val(i.cells[3].innerHTML);
              $("#projectenddate").val(i.cells[6].innerHTML);
              $("#projectscopes").val("");
              $("#add_pastexperience").modal();
          });
            PastExperienceTable.on("click",
      ".delete_pastexperience",
        function (PastExperienceTable) {
            PastExperienceTable.preventDefault();
            var i = $(this).parents("tr")[0];
            //alert("record to be deleted: " + i.cells[1].innerHTML);
            Swal.fire({
                title: "Confirm Deleting Past Experience",
                text: "Sure you'd like to proceed with deletion?",
                type: "warning",
                showCancelButton: true,
                closeOnConfirm: true,
                confirmButtonText: "Yes, Delete Past Experience!",
                confirmButtonClass: "btn-success",
                confirmButtonColor: "#008000",
                position: "center"
            }).then((result) => {
                if (result.value) {
                    //global loader spinner;
                    $.ajaxSetup({
                        global: false,
                        type: "POST",
                        url: "/Home/DeletePastExperienceDetails?pastExperienceCode=" + i.cells[0].innerHTML
                    });
                    $.ajax({
                        data: '',
                        contentType: "application/json",
                        cache: false,
                        processData: false
                    }).done(function (status) {
                        var registerstatus = status.split('*');
                        status = registerstatus[0];
                        console.log(JSON.stringify(status))
                        switch (status) {
                            case "success":
                                Swal.fire
                                ({
                                    title: "Past Experience Details Deleted!",
                                    text: "Past Experience Deleted Successfully!",
                                    type: "success"
                                }).then(() => {
                                    $("#pastexperiencefeedback").css("display", "block");
                                    $("#pastexperiencefeedback").css("color", "green");
                                    $('#pastexperiencefeedback').attr("class", "alert alert-success");
                                    $("#pastexperiencefeedback").html("Your Past Experience Details have been successfully Deleted.Kindly Proceed to fill in the rest details!");
                                    $("#pastexperiencefeedback").css("display", "block");
                                    $("#pastexperiencefeedback").css("color", "green");
                                    $("#pastexperiencefeedback").html("Your Past Experience Details have been successfully Deleted.Kindly Proceed to fill in the rest details!");
                                });
                                VendorPastExperienceDetails.init();
                                break;
                            default:
                                Swal.fire
                                   ({
                                       title: "Past Experience Details Deletion Error!!!",
                                       text: status,
                                       type: "error"
                                   }).then(() => {
                                       $("#pastexperiencefeedback").css("display", "block");
                                       $("#pastexperiencefeedback").css("color", "red");
                                       $('#pastexperiencefeedback').addClass('alert alert-danger');
                                       $("#pastexperiencefeedback").html("Your Past Experience Details could not be Deleted.Kindly Try Again!");
                                   });
                        }
                    });
                } else if (result.dismiss === Swal.DismissReason.cancel) {
                    Swal.fire(
                        'Past Experience Details Deletion Cancelled',
                        'You cancelled your Past Experience details deletion Request!',
                        'error'
                    );
                }
            });

        });
        }
        return {
            init: function () {
                pastexperienceDetails();
            }
        }
    }();
    //Get All Balance Sheet Details
    var VendorBalanceSheetDetails = function () {
        var BalanceSheetDetails = function () {
            var BalanceSheetTable = $("#tab_balancesheet_details"),
                l = BalanceSheetTable.dataTable({
                    lengthMenu: [[5, 15, 20, -1], [5, 15, 20, "All"]],
                    pageLength: 5,
                    language: { lengthMenu: " _MENU_ records" },
                    columnDefs: [
                        {
                            orderable: !0,
                            defaultContent: "-",
                            targets: "_all"
                        },
                        {
                            searchable: !0,
                            targets: "_all"
                        }
                    ],
                    order: [
                        [0, "asc"]
                    ],

                    bDestroy: true,
                    info: false,
                    processing: true,
                    retrieve: true
                });

            $.ajaxSetup({
                global: false,
                type: "POST",
                url: "/Home/GetBalanceSheetDetails",
            });
            $.ajax({
                data: ""
            }).done(function (json) {
                l.fnClearTable();
                console.log(JSON.stringify({ vendorTestdata: json }));
                var o = 1;
                for (var i = 0; i < json.length; i++) {
                    l.fnAddData([
                        o++,
                        json[i].Audit_Year_Code_Reference,
                        json[i].Current_Assets_LCY,
                        json[i].Fixed_Assets_LCY,
                        json[i].Current_Liabilities_LCY,
                        json[i].Long_term_Liabilities_LCY,
                        json[i].Owners_Equity_LCY,
                        '<a class="btn btn-success edit_balance_sheet" href=""><i class="fa fa-edit m-r-10"></i>Edit</a>',
                        '<a class="btn btn-danger delete_balance_sheet"  href=""><i class="fa fa-trash m-r-10">Delete</a>'
                    ]);
                }
            });
            BalanceSheetTable.on("click",
        ".edit_balance_sheet",
       function (BalanceSheetTable) {
          BalanceSheetTable.preventDefault();
          var i = $(this).parents("tr")[0];
          // alert("record to be deleted: " + i.cells[1].innerHTML);
          $("#ddlyearcodes").val(i.cells[1].innerHTML);
          $("#edittotalcurrentassets").val(i.cells[2].innerHTML);
          $("#edittotalfixedassets").val(i.cells[3].innerHTML);
          $("#edittotalcurrentliabilities").val(i.cells[4].innerHTML);
          $("#edittotallongtermliabilities").val(i.cells[5].innerHTML);
          $("#edittotalownersequity").val(i.cells[6].innerHTML);
          $("#edit_balance_sheet_details").modal();
      });
            BalanceSheetTable.on("click",
      ".delete_balance_sheet",
        function (BalanceSheetTable) {
            BalanceSheetTable.preventDefault();
            var i = $(this).parents("tr")[0];
            //alert("record to be deleted: " + i.cells[1].innerHTML);
            Swal.fire({
                title: "Confirm Deleting Balance Sheet Details",
                text: "Sure you'd like to proceed with deletion?",
                type: "warning",
                showCancelButton: true,
                closeOnConfirm: true,
                confirmButtonText: "Yes, Delete Balance Sheet Detail!",
                confirmButtonClass: "btn-success",
                confirmButtonColor: "#008000",
                position: "center"
            }).then((result) => {
                if (result.value) {
                    //global loader spinner;
                    $.ajaxSetup({
                        global: false,
                        type: "POST",
                        url: "/Home/DeleteBalanceSheetDetails?yearCode=" + i.cells[1].innerHTML
                    });
                    $.ajax({
                        data: '',
                        contentType: "application/json",
                        cache: false,
                        processData: false
                    }).done(function (status) {
                        var registerstatus = status.split('*');
                        status = registerstatus[0];
                        console.log(JSON.stringify(status))
                        switch (status) {
                            case "success":
                                Swal.fire
                                ({
                                    title: "Balance Sheet Details Deleted!",
                                    text: "Balance Sheet  Deleted Successfully!",
                                    type: "success"
                                }).then(() => {
                                    $("#balancesheetfeedback").css("display", "block");
                                    $("#balancesheetfeedback").css("color", "green");
                                    $('#balancesheetfeedback').attr("class", "alert alert-success");
                                    $("#balancesheetfeedback").html("Your Balance Sheet  Details have been successfully Deleted.Kindly Proceed to fill in the rest details!");
                                    $("#balancesheetfeedback").css("display", "block");
                                    $("#balancesheetfeedback").css("color", "green");
                                    $("#balancesheetfeedback").html("Your Balance Sheet  Details have been successfully Deleted.Kindly Proceed to fill in the rest details!");
                                });
                                VendorBalanceSheetDetails.init();
                                break;
                            default:
                                Swal.fire
                                   ({
                                       title: "Balance Sheet Details Deletion Error!!!",
                                       text: status,
                                       type: "error"
                                   }).then(() => {
                                       $("#balancesheetfeedback").css("display", "block");
                                       $("#balancesheetfeedback").css("color", "red");
                                       $('#balancesheetfeedback').addClass('alert alert-danger');
                                       $("#balancesheetfeedback").html("Your Balance Sheet  Details could not be Deleted.Kindly Try Again!");
                                   });
                        }
                    });
                } else if (result.dismiss === Swal.DismissReason.cancel) {
                    Swal.fire(
                        'Balance Sheet Details Deletion Cancelled',
                        'You cancelled your Balance Sheet details deletion Request!',
                        'error'
                    );
                }
            });
        });
        }
        return {
            init: function () {
                BalanceSheetDetails();
            }
        }
    }();
    //Get All Balance Sheet Details
    var VendorIncomeStatementDetails = function () {
        var IncomeStatetementDetails = function () {
            var IncomeStatementTable = $("#tb_incomestattement_Details"),
                l = IncomeStatementTable.dataTable({
                    lengthMenu: [[5, 15, 20, -1], [5, 15, 20, "All"]],
                    pageLength: 5,
                    language: { lengthMenu: " _MENU_ records" },
                    columnDefs: [
                        {
                            orderable: !0,
                            defaultContent: "-",
                            targets: "_all"
                        },
                        {
                            searchable: !0,
                            targets: "_all"
                        }
                    ],
                    order: [
                        [0, "asc"]
                    ],

                    bDestroy: true,
                    info: false,
                    processing: true,
                    retrieve: true
                });

            $.ajaxSetup({
                global: false,
                type: "POST",
                url: "/Home/GetIncomeStatementSheetDetails",
            });
            $.ajax({
                data: ""
            }).done(function (json) {
                l.fnClearTable();
                var o = 1;
                for (var i = 0; i < json.length; i++) {
                    l.fnAddData([
                        o++,
                        json[i].Audit_Year_Code_Reference,
                        json[i].Total_Revenue_LCY,
                        json[i].Total_COGS_LCY,
                        json[i].Total_Operating_Expenses_LCY,
                        json[i].Other_Non_operating_Re_Exp_LCY,
                        json[i].Interest_Expense_LCY,
                        '<a class="btn btn-success edit_incomestatement_details" href=""><i class="fa fa-edit m-r-10"></i>Edit</a>',
                        '<a class="btn btn-danger delete_incomestatement_details" href=""><i class="fa fa-trash m-r-10">Delete</a>'
                    ]);
                }
            });
       IncomeStatementTable.on("click",
        ".edit_incomestatement_details",
        function (IncomeStatementTable) {
            IncomeStatementTable.preventDefault();
            var i = $(this).parents("tr")[0];
            // alert("record to be deleted: " + i.cells[1].innerHTML);
            $("#dropdownyearcodeslists").val(i.cells[1].innerHTML);
            $("#edittotalrevenue").val(i.cells[2].innerHTML);
            $("#edittotalcogs").val(i.cells[3].innerHTML);
            $("#edittotaloperatingexpenses").val(i.cells[3].innerHTML);
            $("#editothernonoperatingexpenses").val(i.cells[4].innerHTML);
            $("#editinterstexpense").val(i.cells[5].innerHTML);
            $("#edit_incomestatement_details").modal();
        });
        IncomeStatementTable.on("click",
        ".delete_incomestatement_details",
       function (IncomeStatementTable) {
           IncomeStatementTable.preventDefault();
           var i = $(this).parents("tr")[0];
           //alert("record to be deleted: " + i.cells[1].innerHTML);
           Swal.fire({
               title: "Confirm Deleting Income Statament",
               text: "Sure you'd like to proceed with deletion?",
               type: "warning",
               showCancelButton: true,
               closeOnConfirm: true,
               confirmButtonText: "Yes, Delete Income Statement!",
               confirmButtonClass: "btn-success",
               confirmButtonColor: "#008000",
               position: "center"
           }).then((result) => {
               if (result.value) {
                   //global loader spinner;
                   $.ajaxSetup({
                       global: false,
                       type: "POST",
                       url: "/Home/DeleteIncomeStatementDetails?yearCode=" + i.cells[1].innerHTML
                   });
                   $.ajax({
                       data: '',
                       contentType: "application/json",
                       cache: false,
                       processData: false
                   }).done(function (status) {
                       var registerstatus = status.split('*');
                       status = registerstatus[0];
                       console.log(JSON.stringify(status))
                       switch (status) {
                           case "success":
                               Swal.fire
                               ({
                                   title: "Income Statement Details Deleted!",
                                   text: "Income Statement  Deleted Successfully!",
                                   type: "success"
                               }).then(() => {
                                   $("#incometstatementfeedback").css("display", "block");
                                   $("#incometstatementfeedback").css("color", "green");
                                   $('#incometstatementfeedback').attr("class", "alert alert-success");
                                   $("#incometstatementfeedback").html("Your Income Statement  Details have been successfully Deleted.Kindly Proceed to fill in the rest details!");
                                   $("#incometstatementfeedback").css("display", "block");
                                   $("#incometstatementfeedback").css("color", "green");
                                   $("#incometstatementfeedback").html("Your Income Statement Details have been successfully Deleted.Kindly Proceed to fill in the rest details!");
                               });
                               VendorIncomeStatementDetails.init();
                               break;
                           default:
                               Swal.fire
                                  ({
                                      title: "Income Statement Details Deletion Error!!!",
                                      text: status,
                                      type: "error"
                                  }).then(() => {
                                      $("#incometstatementfeedback").css("display", "block");
                                      $("#incometstatementfeedback").css("color", "red");
                                      $('#incometstatementfeedback').addClass('alert alert-danger');
                                      $("#incometstatementfeedback").html("Your Income Statement Details could not be Deleted.Kindly Try Again!");
                                  });
                       }
                   });
               } else if (result.dismiss === Swal.DismissReason.cancel) {
                   Swal.fire(
                       'Income Statement Details Deletion Cancelled',
                       'You cancelled your Income Statement details deletion Request!',
                       'error'
                   );
               }
           });
       });
        }
        return {
            init: function () {
                IncomeStatetementDetails();
            }
        }
    }();
    function EditBankDetails(bankcode, bankname, countries, bankaccountno, currencyCode, bankbranchno, phonenumber, postcode) {
        $("#bankcode").val(bankcode);
        $("#bankname").val(bankname);
        $("#dropdownCountries").val(countries);
        $("#bankaccountno").val(bankaccountno);
        $("#currencyCode").val(currencyCode);
        $("#bankbranchno").val(bankbranchno);
        $("#phonenumber").val(phonenumber);
        $("#dropdownallpostacodes30").val(postcode);
        $("#add_banks").modal();
    }
    function EditPastExperienceDetails1(Client_Name, Address, Assignment_Project_Name, Assignment_Start_Date, Assignment_End_Date, Total_Nominal_Value, Contract_Ref_No, Project_Scope_Summary) {
        $("#clientname").val(Client_Name);
        $("#projectassignment").val(Assignment_Project_Name);
        $("#projectstartdate").val(Assignment_Start_Date);
        $("#experienceaddress").val(Address);
        $("#projectenddate").val(Assignment_End_Date);
        $("#projectscopes").val(Project_Scope_Summary);
        $("#contractRef").val(Contract_Ref_No);
        $("#projectvalue").val(Total_Nominal_Value);
        $("#add_pastexperience").modal();
    }

    $('.btn_UploadRegisterDocuments_Details').click(function (e) {
        e.preventDefault();
      //  var VendorprequalificationNumber = $("#preapplicationo").val();    
      
        var selectedFtype = $("#ProcDocType").val();
        var selvaluedescription = $("#description").val();
        var browsedDoc = document.getElementById('inputFileselector').files[0];
        var certNumber = $("#certificatenumber").val();
        var dateofissue = $("#issuedates").val();
        var xprydate = $("#documentexpirydates").val();


            var formDt = new FormData();
            formDt.append("typauploadselect", selectedFtype);
            formDt.append("browsedfile", browsedDoc);
            formDt.append("filedescription", selvaluedescription);
            formDt.append("certificatenumber", certNumber);
            formDt.append("dateofissue", dateofissue);
            formDt.append("expirydate", xprydate);
        
      
      
        //for test
        console.log(JSON.stringify({ formdata: formDt }));
        Swal.fire({
            title: "Registration Documents Upload",
            text: "Proceed to upload all the selected document?",
            type: "warning",
            showCancelButton: true,
            closeOnConfirm: true,
            confirmButtonText: "Yes, Upload!",
            confirmButtonClass: "btn-success",
            confirmButtonColor: "#008000",
            position: "center"
        }).then((result) => {
            if (result.value) {
                $.ajax({
                    xhr: function () {
                        var xhr = new window.XMLHttpRequest();
                        xhr.upload.addEventListener("progress", function (evt) {
                            if (evt.lengthComputable) {
                                var percentComplete = ((evt.loaded / evt.total) * 100);
                                $(".progress-bar").width(percentComplete + '%');
                                $(".progress-bar").html(percentComplete + '%');
                            }
                        }, false);
                        return xhr;
                    },
                    type: 'POST',
                    url: '/Home/uploadMandatoryFiles',
                    data: formDt,
                    contentType: false,
                    cache: false,
                    processData: false,
                    error: function () {
                        $("#attachprequalificationdocumentsfeedback").css("color", "red");
                        $('#attachprequalificationdocumentsfeedback').addClass('alert alert-danger');
                        $("#attachprequalificationdocumentsfeedback").html("File upload failed, choose another file and try again!");
                    },
                    success: function (status) {
                        var uploadsfs = status.split('*');
                        status = uploadsfs[0];
                        switch (status) {
                            case "success":
                                Swal.fire
                                ({
                                    title: "Registration Files Uploaded!",
                                    text: "Registration File Uploaded Successfully!",
                                    type: "success"
                                }).then(() => {
                                    $("#attachprequalificationdocumentsfeedback").css("display", "block");
                                    $("#attachprequalificationdocumentsfeedback").css("color", "green");
                                    $('#attachprequalificationdocumentsfeedback').attr("class", "alert alert-success");
                                    $("#attachprequalificationdocumentsfeedback").html("Selected Prequalification File Uploaded Successfully!");
                                    $("#attachprequalificationdocumentsfeedback").css("display", "block");
                                    $("#attachprequalificationdocumentsfeedback").css("color", "green");
                                });
                                window.location.href = "/Home/supplierDocuments";
                                RegistrationDocuments.init();
                                break;
                            case "browsedfilenull":
                                Swal.fire
                                ({
                                    title: "File Selection Null.Select File to Upload!",
                                    text: "File input cannot be empty! Kindly Select File to Upload",
                                    type: "error"
                                }).then(() => {
                                    $("#attachprequalificationdocumentsfeedback").css("display", "block");
                                    $("#attachprequalificationdocumentsfeedback").css("color", "red");
                                    $('#attachprequalificationdocumentsfeedback').attr('class', 'alert alert-danger');
                                    $("#attachprequalificationdocumentsfeedback").html("File input cannot be empty! Kindly Select File to Upload");
                                    $("#attachprequalificationdocumentsfeedback").focus();
                                    $("#attachprequalificationdocumentsfeedback").css("border", "solid 1px red");
                                });
                                break;
                            case "sharepointError":
                                Swal.fire
                                ({
                                    title: "Sharepoint Connection Error!",
                                    text: "There was an Error Connecting to the Sharepoint DMS Server! Kindly Contact KeRRA for More Details!",
                                    type: "error"
                                }).then(() => {
                                    $("#attachprequalificationdocumentsfeedback").css("display", "block");
                                    $("#attachprequalificationdocumentsfeedback").css("color", "red");
                                    $('#attachprequalificationdocumentsfeedback').attr('class', 'alert alert-danger');
                                    $("#attachprequalificationdocumentsfeedback").html("There was an Error Connecting to the Sharepoint DMS Server! Kindly Contact KeRRA for More Details!");
                                    $("#attachprequalificationdocumentsfeedback").focus();
                                    $("#attachprequalificationdocumentsfeedback").css("border", "solid 1px red");
                                });
                                break;
                            default:
                                Swal.fire
                                ({
                                    title: "Document Upload Error!!!",
                                    text: uploadsfs[1],
                                    type: "error"
                                }).then(() => {
                                    $("#attachprequalificationdocumentsfeedback").css("display", "block");
                                    $("#attachprequalificationdocumentsfeedback").css("color", "red");
                                    $('#attachprequalificationdocumentsfeedback').addClass('alert alert-danger');
                                });

                                break;
                        }
                    }
                });
            } else if (result.dismiss === Swal.DismissReason.cancel) {
                Swal.fire(
                    'Registration Document Upload Cancelled',
                    'You cancelled your documents submission!',
                    'error'
                );
            }
        });
    });


    $('.btnUploadPerformanceGuarantDocuments').click(function (e) {
        e.preventDefault();


         var selectedFtype = $("#ProcDocType").val();
         var selvaluedescription = $("#description").val();
            var tprn = $("#prnno").val();
            var tindexNo = $("#indexNo").val();
            
        var browsedDoc = document.getElementById('inputFileselector').files[0];     
        var response = $("#DocNo").val();

        var formDt = new FormData();
        formDt.append("ResponseNumber", response); 
        formDt.append("browsedfile", browsedDoc);

        formDt.append("typauploadselect", selectedFtype);       
        formDt.append("filedescription", selvaluedescription);
        
        formDt.append("prn", tprn);
        formDt.append("indexNo", tindexNo);

      
        Swal.fire({
            title: "Performance Guarantee Documents Upload",
            text: "Proceed to upload all the selected document?",
            type: "warning",
            showCancelButton: true,
            closeOnConfirm: true,
            confirmButtonText: "Yes, Upload!",
            confirmButtonClass: "btn-success",
            confirmButtonColor: "#008000",
            position: "center"
        }).then((result) => {
            if (result.value) {
                $.ajax({
                    xhr: function () {
                        var xhr = new window.XMLHttpRequest();
                        xhr.upload.addEventListener("progress", function (evt) {
                            if (evt.lengthComputable) {
                                var percentComplete = ((evt.loaded / evt.total) * 100);
                                $(".progress-bar").width(percentComplete + '%');
                                $(".progress-bar").html(percentComplete + '%');
                            }
                        }, false);
                        return xhr;
                    },
                    type: 'POST',
                    url: '/Home/FnUploadPerfomanceGuaranteeDocumentsLocal',
                    data: formDt,
                    contentType: false,
                    cache: false,
                    processData: false,
                    error: function () {
                        $("#attachprequalificationdocumentsfeedback").css("color", "red");
                        $('#attachprequalificationdocumentsfeedback').addClass('alert alert-danger');
                        $("#attachprequalificationdocumentsfeedback").html("File upload failed, choose another file and try again!");
                    },
                    success: function (status) {
                        var uploadsfs = status.split('*');
                        status = uploadsfs[0];
                        switch (status) {
                            case "success":
                                Swal.fire
                                ({
                                    title: "Performance Guarantee Files Uploaded!",
                                    text: "Performance Guarantee File Uploaded Successfully!",
                                    type: "success"
                                }).then(() => {
                                    $("#attachprequalificationdocumentsfeedback").css("display", "block");
                                    $("#attachprequalificationdocumentsfeedback").css("color", "green");
                                    $('#attachprequalificationdocumentsfeedback').attr("class", "alert alert-success");
                                    $("#attachprequalificationdocumentsfeedback").html("Selected Performance Guarantee File Uploaded Successfully!");
                                    $("#attachprequalificationdocumentsfeedback").css("display", "block");
                                    $("#attachprequalificationdocumentsfeedback").css("color", "green");
                                });
                                window.location.href = "/Home/PerfGuaranteeDocAttach";
                                // RegistrationDocuments.init();
                                break;
                            case "browsedfilenull":
                                Swal.fire
                                ({
                                    title: "File Selection Null.Select File to Upload!",
                                    text: "File input cannot be empty! Kindly Select File to Upload",
                                    type: "error"
                                }).then(() => {
                                    $("#attachprequalificationdocumentsfeedback").css("display", "block");
                                    $("#attachprequalificationdocumentsfeedback").css("color", "red");
                                    $('#attachprequalificationdocumentsfeedback').attr('class', 'alert alert-danger');
                                    $("#attachprequalificationdocumentsfeedback").html("File input cannot be empty! Kindly Select File to Upload");
                                    $("#attachprequalificationdocumentsfeedback").focus();
                                    $("#attachprequalificationdocumentsfeedback").css("border", "solid 1px red");
                                });
                                break;
                            case "sharepointError":
                                Swal.fire
                                ({
                                    title: "Sharepoint Connection Error!",
                                    text: "There was an Error Connecting to the Sharepoint DMS Server! Kindly Contact KeRRA for More Details!",
                                    type: "error"
                                }).then(() => {
                                    $("#attachprequalificationdocumentsfeedback").css("display", "block");
                                    $("#attachprequalificationdocumentsfeedback").css("color", "red");
                                    $('#attachprequalificationdocumentsfeedback').attr('class', 'alert alert-danger');
                                    $("#attachprequalificationdocumentsfeedback").html("There was an Error Connecting to the Sharepoint DMS Server! Kindly Contact KeRRA for More Details!");
                                    $("#attachprequalificationdocumentsfeedback").focus();
                                    $("#attachprequalificationdocumentsfeedback").css("border", "solid 1px red");
                                });
                                break;
                            default:
                                Swal.fire
                                ({
                                    title: "Document Upload Error!!!",
                                    text: uploadsfs[1],
                                    type: "error"
                                }).then(() => {
                                    $("#attachprequalificationdocumentsfeedback").css("display", "block");
                                    $("#attachprequalificationdocumentsfeedback").css("color", "red");
                                    $('#attachprequalificationdocumentsfeedback').addClass('alert alert-danger');
                                });

                                break;
                        }
                    }
                });
            } else if (result.dismiss === Swal.DismissReason.cancel) {
                Swal.fire(
                    'Performance Guarantee Document Upload Cancelled',
                    'You cancelled your documents submission!',
                    'error'
                );
            }
        });
    });

    $('.btnUploadTenderDocuments').click(function (e) {
        e.preventDefault();
        //  var VendorprequalificationNumber = $("#preapplicationo").val();    

        var prodocType = $("#ProcDocType").val();
        var DocNo = $("#DocNo").val();
        var selvaluedescription = $("#description").val();
        var browsedDoc = document.getElementById('inputFileselector').files[0];
        var certNumber = $("#certificatenumber").val();
        var dateofissue = $("#issuedates").val();
        var xprydate = $("#documentexpirydates").val();
        var response = $("#responseNumber").val();

        var formDt = new FormData();
        formDt.append("BidResponseNumber", response);
        formDt.append("prodocType", prodocType);
        formDt.append("browsedfile", browsedDoc);
        formDt.append("filedescription", selvaluedescription);
        formDt.append("certificatenumber", certNumber);
        formDt.append("dateofissue", dateofissue);
        formDt.append("expirydate", xprydate);



        //for test
        console.log(JSON.stringify(prodocType));
        Swal.fire({
            title: "Tender Documents Upload",
            text: "Proceed to upload all the selected document?",
            type: "warning",
            showCancelButton: true,
            closeOnConfirm: true,
            confirmButtonText: "Yes, Upload!",
            confirmButtonClass: "btn-success",
            confirmButtonColor: "#008000",
            position: "center"
        }).then((result) => {
            if (result.value) {
                $.ajax({
                    xhr: function () {
                        var xhr = new window.XMLHttpRequest();
                        xhr.upload.addEventListener("progress", function (evt) {
                            if (evt.lengthComputable) {
                                var percentComplete = ((evt.loaded / evt.total) * 100);
                                $(".progress-bar").width(percentComplete + '%');
                                $(".progress-bar").html(percentComplete + '%');
                            }
                        }, false);
                        return xhr;
                    },
                    type: 'POST',
                    url: '/Home/FnUploadBidResponseDocumentsc',
                    data: formDt,
                    contentType: false,
                    cache: false,
                    processData: false,
                    error: function () {
                        $("#attachprequalificationdocumentsfeedback").css("color", "red");
                        $('#attachprequalificationdocumentsfeedback').addClass('alert alert-danger');
                        $("#attachprequalificationdocumentsfeedback").html("File upload failed, choose another file and try again!");
                    },
                    success: function (status) {
                        var uploadsfs = status.split('*');
                        status = uploadsfs[0];
                        switch (status) {
                            case "success":
                                Swal.fire
                                ({
                                    title: "Tender Files Uploaded!",
                                    text: "Tender File Uploaded Successfully!",
                                    type: "success"
                                }).then(() => {
                                    $("#attachprequalificationdocumentsfeedback").css("display", "block");
                                    $("#attachprequalificationdocumentsfeedback").css("color", "green");
                                    $('#attachprequalificationdocumentsfeedback').attr("class", "alert alert-success");
                                    $("#attachprequalificationdocumentsfeedback").html("Selected Tender File Uploaded Successfully!");
                                    $("#attachprequalificationdocumentsfeedback").css("display", "block");
                                    $("#attachprequalificationdocumentsfeedback").css("color", "green");
                                });
                                window.location.href = "/Home/TenderAttachDocument?tenderNo=" + DocNo + "&Response="+response;
                               // RegistrationDocuments.init();
                                break;
                            case "browsedfilenull":
                                Swal.fire
                                ({
                                    title: "File Selection Null.Select File to Upload!",
                                    text: "File input cannot be empty! Kindly Select File to Upload",
                                    type: "error"
                                }).then(() => {
                                    $("#attachprequalificationdocumentsfeedback").css("display", "block");
                                    $("#attachprequalificationdocumentsfeedback").css("color", "red");
                                    $('#attachprequalificationdocumentsfeedback').attr('class', 'alert alert-danger');
                                    $("#attachprequalificationdocumentsfeedback").html("File input cannot be empty! Kindly Select File to Upload");
                                    $("#attachprequalificationdocumentsfeedback").focus();
                                    $("#attachprequalificationdocumentsfeedback").css("border", "solid 1px red");
                                });
                                break;
                            case "sharepointError":
                                Swal.fire
                                ({
                                    title: "Sharepoint Connection Error!",
                                    text: "There was an Error Connecting to the Sharepoint DMS Server! Kindly Contact KeRRA for More Details!",
                                    type: "error"
                                }).then(() => {
                                    $("#attachprequalificationdocumentsfeedback").css("display", "block");
                                    $("#attachprequalificationdocumentsfeedback").css("color", "red");
                                    $('#attachprequalificationdocumentsfeedback').attr('class', 'alert alert-danger');
                                    $("#attachprequalificationdocumentsfeedback").html("There was an Error Connecting to the Sharepoint DMS Server! Kindly Contact KeRRA for More Details!");
                                    $("#attachprequalificationdocumentsfeedback").focus();
                                    $("#attachprequalificationdocumentsfeedback").css("border", "solid 1px red");
                                });
                                break;
                            default:
                                Swal.fire
                                ({
                                    title: "Document Upload Error!!!",
                                    text: uploadsfs[1],
                                    type: "error"
                                }).then(() => {
                                    $("#attachprequalificationdocumentsfeedback").css("display", "block");
                                    $("#attachprequalificationdocumentsfeedback").css("color", "red");
                                    $('#attachprequalificationdocumentsfeedback').addClass('alert alert-danger');
                                });

                                break;
                        }
                    }
                });
            } else if (result.dismiss === Swal.DismissReason.cancel) {
                Swal.fire(
                    'Tender Document Upload Cancelled',
                    'You cancelled your documents submission!',
                    'error'
                );
            }
        });
    });
    //$('.btn_UploadDocuments_Details').click(function (e) {
    //    //To prevent form submit after ajax call
    //    e.preventDefault();
    //    var selectedFtype = $("#ProcDocType").val();
    //    var selvaluedescription = $("#description").val();
    //    var browsedDoc = document.getElementById('inputFileselector').files[0];
    //    var certNumber = $("#certificatenumber").val();
    //    var dateofissue = $("#issuedates").val();
    //    var xprydate = $("#documentexpirydates").val();

    //    var formDt = new FormData();
    //    formDt.append("typauploadselect", selectedFtype);
    //    formDt.append("browsedfile", browsedDoc);
    //    formDt.append("filedescription", selvaluedescription);
    //    formDt.append("certificatenumber", certNumber);
    //    formDt.append("dateofissue", dateofissue);
    //    formDt.append("expirydate", xprydate);

    //    //for test
    //    console.log(JSON.stringify({ formdata: formDt }));
    //    Swal.fire({
    //        title: "Registration Documents Upload",
    //        text: "Proceed to upload all the selected document once?",
    //        type: "warning",
    //        showCancelButton: true,
    //        closeOnConfirm: true,
    //        confirmButtonText: "Yes, Upload!",
    //        confirmButtonClass: "btn-success",
    //        confirmButtonColor: "#008000",
    //        position: "center"
    //    }).then((result) => {
    //        if (result.value) {
    //            $.ajax({
    //                xhr: function () {
    //                    var xhr = new window.XMLHttpRequest();
    //                    xhr.upload.addEventListener("progress", function (evt) {
    //                        if (evt.lengthComputable) {
    //                            var percentComplete = ((evt.loaded / evt.total) * 100);
    //                            $(".progress-bar").width(percentComplete + '%');
    //                            $(".progress-bar").html(percentComplete + '%');
    //                        }
    //                    }, false);
    //                    return xhr;
    //                },
    //                type: 'POST',
    //                url: '/Home/FnUploadmandatoryDoc',
    //                data: formDt,
    //                contentType: false,
    //                cache: false,
    //                processData: false,
    //                error: function () {
    //                    $("#keydocumentsuploadfeedback").css("color", "red");
    //                    $('#keydocumentsuploadfeedback').addClass('alert alert-danger');
    //                    $("#keydocumentsuploadfeedback").html("File upload failed, choose another file and try again!");
    //                },
    //                success: function (status) {
    //                    var uploadsfs = status.split('*');
    //                    status = uploadsfs[0];
    //                    switch (status) {
    //                        case "success":
    //                            Swal.fire
    //                            ({
    //                                title: "Files Uploaded!",
    //                                text: "File Uploaded Successfully!",
    //                                type: "success"
    //                            }).then(() => {
    //                                $("#keydocumentsuploadfeedback").css("display", "block");
    //                                $("#keydocumentsuploadfeedback").css("color", "green");
    //                                $('#keydocumentsuploadfeedback').attr("class", "alert alert-success");
    //                                $("#keydocumentsuploadfeedback").html("Selected File Uploaded Successfully!");
    //                                $("#keydocumentsuploadfeedback").css("display", "block");
    //                                $("#keydocumentsuploadfeedback").css("color", "green");
    //                                // Reload Documents
    //                                RegistrationDocuments.init();

    //                            });
    //                            $("button#btn_submitregistration_Details").css("display", "block");
                                
    //                            break;
    //                        case "browsedfilenull":
    //                            Swal.fire
    //                            ({
    //                                title: "File Selection Null.Select File to Upload!",
    //                                text: "File input cannot be empty! Kindly Select File to Upload",
    //                                type: "error"
    //                            }).then(() => {
    //                                $("#keydocumentsuploadfeedback").css("display", "block");
    //                                $("#keydocumentsuploadfeedback").css("color", "red");
    //                                $('#keydocumentsuploadfeedback').attr('class', 'alert alert-danger');
    //                                $("#keydocumentsuploadfeedback").html("File input cannot be empty! Kindly Select File to Upload");
    //                                $("#keydocumentsuploadfeedback").focus();
    //                                $("#keydocumentsuploadfeedback").css("border", "solid 1px red");
    //                            });
    //                            break;
    //                        case "sharepointError":
    //                            Swal.fire
    //                            ({
    //                                title: "Sharepoint Connection Error!",
    //                                text: "There was an Error Connecting to the Sharepoint DMS Server! Kindly Contact KeRRA for More Details!",
    //                                type: "error"
    //                            }).then(() => {
    //                                $("#keydocumentsuploadfeedback").css("display", "block");
    //                                $("#keydocumentsuploadfeedback").css("color", "red");
    //                                $('#keydocumentsuploadfeedback').attr('class', 'alert alert-danger');
    //                                $("#keydocumentsuploadfeedback").html("There was an Error Connecting to the Sharepoint DMS Server! Kindly Contact KeRRA for More Details!");
    //                                $("#keydocumentsuploadfeedback").focus();
    //                                $("#keydocumentsuploadfeedback").css("border", "solid 1px red");
    //                            });
    //                            break;
    //                        default:
    //                            Swal.fire
    //                            ({
    //                                title: "Document Upload Error!!!",
    //                                text: uploadsfs[1],
    //                                type: "error"
    //                            }).then(() => {
    //                                $("#keydocumentsuploadfeedback").css("display", "block");
    //                                $("#keydocumentsuploadfeedback").css("color", "red");
    //                                $('#keydocumentsuploadfeedback').addClass('alert alert-danger');
    //                            });

    //                            break;
    //                    }


    //                }
    //            });
    //        } else if (result.dismiss === Swal.DismissReason.cancel) {
    //            Swal.fire(
    //                'Document Upload Cancelled',
    //                'You cancelled your documents submission!',
    //                'error'
    //            );
    //        }
    //    });
    //});
    $('.btn_Delete_VendorDocuments').click(function (e) {
        //To prevent form submit after ajax call
        e.preventDefault();
        var selectedFtype = $('#vendoregdocumentdroplist').find(":selected").attr('value');
        var selvaluedescription = $("#vendoregdocumentdroplist option:selected").text();
        var browsedDoc = document.getElementById('inputFileselector').files[0];
        var certNumber = $("#certificatenumber").val();
        var dateofissue = $("#issuedates").val();
        var xprydate = $("#documentexpirydates").val();

        var formDt = new FormData();
        formDt.append("typauploadselect", selectedFtype);
        formDt.append("browsedfile", browsedDoc);
        formDt.append("filedescription", selvaluedescription);
        formDt.append("certificatenumber", certNumber);
        formDt.append("dateofissue", dateofissue);
        formDt.append("expirydate", xprydate);

        //for test
        console.log(JSON.stringify({ formdata: formDt }));
        Swal.fire({
            title: "Registration Documents Upload",
            text: "Proceed to upload all the selected document once?",
            type: "warning",
            showCancelButton: true,
            closeOnConfirm: true,
            confirmButtonText: "Yes, Upload!",
            confirmButtonClass: "btn-success",
            confirmButtonColor: "#008000",
            position: "center"
        }).then((result) => {
            if (result.value) {
                $.ajax({
                    xhr: function () {
                        var xhr = new window.XMLHttpRequest();
                        xhr.upload.addEventListener("progress", function (evt) {
                            if (evt.lengthComputable) {
                                var percentComplete = ((evt.loaded / evt.total) * 100);
                                $(".progress-bar").width(percentComplete + '%');
                                $(".progress-bar").html(percentComplete + '%');
                            }
                        }, false);
                        return xhr;
                    },
                    type: 'POST',
                    url: '/Home/FnUploadmandatoryDoc',
                    data: formDt,
                    contentType: false,
                    cache: false,
                    processData: false,
                    error: function () {
                        $("#keydocumentsuploadfeedback").css("color", "red");
                        $('#keydocumentsuploadfeedback').addClass('alert alert-danger');
                        $("#keydocumentsuploadfeedback").html("File upload failed, choose another file and try again!");
                    },
                    success: function (status) {
                        var uploadsfs = status.split('*');
                        status = uploadsfs[0];
                        switch (status) {
                            case "success":
                                Swal.fire
                                ({
                                    title: "Files Uploaded!",
                                    text: "File Uploaded Successfully!",
                                    type: "success"
                                }).then(() => {
                                    $("#keydocumentsuploadfeedback").css("display", "block");
                                    $("#keydocumentsuploadfeedback").css("color", "green");
                                    $('#keydocumentsuploadfeedback').attr("class", "alert alert-success");
                                    $("#keydocumentsuploadfeedback").html("Selected File Uploaded Successfully!");
                                    $("#keydocumentsuploadfeedback").css("display", "block");
                                    $("#keydocumentsuploadfeedback").css("color", "green");
                                    // Reload Documents
                                    RegistrationDocuments.init();

                                });

                                break;
                            case "browsedfilenull":
                                Swal.fire
                                ({
                                    title: "File Selection Null.Select File to Upload!",
                                    text: "File input cannot be empty! Kindly Select File to Upload",
                                    type: "error"
                                }).then(() => {
                                    $("#keydocumentsuploadfeedback").css("display", "block");
                                    $("#keydocumentsuploadfeedback").css("color", "red");
                                    $('#keydocumentsuploadfeedback').attr('class', 'alert alert-danger');
                                    $("#keydocumentsuploadfeedback").html("File input cannot be empty! Kindly Select File to Upload");
                                    $("#keydocumentsuploadfeedback").focus();
                                    $("#keydocumentsuploadfeedback").css("border", "solid 1px red");
                                });
                                break;
                            case "sharepointError":
                                Swal.fire
                                ({
                                    title: "Sharepoint Connection Error!",
                                    text: "There was an Error Connecting to the Sharepoint DMS Server! Kindly Contact KeRRA for More Details!",
                                    type: "error"
                                }).then(() => {
                                    $("#keydocumentsuploadfeedback").css("display", "block");
                                    $("#keydocumentsuploadfeedback").css("color", "red");
                                    $('#keydocumentsuploadfeedback').attr('class', 'alert alert-danger');
                                    $("#keydocumentsuploadfeedback").html("There was an Error Connecting to the Sharepoint DMS Server! Kindly Contact KeRRA for More Details!");
                                    $("#keydocumentsuploadfeedback").focus();
                                    $("#keydocumentsuploadfeedback").css("border", "solid 1px red");
                                });
                                break;
                            default:
                                Swal.fire
                                ({
                                    title: "Document Upload Error!!!",
                                    text: uploadsfs[1],
                                    type: "error"
                                }).then(() => {
                                    $("#keydocumentsuploadfeedback").css("display", "block");
                                    $("#keydocumentsuploadfeedback").css("color", "red");
                                    $('#keydocumentsuploadfeedback').addClass('alert alert-danger');
                                });

                                break;
                        }


                    }
                });
            } else if (result.dismiss === Swal.DismissReason.cancel) {
                Swal.fire(
                    'Document Upload Cancelled',
                    'You cancelled your documents submission!',
                    'error'
                );
            }
        });
    });
    var vendorStaffKeyDetails = function () {
        var staffkeydetails = function () {
            var StaffTable = $("#tbl_keystaff_details"),
                l = StaffTable.dataTable({
                    lengthMenu: [[5, 15, 20, -1], [5, 15, 20, "All"]],
                    pageLength: 5,
                    language: { lengthMenu: " _MENU_ records" },
                    columnDefs: [
                        {
                            orderable: !0,
                            defaultContent: "-",
                            targets: "_all"
                        },
                        {
                            searchable: !0,
                            targets: "_all"
                        }
                    ],
                    order: [
                        [0, "asc"]
                    ],

                    bDestroy: true,
                    info: false,
                    processing: true,
                    retrieve: true
                });
            $.ajaxSetup({
                global: false,
                type: "POST",
                url: "/Home/GetKeyProfessionalStaff",
            });
            $.ajax({
                data: ""
            }).done(function (json) {
                l.fnClearTable();
                console.log(JSON.stringify({ vendorTestdata: json }));
                var o = 1;
                for (var i = 0; i < json.length; i++) {
                    l.fnAddData([
                        o++,
                        json[i].StaffNumber,
                        json[i].StaffName,
                        json[i].StaffDateofBirth,
                        json[i].StaffPhonenumber,
                        json[i].Country_Region_Code,
                        json[i].StaffEmail,
                        '<a class="btn btn-success edit_staff_details" id="edit_staff_details"><i class="fa fa-edit m-r-10"></i>Edit</a>',
                        '<a class="btn btn-danger delete_staff_details"><i class="fa fa-trash m-r-10">Delete</a>'
                    ]);
                }
            });
            StaffTable.on("click",
               ".edit_staff_details",
               function (StaffTable) {
                   StaffTable.preventDefault();
                   var i = $(this).parents("tr")[0];
                   // alert("record to be deleted: " + i.cells[1].innerHTML);
                   $("#editstaffnumber").val(i.cells[1].innerHTML);
                   $("#editkeystaffname").val(i.cells[2].innerHTML);
                   $("#editstaffprofession").val(i.cells[1].innerHTML);
                   $("#editcurrentDesignation").val(i.cells[1].innerHTML);
                   $("#editpersonneljoiningDate").val(i.cells[1].innerHTML);
                   $("#edityearswithfarm").val(i.cells[1].innerHTML);
                   $("#editpersonnelphonenumber").val(i.cells[1].innerHTML);
                   $("#edit_professionalkeystaff_details").modal();

               });
            StaffTable.on("click",
              ".delete_staff_details",
              function (StaffTable) {
                  StaffTable.preventDefault();
                  var i = $(this).parents("tr")[0];
                  //alert("record to be deleted: " + i.cells[1].innerHTML);
                  Swal.fire({
                      title: "Confirm Deleting Staff",
                      text: "Sure you'd like to proceed with deletion?",
                      type: "warning",
                      showCancelButton: true,
                      closeOnConfirm: true,
                      confirmButtonText: "Yes, Delete Staff!",
                      confirmButtonClass: "btn-success",
                      confirmButtonColor: "#008000",
                      position: "center"
                  }).then((result) => {
                      if (result.value) {
                          //global loader spinner;
                          $.ajaxSetup({
                              global: false,
                              type: "POST",
                              url: "/Home/DeleteBankDetails?bankcode=" + i.cells[1].innerHTML
                          });
                          $.ajax({
                              data: '',
                              contentType: "application/json",
                              cache: false,
                              processData: false
                          }).done(function (status) {
                              var registerstatus = status.split('*');
                              status = registerstatus[0];
                              console.log(JSON.stringify(status))
                              switch (status) {
                                  case "success":
                                      Swal.fire
                                      ({
                                          title: "Bank Details Deleted!",
                                          text: "Bank Details Deleted Successfully!",
                                          type: "success"
                                      }).then(() => {
                                          $("#banksfeedback").css("display", "block");
                                          $("#banksfeedback").css("color", "green");
                                          $('#banksfeedback').attr("class", "alert alert-success");
                                          $("#banksfeedback").html("Your Bank Details have been successfully Deleted.Kindly Proceed to fill in the rest details!");
                                          $("#banksfeedback").css("display", "block");
                                          $("#banksfeedback").css("color", "green");
                                          $("#banksfeedback").html("Your Bank Details have been successfully Deleted.Kindly Proceed to fill in the rest details!");
                                      });
                                      vendorbankaccounts.init();
                                      break;
                                  default:
                                      Swal.fire
                                         ({
                                             title: "Bank Details Deletion Error!!!",
                                             text: status,
                                             type: "error"
                                         }).then(() => {
                                             $("#banksfeedback").css("display", "block");
                                             $("#banksfeedback").css("color", "red");
                                             $('#banksfeedback').addClass('alert alert-danger');
                                             $("#banksfeedback").html("Your Banks Details could not be Deleted.KindlyTy Again!");
                                         });
                              }
                          });
                      } else if (result.dismiss === Swal.DismissReason.cancel) {
                          Swal.fire(
                              'Bank Deletion Cancelled',
                              'You cancelled your bank deletion Request!',
                              'error'
                          );
                      }
                  });

              });
        }
        return {
            init: function () {
                bankaccount();
            }
        }
    }();
    var vendorNo = $("#vendorno").val();
    var VendorBanks = function () {
        var Banks = function () {
            var tl = $("#tbl_vendor_banks"),
                l = tl.dataTable({
                    lengthMenu: [[5, 15, 20, -1], [5, 15, 20, "All"]],
                    pageLength: 5,
                    language: { lengthMenu: " _MENU_ records" },
                    columnDefs: [
                        {
                            orderable: !0,
                            // targets: [0],
                            defaultContent: "-",
                            targets: "_all"
                        },
                        {
                            searchable: !0,
                            targets: "_all"
                            // targets: [0]
                        }
                    ],
                    order: [
                        [0, "asc"]
                    ],

                    //stateSave: true,
                    bDestroy: true,
                    info: false,
                    processing: true,
                    retrieve: true
                });
            $.ajax({
                type: "POST",
                url: "/Home/GetBanks",
                data: JSON.stringify(vendorNo),
            }).done(function (BankDetails) {
                console.log(JSON.stringify({ data: BankDetails }));
                l.fnClearTable();
                var o = 1;
                for (var i = 0; i < BankDetails.length; i++) {
                    l.fnAddData([
                        o++,
                        BankDetails[i].BankCode,
                        BankDetails[i].BankName,
                        BankDetails[i].CurrencyCode,
                        BankDetails[i].BankAccountNo,
                        BankDetails[i].Bank_Branch_No,
                        BankDetails[i].Post_Code,
                        BankDetails[i].City,
                        BankDetails[i].Phone_No
                    ]);
                }
            });
        }
        return {
            init: function () {
                Banks();
            }
        }

    }();
    var vendorNo = $("#vendorno").val();
    var RegistrationDocuments = function () {
        var RegisteredDocument = function () {
            var tl = $("#tab_supplier_registered_Documents"),
                l = tl.dataTable({
                    lengthMenu: [[5, 15, 20, -1], [5, 15, 20, "All"]],
                    pageLength: 5,
                    language: { lengthMenu: " _MENU_ records" },
                    columnDefs: [
                        {
                            orderable: !0,
                            defaultContent: "-",
                            targets: "_all"
                        },
                        {
                            searchable: !0,
                            targets: "_all"
                        }
                    ],
                    order: [
                        [0, "asc"]
                    ],

                    //stateSave: true,
                    bDestroy: true,
                    info: false,
                    processing: true,
                    retrieve: true
                });
            $.ajax({
                type: "POST",
                url: "/Home/GetSupplierRgistrationDocuments",
                data: "",
            }).done(function (documents) {
                console.log(JSON.stringify({ data: documents }));
                l.fnClearTable();
                var o = 1;
                for (var i = 0; i < documents.length; i++) {
                    l.fnAddData([
                        documents[i].Certificate_No,
                        documents[i].Description,
                        documents[i].Issue_Date,
                        documents[i].Expiry_Date,
                        documents[i].File_Name,
                        '<button type="submit" class="btn btn-success btnDownloadVendorDocuments"filename=' + documents.File_Name + '><i class="fa fa-download m-r-10"></i> Download </button>',
                           '<a class="btn btn-danger delete_file"><i class="fa fa-trash m-r-10">Delete</a>'
                    ]);
                }
            });
            tl.on("click",
             ".delete_file",
             function (tl) {
                 tl.preventDefault();
                 var i = $(this).parents("tr")[0];
                 //alert("record to be deleted: " + i.cells[1].innerHTML);
                    Swal.fire({
                     title: "Confirm Deleting File Details",
                     text: "Sure you will you like to proceed with deletion?",
                     type: "warning",
                     showCancelButton: true,
                     closeOnConfirm: true,
                     confirmButtonText: "Yes, Delete File!",
                     confirmButtonClass: "btn-success",
                     confirmButtonColor: "#008000",
                     position: "center"
                 }).then((result) => {
                     if (result.value) {
                         //global loader spinner;
                         $.ajaxSetup({
                             global: false,
                             type: "POST",
                             url: "/Home/DeleteRegDocfromSharepoint?filename=" + i.cells[1].innerHTML + "&certificateNo=" + i.cells[5].innerHTML
                         });
                         $.ajax({
                             data: '',
                             contentType: "application/json",
                             cache: false,
                             processData: false
                         }).done(function (status) {
                             var registerstatus = status.split('*');
                             status = registerstatus[0];
                             console.log(JSON.stringify(status))
                             switch (status) {
                                 case "success":
                                     Swal.fire
                                     ({
                                         title: "File Name Details Deleted!",
                                         text: "File Details Deleted Successfully!",
                                         type: "success"
                                     }).then(() => {
                                         $("#keydocumentsuploadfeedback").css("display", "block");
                                         $("#keydocumentsuploadfeedback").css("color", "green");
                                         $('#keydocumentsuploadfeedback').attr("class", "alert alert-success");
                                         $("#keydocumentsuploadfeedback").html("Your File Details have been successfully Deleted!");
                                         $("#keydocumentsuploadfeedback").css("display", "block");
                                         $("#keydocumentsuploadfeedback").css("color", "green");
                                         $("#keydocumentsuploadfeedback").html("Your File Details have been successfully Deleted!");
                                     });
                                     RegistrationDocuments.init();
                                     break;
                                 default:
                                     Swal.fire
                                        ({
                                            title: "File Details Deletion Error!!!",
                                            text: status,
                                            type: "error"
                                        }).then(() => {
                                            $("#keydocumentsuploadfeedback").css("display", "block");
                                            $("#keydocumentsuploadfeedback").css("color", "red");
                                            $('#keydocumentsuploadfeedback').addClass('alert alert-danger');
                                            $("#keydocumentsuploadfeedback").html("Your File Details could not be Deleted.KindlyTy Again!");
                                        });
                             }
                         });
                     } else if (result.dismiss === Swal.DismissReason.cancel) {
                         Swal.fire(
                             'File Deletion Cancelled',
                             'You cancelled your File deletion Request!',
                             'error'
                         );
                     }
                 });

             });
        }
        return {
            init: function () {
                RegisteredDocument();
            }
        }

    }();
     //Supplier Income Statement Details Function
    $(".btn_submitregistration_Details").click(function () {
        //Swal Message
        Swal.fire({
            title: "Confirm Supplier Registration Submission?",
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
                    url: "/Home/SubmitRegistrationDetails",
                    type: "POST",
                    data: "",
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
                                title: "Supplier Profile Registration Submitted!",
                                text: registerstatus[1],
                                type: "success"
                            }).then(() => {
                                $("#completefeedback").css("display", "block");
                                $("#completefeedback").css("color", "green");
                                $('#completefeedback').attr("class", "alert alert-success");
                                $("#completefeedback").html("Your Supplier Registration Details have been successfully submitted!" + " " + registerstatus[1]);
                                $("#completefeedback").css("display", "block");
                                $("#completefeedback").css("color", "green");
                                $("#completefeedback").html("Your Supplier Registration Details have been successfully submitted"+"  "+registerstatus[1]);
                            });
                            window.location.href = "/Home/Dashboard";
                            break;
                        default:
                            Swal.fire
                            ({
                                title: "Supplier Profile Registration Details Submission Error!!!",
                                text: registerstatus[1],
                                type: "error"
                            }).then(() => {
                                $("#completefeedback").css("display", "block");
                                $("#completefeedback").css("color", "red");
                                $('#completefeedback').addClass('alert alert-danger');
                                $("#completefeedback").html("Your Supplier Registration Details could not be submitted" + registerstatus[1]);
                            });
                            break;
                    }
                }
                );
            } else if (result.dismiss === Swal.DismissReason.cancel) {
                Swal.fire(
                    'Supplier Profile Registration Cancelled',
                    'You cancelled your supplier Income Statement registration submission details!',
                    'error'
                );
            }
        });

    });

   

    $("#btn_search").click(function () {
        // Create search model object
        var searchModel = {
            TenderNumber: $("#tendernumber").val(),
            TenderName: $("#tendernames").val(),
            ClosingDate: $("#closingdate").val()
        };

        // Send AJAX request to search action
        $.ajax({
            url: '@Url.Action("Search", "Tender")',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(searchModel),
            success: function (result) {
                $("#searchResults").html(result);
            }
        });
    });

  
})