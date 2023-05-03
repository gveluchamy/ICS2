$(document).ready(function () {


});

function fnLoginMethod() {
    var password = $(".user-passcode").val().trim();

    if (password == null || password == "") {
        toastr.warning('Enter the password!', 'Warn', { timeOut: 4000 });
        return;
    }

    var loginmodel = {};
    loginmodel.Email = "";
    loginmodel.Password = password;
    loginmodel.RememberMe = false;

    $.ajax({
        type: 'POST',
        url: '/Account/Login?returnUrl=' + encodeURIComponent(fnGetParameterByName(ReturnUrl)),
        async: true,
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(loginmodel),
        success: function (response) {
            if (response.success) {
                toastr.success(response.message, 'Success', { timeOut: 4000 });
                window.location.href = response.redirectUrl;
            } else {
                $(".user-passcode").val("");
                $(".user-passcode").focus();
                toastr.error(response.message, 'Error', { timeOut: 4000 })
            }
        },
        error: function (xhr, status, error) {
            toastr.error('Some error has occurred in logging in. Please try again!', 'Error', { timeOut: 4000 })
        }
    });
}

function fnLogoutMethod() {
    $.ajax({
        type: "POST",
        url: "/Account/Logout",
        success: function (data) {
            window.location.href = "/";
        },
        error: function (xhr, status, error) {
            // Handle errors here
            console.log(error);
        }
    });
}

function fnNewUserCreation() {
    debugger;
    var divisionId = fnGetParameterByName("divisionId");
    var locationId = fnGetParameterByName("locationId");
    var lockerId = fnGetParameterByName("lockerId");
    var userCreationModel = {
        UserName: $(".create-user-form .first-name").val().trim() + "-" + $(".create-user-form .last-name").val().trim(),
        Email: $(".create-user-form .email-id").val(),
        FirstName: $(".create-user-form .first-name").val().trim(),
        LastName: $(".create-user-form .last-name").val().trim(),
        SSN: parseInt($(".create-user-form .ssn").val()),
        PasswordEnc: "password123",
        LockerId: parseInt($("#lockerUnit").val()),   //$(".create-user-form .locker-unit").val(),
        DateOfBirth: $(".create-user-form #DateOnly").val(),
        CreatedOn: new Date(),
        CreatedBy: "Admin",
        Role: $(".Role").val(),
        CheckOutStatus: false,
        PhoneNumber: $(".create-user-form .mobile-no").val(),
        LocationId:locationId,
        DivisionId:divisionId
    };

    var isValidated = ValidateUserCreation(JSON.stringify(userCreationModel));


    if (isValidated) {

        $.ajax({
            type: "POST",
            url: "/Account/CreateNewUser",
            headers: { "RequestVerificationToken": $('input[name="__RequestVerificationToken"]').val() },
            contentType: "application/json",
            data: JSON.stringify(userCreationModel),
            success: function (response) {
                debugger;   
                if (response.success) {
                    debugger;
                     window.location.href = "/Admin/Guardian?lockerId=" + parseInt(lockerId) + "&divisionId=" + parseInt(divisionId) + "&locationId=" + parseInt(locationId);
                } else {
                    alert(response.message);
                }
            },
            error: function (xhr, status, error) {
                console.log(error);
            }
        });
    }
}

function ValidateUserCreation(userCreationJSONModel) {
    var userCreationModel = JSON.parse(userCreationJSONModel);

    // Validate first name is not empty
    if (!userCreationModel.FirstName) {
        $(".first-name-div").addClass("form-error");
        $(".first-name-div #error").text("Enter the first name");
    }

    // Validate last name is not empty
    if (!userCreationModel.LastName) {
        $(".last-name-div").addClass("form-error");
        $(".last-name-div #error").text("Enter the last name");
    }
    //Validate Email is not empty
    if (!userCreationModel.Email) {
        $(".email-div").addClass("form-error");
        $(".email-div #error").text("Enter the correct email!");
    }

    if (typeof userCreationModel.PhoneNumber != "string" || userCreationModel.PhoneNumber.length != 10) {
        $(".mobile-div").addClass("form-error");
        $(".mobile-div #error").text("Enter the correct Mobile number!");
    }

    // Validate SSN format
    if (typeof userCreationModel.SSN != "number" || userCreationModel.SSN.toString().length!=9) {
        $(".ssn-div").addClass("form-error");
        $(".ssn-div #error").text("Enter the ssn 9 digit number");
    }

    // All fields are valid
    return $(".form-error").length > 0 ? false : true;

}

function fnValidateEmail (ctrl) {
    var currentValue = $(ctrl).val();
    var emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!emailRegex.test(currentValue)) {
        $(ctrl.parentElement).addClass("form-error");
        $(ctrl.nextElementSibling).text("Please fill the correct email!");
    }
}

function fnRemoveValidation(ctrl) {
    $(ctrl.parentElement).removeClass("form-error");
    $(ctrl.nextElementSibling).text("")
}

function fnAdminLoginMethod (page) {
    var email = $(".user-email").val().trim();
    var password = $(".user-passcode").val().trim();

    if (email == null || email == "") {
        toastr.warning('Enter the email address!', 'Warn', { timeOut: 4000 });
        return;
    }

    if (password == null || password == "") {
        toastr.warning('Enter the password!', 'Warn', { timeOut: 4000 });
        return;
    }

    var loginmodel = {};
    loginmodel.Email = email;
    loginmodel.Password = password;
    loginmodel.RememberMe = false;
    var returnUrls = fnGetParameterByName("ReturnUrl");

    $.ajax({
        type: 'POST',
        url: '/Account/Login?returnUrl=' + encodeURIComponent(returnUrls == null ? "/Admin/Dashboard" : returnUrls) + '&page=' + page,
        async: false,
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(loginmodel),
        success: function (response) {
            debugger;
            if (response.success) {
                toastr.success(response.message, 'Success', { timeOut: 4000 });
                    setTimeout(function () {
                        window.location.href = response.redirectUrl;
                    }, 1500);
            }
            else {
                $(".user-email").val("");
                $(".user-email").focus();
                $(".user-passcode").val("");
                $(".user-passcode").focus();
                toastr.error(response.message, 'Error', { timeOut: 4000 });
            }
        },
        error: function (xhr, status, error) {
            toastr.error('Some error has occurred in logging in. Please try again!', 'Error', { timeOut: 4000 })
        }
    });
}

function fnGetParameterByName (name) {
    url = window.location.href;
    name = name.replace(/[\[\]]/g, "\\$&");
    var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[ 2 ]) return '';
    return decodeURIComponent(results[ 2 ].replace(/\+/g, " "));
}