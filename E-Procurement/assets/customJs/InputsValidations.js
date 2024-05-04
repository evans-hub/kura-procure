'use-strict';

function IsValidEmail(email) {
    var expr = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/ig;
    return expr.test(email);
};
function EmailValidator(emailadd) {
    var isValid = $("#regfeedback");
    if (!IsValidEmail(emailadd.value)) {
        Swal.fire
        ({
            title: "Email Validation Error!",
            text: "Invalid Email address detected!",
            type: "error",
            showCancelButton: true,
            closeOnConfirm: false,
            confirmButtonText: "Provide a valid email!",
            confirmButtonClass: "btn-danger",
            confirmButtonColor: "#ec6c62",
            position: "center"
        }).then(() => {
            isValid.css("display", "block");
            isValid.css("color", "red");
            isValid.attr("class", "alert alert-danger");
            isValid.html("Email is Invalid!");
            $("#email").focus();
            $("#email").css("border", "solid 1px red");
        });
        return;
    }
}
function IsPhoneNumberValid(phone) {
    var expr = /^(?:254|\+254|0)?(7(?:(?:[129][0-9])|(?:0[0-8])|(4[0-1]))[0-9]{6})$/ig;
    return expr.test(phone);
}
function PhoneNoValidator(phonenum) {
    var isValid = $("#regfeedback");
    if (!IsPhoneNumberValid(phonenum.value)) {
        Swal.fire
        ({
            title: "Mobile Number Validation Error!",
            text: "Invalid Mobile Number detected!",
            type: "error",
            showCancelButton: true,
            closeOnConfirm: false,
            confirmButtonText: "Provide a valid Phone Number!",
            confirmButtonClass: "btn-danger",
            confirmButtonColor: "#ec6c62",
            position: "center"
        }).then(() => {
            isValid.css("display", "block");
            isValid.css("color", "red");
            isValid.attr("class", "alert alert-danger");
            isValid.html("Provide a valid Phone Number!");
            $("#txtPhonenumberInd").focus();
            $("#txtPhonenumberInd").css("border", "solid 1px red");
        });
        return;
    }
    $("#txtPhonenumberInd").css("border-width", "0");
    $("#txtPhonenumberInd").css("border", "none");
    isValid.css("display", "none");
}
function PhoneNoValidator_Talktous(phonenum) {
    var isValid = $("#submitedfeedback");
    if (!IsPhoneNumberValid(phonenum.value)) {
        Swal.fire
        ({
            title: "Mobile Number Validation Error!",
            text: "Invalid Mobile Number detected!",
            type: "error",
            showCancelButton: true,
            closeOnConfirm: false,
            confirmButtonText: "Provide a valid Phone Number!",
            confirmButtonClass: "btn-danger",
            confirmButtonColor: "#ec6c62",
            position: "center"
        }).then(() => {
            isValid.css("display", "block");
            isValid.css("color", "red");
            isValid.attr("class", "alert alert-danger");
            isValid.html("Provide a valid Phone Number!");
            $("#txtphone").focus();
            $("#txtphone").css("border", "solid 1px red");
        });
        return;
    }
}