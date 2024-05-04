$(document).ready(function () {
    $(".btn_work_execution_Details").click(function () {
    var WorksObj = {
        "Contractor_No": $("#contractno").val(),
        "Region_ID": $("#dropdownRegionsList").val(),
        "Description": $("#projecttitle").val(),
        "Road_Class_ID": $("#roadclass").val(),
        "Funding_Source": $("#ddfundingsource").val(),
        "Project_Start_Date": $("#projectstartdate").val(),
        "Project_End_Date": $("#projectenddate").val(),
        "Person_Responsible": $("#projectaccountant").val(),
        "Project_Manager": $("#residentengineer").val()
    }

    //Swal Message
    Swal.fire({
        title: "Confirm Submission of Work Execution Plan?",
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
                            title: "Work ExecutionPlan Details Submitted!",
                            text: "Your Work Execution Plan Details have been successfully submitted",
                            type: "success"
                        }).then(() => {
                            $("#workexecutionplanfeedback").css("display", "block");
                            $("#workexecutionplanfeedback").css("color", "green");
                            $('#workexecutionplanfeedback').attr("class", "alert alert-success");
                            $("#workexecutionplanfeedback").html("Your Work Execution Plan Details have been successfully submitted.Kindly Try Again!");
                            $("#workexecutionplanfeedback").css("display", "block");
                            $("#workexecutionplanfeedback").css("color", "green");
                            $("#workexecutionplanfeedback").html("Your Work Execution Plan Details have been successfully submitted.Kindly Try Again!");
                        });
                       // vendorbankaccounts.init();
                        break;
                    default:
                        Swal.fire
                        ({
                            title: "Wrok Execution Plan Details Submission Error!!!",
                            text: "Your Work Execution Plan Details could not be submitted" +" "+ registerstatus[1],
                            type: "error"
                        }).then(() => {
                            $("#workexecutionplanfeedback").css("display", "block");
                            $("#workexecutionplanfeedback").css("color", "red");
                            $('#workexecutionplanfeedback').addClass('alert alert-danger');
                            $("#workexecutionplanfeedback").html("Your Work Execution Plan Details could not be submitted.Kindly Try Again!");
                        });
                        break;

                }
            }
            );
        } else if (result.dismiss === Swal.DismissReason.cancel) {
            Swal.fire(
                'Work Execution Plan Details Cancelled',
                'You cancelled your work execution plan submission details!',
                'error'
            );
        }
    });

    });
    var ExecutionPlanNumber = $("#executionplannumber").val();
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
                data: JSON.stringify(ExecutionPlanNumber),
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
})