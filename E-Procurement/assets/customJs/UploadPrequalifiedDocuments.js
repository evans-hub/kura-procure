$("body").on("click", "#btnSavePrequalifiedDocuments", function () {
    //Loop through the Table rows and build a JSON array.
    //Supplier Registration Function
  //  $(".btnSavePrequalifiedDocuments").click(function () {

        //Loop through the Table rows and build a JSON array.
        var DocumentNo = $("#preapplicationo").val();
        var financials = new Array();
        var formDt = new FormData(); 
        $("#tbl_prequalified_documents TBODY TR").each(function () {
            var row = $(this);
            var finance = {};
            var i = 0;
            finance.procurementDocumentType = row.find('td:eq(1)').text().trim();
            //var browsedDoc = row.find("TD input").eq(0).files[0];
            //var input = row.attr("id", "PrequalificationinputFileselectors" + i++).find(".PrequalificationinputFileselectors").val();
            //var browsedDoc = row.attr("id", "PrequalificationinputFileselectors" + i++).find(".PrequalificationinputFileselectors").val();
            finance.browsedDoc = row.attr("id", "PrequalificationinputFileselectors" + i++).find(".PrequalificationinputFileselectors").val().replace(/C:\\fakepath\\/i, '');
            //var fileName = e.target.files[0].name;

            //finance.browsedDoc = row.find('TD input[type="file"]').eq(0).val().replace(/C:\\fakepath\\/i, '');
            //var browsedDoc = row.find('TD input[type="file"]').eq(0).val().replace(/C:\\fakepath\\/i, '');
            //finance.browsedDoc = x.target.files[0].name;
            finance.expirydate = row.find("TD input").eq(3).val();
            finance.certificateNo = row.find("TD input").eq(2).val();
            finance.issueDate = row.find("TD input").eq(1).val();
            finance.applicationNO = DocumentNo;

                      
            //formDt.append("browsedfile", browsedDoc);
            financials.push(finance);
        });
        console.log(JSON.stringify(financials))
       // console.log(JSON.stringify({ formdata: formDt }));
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
                    type: "POST",
                    url: '/Home/PrequalifiedAttachDocuments',
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
                                   title: "Documents Upload Successfull!",
                                   text: "Your Documents were successfully submitted.",
                                   type: "success"
                               }).then(() => {
                                   $("#feedback1").css("display", "block");
                                   $("#feedback1").css("color", "green");
                                   $('#feedback1').attr("class", "alert alert-success");
                                   $("#feedback1").html("Your Documents were successfully submitted.");
                                   location.reload(true);
                               });
                            break;
                        default:
                            Swal.fire
                                    ({
                                        title: "Documents Upload Error!!!",
                                        text: "Error Occured when Uploading your Documents.Kindly Try Again",
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

function AttachDocuments(Procurement_Document_Type) {
    $("#filecategory").val(Procurement_Document_Type);
    $("#AttachDocuments").modal();
}



$("body").on("click", "#btn_UploadDocuments_Details", function () {
    //Loop through the Table rows and build a JSON array.
    //Supplier Registration Function
    //  $(".btnSavePrequalifiedDocuments").click(function () {

    //Loop through the Table rows and build a JSON array.
    var DocumentNo = $("#preapplicationo").val();
    var financials = new Array();
    var formDt = new FormData();
    $("#tbl_prequalified_documents TBODY TR").each(function () {
        var row = $(this);
        var finance = {};
        var i = 0;
        finance.procurementDocumentType = row.find('td:eq(1)').text().trim();
        //var browsedDoc = row.find("TD input").eq(0).files[0];
        //var input = row.attr("id", "PrequalificationinputFileselectors" + i++).find(".PrequalificationinputFileselectors").val();
        //var browsedDoc = row.attr("id", "PrequalificationinputFileselectors" + i++).find(".PrequalificationinputFileselectors").val();
        finance.browsedDoc = row.attr("id", "PrequalificationinputFileselectors" + i++).find(".PrequalificationinputFileselectors").val().replace(/C:\\fakepath\\/i, '');
        //var fileName = e.target.files[0].name;

        //finance.browsedDoc = row.find('TD input[type="file"]').eq(0).val().replace(/C:\\fakepath\\/i, '');
        //var browsedDoc = row.find('TD input[type="file"]').eq(0).val().replace(/C:\\fakepath\\/i, '');
        //finance.browsedDoc = x.target.files[0].name;
        finance.expirydate = row.find("TD input").eq(3).val();
        finance.certificateNo = row.find("TD input").eq(2).val();
        finance.issueDate = row.find("TD input").eq(1).val();
        finance.applicationNO = DocumentNo;


        //formDt.append("browsedfile", browsedDoc);
        financials.push(finance);
    });
    console.log(JSON.stringify(financials))
    // console.log(JSON.stringify({ formdata: formDt }));
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
                type: "POST",
                url: '/Home/PrequalifiedAttachDocuments',
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
                               title: "Documents Upload Successfull!",
                               text: "Your Documents were successfully submitted.",
                               type: "success"
                           }).then(() => {
                               $("#feedback1").css("display", "block");
                               $("#feedback1").css("color", "green");
                               $('#feedback1').attr("class", "alert alert-success");
                               $("#feedback1").html("Your Documents were successfully submitted.");
                               location.reload(true);
                           });
                        break;
                    default:
                        Swal.fire
                                ({
                                    title: "Documents Upload Error!!!",
                                    text: "Error Occured when Uploading your Documents.Kindly Try Again",
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


$("body").on("click", "#button_upload_response_Documents_Tender", function () {
    //Loop through the Table rows and build a JSON array.
    //Supplier Registration Function
    //  $(".btnSavePrequalifiedDocuments").click(function () {

    //Loop through the Table rows and build a JSON array.
    var DocumentNo = $("#Invresponse").val();
    var financials = new Array();
    var formDt = new FormData();
    $("#tbl_prequalified_documents TBODY TR").each(function () {
        var row = $(this);
        var finance = {};
        var i = 0;
        finance.procurementDocumentType = row.find('td:eq(1)').text().trim();
        finance.description = row.find('td:eq(2)').text().trim();
        finance.browsedDoc = row.attr("id", "PrequalificationinputFileselectors" + i++).find(".PrequalificationinputFileselectors").val().replace(/C:\\fakepath\\/i, '');
        finance.expirydate = row.find("TD input").eq(3).val();
        finance.certificateNo = row.find("TD input").eq(2).val();
        finance.issueDate = row.find("TD input").eq(1).val();
        finance.applicationNO = DocumentNo;
        financials.push(finance);
    });
    console.log(JSON.stringify(financials))
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
                type: "POST",
                url: '/Home/FnUploadBidResponseDocumentsTender',
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
                               title: "Documents Upload Successfull!",
                               text: "Your Documents were successfully submitted.",
                               type: "success"
                           }).then(() => {
                               $("#feedback1").css("display", "block");
                               $("#feedback1").css("color", "green");
                               $('#feedback1').attr("class", "alert alert-success");
                               $("#feedback1").html("Your Documents were successfully submitted.");
                               location.reload(true);
                           });
                        break;
                    default:
                        Swal.fire
                                ({
                                    title: "Documents Upload Error!!!",
                                    text: "Error Occured when Uploading your Documents.Kindly Try Again",
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