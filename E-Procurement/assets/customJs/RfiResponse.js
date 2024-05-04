$(document).ready(function () {
    //Supplier Registration Function
    $(".btn_submitresponsegeneralDetails").click(function () {
        //Set data to be sent
        var data = {
            "BidRespNumber": $("#bidnumber").val(),
            "BidderRepName": $("#biddrerepname").val(),
            "BidderRepDesignation": $("#bidderwitdesignation").val(),
            "BidderRepAddress": $("#bidderrepaddress").val(),
            "BidderWitnessName": $("#bidderwitnessname").val(),
            "BidderWitnessDesignation": $("#bidderrepdesignations").val(),
            "BidderWitnessAddress": $("#bidderwitnessaddress").val(),
            "PaymentReference": $("#paymentsreference").val(),
            "BidderType": $("#biddertypes").val(),
            "TenderDocumentsSource": $("#txtTenderDocSource").val()          
        }
        var JointVenture=$("#jointventures").val()
        //Swal Message
        Swal.fire({
            title: "Confirm Bid General Details?",
            text: "Are you sure you would like to Submit Bid Response Details?",
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
                    url: "/Home/AddBidResponseGeneralDetails",
                    type: "POST",
                    data: JSON.stringify(data, JointVenture),
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
                                title: "Bid Response Details Submitted!",
                                text: "Your Bid Response General Details was successfully submitted" + " " + registerstatus[1],
                                type: "success"
                            }).then(() => {
                                $("#bideresponsefeedback").css("display", "block");
                                $("#bideresponsefeedback").css("color", "green");
                                $('#bideresponsefeedback').attr("class", "alert alert-success");
                                $("#bideresponsefeedback").html("Your Bid Response General Details was successfully submitted.Kindly proceed to fill in More Details!");
                                $("#bideresponsefeedback").css("display", "block");
                                $("#bideresponsefeedback").css("color", "green");
                                $("#bideresponsefeedback").html("Your Bid Response General Details was successfully submitted.Kindly proceed to fill in More Details!");
                                $("#bideresponsefeedback").reset();
                                $("button#nextBtn").css("display", "block");
                            });
                            $("button#generalnextBtn").css("display", "block");
                            break;                          
                        default:
                            Swal.fire
                            ({
                                title: "Bid Response  Error!!!",
                                text: "Your Bid Response Details Could not be Submitted.Kindly Ensure you fill in all the Details" + " " + registerstatus[1],
                                type: "error"
                            }).then(() => {
                                $("#bideresponsefeedback").css("display", "block");
                                $("#bideresponsefeedback").css("color", "red");
                                $('#bideresponsefeedback').addClass('alert alert-danger');
                                $("#bideresponsefeedback").html("Your Bid Response Details Could not be Submitted.Kindly Ensure you fill in all the Details" + " "+ registerstatus[1]);
                            });
                            break;
                    }
                }
                );
            } else if (result.dismiss === Swal.DismissReason.cancel) {
                Swal.fire(
                    'Bid Response Details Cancelled',
                    'You cancelled your Bid Response submission details!',
                    'error'
                );
            }
        });

    });
    $(".btn_RFQsubmitresponsegeneralDetails").click(function () {
        //Set data to be sent
        var data = {
            "BidRespNumber": $("#bidnumber").val(),
            "BidderRepName": $("#biddrerepname").val(),
            "BidderRepDesignation": $("#bidderrepdesignations").val(),
            "BidderRepAddress": $("#bidderrepaddress").val()        
        }
        Swal.fire({
            title: "Confirm Bid General Details?",
            text: "Are you sure you would like to Submit Bid Response Details?",
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
                    url: "/Home/AddRFQBidResponseGeneralDetails",
                    type: "POST",
                    data: JSON.stringify(data),
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
                                title: "Bid Response Details Submitted!",
                                text: "Your Bid Response General Details was successfully submitted" + " " + registerstatus[1],
                                type: "success"
                            }).then(() => {
                                $("#bideresponsefeedback").css("display", "block");
                                $("#bideresponsefeedback").css("color", "green");
                                $('#bideresponsefeedback').attr("class", "alert alert-success");
                                $("#bideresponsefeedback").html("Your Bid Response General Details was successfully submitted.Kindly proceed to fill in More Details!");
                                $("#bideresponsefeedback").css("display", "block");
                                $("#bideresponsefeedback").css("color", "green");
                                $("#bideresponsefeedback").html("Your Bid Response General Details was successfully submitted.Kindly proceed to fill in More Details!");
                                $("#bideresponsefeedback").reset();
                                $("button#nextBtn").css("display", "block");
                            });
                            $("button#generalnextBtn").css("display", "block");
                            break;                          
                        default:
                            Swal.fire
                            ({
                                title: "Bid Response  Error!!!",
                                text: "Your Bid Response Details Could not be Submitted.Kindly Ensure you fill in all the Details" + " " + registerstatus[1],
                                type: "error"
                            }).then(() => {
                                $("#bideresponsefeedback").css("display", "block");
                                $("#bideresponsefeedback").css("color", "red");
                                $('#bideresponsefeedback').addClass('alert alert-danger');
                                $("#bideresponsefeedback").html("Your Bid Response Details Could not be Submitted.Kindly Ensure you fill in all the Details" + " "+ registerstatus[1]);
                            });
                            break;
                    }
                }
                );
            } else if (result.dismiss === Swal.DismissReason.cancel) {
                Swal.fire(
                    'Bid Response Details Cancelled',
                    'You cancelled your Bid Response submission details!',
                    'error'
                );
            }
        });

    });

    //Supplier Balance Sheet Details Function
    $(".btn_balancesheetResponse").click(function () {
        var BalanceSheetObj = {
            "No": $("#bidnumber").val(),
            "Audit_Year_Code_Reference": $("#ddlyearcodes").val(),
            "Total_Assets_LCY": $("#totalcurrentassets").val(),
            "Fixed_Assets_LCY": $("#totalfixedassets").val(),
            "Current_Liabilities_LCY": $("#totalcurrentliabilities").val(),
            "Long_term_Liabilities_LCY": $("#totallontermliabilities").val(),
            "Owners_Equity_LCY": $("#totalownersequity").val(),
        }
        //Swal Message
        Swal.fire({
            title: "Confirm Balance Sheet Details Submission?",
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
                    url: "/Home/BidResponseBalanceSheetDetails",
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
                                title: "Balance Sheet Details Submitted!",
                                text: status,
                                type: "success"
                            }).then(() => {
                                var bidResponseNumber = $("#bidnumber").val();
                                var balancesheetdata = JSON.stringify(BalanceSheetObj);
                                console.log(JSON.stringify(bidResponseNumber));
                                $("#balancesheetfeedback").css("display", "block");
                                $("#balancesheetfeedback").css("color", "green");
                                $('#balancesheetfeedback').attr("class", "alert alert-success");
                                $("#balancesheetfeedback").html("Your Balance Sheet Details have been successfully submitted.Kindly Proceed to fill in the rest details!");
                                $("#balancesheetfeedback").css("display", "block");
                                $("#balancesheetfeedback").css("color", "green");
                                $("#balancesheetfeedback").html("Your Balance Sheet Details have been successfully submitted.Kindly Proceed to fill in the rest details!");
                              
                            });
                            BidResponseBalanceSheet.init();
                            break;
                        default:
                            Swal.fire
                            ({
                                title: "Balance Sheet Details Submission Error!!!",
                                text: status,
                                type: "error"
                            }).then(() => {
                                $("#balancesheetfeedback").css("display", "block");
                                $("#balancesheetfeedback").css("color", "red");
                                $('#balancesheetfeedback').addClass('alert alert-danger');
                                $("#balancesheetfeedback").html("Your Balance Sheet Details could not be submitted" + status + ".Kindly Proceed to fill in the rest details!");
                            });
                            break;
                    }
                }
                );
            } else if (result.dismiss === Swal.DismissReason.cancel) {
                Swal.fire(
                    'Balance Sheet Details Cancelled',
                    'You cancelled your supplier Balance Sheet submission details!',
                    'error'
                );
            }
        });

    });

    //Supplier Income Statement Details Function
    $(".btn_Bid_Responze_incomestatement_details").click(function () {
        var IncomeSatetemtnObj = {
            "No": $("#bidnumber").val(),
            "Audit_Year_Code_Reference": $("#incomesddlyearcodes").val(),
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
                    url: "/Home/BidResponseIncomeStatementDetails",
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
                            BidResponseIncomeStatement.init();
                            break;
                        default:
                            Swal.fire
                            ({
                                title: "Income Statement Details Submission Error!!!",
                                text: status,
                                type: "error"
                            }).then(() => {
                                $("#incometstatementfeedback").css("display", "block");
                                $("#incometstatementfeedback").css("color", "red");
                                $('#incometstatementfeedback').addClass('alert alert-danger');
                                $("#incometstatementfeedback").html("Your Income Statement Details could not be submitted" + status + ".Kindly Proceed to fill in the rest details!");
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

    //Supplier PastExperience Details Function
    $(".btn_submit_pastexperience").click(function () {
        var PastExperiencenObj = {
            "No": $("#bidnumber").val(),
            "Client_Name": $("#clientname").val(),
            "Address": $("#clientaddress").val(),
            "Phone_No": $("#clientphonenumber").val(),
            "Country_Region_Code": $("#countriesdropdownCountries").val(),
            "Primary_Contact_Email": $("#clientemail").val(),
            "Project_Scope_Summary": $("#projectscope").val(),
            "Assignment_Project_Name": $("#projectname").val(),
            "Contract_Ref_No": $("#contractrefnumber").val(),
            "Assignment_Value_LCY": $("#assignmentvalue").val(),
            "Assignment_Status": $("#assignmentstatus").val(), 
            "Assignment_Start_Date": $("#assignmentsendstartdate").val(),
            "Assignment_End_Date": $("#assignmentsenddate").val(),
        }
       
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
                    url: "/Home/BidResponsePastExperienceDetails",
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
                                text: status,
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
                                title: "Past Experience Details Submission Error!!!",
                                text: status,
                                type: "error"
                            }).then(() => {
                                $("#pastexperiencefeedback").css("display", "block");
                                $("#pastexperiencefeedback").css("color", "red");
                                $('#pastexperiencefeedback').addClass('alert alert-danger');
                                $("#pastexperiencefeedback").html("Your Past Experience Details could not be submitted" + status + ".Kindly Proceed to fill in the rest details!");
                            });                           
                            $('#past_experience').modal('hide');
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


    $(".button_submit_performance_response").click(function () {
        var PastExperiencenObj = {
            "docNo": $("#responseNumber").val(),
           
        }

        //Swal Message
        Swal.fire({
            title: "Confirm Performance Guarantee Details Submission?",
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
                    url: "/Home/fnSubmitPerformanceGuarantee",
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
                                title: "Performance Guarantee Submitted!",
                                text: status,
                                type: "success"
                            }).then(() => {
                                $("#pastexperiencefeedback").css("display", "block");
                                $("#pastexperiencefeedback").css("color", "green");
                                $('#pastexperiencefeedback').attr("class", "alert alert-success");
                                $("#pastexperiencefeedback").html("Your Performance Guarantee have been successfully submitted!");
                                $("#pastexperiencefeedback").css("display", "block");
                                $("#pastexperiencefeedback").css("color", "green");
                                $("#pastexperiencefeedback").html("Your Performance Guarantee have been successfully submitted.!");
                                window.location.href = "/Home/OpenPerfomanceGuarantee"
                            });
                            VendorBidPastExperienceDetails.init();


                            break;
                        default:
                            Swal.fire
                            ({
                                title: "Performance Guarantee Submission Error!!!",
                                text: status,
                                type: "error"
                            }).then(() => {
                                $("#pastexperiencefeedback").css("display", "block");
                                $("#pastexperiencefeedback").css("color", "red");
                                $('#pastexperiencefeedback').addClass('alert alert-danger');
                                $("#pastexperiencefeedback").html("Your Performance Guarantee  could not be submitted" + status + ".!");
                            });
                            break;
                    }
                }
                );
            } else if (result.dismiss === Swal.DismissReason.cancel) {
                Swal.fire(
                    'Performance Guarantee  Cancelled',
                    'You cancelled your Performance Guarantee submission!',
                    'error'
                );
            }
        });

    });

    $(".btn_savePerformanceGuarantee").click(function () {
        var PastExperiencenObj = {           
            "purchaseContractId": $("#purchasecontractid").val(),
            "projectId": $("#projectid").val(),
            "gurantorName": $("#guarantorName").val(),
            "policyNo": $("#policyNo").val(),
            "amount": $("#amountIns").val(),
            "formOfSec": $("#formOfSec").val(),
            "InstType": $("#institutionType").val(),
            "regOffice": $("#issuerRegOffice").val(),
            "insurerEmail": $("#insurerEmail").val(),
            "effectiveDate": $("#effectiveDate").val(),
            "expiryDate": $("#expiryDate").val(),
         
        }

        //Swal Message
        Swal.fire({
            title: "Confirm Performance Guarantee Details Submission?",
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
                    url: "/Home/PerformanceGuaranteeDetails",
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
                                title: "Performance Guarantee Details Submitted!",
                                text: status,
                                type: "success"
                            }).then(() => {
                                $("#pastexperiencefeedback").css("display", "block");
                                $("#pastexperiencefeedback").css("color", "green");
                                $('#pastexperiencefeedback').attr("class", "alert alert-success");
                                $("#pastexperiencefeedback").html("Your Performance Guarantee Details have been successfully submitted.Kindly Proceed to fill in the rest details!");
                                $("#pastexperiencefeedback").css("display", "block");
                                $("#pastexperiencefeedback").css("color", "green");
                                $("#pastexperiencefeedback").html("Your Performance Guarantee Details have been successfully submitted.Kindly Proceed to fill in the rest details!");
                                window.location.href = "/Home/PerfGuaranteeDocAttach"
                            });
                            VendorBidPastExperienceDetails.init();
                          
                            
                            break;
                        default:
                            Swal.fire
                            ({
                                title: "Performance Guarantee Details Submission Error!!!",
                                text: status,
                                type: "error"
                            }).then(() => {
                                $("#pastexperiencefeedback").css("display", "block");
                                $("#pastexperiencefeedback").css("color", "red");
                                $('#pastexperiencefeedback').addClass('alert alert-danger');
                                $("#pastexperiencefeedback").html("Your Performance Guarantee Details could not be submitted" + status + ".Kindly Proceed to fill in the rest details!");
                            });
                            break;
                    }
                }
                );
            } else if (result.dismiss === Swal.DismissReason.cancel) {
                Swal.fire(
                    'Performance Guarantee Details Cancelled',
                    'You cancelled your Performance Guarantee submission details!',
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
            var PastExperienceTable = $("#tbl_past_experiences"),
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
       
            $.ajaxSetup({
                global: false,
                type: "POST",
                url: "/Home/GetVendorBideResponsPastExperience", 
            });
            $.ajax({
                data: { BidResponseNumber: BidResponseNumber },               
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
                        //'<a class="btn btn-success edit_past_experience_details"><i class="fa fa-edit m-r-10"></i>Edit</a>',
                        //'<a class="btn btn-danger  delete_pastexperience_details"><i class="fa fa-trash m-r-10">Delete</a>'
                    ]);
                }
            });
           
        }
       
        return {
            init: function () {
                bidpastexperienceDetails();
            }
        }
    }();
    var BidResponseNumber = $("#bidnumber").val();
    //Get All Equipment  Details
    var VendorBidEquipmentsDetails = function () {       
        var bidEquipmentsDetails = function () {
            var EquipmentsTable = $("#tbl_bid_equipments"),
                l = EquipmentsTable.dataTable({
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
          
            EquipmentsTable.on("click",
               ".delete_bidequipment",
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
                url: "/Home/GetBidEquipmentsDetails",
             });
             $.ajax({
                 data: { BidResponseNumber: BidResponseNumber },
              }).done(function (json) {
                l.fnClearTable();
                var o = 1;
                for (var i = 0; i < json.length; i++) {
                    l.fnAddData([
                        o++,
                        json[i].Equipment_Type_Code,
                        json[i].Description,
                        json[i].Ownership_Type,
                        json[i].Equipment_Serial,
                        json[i].Years_of_Previous_Use,
                        json[i].Equipment_Condition_Code,
                        json[i].Qty_of_Equipment,
                        '<a class="btn btn-success edit_equipment_details" id="edit_equipment_details"><i class="fa fa-share m-r-10"></i>Edit</a>',
                        '<a class="btn btn-danger edit_equipment_details" id="edit_equipment_details"><i class="fa fa-share m-r-10"></i>Delete</a>'
                    ]);
                }
              });
             EquipmentsTable.on("click",
            ".edit_equipment_details",
               function (EquipmentsTable) {
                   EquipmentsTable.preventDefault();
                   var i = $(this).parents("tr")[0];
                   //put editing code here below
                   $("#editequipmentcategory").val(i.cells[1].innerHTML);
                   $("#editdescription").val(i.cells[2].innerHTML);
                   $("#editOwnershiptype").val(i.cells[3].innerHTML);
                   $("#editequipmentserial").val(i.cells[4].innerHTML);
                   $("#edityears").val(i.cells[5].innerHTML);
                   $("#editequipments").val(i.cells[6].innerHTML);
                   $('#edit_Equipments').modal('show');
                   //end editing code
               });
        }
        return {
            init: function () {
                bidEquipmentsDetails();
            }
        }
    }();

    //Get Personnel details 
    var tendernumber = $("#bidnumber").val();

    var VendorPersonnelDetails = function () {
        var bidpersonnel = function () {
            //tbl_personnel_details
            
            var personnelTable = $("#tbl_bid_personnel"),
                l = personnelTable.dataTable({
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

            personnelTable.on("click",
               ".delete_bidequipment",
           function (e) {
               if (e.preventDefault()) {
                   var t = $(this).parents("tr")[0];
                   l.fnDeleteRow(t),
                   //put editing code here below
                   $('#delete_pastexperience_modal').modal('show');
                   //end delete code
                   //
               }
           })
            $.ajaxSetup({
                global: false,
                type: "POST",
                url: "/Home/GetStaffDetails",
            });
            $.ajax({
                data: { tendernumber: tendernumber },
            }).done(function (json) {
                l.fnClearTable();
                var o = 1;
                for (var i = 0; i < json.length; i++) {
                    l.fnAddData([
                        o++,
                        json[i].IFS_Code,
                        json[i].Staff_Role_Code,
                        json[i].Title_Designation_Description,
                        json[i].Min_No_of_Recomm_Staff,
                        json[i].Requirement_Type,
                        json[i].Staff_Category,                        
                        '<a class="btn btn-success edit_equipment_details" id="edit_equipment_details"><i class="fa fa-share m-r-10"></i>Edit</a>',
                        '<a class="btn btn-danger edit_equipment_details" id="edit_equipment_details"><i class="fa fa-share m-r-10"></i>Delete</a>'
                    ]);
                }
            });
           // personnelTable.on("click",
           //".edit_equipment_details",
           //   function (personnelTable) {
           //       personnelTable.preventDefault();
           //       var i = $(this).parents("tr")[0];
           //       //put editing code here below
           //       $("#editequipmentcategory").val(i.cells[1].innerHTML);
           //       $("#editdescription").val(i.cells[2].innerHTML);
           //       $("#editOwnershiptype").val(i.cells[3].innerHTML);
           //       $("#editequipmentserial").val(i.cells[4].innerHTML);
           //       $("#edityears").val(i.cells[5].innerHTML);
           //       $("#editequipments").val(i.cells[6].innerHTML);
           //       $('#edit_Equipments').modal('show');
           //       //end editing code
           //   });
        }
        return {
            init: function () {
                bidpersonnel();
            }
        }
    }();
    //Get All BankAccounts  Details
    var BidResponseBalanceSheet = function () {
        var balancesheet = function () {
            var balanceSheetTable = $("#tbl_vendor_responsebalancesheet"),
                l = balanceSheetTable.dataTable({
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
                url: "/Home/GetBidResponseBalanceSheetDetails",
            });
            $.ajax({
                data: { BidResponseNumber: BidResponseNumber },
            }).done(function (json) {
                l.fnClearTable();
                var o = 1;
                for (var i = 0; i < json.length; i++) {
                    l.fnAddData([
                        o++,
                        json[i].Audit_Year_Code_Reference,
                        json[i].Owners_Equity_LCY,
                        json[i].Fixed_Assets_LCY,
                        json[i].Current_Assets_LCY,
                        json[i].Current_Liabilities_LCY,
                        '<a class="btn btn-success edit_balancesheet_details" id="edit_banks"><i class="fa fa-edit m-r-10"></i>Edit</a>',
                        '<a class="btn btn-danger  delete_balance_details"><i class="fa fa-trash m-r-10">Delete</a>'
                    ]);
                }
            });
            balanceSheetTable.on("click",
               ".edit_balancesheet_details",
               function (balanceSheetTable) {
                   balanceSheetTable.preventDefault();
                   var i = $(this).parents("tr")[0];
                   // alert("record to be deleted: " + i.cells[1].innerHTML);
                   $("#ddlyearcodes").val(i.cells[1].innerHTML);
                   $("#edittotalcurrentassets").val(i.cells[3].innerHTML);
                   $("#edittotalfixedassets").val(i.cells[4].innerHTML);
                   $("#edittotalcurrentliabilities").val(i.cells[5].innerHTML);
                   $("#edittotallontermliabilities").val(i.cells[5].innerHTML);
                   $("#edittotalownersequity").val(i.cells[6].innerHTML);
                   $("#edit_Balancesheet").modal();
            });
            balanceSheetTable.on("click",
              ".delete_balance_details",
              function (balanceSheetTable) {
                  balanceSheetTable.preventDefault();
                  var i = $(this).parents("tr")[0];
                  //alert("record to be deleted: " + i.cells[1].innerHTML);
                  BidRespNumber = $("#bidnumber").val(),
                  yearCode = i.cells[1].innerHTML
                  Swal.fire({
                      title: "Confirm Deleting Balance Sheet",
                      text: "Sure you'd like to proceed with deletion?",
                      type: "warning",
                      showCancelButton: true,
                      closeOnConfirm: true,
                      confirmButtonText: "Yes, Delete Balance Sheet!",
                      confirmButtonClass: "btn-success",
                      confirmButtonColor: "#008000",
                      position: "center"
                  }).then((result) => {
                      if (result.value) {
                          //global loader spinner;
                          $.ajaxSetup({
                              global: false,
                              type: "POST",
                              url: "/Home/DeleteBidResponseBalanceSheetDetails",
                          });
                          $.ajax({
                              data: "{'BidRespNumber':'" + BidRespNumber + "','yearCode':'" + yearCode + "'}",
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
                                          title:"Balance Sheet Details Deleted!",
                                          text: "Balance Sheet Details Deleted Successfully!",
                                          type: "success"
                                      }).then(() => {
                                          $("#balancesheetfeedback").css("display", "block");
                                          $("#balancesheetfeedback").css("color", "green");
                                          $('#balancesheetfeedback').attr("class", "alert alert-success");
                                          $("#balancesheetfeedback").html("Your Balance Sheet Details have been successfully Deleted.Kindly Proceed to fill in the rest details!");
                                          $("#balancesheetfeedback").css("display", "block");
                                          $("#balancesheetfeedback").css("color", "green");
                                          $("#balancesheetfeedback").html("Your Balance Sheet Details have been successfully Deleted.Kindly Proceed to fill in the rest details!");
                                      });
                                      BidResponseBalanceSheet.init();
                                      break;
                                  default:
                                      Swal.fire
                                         ({
                                             title:"Balance Sheet Details Deletion Error!!!",
                                             text: status,
                                             type: "error"
                                         }).then(() => {
                                             $("#balancesheetfeedback").css("display", "block");
                                             $("#balancesheetfeedback").css("color", "red");
                                             $('#balancesheetfeedback').addClass('alert alert-danger');
                                             $("#balancesheetfeedback").html("Your Balance Sheet Details could not be Deleted.KindlyTy Again!");
                                         });
                              }
                          });
                      } else if (result.dismiss === Swal.DismissReason.cancel) {
                          Swal.fire(
                              'Balance Sheet Deletion Cancelled',
                              'You cancelled your Balance Sheet deletion Request!',
                              'error'
                          );
                      }
                  });

              });
        }
        return {
            init: function () {
                balancesheet();
            }
        }
    }();

    //Get All BankAccounts  Details
    var BidResponseIncomeStatement = function () {
        var Incomestatement = function () {
            var IncomestatementTable = $("#tbl_incomestatement_details"),
                l = IncomestatementTable.dataTable({
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
                url: "/Home/GetBidResponseIncomeStatementDetails",
            });
            $.ajax({
                data: { BidResponseNumber: BidResponseNumber },
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
                        '<a class="btn btn-success edit_incomestatament_details" id="edit_banks"><i class="fa fa-edit m-r-10"></i>Edit</a>',
                        '<a class="btn btn-danger  delete_incomestatement_details"><i class="fa fa-trash m-r-10">Delete</a>'
                    ]);
                }
            });
            IncomestatementTable.on("click",
               ".edit_incomestatament_details",
               function (IncomestatementTable) {
                   IncomestatementTable.preventDefault();
                   var i = $(this).parents("tr")[0];
                   // alert("record to be deleted: " + i.cells[1].innerHTML);
                   $("#dropdownyearcodeslists").val(i.cells[1].innerHTML);
                   $("#edittotalrevenue").val(i.cells[2].innerHTML);
                   $("#edittotalcogs").val(i.cells[3].innerHTML);
                   $("#editoperatingexpense").val(i.cells[3].innerHTML);
                   $("#editnonoperatingexpense").val(i.cells[4].innerHTML);
                   $("#editinterestexpense").val(i.cells[5].innerHTML);
                   $("#edit_incomestatement").modal();
               });
            IncomestatementTable.on("click",
              ".delete_incomestatement_details",
              function (IncomestatementTable) {
                  IncomestatementTable.preventDefault();
                  var i = $(this).parents("tr")[0];
                  //alert("record to be deleted: " + i.cells[1].innerHTML);
                  BidRespNumber = $("#bidnumber").val(),
                  yearCode = i.cells[1].innerHTML
                  Swal.fire({
                      title: "Confirm Deleting Income Stataement",
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
                              url: "/Home/DeleteBidResponseIncomeStatementDetails",
                          });
                          $.ajax({
                              data: "{'BidRespNumber':'" + BidRespNumber + "','yearCode':'" + yearCode + "'}",
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
                                          text: "Income Statement  Details Deleted Successfully!",
                                          type: "success"
                                      }).then(() => {
                                          $("#incometstatementfeedback").css("display", "block");
                                          $("#incometstatementfeedback").css("color", "green");
                                          $('#incometstatementfeedback').attr("class", "alert alert-success");
                                          $("#incometstatementfeedback").html("Your Income Statement  Details have been successfully Deleted.Kindly Proceed to fill in the rest details!");
                                          $("#incometstatementfeedback").css("display", "block");
                                          $("#incometstatementfeedback").css("color", "green");
                                          $("#incometstatementfeedback").html("Your Income Statement  Details have been successfully Deleted.Kindly Proceed to fill in the rest details!");
                                      });
                                      BidResponseIncomeStatement.init();
                                      break;
                                  default:
                                      Swal.fire
                                         ({
                                             title: "Income Statement  Details Deletion Error!!!",
                                             text: status,
                                             type: "error"
                                         }).then(() => {
                                             $("#incometstatementfeedback").css("display", "block");
                                             $("#incometstatementfeedback").css("color", "red");
                                             $('#incometstatementfeedback').addClass('alert alert-danger');
                                             $("#incometstatementfeedback").html("Your Income Statement  Details could not be Deleted.KindlyTy Again!");
                                         });
                              }
                          });
                      } else if (result.dismiss === Swal.DismissReason.cancel) {
                          Swal.fire(
                              'Income Statement  Deletion Cancelled',
                              'You cancelled your Income Statement  deletion Request!',
                              'error'
                          );
                      }
                  });

              });
        }
        return {
            init: function () {
                Incomestatement();
            }
        }
    }();
    //Supplier Bid Pricing Details Function
    $(".btn_edit_pricingDetails").click(function () {
        var PastExperiencenObj = {
            "Document_No": $("#bidnumber").val(),
            "Line_No": $("#editilinetemnumber").val(),
            "No": $("#edititemnumber").val(),
            "Direct_Unit_Cost": $("#editdirectexvat").val(),
            "Quantity": $("#bidedititemquantity").val(),
        }
        console.log(JSON.stringify(PastExperiencenObj))
        //Swal Message
        Swal.fire({
            title: "Confirm Price  Details Submission?",
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
                    url: "/Home/BidResponsePriceDetails",
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
                                title: "Price Details Submitted!",
                                text: "Your Price Details have been successfully submitted",
                                type: "success"
                            }).then(() => {
                                $("#pricingfeedback").css("display", "block");
                                $("#pricingfeedback").css("color", "green");
                                $('#pricingfeedback').attr("class", "alert alert-success");
                                $("#pricingfeedback").html("Your Price Details have been successfully submitted.Kindly Proceed to fill in the rest details!");
                                $("#pricingfeedback").css("display", "block");
                                $("#pricingfeedback").css("color", "green");
                                $("#pricingfeedback").html("Your Price Details have been successfully submitted.Kindly Proceed to fill in the rest details!");

                            });
                            BidResponsePricing.init();
                            $('#edit_PriceLines').modal('hide');
                            break;
                        default:
                            Swal.fire
                            ({
                                title: "Price Details Submission Error!!!",
                                text: "Your Price Details could not be submitted" + " " + registerstatus[1] + ".Kindly Proceed to fill in the rest details",
                                type: "error"
                            }).then(() => {
                                $("#pricingfeedback").css("display", "block");
                                $("#pricingfeedback").css("color", "red");
                                $('#pricingfeedback').addClass('alert alert-danger');
                                $("#pricingfeedback").html("Your Price Details could not be submitted" +" "+ registerstatus[1] + ".Kindly Proceed to fill in the rest details!");
                            });
                            break;
                    }
                }
                );
            } else if (result.dismiss === Swal.DismissReason.cancel) {
                Swal.fire(
                    'Price Details Cancelled',
                    'You cancelled your Price submission details!',
                    'error'
                );
            }
        });

    });

    //Get All BankAccounts  Details
    var BidResponsePricing = function () {
        var bidpricing = function () {
            var PricingTable = $("#tbl_bidpricing_details"),
                l = PricingTable.dataTable({
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
                url: "/Home/GetBidResponsePricingDetails",
            });
            $.ajax({
                data: { BidResponseNumber: BidResponseNumber },
            }).done(function (json) {
                l.fnClearTable();
                var o = 1;
                for (var i = 0; i < json.length; i++) {
                    l.fnAddData([
                        o++,
                        json[i].Line_No,
                        json[i].Type,
                        json[i].No,
                        json[i].Description,
                        json[i].Quantity,
                        json[i].Unit_of_Measure,
                        json[i].Amount,
                        json[i].Amount_Including_VAT,
                        '<a class="btn btn-success edit_pricing_details" id="edit_banks"><i class="fa fa-share m-r-10"></i>Respond</a>'
                    ]);
                }
            });
            PricingTable.on("click",
               ".edit_pricing_details",
               function (balanceSheetTable) {
                   balanceSheetTable.preventDefault();
                   var i = $(this).parents("tr")[0];
                   $("#editilinetemnumber").val(i.cells[1].innerHTML);
                   $("#edititemdescription").val(i.cells[4].innerHTML);
                   $("#edititemquantity").val(i.cells[5].innerHTML);
                   $("#editunitofmeasure").val(i.cells[6].innerHTML);
                   $("#editdirectexvat").val(i.cells[7].innerHTML);
                   $("#editmaouninvat").val(i.cells[8].innerHTML);
                   $("#edit_PriceLines").modal();


               });
        }
        return {
            init: function () {
                bidpricing();
            }
        }
    }();

    //Supplier Bid Pricing Details Function
    $(".button_submit_tender_response").click(function () {
        //Swal Message
        Swal.fire({
            title: "Confirm Bid Response Submission?",
            text: "Are you sure you would like to proceed with Bid Response submission?",
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
                    url: "/Home/ActiveTenderNotices",
                    type: "POST",
                    data:"",
                    contentType: "application/json",
                    cache: false,
                    processData: false
                }).done(function () {
                    Swal.fire
                           ({
                               title: "Tender Response Submitted!",
                               text: status,
                               type: "success"
                           }).then(() => {
                               $("#bideresponsesubmissionfeedback").css("display", "block");
                               $("#bideresponsesubmissionfeedback").css("color", "green");
                               $('#bideresponsesubmissionfeedback').attr("class", "alert alert-success");
                               $("#bideresponsesubmissionfeedback").html("Your Tender Response Details have been successfully submitted.");
                               $("#bideresponsesubmissionfeedback").css("display", "block");
                               $("#bideresponsesubmissionfeedback").css("color", "green");
                               $("#bideresponsesubmissionfeedback").html("Your Tender Response Details have been successfully submitted.!");
                               window.location.href = "/Home/ActiveTenderNotices"
                           });
                   
                }
                );
            } else if (result.dismiss === Swal.DismissReason.cancel) {
                Swal.fire(
                    'Tender Response Details Cancelled',
                    'You cancelled your Tender Response submission details!',
                    'error'
                );
            }
        });

    });

  
    //Supplier BidEquipments Reponse Function
    $(".btn_editEquipments").click(function () {
        //Set data to be sent
        var data = {
            "No": $("#bidnumber").val(),
            "Equipment_Type_Code": $("#ddlequipmentcategories").val(),
            "Ownership_Type": $("#editOwnershiptype").val(),
            "Years_of_Previous_Use": $("#edityears").val(),
            "Equipment_Condition_Code": $("#editequipments").val(),
            "Equipment_Usability_Code": $("#editusabilitycode").val(),
            "Equipment_Serial": $("#editequipmentserial").val(),
            "Qty_of_Equipment": $("#editequipmentquantity").val(),

        }
        var No = $("#bidnumber").val();
        var Equipment_Type_Code = $("#ddlequipmentcategories").val();
        var browsedDoc = document.getElementById('inputFileselector').files[0];
        var Ownership_Type = $("#editOwnershiptype").val();
        var Years_of_Previous_Use = $("#edityears").val();
        var Equipment_Condition_Code = $("#editequipments").val();
        var Equipment_Usability_Code = $("#editusabilitycode").val();
        var Equipment_Serial = $("#editequipmentserial").val();
        var Qty_of_Equipment = $("#editequipmentquantity").val();


        var formDt = new FormData();
        formDt.append("No", No);
        formDt.append("browsedfile", browsedDoc);
        formDt.append("Equipment_Type_Code", Equipment_Type_Code);
        formDt.append("Ownership_Type", Ownership_Type);
        formDt.append("Years_of_Previous_Use", Years_of_Previous_Use);
        formDt.append("Equipment_Condition_Code", Equipment_Condition_Code);
        formDt.append("Equipment_Usability_Code", Equipment_Usability_Code);
        formDt.append("Equipment_Serial", Equipment_Serial);
        formDt.append("Qty_of_Equipment", Qty_of_Equipment);
     

        //Swal Message
        Swal.fire({
            title: "Confirm Bid Equipments Details?",
            text: "Are you sure you would like to Submit Bid Response  Equipments Details?",
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
                    url: "/Home/AddBidEquipmentsSpecificationDetails",
                    type: "POST",
                    data: formDt,
                    contentType: false,
                    cache: false,
                    processData: false
                }).done(function (status) {
                    var registerstatus = status.split('*');
                    status = registerstatus[0];
                    switch (status) {
                        case "success":
                            Swal.fire
                            ({
                                title: "Bid Response Equipments Details Submitted!",
                                text: "Your Bid Response Equipments Details was successfully submitted",
                                type: "success"
                            }).then(() => {
                                $("#bideresponseequipmentsfeedback").css("display", "block");
                                $("#bideresponseequipmentsfeedback").css("color", "green");
                                $('#bideresponseequipmentsfeedback').attr("class", "alert alert-success");
                                $("#bideresponseequipmentsfeedback").html("Your Bid Response Equipments Details was successfully submitted.Kindly proceed to fill in More Details!");
                                $("#bideresponseequipmentsfeedback").css("display", "block");
                                $("#bideresponseequipmentsfeedback").css("color", "green");
                                $("#bideresponseequipmentsfeedback").html("Your Bid Response Equipments Details was successfully submitted.Kindly proceed to fill in More Details!");
                           
                            });
                            VendorBidEquipmentsDetails.init();
                            $('#edit_Equipments').modal('hide');
                            break;
                        default:
                            Swal.fire
                            ({
                                title: "Bid Response Equipments Error!!!",
                                text: "Your Bid Response Equipments Details was successfully submitted" + registerstatus[1],
                                type: "error"
                            }).then(() => {
                                $("#bideresponseequipmentsfeedback").css("display", "block");
                                $("#bideresponseequipmentsfeedback").css("color", "red");
                                $('#bideresponseequipmentsfeedback').addClass('alert alert-danger');
                                $("#bideresponseequipmentsfeedback").html("Your Bid Response Equipments Details was successfully submitted" + registerstatus[1]);
                            });
                            break;
                    }
                }
                );
            } else if (result.dismiss === Swal.DismissReason.cancel) {
                Swal.fire(
                    'Bid Response Equipments Details Cancelled',
                    'You cancelled your Bid Response Equipments submission details!',
                    'error'
                );
            }
        });

    });

    //Supplier BidEquipments Reponse Function
    $(".btn_savepersonnel").click(function () {
        //Set data to be sent
        
        var data = {
            "No": $("#bidnumber").val(),
            "StaffName": $("#staffName").val(),
            "StaffCategory": $("#staffcategory").val(),
            "EmploymentType": $("#emplymentType").val(),
            "EmailAddress": $("#emailAddress").val(),
            "Profession": $("#profession").val(),
            "ProjectRoleCode": $("#projectRoleCode").val(),
            "RequiredProfession": $("#requiredProjectRole").val(),
            "browsedFile": document.getElementById('inputFileselectorstaff').files[0]
            
        }
        var No = $("#bidnumber").val();
        var StaffName = $("#staffName").val();
        var StaffCategory = $("#staffcategory").val();
        var EmploymentType = $("#emplymentType").val();
        var EmailAddress = $("#emailAddress").val();
        var Profession = $("#profession").val();
        var ProjectRoleCode = $("#projectRoleCode").val();
        var RequiredProfession = $("#requiredProjectRole").val();
        var browsedDoc = document.getElementById('inputFileselectorstaff').files[0];


        var formDt = new FormData();
        formDt.append("No", No);
        formDt.append("StaffName", StaffName);
        formDt.append("StaffCategory", StaffCategory);
        formDt.append("EmploymentType", EmploymentType);
        formDt.append("EmailAddress", EmailAddress);
        formDt.append("Profession", Profession);
        formDt.append("ProjectRoleCode", ProjectRoleCode);
        formDt.append("RequiredProfession", RequiredProfession);
        formDt.append("browsedfile", browsedDoc);
        console.log(JSON.stringify({ formdata: formDt }));
        //Swal Message
        Swal.fire({
            title: "Confirm Personnel Details?",
            text: "Are you sure you would like to Submit Personnel Details?",
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
                    url: "/Home/AddBidPersonnelDetails",
                    type: "POST",
                    data: formDt,
                    contentType: false,
                    cache: false,
                    processData: false
                }).done(function (status) {
                    var registerstatus = status.split('*');
                    status = registerstatus[0];
                    switch (status) {
                        case "success":
                            Swal.fire
                            ({
                                title: "Bid Response Personel Details Submitted!",
                                text: "Your Bid Response personnel Details was successfully submitted",
                                type: "success"
                            }).then(() => {
                                $("#bideresponseequipmentsfeedback").css("display", "block");
                                $("#bideresponseequipmentsfeedback").css("color", "green");
                                $('#bideresponseequipmentsfeedback').attr("class", "alert alert-success");
                                $("#bideresponseequipmentsfeedback").html("Your Bid Response personnel Details was successfully submitted.Kindly proceed to fill in More Details!");
                                $("#bideresponseequipmentsfeedback").css("display", "block");
                                $("#bideresponseequipmentsfeedback").css("color", "green");
                                $("#bideresponseequipmentsfeedback").html("Your Bid Response personnel Details was successfully submitted.Kindly proceed to fill in More Details!");
                                
                            });
                            VendorPersonnelDetails.init();
                            $('#edit_personell').modal('hide');
                            break;
                        default:
                            Swal.fire
                            ({
                                title: "Bid Response personnel Error!!!",
                                text: "Your Bid Response personnel Details was successfully submitted" + registerstatus[1],
                                type: "error"
                            }).then(() => {
                                $("#bideresponseequipmentsfeedback").css("display", "block");
                                $("#bideresponseequipmentsfeedback").css("color", "red");
                                $('#bideresponseequipmentsfeedback').addClass('alert alert-danger');
                                $("#bideresponseequipmentsfeedback").html("Your Bid Response personnel Details was successfully submitted" + registerstatus[1]);
                            });
                            break;
                    }
                }
                );
            } else if (result.dismiss === Swal.DismissReason.cancel) {
                Swal.fire(
                    'Bid Response personnel Details Cancelled',
                    'You cancelled your Bid Response personnel submission details!',
                    'error'
                );
            }
        });

    });

    //Supplier Balance Sheet Reponse Function
    $(".btn_editBalancesheeetDetails").click(function () {
        //Set data to be sent
        var data = {
            "No": $("#bidnumber").val(),
            "Audit_Year_Code_Reference": $("#ddlyearcodes").val(),
            "Total_Assets_LCY": $("#edittotalcurrentassets").val(),
            "Fixed_Assets_LCY": $("#edittotalfixedassets").val(),
            "Current_Liabilities_LCY": $("#edittotalcurrentliabilities").val(),
            "Long_term_Liabilities_LCY": $("#edittotallontermliabilities").val(),
            "Owners_Equity_LCY": $("#edittotalownersequity").val()
        }
        //Swal Message
        Swal.fire({
            title: "Confirm Bid Balance Sheet Details?",
            text: "Are you sure you would like to Submit Bid Response  Equipments Details?",
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
                    url: "/Home/EditBidBalanceSheetDetails",
                    type: "POST",
                    data: JSON.stringify(data),
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
                                title: "Bid Response Balance Sheet  Details Submitted!",
                                text: status,
                                type: "success"
                            }).then(() => {
                                $("#balancesheetfeedback").css("display", "block");
                                $("#balancesheetfeedback").css("color", "green");
                                $('#balancesheetfeedback').attr("class", "alert alert-success");
                                $("#balancesheetfeedback").html("Your Bid Response Balance Sheet  Details was successfully submitted.Kindly proceed to fill in More Details!");
                                $("#balancesheetfeedback").css("display", "block");
                                $("#balancesheetfeedback").css("color", "green");
                                $("#balancesheetfeedback").html("Your Bid Response Balance Sheet  Details was successfully submitted.Kindly proceed to fill in More Details!");
                                $("#balancesheetfeedback").reset();
                            });
                            BidResponseBalanceSheet.init();
                            $('#edit_Balancesheet').modal('hide');
                          
                            break;
                        default:
                            Swal.fire
                            ({
                                title: "Bid Response Equipments Error!!!",
                                text: status,
                                type: "error"
                            }).then(() => {
                                $("#balancesheetfeedback").css("display", "block");
                                $("#balancesheetfeedback").css("color", "red");
                                $('#balancesheetfeedback').addClass('alert alert-danger');
                                $("#balancesheetfeedback").html(status);
                            });
                            break;
                    }
                }
                );
            } else if (result.dismiss === Swal.DismissReason.cancel) {
                Swal.fire(
                    'Bid Response Balance Sheet  Details Cancelled',
                    'You cancelled your Bid Response Balance Sheet  submission details!',
                    'error'
                );
            }
        });
        
    });


    //Supplier Income Statement Function
    $(".btn_editIncomeStatementDetails").click(function () {
        //Set data to be sent
        var data = {
            "No": $("#bidnumber").val(),
            "Audit_Year_Code_Reference": $("#ddlyearcodes").val(),
            "Total_Revenue_LCY": $("#edittotalrevenue").val(),
            "Total_COGS_LCY": $("#totalcogs").val(),
            "Total_Operating_Expenses_LCY": $("#editoperatingexpense").val(),
            "Other_Non_operating_Re_Exp_LCY": $("#editnonoperating").val(),
            "Interest_Expense_LCY": $("#editinterestexpense").val()
        }
        //Swal Message
        Swal.fire({
            title: "Confirm Bid Income Statement Details?",
            text: "Are you sure you would like to Submit Bid Response Income Statement Details?",
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
                    url: "/Home/EditBidIncomeStatementetails",
                    type: "POST",
                    data: JSON.stringify(data),
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
                                title: "Bid Response  Income Statement Details Submitted!",
                                text: status,
                                type: "success"
                            }).then(() => {
                                $("#incometstatementfeedback").css("display", "block");
                                $("#incometstatementfeedback").css("color", "green");
                                $('#incometstatementfeedback').attr("class", "alert alert-success");
                                $("#incometstatementfeedback").html("Your Bid Response Income Statement Details was successfully submitted.Kindly proceed to fill in More Details!");
                                $("#incometstatementfeedback").css("display", "block");
                                $("#incometstatementfeedback").css("color", "green");
                                $("#incometstatementfeedback").html("Your Bid Response Income Statement  Details was successfully submitted.Kindly proceed to fill in More Details!");
                                $("#incometstatementfeedback").reset();
                            });
                            BidResponseIncomeStatement.init();
                            $('#edit_incomestatement').modal('hide');
                            break;
                        default:
                            Swal.fire
                            ({
                                title: "Bid Response Income Statement Error!!!",
                                text: status,
                                type: "error"
                            }).then(() => {
                                $("#incometstatementfeedback").css("display", "block");
                                $("#incometstatementfeedback").css("color", "red");
                                $('#incometstatementfeedback').addClass('alert alert-danger');
                                $("#incometstatementfeedback").html(status);
                            });
                            break;
                    }
                }
                );
            } else if (result.dismiss === Swal.DismissReason.cancel) {
                Swal.fire(
                    'Bid Response Income Statement  Details Cancelled',
                    'You cancelled your Bid Response Balance Sheet  submission details!',
                    'error'
                );
            }
        });
    });
    //Get Balance Sheet  bidder Details
    var BidBalanceSheetDetails = function () {
        var bidResponseNumber = $("#bidnumber").val();
        var balancesheets = function () {
            $.ajaxSetup({
                global: false,
                type: "POST",
                url: "/Home/RespondTenderWizard?respondtendernumber=" + bidResponseNumber,
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
                        json[i].Total_Assets_LCY,
                        json[i].Fixed_Assets_LCY,
                        json[i].Current_Assets_LCY,
                        json[i].Total_Liabilities_LCY                     
                    ]);
                }
            });
        }
        return {
            init: function () {
                balancesheets();
            }
        }
    }();
    $('.button-upload_response_Documents').click(function (e) {
        //To prevent form submit after ajax call
        e.preventDefault();
        //reset to empty
        $("#uploadsMsg").html("");
        var selectedFtype = $('#ddldocumentdroplist').find(":selected").attr('value');
        var selvaluedescription = $("#ddldocumentdroplist option:selected").text();
        var browsedDoc = document.getElementById('inputFileselector').files[0];
        var certNumber = $("#txtCertNo").val();
        var dateofissue = $("#dateOfIssue").val();
        var xprydate = $("#dateOfexpiry").val();

        var formDt = new FormData();
        formDt.append("typauploadselect", selectedFtype);
        formDt.append("browsedfile", browsedDoc);
        formDt.append("filedescription", selvaluedescription);
        formDt.append("certificatenumber", certNumber);
        formDt.append("dateofissue", dateofissue);
        formDt.append("expirydate", xprydate);

        //for test
        console.log(JSON.stringify({formdata: formDt }));
        Swal.fire({
            title: "Upload Document?",
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
                    beforeSend: function () {
                        $(".progress-bar").width('0%');
                        $('#uploadsMsg').html('<img src="~/assets/loaders/load.gif"/>');
                    },
                    error: function () {
                        $("#uploadsMsg").css("color", "red");
                        $('#uploadsMsg').addClass('alert alert-danger');
                        $("#uploadsMsg").html("File upload failed, choose another file and try again!");
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
                                    $("#regfeedback").css("display", "block");
                                    $("#regfeedback").css("color", "green");
                                    $('#regfeedback').attr("class", "alert alert-success");
                                    $("#regfeedback").html("Selected File Uploaded Successfully!");
                                    $("#uploadsMsg").css("display", "block");
                                    $("#uploadsMsg").css("color", "green");
                                    $("#uploadsMsg").html(uploadsfs[1]);
                                    po.init();

                                });

                                break;
                            case "browsedfilenull":
                                Swal.fire
                                ({
                                    title: "File Selection Null!",
                                    text: "File input cannot be empty!",
                                    type: "error"
                                }).then(() => {
                                    $("#regfeedback").css("display", "block");
                                    $("#regfeedback").css("color", "red");
                                    $('#regfeedback').attr('class', 'alert alert-danger');
                                    $("#regfeedback").html("File input cannot be empty!");
                                    $("#inputFileselector").focus();
                                    $("#inputFileselector").css("border", "solid 1px red");
                                });
                                break;

                            default:
                                Swal.fire
                                ({
                                    title: "Error!!!",
                                    text: uploadsfs[1],
                                    type: "error"
                                }).then(() => {
                                    $("#regfeedback").css("display", "block");
                                    $("#regfeedback").css("color", "red");
                                    $('#regfeedback').addClass('alert alert-danger');
                                    $("#regfeedback").html(uploadsfs[1]);
                                });

                                break;
                        }


                    }
                });
            } else if (result.dismiss === Swal.DismissReason.cancel) {
                Swal.fire(
                    'Cancelled',
                    'You cancelled your submission!',
                    'error'
                );
            }
        });
    });
    //Supplier Bid Pricing Details Function
    $(".btn_submitBidSecurity_Details").click(function () {
        var BidSecurityObj = {
            "No": $("#bidnumber").val(),
            "IFS_No": $("#invitationnumber").val(),
            "Form_of_Security": $("#ddformofsecurity").val(),
            "Issuer_Institution_Type": $("#issuertype").val(),
            "Security_Type": $("#securitytypes").val(),
            "Issuer_Guarantor_Name": $("#guarantorname").val(),
            "Issuer_Registered_Offices": $("#issueroffices").val(),
            "Description": $("#biddescriptions").val(),
            "Security_Amount_LCY": $("#securityamounts").val(),
            "Bid_Security_Effective_Date": $("#bideffectivedates").val(),
            "Bid_Security_Validity_Expiry": $("#bidexpirydates").val()
        }
        console.log(JSON.stringify(BidSecurityObj))
        //Swal Message
        Swal.fire({
            title: "Confirm Bid Security Submission?",
            text: "Are you sure you would like to proceed with submission of Bid Security?",
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
                    url: "/Home/RegisterBidSecurityDetails",
                    type: "POST",
                    data: JSON.stringify(BidSecurityObj),
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
                                title: "Bid Security Details Submitted!",
                                text: status,
                                type: "success"
                            }).then(() => {
                                $("#bidsecurityfeedback").css("display", "block");
                                $("#bidsecurityfeedback").css("color", "green");
                                $('#bidsecurityfeedback').attr("class", "alert alert-success");
                                $("#bidsecurityfeedback").html("Your Bid Security Details have been successfully submitted.Kindly Proceed to fill in the rest details!");
                                $("#bidsecurityfeedback").css("display", "block");
                                $("#bidsecurityfeedback").css("color", "green");
                                $("#bidsecurityfeedback").html("Your Bid Security Details have been successfully submitted.Kindly Proceed to fill in the rest details!");
                            });
                            BidTenderSecurity.init();
                            $('#add_BidSecurity').modal('hide');
                            break;
                        default:
                            Swal.fire
                            ({
                                title: "Bid Security Details Submission Error!!!",
                                text: status,
                                type: "error"
                            }).then(() => {
                                $("#bidsecurityfeedback").css("display", "block");
                                $("#bidsecurityfeedback").css("color", "red");
                                $('#bidsecurityfeedback').addClass('alert alert-danger');
                                $("#bidsecurityfeedback").html("Your Bid Security Details could not be submitted" + status + ".Kindly Proceed to fill in the rest details!");
                            });
                            break;
                    }
                }
                );
            } else if (result.dismiss === Swal.DismissReason.cancel) {
                Swal.fire(
                    'Bid Security Details Cancelled',
                    'You cancelled your Bid Security submission details!',
                    'error'
                );
            }
        });

    });
    var BidTenderSecurity = function () {
        var tendersecurity = function () {
            var tendersecuritytable = $("#tbl_tender_security"),
                l = tendersecuritytable.dataTable({
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
                url: "/Home/GetTenderSecurityDetails",
            });
            $.ajax({
                data: { BidResponseNumber: BidResponseNumber },
            }).done(function (json) {
                l.fnClearTable();
                var o = 1;
                for (var i = 0; i < json.length; i++) {
                    l.fnAddData([
                        //o++,
                        json[i].Security_ID,
                        json[i].Security_Type,
                        json[i].Issuer_Institution_Type,
                        json[i].Issuer_Guarantor_Name,
                        json[i].Issuer_Registered_Offices,
                        json[i].Description,
                        json[i].Security_Amount_LCY,
                        '<a class="btn btn-success edit_tender_security" id="edit_banks"><i class="fa fa-edit m-r-10"></i>Edit</a>',
                        '<a class="btn btn-danger  delete_tender_security"><i class="fa fa-trash m-r-10">Delete</a>'
                    ]);
                }
            });
            tendersecuritytable.on("click",
               ".edit_tender_security",
               function (tendersecuritytable) {
                   tendersecuritytable.preventDefault();
                   var i = $(this).parents("tr")[0];
                   // alert("record to be deleted: " + i.cells[1].innerHTML);
                   $("#dropdownyearcodeslists").val(i.cells[1].innerHTML);
                   $("#edittotalrevenue").val(i.cells[2].innerHTML);
                   $("#edittotalcogs").val(i.cells[3].innerHTML);
                   $("#editoperatingexpense").val(i.cells[3].innerHTML);
                   $("#editnonoperatingexpense").val(i.cells[4].innerHTML);
                   $("#editinterestexpense").val(i.cells[5].innerHTML);
                   $("#edit_incomestatement").modal();
               });
            tendersecuritytable.on("click",
              ".delete_tender_security",
              function (tendersecuritytable) {
                  tendersecuritytable.preventDefault();
                  var i = $(this).parents("tr")[0];
                  //alert("record to be deleted: " + i.cells[1].innerHTML);
                  BidRespNumber = $("#bidnumber").val(),
                  Securityid = i.cells[1].innerHTML
                  Swal.fire({
                      title: "Confirm Deleting Tender Security",
                      text: "Sure you'd like to proceed with deletion?",
                      type: "warning",
                      showCancelButton: true,
                      closeOnConfirm: true,
                      confirmButtonText: "Yes, Delete Tender Security!",
                      confirmButtonClass: "btn-success",
                      confirmButtonColor: "#008000",
                      position: "center"
                  }).then((result) => {
                      if (result.value) {
                          //global loader spinner;
                          $.ajaxSetup({
                              global: false,
                              type: "POST",
                              url: "/Home/DeleteBidTenderSecurityDetails",
                          });
                          $.ajax({
                              data: "{'BidRespNumber':'" + BidRespNumber + "','Securityid':'" + Securityid + "'}",
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
                                          title:"Tender Security Details Deleted!",
                                          text: "Tender Security Details Deleted Successfully!",
                                          type: "success"
                                      }).then(() => {
                                          $("#bidsecurityfeedback").css("display", "block");
                                          $("#bidsecurityfeedback").css("color", "green");
                                          $('#bidsecurityfeedback').attr("class", "alert alert-success");
                                          $("#bidsecurityfeedback").html("Your Tender Security  Details have been successfully Deleted.Kindly Proceed to fill in the rest details!");
                                          $("#bidsecurityfeedback").css("display", "block");
                                          $("#bidsecurityfeedback").css("color", "green");
                                          $("#bidsecurityfeedback").html("Your Tender Security  Details have been successfully Deleted.Kindly Proceed to fill in the rest details!");
                                      });
                                      BidResponseIncomeStatement.init();
                                      break;
                                  default:
                                      Swal.fire
                                         ({
                                             title: "Tender Security Details Deletion Error!!!",
                                             text: status,
                                             type: "error"
                                         }).then(() => {
                                             $("#bidsecurityfeedback").css("display", "block");
                                             $("#bidsecurityfeedback").css("color", "red");
                                             $('#bidsecurityfeedback').addClass('alert alert-danger');
                                             $("#bidsecurityfeedback").html("Your Tender Security Details could not be Deleted.KindlyTy Again!");
                                         });
                              }
                          });
                      } else if (result.dismiss === Swal.DismissReason.cancel) {
                          Swal.fire(
                              'Tender Security Deletion Cancelled',
                              'You cancelled your Tender Security deletion Request!',
                              'error'
                          );
                      }
                  });

              });
        }
        return {
            init: function () {
                tendersecurity();
            }
        }
    }();
    $('.button_upload_response_Documents').click(function (e) {
        //To prevent form submit after ajax call
        e.preventDefault();
        //reset to empty
        $("#uploadsMsg").html("")
        var TenderBidReponseNumber = $("#bidnumber").val();
        var selectedFtype = $('#tenderddldocumentdroplist').find(":selected").attr('value');
        var selvaluedescription = $("#tenderddldocumentdroplist option:selected").text();
        var browsedDoc = document.getElementById('inputFileselector').files[0];
        var certNumber = $("#externaltxtCertNo").val();
        var dateofissue = $("#datesOfIssues").val();
        var xprydate = $("#datesOfexpiries").val();

        var formDt = new FormData();
        formDt.append("BidResponseNumber", TenderBidReponseNumber);
        formDt.append("browsedfile", browsedDoc);
        formDt.append("typauploadselect", selectedFtype);
        formDt.append("filedescription", selvaluedescription);
        formDt.append("certificatenumber", certNumber);
        formDt.append("dateofissue", dateofissue);
        formDt.append("expirydate", xprydate);

        //for test
        console.log(JSON.stringify({ formdata: formDt }));
        Swal.fire({
            title: "Bid Response Documents Upload",
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
                    url: '/Home/FnUploadBidResponseDocuments',
                    data: formDt,
                    contentType: false,
                    cache: false,
                    processData: false,
                    error: function () {
                        $("#bidresponsesfeedback").css("color", "red");
                        $('#bidresponsesfeedback').addClass('alert alert-danger');
                        $("#bidresponsesfeedback").html("File upload failed, choose another file and try again!");
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
                                    $("#bidresponsesfeedback").css("display", "block");
                                    $("#bidresponsesfeedback").css("color", "green");
                                    $('#bidresponsesfeedback').attr("class", "alert alert-success");
                                    $("#bidresponsesfeedback").html("Selected File Uploaded Successfully!");
                                    $("#bidresponsesfeedback").css("display", "block");
                                    $("#bidresponsesfeedback").css("color", "green");
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
                                    $("#bidresponsesfeedback").css("display", "block");
                                    $("#bidresponsesfeedback").css("color", "red");
                                    $('#bidresponsesfeedback').attr('class', 'alert alert-danger');
                                    $("#bidresponsesfeedback").html("File input cannot be empty! Kindly Select File to Upload");
                                    $("#bidresponsesfeedback").focus();
                                    $("#bidresponsesfeedback").css("border", "solid 1px red");
                                });
                                break;
                            case "sharepointError":
                                Swal.fire
                                ({
                                    title: "Sharepoint Connection Error!",
                                    text: "There was an Error Connecting to the Sharepoint DMS Server! Kindly Contact KeRRA for More Details!",
                                    type: "error"
                                }).then(() => {
                                    $("#bidresponsesfeedback").css("display", "block");
                                    $("#bidresponsesfeedback").css("color", "red");
                                    $('#bidresponsesfeedback').attr('class', 'alert alert-danger');
                                    $("#bidresponsesfeedback").html("There was an Error Connecting to the Sharepoint DMS Server! Kindly Contact KeRRA for More Details!");
                                    $("#bidresponsesfeedback").focus();
                                    $("#bidresponsesfeedback").css("border", "solid 1px red");
                                });
                                break;
                            default:
                                Swal.fire
                                ({
                                    title: "Document Upload Error!!!",
                                    text: uploadsfs[1],
                                    type: "error"
                                }).then(() => {
                                    $("#bidresponsesfeedback").css("display", "block");
                                    $("#bidresponsesfeedback").css("color", "red");
                                    $('#bidresponsesfeedback').addClass('alert alert-danger');
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
});
