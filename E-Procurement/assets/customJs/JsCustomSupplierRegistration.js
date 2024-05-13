'use-strict';
function getSelectedPosta30() {
    var selectedVal = $('#dropdownallpostacodes30').find(":selected").attr('value');
    var ppInd = document.getElementById('postcity');
    $.ajax({
        type: "POST",
        url: "/Home/SelectedPosta",
        data: "postcode=" + selectedVal
    }).done(function (status) {
        if (status !== "notfound") {
            ppInd.style = "background-color: #d7f4d7";
            ppInd.setAttribute('value', status);
            console.log('Selected City: ' + status);
        }
        else {
            $('#postcity').val('');
            ppInd.style = "background-color: #f2bfb6";
            alert('Please Select valid Postal code!');
            $("#regfeedback").css("display", "block");
            $("#regfeedback").css("color", "red");
            $("#regfeedback").html("Please choose a valid post code!");
        }
        console.log(status);
    });

}


function getSelectedBidSecurity() {
    var selectedVal = $('#ddformofsecurity').find(":selected").attr('value');
    var ppInd = document.getElementById('biddescriptions');
    $.ajax({
        type: "POST",
        url: "/Home/SelectedBidSecurity",
        data: "postcode=" + selectedVal
    }).done(function (status) {
        if (status !== "notfound") {
            ppInd.style = "background-color: #d7f4d7";
            ppInd.setAttribute('value', status);
            console.log('Selected City: ' + status);
        }
        else {
            $('#postcity').val('');
            ppInd.style = "background-color: #f2bfb6";
            alert('Please Select valid Postal code!');
            $("#regfeedback").css("display", "block");
            $("#regfeedback").css("color", "red");
            $("#regfeedback").html("Please choose a valid Bid code!");
        }
        console.log(status);
    });

}

function getSelectedRegion30() {
    var selectedVal = $('#dropdownResponsibilityCenter').find(":selected").attr('value');
    var ppInd = document.getElementById('dropdownconstituencies');
    $.ajax({
        type: "POST",
        url: "/Home/selectedResponsibilityCenter",
        data: "regionCode" + selectedVal
    }).done(function (status) {
        if (status !== "notfound") {
            ppInd.style = "background-color: #d7f4d7";
            ppInd.setAttribute('value', status);
            console.log('Selected City: ' + status);
        }
        else {
            $('#dropdownconstituencies').val('');
            ppInd.style = "background-color: #f2bfb6";
            alert('Please Select valid Postal code!');
            $("#regfeedback").css("display", "block");
            $("#regfeedback").css("color", "red");
            $("#regfeedback").html("Please choose a valid responsibility center!");
        }
        console.log(status);
    });

}
function getSelectedBank30() {
    var selectedVal = $('#bankcode').find(":selected").attr('value');
    //var branchName = document.getElementById('bankBranchName');
    //var ppInd = document.getElementById('bankbranchno');
    var branchName = $(this).next('.bankBranchName');
   
    $.ajax({
        type: "POST",
        url: "/Home/SelectedBank",
        data: "bankcode=" + selectedVal,
        success: function (data) {
            if (data) {
                $('#bankBranchName').html('');
                var options = '';
                options += '<option value="">--Select Bank Branch--</option>';
                for (var i = 0; i < data.length; i++) {
                    options += '<option value="' + data[i]["Bank_Branch_No"] + '">' + data[i]["bankBranchName"] + '</option>';
                }
                $('#bankBranchName').append(options);
                //branchName.append($('<option></option>').val('').text('Select Branch Name'));
                //$.each(data, function (index, item) {
                //    branchName.append($('<option</option>').val(item.Bank_Branch_No).html(item.bankBranchName));
                //});
            } else {
                // oops
            }
        },
        error: function (err) {
            alert(err);
        }

    }).done(function (status) {
        if (status !== "notfound") {
            //ppInd.style = "background-color: #d7f4d7";
            //ppInd.setAttribute('value', status);
           // branchName.style = "background-color: #d7f4d7";
            //branchName.setAttribute('value', status);
            console.log('Selected Bank: ' + status);
        }
        else {
            $('#branchname').val('');
            $('#bankbranchno').val('');
            //ppInd.style = "background-color: #f2bfb6";
           // branchName.style = "background-color: #f2bfb6";
            alert('Please Select valid bank code!');
            $("#regfeedback").css("display", "block");
            $("#regfeedback").css("color", "red");
            $("#regfeedback").html("Please choose a valid bank code!");
        }
        console.log(status);
    });

}

