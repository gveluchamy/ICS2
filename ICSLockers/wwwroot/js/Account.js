$(document).ready(function () {


});


function fnLoginMethod () {
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

function fnLogoutMethod () {
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

function fnNewUserCreation () {
    debugger;

    //var userCreationModel = {
    //    UserName: $(".create-user-form .first-name").val().trim() + $(".create-user-form .last-name").val().trim(),
    //    Email: $(".create-user-form .email-id").val(),
    //    PasswordHash: "Admin",
    //    FirstName: $(".create-user-form .first-name").val(),
    //    LastName: $(".create-user-form .last-name").val(),
    //    SSN: $(".create-user-form .ssn").val(),
    //    LockerUnit: $(".create-user-form .locker-unit").val(),
    //    PhoneNumber: $(".create-user-form .mobile-no").val(),
    //    CheckOutStatus: false,
    //    /*CreatedOn: n,*/
    //    CreatedBy: "Admin",
    //    //NormalizedUserName: null,
    //    //NormalizedEmail: null,
    //    //EmailConfirmed: false,
    //    //SecurityStamp: null,
    //    //ConcurrencyStamp: null,
    //}

    var userCreationModel = {
        UserName: $(".create-user-form .first-name").val().trim() + $(".create-user-form .last-name").val().trim(),
        Email: $(".create-user-form .email-id").val(),
        FirstName: $(".create-user-form .first-name").val().trim(),
        LastName: $(".create-user-form .last-name").val().trim(),
        SSN: $(".create-user-form .ssn").val(),
        PasswordEnc: "password123",
        LockerUnit: $(".create-user-form .locker-unit").val(),
        CreatedOn: new Date(),
        CreatedBy: "Admin",
        CheckOutStatus: false
    };

    $.ajax({
        type: "POST",
        url: "/api/user",
      /*  async: true,*/
        headers: { "RequestVerificationToken": $('input[name="__RequestVerificationToken"]').val() },
        /*contentType: 'application/json; charset=utf-8',*/
        contentType: "application/json",
        data: JSON.stringify(userCreationModel),
        success: function (data) {
            window.location.href = "/";
        },
        error: function (xhr, status, error) {
            // Handle errors here
            console.log(error);
        }
    });
}