﻿$(document).ready(function () {


});


function fnLoginMethod() {
    var password = $(".user-passcode").val().trim();

    if (password == null || password == "") {
        return;
    }

    var loginmodel = {};
    loginmodel.Email = "elanchezhiyan.p@aitechindia.com";
    loginmodel.Password = "Aitech$321";
    loginmodel.RememberMe = false;

    $.ajax({
        type: 'POST',
        url: '/Account/Login?returnUrl=' + encodeURIComponent(window.location.pathname),
        async: true,
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(loginmodel),
        success: function (result) {
            location.reload();
        },
        error: function () {
        },
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

    var userCreationModel = {
        UserName: $(".create-user-form .first-name").val().trim() + $(".create-user-form .last-name").val().trim(),
        Email: $(".create-user-form .email-id").val(),
        FirstName: $(".create-user-form .first-name").val().trim(),
        LastName: $(".create-user-form .last-name").val().trim(),
        SSN: parseInt($(".create-user-form .ssn").val()),
        PasswordEnc: "password123",
        LockerUnit: $(".create-user-form .locker-unit").val() ,
        CreatedOn: new Date(),
        CreatedBy: "Admin",
        CheckOutStatus: false,
        PhoneNumber: parseInt($(".create-user-form .mobile-no").val())
    };

    var isValidated = ValidateUserCreation(JSON.stringify(userCreationModel));


    if (isValidated) {

        $.ajax({
            type: "POST",
            url: "/api/user",
            headers: { "RequestVerificationToken": $('input[name="__RequestVerificationToken"]').val() },
            contentType: "application/json",
            data: JSON.stringify(userCreationModel),
            success: function (data) {
                window.location.href = "/";
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

    if (typeof userCreationModel.PhoneNumber != "number" || userCreationModel.PhoneNumber.toString().length != 10) {
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

function fnValidateEmail(ctrl) {
    debugger;

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