function calculateyearswithFarm() {
    var joiningDate = $('#editpersonneljoiningDate').find(":selected").attr('value');
    //var yearswithfarm = document.getElementById('edityearswithfarm');
    var today = new Date();
    var yr = new Date(joiningDate);
    var yearswithfarm = today.getFullYear() - yr.getFullYear();
    var m = today.getMonth() - birthDate.getMonth();
    if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
        yearswithfarm--;
    }
    document.getElementById('edityearswithfarm').value = yearswithfarm;
}
function getSelectedExpiryDate() {
    var selectedVal = $('#vendoregdocumentdroplist').find(":selected").attr('value');
    var ppInd = document.getElementById('vendoregdocumentdroplist');
    $.ajax({
        type: "POST",
        url: "/Home/GetSelectedDocumentExpiryDate",
        data: "SelectedDocument=" + selectedVal
    }).done(function (status) {
        if (status== "success") {
            document.getElementById('expirydatestracking').style.display = 'block'
        }
        else {
            document.getElementById('expirydatestracking').style.display = 'none'
        }
    });
}

function getSelectedExpiryDatesTender() {
    var selectedVal = $('#tenderddldocumentdroplist').find(":selected").attr('value');
    var ppInd = document.getElementById('tenderddldocumentdroplist');
    $.ajax({
        type: "POST",
        url: "/Home/GetSelectedTenderDocumentDocumentExpiryDate",
        data: "SelectedDocument=" + selectedVal
    }).done(function (status) {
        if (status == "success") {
            document.getElementById('tenderexpirydatestracking').style.display = 'block'
        }
        else {
            document.getElementById('tenderexpirydatestracking').style.display = 'none'
        }
    });

}
function getSelectedExpiryDatesPrequalification() {
    var selectedVal = $('#vendoregdocumentdroplist').find(":selected").attr('value');
    var ppInd = document.getElementById('vendoregdocumentdroplist');
    $.ajax({
        type: "POST",
        url: "/Home/GetSelectedPrequalificationDocumentExpiryDate",
        data: "SelectedDocument=" + selectedVal
    }).done(function (status) {
        if (status == "success") {
            document.getElementById('documentuploads').style.display = 'block'
        }
        else {
            document.getElementById('documentuploads').style.display = 'none'
        }
    });

}
function getSelectedExpiryDatesTenderResponse() {
    var selectedVal = $('#tenderddldocumentdroplist').find(":selected").attr('value');
    var TenderVal = $('#invitationnumber').val();
    var ppInd = document.getElementById('tenderddldocumentdroplist');
    $.ajax({
        type: "POST",
        url: "/Home/GetSelectedTenderDocumentDocumentExpiryDate",
        data: "SelectedDocument=" + selectedVal
    }).done(function (status) {
        if (status == "success") {
            document.getElementById('documentuploads').style.display = 'block'
        }
        else {
            document.getElementById('documentuploads').style.display = 'none'
        }
    });

}
function DeleteBank(url) {
    console.log(JSON.stringify(url))
    Swal.fire({
        title: "Delete Bank Details",
        text: "Proceed to delete the selected Bank?",
        type: "warning",
        showCancelButton: true,
        closeOnConfirm: true,
        confirmButtonText: "Yes, Delete!",
        confirmButtonClass: "btn-success",
        confirmButtonColor: "#008000",
        position: "center"
    }).then((result) => {
        if (result.value) {
            $.ajax({
                type: 'POST',
                url: url,
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
                'You cancelled your bank details deletion!',
                'error'
            );
        }
    });
}
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
                    json[i].CurrencyCode,
                    json[i].BankAccountNo,
                    json[i].Bank_Branch_No,
                    json[i].Post_Code,
                    '<a class="btn btn-success edit_banks_details" id="edit_banks"><i class="fa fa-edit m-r-10"></i>Edit</a>',
                    '<a class="btn btn-danger delete_bank_details"><i class="fa fa-trash m-r-10">Delete</a>'
                ]);
            }
        });
        vendorBanksTable.on("click",
           ".edit_banks_details",
           function (vendorBanksTable) {
               vendorBanksTable.preventDefault();
               var i = $(this).parents("tr")[0];
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
 
function DeleteShareholder(url) {
        Swal.fire({
            title: "Delete Shareholders Details",
            text: "Proceed to delete the selected Shareholder?",
            type: "warning",
            showCancelButton: true,
            closeOnConfirm: true,
            confirmButtonText: "Yes, Delete!",
            confirmButtonClass: "btn-success",
            confirmButtonColor: "#008000",
            position: "center"
        }).then((result) => {
            if (result.value) {
                $.ajax({
                    cache: false,
                    type: 'GET',
                    url: url,
                    success: function (status) {
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
                    }
                });
            } else if (result.dismiss === Swal.DismissReason.cancel) {
                Swal.fire(
                    'Shareholder Deletion Cancelled',
                    'You cancelled your Shareholder details deletion!',
                    'error'
                );
            }
        });
}

function DeleteBeneficiary(url) {
    Swal.fire({
        title: "Delete Beneficiary Details",
        text: "Proceed to delete the selected Beneficiary?",
        type: "warning",
        showCancelButton: true,
        closeOnConfirm: true,
        confirmButtonText: "Yes, Delete!",
        confirmButtonClass: "btn-success",
        confirmButtonColor: "#008000",
        position: "center"
    }).then((result) => {
        if (result.value) {
            $.ajax({
                cache: false,
                type: 'GET',
                url: url,
                success: function (status) {
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
                }
            });
        } else if (result.dismiss === Swal.DismissReason.cancel) {
            Swal.fire(
                'Beneficiary Deletion Cancelled',
                'You cancelled your Beneficiary details deletion!',
                'error'
            );
        }
    });
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
            url: "/Home/GetShareholderDetails",
        });
        $.ajax({
            data: ""
        }).done(function (json) {
            l.fnClearTable();
            var o = 1;
            for (var i = 0; i < json.length; i++) {
                l.fnAddData([
                    o++,
                    json[i].Entry_No,
                    json[i].Name,
                    json[i].Nationality_ID,
                    json[i].Citizenship_Type,
                    json[i].Entity_Ownership,
                    json[i].Phone_No,
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

function DeleteLitigation(url) {
        Swal.fire({
            title: "Delete Litigation History Details",
            text: "Proceed to delete the selected Litigation History Details?",
            type: "warning",
            showCancelButton: true,
            closeOnConfirm: true,
            confirmButtonText: "Yes, Delete!",
            confirmButtonClass: "btn-success",
            confirmButtonColor: "#008000",
            position: "center"
        }).then((result) => {
            if (result.value) {
                $.ajax({
                    cache: false,
                    type: 'GET',
                    url: url,
                    success: function (status) {
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
                    }
                });
            } else if (result.dismiss === Swal.DismissReason.cancel) {
                Swal.fire(
                    'Litigation History Deletion Cancelled',
                    'You cancelled your Litigation History details deletion!',
                    'error'
                );
            }
        });
    }
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
                    json[i].Thirdparty,
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
 
function DeletePastExpeience(url) {
        Swal.fire({
            title: "Delete Past Experience Details",
            text: "Proceed to delete the selected Past Experience Details?",
            type: "warning",
            showCancelButton: true,
            closeOnConfirm: true,
            confirmButtonText: "Yes, Delete!",
            confirmButtonClass: "btn-success",
            confirmButtonColor: "#008000",
            position: "center"
        }).then((result) => {
            if (result.value) {
                $.ajax({
                    cache: false,
                    type: 'GET',
                    url: url,
                    success: function (status) {
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
                    }
                });
            } else if (result.dismiss === Swal.DismissReason.cancel) {
                Swal.fire(
                    'Past Experience Deletion Cancelled',
                    'You cancelled your Past Experinece details deletion!',
                    'error'
                );
            }
        });
    }
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
        $.ajax({
            data: ""
        }).done(function (json) {
            l.fnClearTable();
            console.log(JSON.stringify({ vendorTestdata: json }));
            var o = 1;
            for (var i = 0; i < json.length; i++) {
                l.fnAddData([
                    //o++,
                    json[i].Entry_No,
                    json[i].ClientName,
                    json[i].Address,
                    json[i].Assignment_Name,
                    json[i].ProjectStartDate,
                    json[i].ProjectEndDate,
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
function DeleteBanlanceSheet(url) {
        console.log(JSON.stringify(url))
        Swal.fire({
            title: "Delete Balance Sheet Details",
            text: "Proceed to delete the selected Balance Sheet Details?",
            type: "warning",
            showCancelButton: true,
            closeOnConfirm: true,
            confirmButtonText: "Yes, Delete!",
            confirmButtonClass: "btn-success",
            confirmButtonColor: "#008000",
            position: "center"
        }).then((result) => {
            if (result.value) {
                $.ajax({
                    cache: false,
                    type: 'POST',
                    url: url,
                    success: function (status) {
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
                    }
                });
            } else if (result.dismiss === Swal.DismissReason.cancel) {
                Swal.fire(
                    'Balance Sheet Deletion Cancelled',
                    'You cancelled your Balance Sheet details deletion!',
                    'error'
                );
            }
        });
    }
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

 function DeleteIncome(url) {
        Swal.fire({
            title: "Delete Income Statement Details",
            text: "Proceed to delete the selected Income Statement Details?",
            type: "warning",
            showCancelButton: true,
            closeOnConfirm: true,
            confirmButtonText: "Yes, Delete!",
            confirmButtonClass: "btn-success",
            confirmButtonColor: "#008000",
            position: "center"
        }).then((result) => {
            if (result.value) {
                $.ajax({
                    cache: false,
                    type: 'GET',
                    url: url,
                    success: function (status) {
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
                    }
                });
            } else if (result.dismiss === Swal.DismissReason.cancel) {
                Swal.fire(
                    'Income Statement Deletion Cancelled',
                    'You cancelled your Income Statement details deletion!',
                    'error'
                );
            }
        });
    }
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
function DeleteStaff(url) {
        console.log(JSON.stringify(url))
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
                $.ajax({
                    cache: false,
                    type: 'GET',
                    url: url,
                    success: function (status) {
                        var registerstatus = status.split('*');
                        status = registerstatus[0];
                        switch (status) {
                            case "success":
                                Swal.fire
                                ({
                                    title: "Proffessional Staff Details Deleted!",
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
                                       title: "Proffessional Staff Details Deletion Error!!!",
                                       text: status,
                                       type: "error"
                                   }).then(() => {
                                       $("#keyprofessionalfeedback").css("display", "block");
                                       $("#keyprofessionalfeedback").css("color", "red");
                                       $('#keyprofessionalfeedback').addClass('alert alert-danger');
                                       $("#keyprofessionalfeedback").html("Your Proffessional Staff Details could not be Deleted.Kindly Try Again!");
                                   });
                        }
                    }
                });
            } else if (result.dismiss === Swal.DismissReason.cancel) {
                Swal.fire(
                    'Key Proffesssional Staff Deletion Cancelled',
                    'You cancelled your Key Proffesssional Staff details deletion!',
                    'error'
                );
            }
        });
    }
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
                     '<a class="btn btn-success edit_professionalstaff_details" id="edit_professionalstaff_details"><i class="fa fa-edit m-r-10"></i>View</a>',
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
                                      title: "Proffessional Staff Details Deleted!",
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
                                         title: "Proffessional Staff Details Deletion Error!!!",
                                         text: status,
                                         type: "error"
                                     }).then(() => {
                                         $("#keyprofessionalfeedback").css("display", "block");
                                         $("#keyprofessionalfeedback").css("color", "red");
                                         $('#keyprofessionalfeedback').addClass('alert alert-danger');
                                         $("#keyprofessionalfeedback").html("Your Proffessional Staff Details could not be Deleted.Kindly Try Again!");
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
function DownloadDocument(url) {
        Swal.fire({
            title: "Documents Download",
            text: "Proceed to download the selected document?",
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
                    cache: false,
                    type: 'GET',
                    url: url,
                    success: function (status) {
                        var uploadsfs = status.split('*');
                        status = uploadsfs[0];
                        switch (status) {
                            case "success":
                                Swal.fire
                                ({
                                    title: "Files Downloaded!",
                                    text: "File Downloded Successfully!",
                                    type: "success"
                                }).then(() => {
                                    $("#keydocumentsuploadfeedback").css("display", "block");
                                    $("#keydocumentsuploadfeedback").css("color", "green");
                                    $('#keydocumentsuploadfeedback').attr("class", "alert alert-success");
                                    $("#keydocumentsuploadfeedback").html("Selected File has been Downloaded Successfully!");
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
                                    $("#keydocumentsuploadfeedback").html("Selected File has Could not be Downloaded Successfully!");
                                    $("#keydocumentsuploadfeedback").css("color", "red");
                                    $('#keydocumentsuploadfeedback').addClass('alert alert-danger');
                                });
                                break;
                        }
                    }
                })
            } else if (result.dismiss === Swal.DismissReason.cancel) {
                Swal.fire(
                    'Document Download Cancelled',
                    'You cancelled your documents download!',
                    'error'
                );
            }
        });
}
function DocumentsDelete(url) {
        Swal.fire({
            title: "Registration Document Deletion",
            text: "Proceed to delete the selected document?",
            type: "warning",
            showCancelButton: true,
            closeOnConfirm: true,
            confirmButtonText: "Yes, Delete!",
            confirmButtonClass: "btn-success",
            confirmButtonColor: "#008000",
            position: "center"
        }).then((result) => {
            if (result.value) {
                $.ajax({
                    cache: false,
                    type: 'GET',
                    url: url,
                    success: function (status) {
                        var registerstatus = status.split('*');
                        status = registerstatus[0];
                        console.log(JSON.stringify(status))
                        switch (status) {
                            case "success":
                                Swal.fire
                                ({
                                    title:"Files Deleted!",
                                    text: "File Deleted Successfully!",
                                    type: "success"
                                }).then(() => {
                                    $("#deletekeydocumentsuploadfeedback").css("display", "block");
                                    $("#deletekeydocumentsuploadfeedback").css("color", "green");
                                    $('#deletekeydocumentsuploadfeedback').attr("class", "alert alert-success");
                                    $("#deletekeydocumentsuploadfeedback").html("Selected File has been Deleted Successfully!");
                                    $("#deletekeydocumentsuploadfeedback").css("display", "block");
                                    $("#deletekeydocumentsuploadfeedback").css("color", "green");
                                });
                                window.location.href = "/Home/SupplierRegistration";
                                vendorUploadedDocuments.init();
                                break;
                            case "filenotfound":
                                Swal.fire
                                ({
                                    title: "File to Be Deleted Not Found!",
                                    text: "File to be Deleted Could not be Found!",
                                    type: "error"
                                }).then(() => {
                                    $("#deletekeydocumentsuploadfeedback").css("display", "block");
                                    $("#deletekeydocumentsuploadfeedback").css("color", "red");
                                    $('#deletekeydocumentsuploadfeedback').attr("class", "alert alert-danger");
                                    $("#deletekeydocumentsuploadfeedback").html("Selected File could not be found!");
                                    $("#deletekeydocumentsuploadfeedback").css("display", "block");
                                    $("#deletekeydocumentsuploadfeedback").css("color", "green");
                                });
                                break;
                            default:
                                Swal.fire
                                ({
                                    title: "Document Deletion Error!!!",
                                    text: "File Could not be deleted.Kindly Tray Again Later",
                                    type: "error"
                                }).then(() => {
                                    $("#deletekeydocumentsuploadfeedback").css("display", "block");
                                    $("#deletekeydocumentsuploadfeedback").html("Selected File Could Not be Deleted. Kindly Try Again Later!");
                                    $("#deletekeydocumentsuploadfeedback").css("color", "red");
                                    $('#deletekeydocumentsuploadfeedback').addClass('alert alert-danger');
                                });
                                break;
                        }
                    }
                })
            } else if (result.dismiss === Swal.DismissReason.cancel) {
                Swal.fire(
                    'Document Deletion Cancelled',
                    'You cancelled your documents deletion!',
                    'error'
                );
            }
        });
}
function DocumentsDeleteBidResp(url) {

    var DocNo = $("#preapplicationo").val();
    var response = $("#Invresponse").val();


    Swal.fire({
        title: "Response Document Deletion",
        text: "Proceed to delete the selected document?",
        type: "warning",
        showCancelButton: true,
        closeOnConfirm: true,
        confirmButtonText: "Yes, Delete!",
        confirmButtonClass: "btn-success",
        confirmButtonColor: "#008000",
        position: "center"
    }).then((result) => {
        if (result.value) {
            $.ajax({
                cache: false,
                type: 'GET',
                url: url,
                success: function (status) {
                    var registerstatus = status.split('*');
                    status = registerstatus[0];
                    console.log(JSON.stringify(status))
                    switch (status) {
                        case "success":
                            Swal.fire
                            ({
                                title: "Files Deleted!",
                                text: "File Deleted Successfully!",
                                type: "success"
                            }).then(() => {
                                $("#deletekeydocumentsuploadfeedback").css("display", "block");
                                $("#deletekeydocumentsuploadfeedback").css("color", "green");
                                $('#deletekeydocumentsuploadfeedback').attr("class", "alert alert-success");
                                $("#deletekeydocumentsuploadfeedback").html("Selected File has been Deleted Successfully!");
                                $("#deletekeydocumentsuploadfeedback").css("display", "block");
                                $("#deletekeydocumentsuploadfeedback").css("color", "green");
                            });
                            window.location.href = "/Home/TenderRFQAttachDocument?tenderNo=" + DocNo + "&Response=" + response;
                            vendorUploadedDocuments.init();
                            break;
                        case "filenotfound":
                            Swal.fire
                            ({
                                title: "File to Be Deleted Not Found!",
                                text: "File to be Deleted Could not be Found!",
                                type: "error"
                            }).then(() => {
                                $("#deletekeydocumentsuploadfeedback").css("display", "block");
                                $("#deletekeydocumentsuploadfeedback").css("color", "red");
                                $('#deletekeydocumentsuploadfeedback').attr("class", "alert alert-danger");
                                $("#deletekeydocumentsuploadfeedback").html("Selected File could not be found!");
                                $("#deletekeydocumentsuploadfeedback").css("display", "block");
                                $("#deletekeydocumentsuploadfeedback").css("color", "green");
                            });
                            break;
                        default:
                            Swal.fire
                            ({
                                title: "Document Deletion Error!!!",
                                text: "File Could not be deleted.Kindly Tray Again Later",
                                type: "error"
                            }).then(() => {
                                $("#deletekeydocumentsuploadfeedback").css("display", "block");
                                $("#deletekeydocumentsuploadfeedback").html("Selected File Could Not be Deleted. Kindly Try Again Later!");
                                $("#deletekeydocumentsuploadfeedback").css("color", "red");
                                $('#deletekeydocumentsuploadfeedback').addClass('alert alert-danger');
                            });
                            break;
                    }
                }
            })
        } else if (result.dismiss === Swal.DismissReason.cancel) {
            Swal.fire(
                'Document Deletion Cancelled',
                'You cancelled your documents deletion!',
                'error'
            );
        }
    });
}


function DocumentsDeletePerformance(url) {

   
    var response = $("#responseNumber").val();


    Swal.fire({
        title: "Response Document Deletion",
        text: "Proceed to delete the selected document?",
        type: "warning",
        showCancelButton: true,
        closeOnConfirm: true,
        confirmButtonText: "Yes, Delete!",
        confirmButtonClass: "btn-success",
        confirmButtonColor: "#008000",
        position: "center"
    }).then((result) => {
        if (result.value) {
            $.ajax({
                cache: false,
                type: 'GET',
                url: url,
                success: function (status) {
                    var registerstatus = status.split('*');
                    status = registerstatus[0];
                    console.log(JSON.stringify(status))
                    switch (status) {
                        case "success":
                            Swal.fire
                            ({
                                title: "Files Deleted!",
                                text: "File Deleted Successfully!",
                                type: "success"
                            }).then(() => {
                                $("#deletekeydocumentsuploadfeedback").css("display", "block");
                                $("#deletekeydocumentsuploadfeedback").css("color", "green");
                                $('#deletekeydocumentsuploadfeedback').attr("class", "alert alert-success");
                                $("#deletekeydocumentsuploadfeedback").html("Selected File has been Deleted Successfully!");
                                $("#deletekeydocumentsuploadfeedback").css("display", "block");
                                $("#deletekeydocumentsuploadfeedback").css("color", "green");
                            });
                            window.location.href = "/Home/PerfGuaranteeDocAttach";
                            vendorUploadedDocuments.init();
                            break;
                        case "filenotfound":
                            Swal.fire
                            ({
                                title: "File to Be Deleted Not Found!",
                                text: "File to be Deleted Could not be Found!",
                                type: "error"
                            }).then(() => {
                                $("#deletekeydocumentsuploadfeedback").css("display", "block");
                                $("#deletekeydocumentsuploadfeedback").css("color", "red");
                                $('#deletekeydocumentsuploadfeedback').attr("class", "alert alert-danger");
                                $("#deletekeydocumentsuploadfeedback").html("Selected File could not be found!");
                                $("#deletekeydocumentsuploadfeedback").css("display", "block");
                                $("#deletekeydocumentsuploadfeedback").css("color", "green");
                            });
                            break;
                        default:
                            Swal.fire
                            ({
                                title: "Document Deletion Error!!!",
                                text: "File Could not be deleted.Kindly Tray Again Later",
                                type: "error"
                            }).then(() => {
                                $("#deletekeydocumentsuploadfeedback").css("display", "block");
                                $("#deletekeydocumentsuploadfeedback").html("Selected File Could Not be Deleted. Kindly Try Again Later!");
                                $("#deletekeydocumentsuploadfeedback").css("color", "red");
                                $('#deletekeydocumentsuploadfeedback').addClass('alert alert-danger');
                            });
                            break;
                    }
                }
            })
        } else if (result.dismiss === Swal.DismissReason.cancel) {
            Swal.fire(
                'Document Deletion Cancelled',
                'You cancelled your documents deletion!',
                'error'
            );
        }
    });
}
var vendorUploadedDocuments = function () {
    var documents = function () {
        var documentsTable = $("#tab_supplier_registered_Documents"),
            l = documentsTable.dataTable({
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
            url: "/Home/GetUploadedDocuments",
        });
        $.ajax({
            data: ""
        }).done(function (json) {
            l.fnClearTable();
            var o = 1;
            for (var i = 0; i < json.length; i++) {
                l.fnAddData([
                    json[i].Certificate_No,
                    json[i].Description,
                    json[i].Issue_Date,
                    json[i].Expiry_Date,
                    json[i].File_Name,
                    '<a class="btn btn-success download_documents" id="download_documents"><i class="fa fa-edit m-r-10"></i>Edit</a>',
                    '<a class="btn btn-danger delete_document"><i class="fa fa-trash m-r-10">Delete</a>'
                ]);
            }
        });
        documentsTable.on("click",
           ".download_documents",
           function (documentsTable) {
               documentsTable.preventDefault();
               var i = $(this).parents("tr")[0];
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
        documentsTable.on("click",
          ".delete_document",
          function (documentsTable) {
              documentsTable.preventDefault();
              var i = $(this).parents("tr")[0];
              //alert("record to be deleted: " + i.cells[1].innerHTML);
              Swal.fire({
                  title: "Confirm Deleting Document",
                  text: "Sure you'd like to proceed with deletion?",
                  type: "warning",
                  showCancelButton: true,
                  closeOnConfirm: true,
                  confirmButtonText: "Yes, Delete Document",
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
                                      title: "File Document Deleted Successfully!",
                                      text: "File Document Deleted Successfully!",
                                      type: "success"
                                  }).then(() => {
                                      $("#banksfeedback").css("display", "block");
                                      $("#banksfeedback").css("color", "green");
                                      $('#banksfeedback').attr("class", "alert alert-success");
                                      $("#banksfeedback").html("Your File Document have been successfully Deleted!");
                                      $("#banksfeedback").css("display", "block");
                                      $("#banksfeedback").css("color", "green");
                                      $("#banksfeedback").html("Your File Document have been successfully Deleted!");
                                  });
                                  vendorUploadedDocuments.init();
                                  break;
                              default:
                                  Swal.fire
                                     ({
                                         title: "Document Deletion Error Error!!!",
                                         text: status,
                                         type: "error"
                                     }).then(() => {
                                         $("#banksfeedback").css("display", "block");
                                         $("#banksfeedback").css("color", "red");
                                         $('#banksfeedback').addClass('alert alert-danger');
                                         $("#banksfeedback").html("Your Document File could not be Deleted");
                                     });
                          }
                      });
                  } else if (result.dismiss === Swal.DismissReason.cancel) {
                      Swal.fire(
                          'Document  Deletion Cancelled',
                          'You cancelled your Document deletion Request!',
                          'error'
                      );
                  }
              });

          });
    }
    return {
        init: function () {
            documents();
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
function EditShareholdersDetails(directorname, idnumber, citizenship, ownership, phone, address, email) {
    $("#directorname").val(directorname);
    $("#idnumbers").val(idnumber);
    $("#citizenship").val(citizenship);
    $("#ownershippercentage").val(ownership);
    $("#phonenumbers").val(phone);
    $("#shareholderaddress").val(address);
    $("#emailaddress").val(email);
    $("#add_shareholders").modal();
}
function AttachDocuments(Document_No, Procurement_Document_Type, Description, Requirement_Type) {
    $("#DocNo").val(Document_No);
    $("#ProcDocType").val(Procurement_Document_Type);
    $("#description").val(Description);
    $("#RequirementType").val(Requirement_Type);
    $("#AttachDocumentsModal").modal();
}
function AttachSupplierDocuments(Document_No, Procurement_Document_Type, Description, Requirement_Type) {
    $("#DocNo").val(Document_No);
    $("#ProcDocType").val(Procurement_Document_Type);
    $("#description").val(Description);
    $("#RequirementType").val(Requirement_Type);
    $("#AttachDocumentsModal").modal();
}
function AttachDocumentsTender(Document_No, Procurement_Document_Type, Description, Requirement_Type,ResponseNo) {
    $("#DocNo").val(Document_No);
    $("#responseNumber").val(ResponseNo);
    $("#ProcDocType").val(Procurement_Document_Type);
    $("#description").val(Description);
    $("#RequirementType").val(Requirement_Type);
    $("#AttachDocumentsTend").modal();

}

function AttachDocumentsContract(Document_No, Procurement_Document_Type, prnNo, Requirement_Type, index) {
    $("#DocNo").val(Document_No);  
    $("#ProcDocType").val(Procurement_Document_Type);
    $("#prnno").val(prnNo);
    $("#indexNo").val(index);
    $("#RequirementType").val(Requirement_Type);
    $("#AttachDocumentsContracts").modal();

}


function EditBeneficiaryDetails(beneficiaryName, idnumber, type, passportNo, phone, email, Allocatedshares,beneficiaryType) {
    $("#beneficiaryname").val(beneficiaryName);
    $("#beneficiaryidnumbers").val(passportNo);
    $("#IdType").val(type);
    $("#beneficiaryPhoneNumber").val(phone);
    $("#beneficiaryemailaddress").val(email);
    $("#allocatedShares").val(Allocatedshares);
    $("#beneficiarytype").val(beneficiaryType);
    $("#add_beneficiaries").modal();
}
function EditLitigationsDetails(CategoryofDispute, DisputeDescription, TheotherDisputeparty, DisputeAmount, Year, AwardType) {
    $("#disputecategory").val(CategoryofDispute);
    $("#disputedescription").val(DisputeDescription);
    $("#disputeamounts").val(TheotherDisputeparty);
    $("#disputeparties").val(DisputeAmount);
    $("#litigationyear").val(Year);
    $("#awardtype").val(AwardType);
    $("#add_litigation").modal();
}
function EditPastExperienceDetails(Client_Name, Address, Assignment_Project_Name, Assignment_Start_Date, Assignment_End_Date, Total_Nominal_Value, Contract_Ref_No, Project_Scope_Summary) {
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
function EditBalanceSheetDetails(Audit_Year_Code_Reference, Current_Assets_LCY, Fixed_Assets_LCY, Current_Liabilities_LCY, Long_term_Liabilities_LCY, Owners_Equity_LCY) {

    $("#ddlyearcodes").val(Audit_Year_Code_Reference);
    $("#edittotalcurrentassets").val(Current_Assets_LCY);
    $("#edittotalfixedassets").val(Fixed_Assets_LCY);
    $("#edittotalcurrentliabilities").val(Current_Liabilities_LCY);
    $("#edittotallongtermliabilities").val(Long_term_Liabilities_LCY);
    $("#edittotalownersequity").val(Owners_Equity_LCY);
    $("#edit_balance_sheet_details").modal();
}

function EditIncomeStatementDetails(Audit_Year_Code_Reference, Total_Revenue_LCY, Total_COGS_LCY, Total_Operating_Expenses_LCY, Other_Non_operating_Re_Exp_LCY, Interest_Expense_LCY) {
    $("#dropdownyearcodeslists").val(Audit_Year_Code_Reference);
    $("#edittotalrevenue").val(Total_Revenue_LCY);
    $("#edittotalcogs").val(Total_COGS_LCY);
    $("#edittotaloperatingexpenses").val(Total_Operating_Expenses_LCY);
    $("#editothernonoperatingexpenses").val(Other_Non_operating_Re_Exp_LCY);
    $("#editinterstexpense").val(Interest_Expense_LCY);
    $("#edit_incomestatement_details").modal();
}
function EditKeyStaffDetails(StaffNumber, StaffName, StaffDateofBirth, StaffPhonenumber, Country_Region_Code, StaffEmail) {
    $("#editstaffnumber").val(StaffNumber);
    $("#editkeystaffname").val(StaffName);
    $("#editstaffprofession").val();
    $("#editcurrentDesignation").val();
    $("#editpersonneljoiningDate").val();
    $("#edityearswithfarm").val();
    $("#editpersonnelphonenumber").val(StaffPhonenumber);
    $("#edit_professionalkeystaff_details").modal();
}