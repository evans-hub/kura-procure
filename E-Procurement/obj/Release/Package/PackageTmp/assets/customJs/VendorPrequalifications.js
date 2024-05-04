$(document).ready(function () {
    //Supplier Prequalifications Function
    $(".btn_submit_response_generaldetails").click(function () {
        //Set data to be sent
        var data = {
            "RfiDocumentNo": $("#prequaliinvitno").val(),
            "RepFullName": $("#vendrepresentativename").val(),
            "RepDesignation": $("#vendrepresentativetitle").val(),
            "RfiDocApplicationNo": $("#preapplicationo").val(),
            "Region": $("#regionCode").val(),
            "registrationPeriod": $("#dropdownregistartionPeriod").val(),
            "constituency": $("#constituencyCode").val()
        }
        //Swal Message
        Swal.fire({
            title: "Confirm Prequalification Details?",
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
                    url: "/Home/SubmitRfiResponse",
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
                                title: "Response Submitted!",
                                text: registerstatus[1],
                                type: "success"
                            }).then(() => {
                                $("#rfiresponsesfeedback").css("display", "block");
                                $("#rfiresponsesfeedback").css("color", "green");
                                $('#rfiresponsesfeedback').attr("class", "alert alert-success");
                                $("#rfiresponsesfeedback").html("Your Request have been successfully submitted!" + registerstatus[1]);
                                $("#rfiresponsesfeedback").css("display", "block");
                                $("#rfiresponsesfeedback").css("color", "green");
                                $("#rfiresponsesfeedback").html("Your Request have been successfully submitted!" + registerstatus[1]);
                                $("#rfiresponsesfeedback").reset();
                            });
                            $("button#nextBtnrfiresponse").css("display", "block");
                            break;
                        default:
                            Swal.fire
                            ({
                                title: "Response Error!!!",
                                text: "The Details Could not be submitted" + registerstatus[1],
                                type: "error"
                            }).then(() => {
                                $("#rfiresponsesfeedback").css("display", "block");
                                $("#rfiresponsesfeedback").css("color", "red");
                                $('#rfiresponsesfeedback').addClass('alert alert-danger');
                                $("#rfiresponsesfeedback").html("The Details Could not be submitted" + registerstatus[1]);
                            });
                            break;
                    }
                }
                );
            } else if (result.dismiss === Swal.DismissReason.cancel) {
                Swal.fire(
                    'Response Cancelled',
                    'You cancelled your supplier prequalifications submission details!',
                    'error'
                );
            }
        });

    });

        //Supplier Responsibility Center
    $(".btn_submitregionDetails").click(function () {
        //Set data to be sent
        var data = {
            "ResponsibilityCenterCode": $("#dropdownResponsibilityCenter").val(),
            "constituencyCode": $("#dropdownconstituencies").val(),
            "DocumentNo": $("#docNo").val(),
            "Category_ID": $("#catID").val(),
           
        }
        //Swal Message
        Swal.fire({
            title: "Confirm Responsibility Center Details?",
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
                    url: "/Home/submitResponibilityCenters",
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
                                title: "Responsibility center Submitted!",
                                text: registerstatus[1],
                                type: "success"
                            }).then(() => {
                                $("#rfiresponsesfeedback").css("display", "block");
                                $("#rfiresponsesfeedback").css("color", "green");
                                $('#rfiresponsesfeedback').attr("class", "alert alert-success");
                                $("#rfiresponsesfeedback").html("Your Prequalifications Request have been successfully submitted!" + registerstatus[1]);
                                $("#rfiresponsesfeedback").css("display", "block");
                                $("#rfiresponsesfeedback").css("color", "green");
                                $("#rfiresponsesfeedback").html("Your Prequalifications Request have been successfully submitted!" + registerstatus[1]);
                                $("#rfiresponsesfeedback").reset();
                            });
                            //$("button#nextBtnrfiresponse").css("display", "block");
                            break;
                        default:
                            Swal.fire
                            ({
                                title: "Responsibility center Error!!!",
                                text: "The Responsibility center Details Could not be submitted" + registerstatus[1],
                                type: "error"
                            }).then(() => {
                                $("#rfiresponsesfeedback").css("display", "block");
                                $("#rfiresponsesfeedback").css("color", "red");
                                $('#rfiresponsesfeedback').addClass('alert alert-danger');
                                $("#rfiresponsesfeedback").html("The PResponsibility center Details Could not be submitted" + registerstatus[1]);
                            });
                            break;
                    }
                }
                );
            } else if (result.dismiss === Swal.DismissReason.cancel) {
                Swal.fire(
                    'Responsibility center details submission Cancelled',
                    'You cancelled your Responsibility center submission details!',
                    'error'
                );
            }
        });

    });

    $('#checkBoxAllGoods').click(function () {
        var checked = this.checked;
    })
    var td2 = $(".selectedprequalifcationGoods")
    td2.on("change",
        "tbody tr .checkboxes",
        function () {
            var t = jQuery(this).is(":checked"), selected_arr = [];
            t ? ($(this).prop("checked", !0), $(this).parents("tr").addClass("active"))
                : ($(this).prop("checked", !1), $(this).parents("tr").removeClass("active"));
            // Read all checked checkboxes
            $("input:checkbox[class=checkboxes]:checked").each(function () {
                selected_arr.push($(this).val());
            });

            if (selected_arr.length > 0) {
                $("#rfiresponsefeedback").css("display", "block");

            } else {
                $("#rfiresponsefeedback").css("display", "none");
                selected_arr = [];
            }

        });
        var selected_arr = [];
        $(".btn_apply_goodsIFR").on("click",
        function (e) {
            e.preventDefault();
            // Read all checked checkboxes
            $.each($(".selectedprequalifcationGoods tr.active"), function () {
                //procurement category
                var checkbox_value = $('#goodselected').val();
                //document.getElementById("#selectedrecordid");
                //$('#goodselected').text();
                // $('#goodselected').
                selected_arr.push($(this).find('td').eq(1).text());


                //$(this).find('input[type=checkbox]').val());
                // $(this).find('td').eq(2).text()
            });
            var postData = {
                DocumentNo: $("#preapplicationo").val(),
                RfiDocumentNo: $('#prequaliinvitno').val(),
                Region: $("#regionCode").val(),
                constituency: $("#constituencyCode").val(),
                ProcurementCategory: selected_arr
            };
            Swal.fire({
                title: "Confirm Registration Application?",
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
                        url: "/Home/InsertIFRResponseLines",
                        type: "POST",
                        data: JSON.stringify(postData),
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
                                    title: "Registration Categories Submitted!",
                                    text: status,
                                    type: "success"
                                }).then(() => {
                                    $("#goodsfeedback").css("display", "block");
                                    $("#goodsfeedback").css("color", "green");
                                    $('#goodsfeedback').attr("class", "alert alert-success");
                                    $("#goodsfeedback").html("Your Prequalifications Details have been successfully submitted.Kindly Proceed to fill in the rest details!");
                                    $("#goodsfeedback").css("display", "block");
                                    $("#goodsfeedback").css("color", "green");
                                    $("#goodsfeedback").html("Your Prequalifications Details have been successfully submitted.Kindly Proceed to fill in the rest details!");
                                    $("#goodsfeedback").reset();
                                });
                                selected_arr = [];
                                break;
                            default:
                                Swal.fire
                                ({
                                    title: "Registration Error!!!",
                                    text: registerstatus[1],
                                    type: "error"
                                }).then(() => {
                                    $("#goodsfeedback").css("display", "block");
                                    $("#goodsfeedback").css("color", "red");
                                    $('#goodsfeedback').addClass('alert alert-danger');
                                    $("#goodsfeedback").html("Your Registration Details could not be submitted.Kindly Proceed to fill in the rest details!" + registerstatus[1]);
                                });
                                selected_arr = [];
                                break;
                        }
                    }
                    );
                } else if (result.dismiss === Swal.DismissReason.cancel) {
                    Swal.fire(
                        'Registration Cancelled',
                        'You cancelled your supplier Registration submission details!',
                        'error'
                    );
                }
            });

        });
    $('#checkBoxServiceAll').click(function () {
        var checked = this.checked;
    })
    var td2 = $(".selectedprequalificationsservices")
    td2.on("change",
        "tbody tr .checkboxes",
        function () {
            var t = jQuery(this).is(":checked"), selected_arr = [];
            t ? ($(this).prop("checked", !0), $(this).parents("tr").addClass("active"))
                : ($(this).prop("checked", !1), $(this).parents("tr").removeClass("active"));
            // Read all checked checkboxes
            $("input:checkbox[class=checkboxes]:checked").each(function () {
                selected_arr.push($(this).val());
            });

            if (selected_arr.length > 0) {
                $("#rfisubmitallServicescategories").css("display", "block");

            } else {
                $("#rfisubmitallServicescategories").css("display", "none");
                selected_arr = [];
            }

        });
    var selected_arr = [];
    $(".btn_saveallServicescategoriesIFR").on("click",
        function (e) {
            e.preventDefault();
            // Read all checked checkboxes
            $.each($(".selectedprequalificationsservices tr.active"), function () {
                //procurement category
                var checkbox_value = $('#servicesfeedback').val();
                //$('#servicesfeedback').val();
                selected_arr.push($(this).find('td').eq(1).text());
                //$(this).find('input[type=checkbox]').text());
                $(this).find('td').eq(1).text()
            });

            var postData = {
                DocumentNo: $("#preapplicationo").val(),
                RfiDocumentNo: $('#prequaliinvitno').val(),
                Region: $("#regionCode").val(),
                constituency: $("#constituencyCode").val(),
                ProcurementCategory: selected_arr
            };
            console.log(JSON.stringify(selected_arr))
            Swal.fire({
                title: "Confirm Registration Response?",
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
                        url: "/Home/InsertIFRResponseLines",
                        type: "POST",
                        data: JSON.stringify(postData),
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
                                    title: "Registration Categories Submitted!",
                                    text: status,
                                    type: "success"
                                }).then(() => {
                                    $("#servicesfeedback").css("display", "block");
                                    $("#servicesfeedback").css("color", "green");
                                    $('#servicesfeedback').attr("class", "alert alert-success");
                                    $("#servicesfeedback").html("Your Prequalifications Details have been successfully submitted.Kindly Proceed to fill in the rest details!");
                                    $("#servicesfeedback").css("display", "block");
                                    $("#servicesfeedback").css("color", "green");
                                    $("#servicesfeedback").html("Your Prequalifications Details have been successfully submitted.Kindly Proceed to fill in the rest details!");
                                    $("#servicesfeedback").reset();
                                });
                                selected_arr = [];
                                break;
                            default:
                                Swal.fire
                                ({
                                    title: "Registration Error!!!",
                                    text: registerstatus[1],
                                    type: "error"
                                }).then(() => {
                                    $("#servicesfeedback").css("display", "block");
                                    $("#servicesfeedback").css("color", "red");
                                    $('#servicesfeedback').addClass('alert alert-danger');
                                    $("#servicesfeedback").html("Your Registration Details could not be submitted.Kindly Proceed to fill in the rest details!" + registerstatus[1]);
                                });
                                selected_arr = [];
                                break;
                        }
                    }
                    );
                } else if (result.dismiss === Swal.DismissReason.cancel) {
                    Swal.fire(
                        'Registration Cancelled',
                        'You cancelled your supplier Registration submission details!',
                        'error'
                    );
                }
            });

        });
    $('#checkBoxWorksAll').click(function () {
        var checked = this.checked;
    })
    var td2 = $(".selectedprequalificationsWorks")
    td2.on("change",
        "tbody tr .checkboxes",
        function () {
            var t = jQuery(this).is(":checked"), selected_arr = [];
            t ? ($(this).prop("checked", !0), $(this).parents("tr").addClass("active"))
                : ($(this).prop("checked", !1), $(this).parents("tr").removeClass("active"));
            // Read all checked checkboxes
            $("input:checkbox[class=checkboxes]:checked").each(function () {
                selected_arr.push($(this).val());
            });

            if (selected_arr.length > 0) {
                $("#rfisubmitallworkscategories").css("display", "block");

            } else {
                $("#rfisubmitallworkscategories").css("display", "none");
                selected_arr = [];
            }

        });
    var selected_arr = [];
    $(".bbtn_saveallWorkscategoriesIFR").on("click",
        function (e) {
            e.preventDefault();
            // Read all checked checkboxes
            $.each($(".selectedprequalificationsWorks tr.active"), function () {
                //procurement category
                var checkbox_value = $('#worksselected').val();
                selected_arr.push($(this).find('td').eq(1).text());
                //$(this).find('input[type=checkbox]').val());
                // $(this).find('td').eq(2).text()
            });
            var postData = {
                DocumentNo: $("#preapplicationo").val(),
                RfiDocumentNo: $('#prequaliinvitno').val(),
                Region: $("#regionCode").val(),
                constituency: $("#constituencyCode").val(),
                ProcurementCategory: selected_arr
            };
            Swal.fire({
                title: "Confirm Registration Application?",
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
                        url: "/Home/InsertIFRResponseLines",
                        type: "POST",
                        data: JSON.stringify(postData),
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
                                    title: "Registration Categories Submitted!",
                                    text: status,
                                    type: "success"
                                }).then(() => {
                                    $("#worksfeedback").css("display", "block");
                                    $("#worksfeedback").css("color", "green");
                                    $('#worksfeedback').attr("class", "alert alert-success");
                                    $("#worksfeedback").html("Your Registration Details have been successfully submitted.Kindly Proceed to fill in the rest details!");
                                    $("#worksfeedback").css("display", "block");
                                    $("#worksfeedback").css("color", "green");
                                    $("#worksfeedback").html("Your Registration Details have been successfully submitted.Kindly Proceed to fill in the rest details!");
                                    $("#worksfeedback").reset();
                                });
                                selected_arr = [];
                                break;
                            default:
                                Swal.fire
                                ({
                                    title: "Registration Error!!!",
                                    text: registerstatus[1],
                                    type: "error"
                                }).then(() => {
                                    $("#worksfeedback").css("display", "block");
                                    $("#worksfeedback").css("color", "red");
                                    $('#worksfeedback').addClass('alert alert-danger');
                                    $("#worksfeedback").html("Your Registration Details could not be submitted.Kindly Proceed to fill in the rest details!" + registerstatus[1]);
                                });
                                selected_arr = [];
                                break;
                        }
                    }
                    );
                } else if (result.dismiss === Swal.DismissReason.cancel) {
                    Swal.fire(
                        'Registration Cancelled',
                        'You cancelled your supplier Registration submission details!',
                        'error'
                    );
                }
            });

        });

    var selected_arr = [];
    $(".btn_apply_goods").on("click",
        function (e) {
            e.preventDefault();
            // Read all checked checkboxes
            $.each($(".selectedprequalifcationGoods tr.active"), function () {
                //procurement category
                var checkbox_value = $('#goodselected').val();
                //document.getElementById("#selectedrecordid");
                //$('#goodselected').text();
                // $('#goodselected').
                selected_arr.push($(this).find('td').eq(1).text());


                //$(this).find('input[type=checkbox]').val());
                // $(this).find('td').eq(2).text()
            });
            var postData = {
                DocumentNo: $("#preapplicationo").val(),
                RfiDocumentNo: $('#prequaliinvitno').val(),
                Region: $("#regionCode").val(),
                constituency: $("#constituencyCode").val(),
                ProcurementCategory: selected_arr
            };
            Swal.fire({
                title: "Confirm Prequalification Application?",
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
                        url: "/Home/InsertResponseLines",
                        type: "POST",
                        data: JSON.stringify(postData),
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
                                    title: "Prequalifications Categories Submitted!",
                                    text: status,
                                    type: "success"
                                }).then(() => {
                                    $("#goodsfeedback").css("display", "block");
                                    $("#goodsfeedback").css("color", "green");
                                    $('#goodsfeedback').attr("class", "alert alert-success");
                                    $("#goodsfeedback").html("Your Prequalifications Details have been successfully submitted.Kindly Proceed to fill in the rest details!");
                                    $("#goodsfeedback").css("display", "block");
                                    $("#goodsfeedback").css("color", "green");
                                    $("#goodsfeedback").html("Your Prequalifications Details have been successfully submitted.Kindly Proceed to fill in the rest details!");
                                    $("#goodsfeedback").reset();
                                });
                                selected_arr = [];
                                break;
                            default:
                                Swal.fire
                                ({
                                    title: "Prequalifications Error!!!",
                                    text: registerstatus[1],
                                    type: "error"
                                }).then(() => {
                                    $("#goodsfeedback").css("display", "block");
                                    $("#goodsfeedback").css("color", "red");
                                    $('#goodsfeedback').addClass('alert alert-danger');
                                    $("#goodsfeedback").html("Your Prequalifications Details could not be submitted.Kindly Proceed to fill in the rest details!" + registerstatus[1]);
                                });
                                selected_arr = [];
                                break;
                        }
                    }
                    );
                } else if (result.dismiss === Swal.DismissReason.cancel) {
                    Swal.fire(
                        'Prequalifications Cancelled',
                        'You cancelled your supplier prequalifications submission details!',
                        'error'
                    );
                }
            });

        });
    $('#checkBoxServiceAll').click(function () {
        var checked = this.checked;
    })
    var td2 = $(".selectedprequalificationsservices")
    td2.on("change",
        "tbody tr .checkboxes",
        function () {
            var t = jQuery(this).is(":checked"), selected_arr = [];
            t ? ($(this).prop("checked", !0), $(this).parents("tr").addClass("active"))
                : ($(this).prop("checked", !1), $(this).parents("tr").removeClass("active"));
            // Read all checked checkboxes
            $("input:checkbox[class=checkboxes]:checked").each(function () {
                selected_arr.push($(this).val());
            });

            if (selected_arr.length > 0) {
                $("#rfisubmitallServicescategories").css("display", "block");

            } else {
                $("#rfisubmitallServicescategories").css("display", "none");
                selected_arr = [];
            }

        });
    var selected_arr = [];
    $(".btn_saveallServicescategories").on("click",
        function (e) {
            e.preventDefault();
            // Read all checked checkboxes
            $.each($(".selectedprequalificationsservices tr.active"), function () {
                //procurement category
                var checkbox_value = $('#servicesfeedback').val();
                //$('#servicesfeedback').val();
                selected_arr.push($(this).find('td').eq(1).text());
                //$(this).find('input[type=checkbox]').text());
                $(this).find('td').eq(1).text()
            });

            var postData = {
                DocumentNo: $("#preapplicationo").val(),
                RfiDocumentNo: $('#prequaliinvitno').val(),
                Region: $("#regionCode").val(),
                constituency: $("#constituencyCode").val(),
                ProcurementCategory: selected_arr
            };
            console.log(JSON.stringify(selected_arr))
            Swal.fire({
                title: "Confirm Prequalification Application?",
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
                        url: "/Home/InsertResponseLines",
                        type: "POST",
                        data: JSON.stringify(postData),
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
                                    title: "Prequalifications Categories Submitted!",
                                    text: status,
                                    type: "success"
                                }).then(() => {
                                    $("#servicesfeedback").css("display", "block");
                                    $("#servicesfeedback").css("color", "green");
                                    $('#servicesfeedback').attr("class", "alert alert-success");
                                    $("#servicesfeedback").html("Your Prequalifications Details have been successfully submitted.Kindly Proceed to fill in the rest details!");
                                    $("#servicesfeedback").css("display", "block");
                                    $("#servicesfeedback").css("color", "green");
                                    $("#servicesfeedback").html("Your Prequalifications Details have been successfully submitted.Kindly Proceed to fill in the rest details!");
                                    $("#servicesfeedback").reset();
                                });
                                selected_arr = [];
                                break;
                            default:
                                Swal.fire
                                ({
                                    title: "Prequalifications Error!!!",
                                    text: registerstatus[1],
                                    type: "error"
                                }).then(() => {
                                    $("#servicesfeedback").css("display", "block");
                                    $("#servicesfeedback").css("color", "red");
                                    $('#servicesfeedback').addClass('alert alert-danger');
                                    $("#servicesfeedback").html("Your Prequalifications Details could not be submitted.Kindly Proceed to fill in the rest details!" + registerstatus[1]);
                                });
                                selected_arr = [];
                                break;
                        }
                    }
                    );
                } else if (result.dismiss === Swal.DismissReason.cancel) {
                    Swal.fire(
                        'Prequalifications Cancelled',
                        'You cancelled your supplier prequalifications submission details!',
                        'error'
                    );
                }
            });

        });
    $('#checkBoxWorksAll').click(function () {
        var checked = this.checked;
    })
    var td2 = $(".selectedprequalificationsWorks")
    td2.on("change",
        "tbody tr .checkboxes",
        function () {
            var t = jQuery(this).is(":checked"), selected_arr = [];
            t ? ($(this).prop("checked", !0), $(this).parents("tr").addClass("active"))
                : ($(this).prop("checked", !1), $(this).parents("tr").removeClass("active"));
            // Read all checked checkboxes
            $("input:checkbox[class=checkboxes]:checked").each(function () {
                selected_arr.push($(this).val());
            });

            if (selected_arr.length > 0) {
                $("#rfisubmitallworkscategories").css("display", "block");

            } else {
                $("#rfisubmitallworkscategories").css("display", "none");
                selected_arr = [];
            }

        });
    var selected_arr = [];
    $(".btn_saveallWorkscategories").on("click",
        function (e) {
            e.preventDefault();
            // Read all checked checkboxes
            $.each($(".selectedprequalificationsWorks tr.active"), function () {
                //procurement category
                var checkbox_value = $('#worksselected').val();
                selected_arr.push($(this).find('td').eq(1).text());
                //$(this).find('input[type=checkbox]').val());
                // $(this).find('td').eq(2).text()
            });
            var postData = {
                DocumentNo: $("#preapplicationo").val(),
                RfiDocumentNo: $('#prequaliinvitno').val(),
                Region: $("#regionCode").val(),
                constituency: $("#constituencyCode").val(),
                ProcurementCategory: selected_arr
            };
            Swal.fire({
                title: "Confirm Prequalification Application?",
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
                        url: "/Home/InsertResponseLines",
                        type: "POST",
                        data: JSON.stringify(postData),
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
                                    title: "Prequalifications Categories Submitted!",
                                    text: status,
                                    type: "success"
                                }).then(() => {
                                    $("#worksfeedback").css("display", "block");
                                    $("#worksfeedback").css("color", "green");
                                    $('#worksfeedback').attr("class", "alert alert-success");
                                    $("#worksfeedback").html("Your Prequalifications Details have been successfully submitted.Kindly Proceed to fill in the rest details!");
                                    $("#worksfeedback").css("display", "block");
                                    $("#worksfeedback").css("color", "green");
                                    $("#worksfeedback").html("Your Prequalifications Details have been successfully submitted.Kindly Proceed to fill in the rest details!");
                                    $("#worksfeedback").reset();
                                });
                                selected_arr = [];
                                break;
                            default:
                                Swal.fire
                                ({
                                    title: "Prequalifications Error!!!",
                                    text: registerstatus[1],
                                    type: "error"
                                }).then(() => {
                                    $("#worksfeedback").css("display", "block");
                                    $("#worksfeedback").css("color", "red");
                                    $('#worksfeedback').addClass('alert alert-danger');
                                    $("#worksfeedback").html("Your Prequalifications Details could not be submitted.Kindly Proceed to fill in the rest details!" + registerstatus[1]);
                                });
                                selected_arr = [];
                                break;
                        }
                    }
                    );
                } else if (result.dismiss === Swal.DismissReason.cancel) {
                    Swal.fire(
                        'Prequalifications Cancelled',
                        'You cancelled your supplier prequalifications submission details!',
                        'error'
                    );
                }
            });

        });

   
    $('.btn_uploadPrequalifiationsdocuments').click(function (e) {
        e.preventDefault();
        var VendorprequalificationNumber = $("#preapplicationo").val();
        var invitationNumber = $("#invitationnumber").val();
        var selectedFtype = $('#filecategory').val();
        var selvaluedescription = $("#ddlprequalificationdocumentdroplist_rfi option:selected").text();
        var browsedDoc = document.getElementById('PrequalificationinputFileselectors').files[0];
        var certNumber = $("#documentstxtCertNo").val();
        var dateofissue = $("#documentsdateOfIssues").val();
        var xprydate = $("#documentsdateOfexpiries").val();

        var formDt = new FormData();
        formDt.append("prequalificationNumber", VendorprequalificationNumber);
        formDt.append("typauploadselect", selectedFtype);
        formDt.append("browsedfile", browsedDoc);
        formDt.append("filedescription", selvaluedescription);
        formDt.append("certificatenumber", certNumber);
        formDt.append("dateofissue", dateofissue);
        formDt.append("expirydate", xprydate);
        var urlData = new FormData();
        urlData.append("InvitationNumber", invitationNumber)
        urlData.append("prequalificationNo", VendorprequalificationNumber)

        //for test
        console.log(JSON.stringify({ formdata: formDt }));
        Swal.fire({
            title: "Prequalification Documents Upload",
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
                    url: '/Home/FnUploadmandatoryPrequalificationDoc',
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
                                    title: "Prequalification Files Uploaded!",
                                    text: "Prequalification File Uploaded Successfully!",
                                    type: "success"
                                }).then(() => {
                                    $("#attachprequalificationdocumentsfeedback").css("display", "block");
                                    $("#attachprequalificationdocumentsfeedback").css("color", "green");
                                    $('#attachprequalificationdocumentsfeedback').attr("class", "alert alert-success");
                                    $("#attachprequalificationdocumentsfeedback").html("Selected Prequalification File Uploaded Successfully!");
                                    $("#attachprequalificationdocumentsfeedback").css("display", "block");
                                    $("#attachprequalificationdocumentsfeedback").css("color", "green");
                                });
                                $.ajax({
                                    type: 'POST',
                                    url: '/Home/PrequalificationAttachedDocuments',
                                    data:urlData,
                                    contentType: false,
                                    cache: false,
                                    processData: false,
                                    success: function (response) {                                        
                                        location.href = "/Home/PrequalificationAttachedDocuments?InvitationNumber=" + invitationNumber + "&prequalificationNo=" + VendorprequalificationNumber
                                    }

                                })                            
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
                                    $("#attachprequalificationdocumentsfeedback").html("There was an Error Connecting to the Server! Kindly Contact KURA for More Details!");
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
                    'Prequalification Document Upload Cancelled',
                    'You cancelled your documents submission!',
                    'error'
                );
            }
        });
    });




    var PrequalificationNumbers = $("#preapplicationo").val();
    var VenxdorPrequalificationsDocuments = function () {
        var PrequalificationDocument = function () {
            var tl = $("#tbl_prequalification_documents"),
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
                url: "/Home/GetPrequalificationsDocuments",
                data: "PrequalificationNumber=" + PrequalificationNumbers,
            }).done(function (documents) {
                l.fnClearTable();
                var o = 1;
                for (var i = 0; i < documents.length; i++) {
                    l.fnAddData([
                        o++,
                        documents[i].Description,
                        documents[i].Date_Filed,
                        documents[i].Issue_Date,
                        documents[i].Expiry_Date,
                        documents[i].File_Name,
                        '<button type="submit" class="btn btn-success btnDownloadVendorDocuments"filename=' + documents.File_Name + '><i class="fa fa-download m-r-10"></i> Download </button>',
                        '<a class="btn btn-danger" href=""><i class="fa fa-trash m-r-10">Delete</a>'
                    ]);
                }
            });
        }
        return {
            init: function () {
                PrequalificationDocument();
            }
        }

    }();

    $(".btn_PrequalifiationsDeclaration").click(function () {
        var supplierObj = {
            "Ref_No": $("#preapplicationo").val()
        }
        console.log(JSON.stringify(supplierObj))
        Swal.fire({
            title: "Confirm Prequalifications Submission?",
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
                    url: "/Home/SubmitPrequalificationsDetails",
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
                                title: "Submission Successful",
                                text: registerstatus[1],
                                type: "success"
                            }).then(() => {
                                $("#completefeedback").css("display", "block");
                                $("#completefeedback").css("color", "green");
                                $('#completefeedback').attr("class", "alert alert-success");
                                $("#completefeedback").html("Your Prequalifications Details have been successfully submitted!" + registerstatus[1]);
                                $("#completefeedback").css("display", "block");
                                $("#completefeedback").css("color", "green");
                                $("#completefeedback").html("Your Prequalifications Details have been successfully submitted");
                            });
                            window.location.href = "/Home/Dashboard";
                            break;
                        case "mandatory":
                            Swal.fire
                            ({
                                title: "Mandatory Documents Upload",
                                text: registerstatus[1],
                                type: "error"
                            }).then(() => {
                                $("#completefeedback").css("display", "block");
                                $("#completefeedback").css("color", "green");
                                $('#completefeedback').attr("class", "alert alert-success");
                                $("#completefeedback").html("Please attach all the mandatory Documents!" + registerstatus[1]);
                                $("#completefeedback").css("display", "block");
                                $("#completefeedback").css("color", "green");
                                $("#completefeedback").html("Please attach all the mandatory Documents");
                            });
                            break;
                        default:
                            Swal.fire
                            ({
                                title: "Supplier Prequalifications Details Submission Error!!",
                                text: "Your Prequalifications Details could not be submitted" + registerstatus[1],
                                type: "error"
                            }).then(() => {
                                $("#completefeedback").css("display", "block");
                                $("#completefeedback").css("color", "red");
                                $('#completefeedback').addClass('alert alert-danger');
                                $("#completefeedback").html("Your Prequalifications Details could not be submitted" + registerstatus[1]);
                            });
                            break;
                    }
                }
                );
            } else if (result.dismiss === Swal.DismissReason.cancel) {
                Swal.fire(
                    'Supplier Prequalifications Cancelled',
                    'You cancelled your supplier prequalifications registration submission details!',
                    'error'
                );
            }
        });

    });
})