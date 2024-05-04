'use-strict';
function EditPricing(itemlinenumber, itemnumber, itemdescription, itemunitofmeasure, itemdirectunitcost, tquantity) {
    $("#editilinetemnumber").val(itemlinenumber);
    $("#edititemnumber").val(itemnumber);
    $("#edititemdescription").val(itemdescription);
    $("#editunitofmeasure").val(itemunitofmeasure);
    $("#editdirectexvat").val(itemdirectunitcost);
    $("#bidedititemquantity").val(tquantity);
    $("#edit_PriceLines").modal();
}
function EditBidSecurity(issuer, offices, description, amount, effectivedate, expirydate) {
    $("#editilinetemnumber").val(itemlinenumber);
    $("#edititemnumber").val(itemnumber);
    $("#edititemdescription").val(itemdescription);
    $("#editunitofmeasure").val(itemunitofmeasure);
    $("#editdirectexvat").val(itemdirectunitcost);
    $("#bidedititemquantity").val(tquantity);
    $("#edit_BidSecurityDetails").modal();
}
function showDiv(divId, element) {
    document.getElementById(divId).style.display = element.value == 2 ? 'block' : 'none';
    //showDiv2('hidden_div2', element);
}
function showDiv2(divId2, element) {
    document.getElementById(divId2).style.display = element.value == 1 ? 'none' : 'block';
    
}
function showDiv3(divId3, element) {
    document.getElementById(divId3).style.display = element.value == 0 ? 'none' : 'block';

}
function DeleteBidBalanceSheet(url) {
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
function DeleteBidsecurity(url) {
    Swal.fire({
        title: "Delete Bid security Details",
        text: "Proceed to delete the selected Bid Security Details?",
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
                                title: "Bid Security Details Deleted!",
                                text: "Bid Security Details Successfully!",
                                type: "success"
                            }).then(() => {
                                $("#bidsecurityfeedback").css("display", "block");
                                $("#bidsecurityfeedback").css("color", "green");
                                $('#bidsecurityfeedback').attr("class", "alert alert-success");
                                $("#bidsecurityfeedback").html("Your Bid Security Details have been successfully Deleted.Kindly Proceed to fill in the rest details!");
                                $("#bidsecurityfeedback").css("display", "block");
                                $("#bidsecurityfeedback").css("color", "green");
                                $("#bidsecurityfeedback").html("Your Bid Security Details have been successfully Deleted.Kindly Proceed to fill in the rest details!");
                                window.location.href = "/Home/RespondTenderWizard";
                            });
                            
                            break;
                        default:
                            Swal.fire
                               ({
                                   title: "Bid Security Details Deletion Error!!!",
                                   text: status,
                                   type: "error"
                               }).then(() => {
                                   $("#bidsecurityfeedback").css("display", "block");
                                   $("#bidsecurityfeedback").css("color", "red");
                                   $('#bidsecurityfeedback').addClass('alert alert-danger');
                                   $("#bidsecurityfeedback").html("Your BBid Security Details could not be Deleted.Kindly Try Again!");
                               });
                    }
                }
            });
        } else if (result.dismiss === Swal.DismissReason.cancel) {
            Swal.fire(
                'Bid Security Details Deletion Cancelled',
                'You cancelled your Bid Security Details  deletion!',
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
function EditIncomestatementDetails(yearcode, totalincome, cogs, operatingincome, interestexpense) {
    $("#ddlyearcodes").val(yearcode);
    $("#edittotalrevenue").val(totalincome);
    $("#totalcogs").val(cogs);
    $("#editoperatingexpense").val(operatingincome);
    $("#editnonoperating").val(operatingincome);
    $("#editinterestexpense").val(interestexpense);
    $("#edit_incomestatement").modal();
};
function EditBalanceSheetDetails(yearcode, currentassets, fixedassets, currentliabilities, longtermliabilities, ownersequity) {
    $("#editbalancesheetyearcode").val(yearcode);
    $("#edittotalcurrentassets").val(currentassets);
    $("#edittotalfixedassets").val(fixedassets);
    $("#edittotalcurrentliabilities").val(currentliabilities);
    $("#edittotallontermliabilities").val(longtermliabilities);
    $("#edittotalownersequity").val(ownersequity);
    $("#edit_Balancesheet").modal();
}
function EditEquipment(equpcategory, description, ownership, serialnumber, yearsofuser, equipmentcondition) {
    $("#editequipmentcategory").val(equpcategory);
    $("#editdescription").val(description);
    $("#editOwnershiptype").val(ownership);
    $("#editequipmentserial").val(serialnumber);
    $("#edityears").val(yearsofuser);
    $("#editequipments").val(equipmentcondition);
    $("#edit_Equipments").modal();

};
function EditPersonnel(staffname, staffcategory, employtype, email, profession, projectrole) {
    $("#staffName").val(staffname);
    $("#staffcategory").val(staffcategory);
    $("#emplymentType").val(employtype);
    $("#emailAddress").val(email);
    $("#profession").val(profession);
    $("#requiredProjectRole").val(projectrole);
    $("#edit_personell").modal();

};
function DeleteBidEquipment(url) {
    Swal.fire({
        title: "Delete Bid Equipment Details",
        text: "Proceed to delete the selected Bid Equipment Details?",
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
                                title: "Bid Equipment Details Deleted!",
                                text: "Bid Equipment Details Successfully!",
                                type: "success"
                            }).then(() => {
                                $("#bidsecurityfeedback").css("display", "block");
                                $("#bidsecurityfeedback").css("color", "green");
                                $('#bidsecurityfeedback').attr("class", "alert alert-success");
                                $("#bidsecurityfeedback").html("Your Bid Equipment Details have been successfully Deleted.Kindly Proceed to fill in the rest details!");
                                $("#bidsecurityfeedback").css("display", "block");
                                $("#bidsecurityfeedback").css("color", "green");
                                $("#bidsecurityfeedback").html("Your Bid Equipment Details have been successfully Deleted.Kindly Proceed to fill in the rest details!");
                            });
                            VendorBidEquipmentsDetails.init();
                            break;
                        default:
                            Swal.fire
                               ({
                                   title: "Bid Equipment Details Deletion Error!!!",
                                   text: status,
                                   type: "error"
                               }).then(() => {
                                   $("#bidsecurityfeedback").css("display", "block");
                                   $("#bidsecurityfeedback").css("color", "red");
                                   $('#bidsecurityfeedback').addClass('alert alert-danger');
                                   $("#bidsecurityfeedback").html("Your BBid Equipment Details could not be Deleted.Kindly Try Again!");
                               });
                    }
                }
            });
        } else if (result.dismiss === Swal.DismissReason.cancel) {
            Swal.fire(
                'Bid Equipment Details Deletion Cancelled',
                'You cancelled your Bid Equipment Details  deletion!',
                'error'
            );
        }
    });
}

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

function DeleteBidPersonel(url) {
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
                                window.location.href = "/Home/RespondTenderWizard";
                            });
                            vendorBidResponseStaff.init();
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
var vendorBidResponseStaff = function () {
    var keyprofessionalstaff = function () {
        var KeyProfessionalStaffTable = $("#tbl_bid_personnel"),
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
            url: "/Home/GetBidPersonnelDetails",
        });
        $.ajax({
            data: { BidResponseNumber: BidResponseNumber },
        }).done(function (json) {
            l.fnClearTable();
            //console.log(JSON.stringify({ vendorTestdata: json }));
            var o = 1;
            for (var i = 0; i < json.length; i++) {
                l.fnAddData([
                    o++,
                    json[i].StaffName,
                    json[i].ProjectRoleCode,
                    json[i].RequiredProfession,
                    json[i].StaffCategory,
                    json[i].EmailAddress,
                    json[i].EmploymentType,
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