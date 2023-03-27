function fnLoginMethod () {
    var password = $(".user-passcode").val().trim();

    if (password == null || password == "") {
        return;
    }

    var loginmodel = {};
    loginmodel.Email = "elanchezhiyan.p@aitechindia.com"
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