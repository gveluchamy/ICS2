
$(document).ready(function () {
    $('.user-menu a').click(function () {
        $('.user-menu a.active').removeClass('active');
        $(this).toggleClass('active');

    });
});
$('#myModal').on('shown.bs.modal', function () {
    $('#myInput').trigger('focus')
})
function increaseValue(button, limit) {
    const numberInput = button.parentElement.querySelector('.number');
    var value = parseInt(numberInput.innerHTML, 10);
    if (isNaN(value)) value = 0;
    if (limit && value >= limit) return;
    numberInput.innerHTML = value + 1;
}


function decreaseValue(button) {
    const numberInput = button.parentElement.querySelector('.number');
    var value = parseInt(numberInput.innerHTML, 10);
    if (isNaN(value)) value = 0;
    if (value < 1) return;
    numberInput.innerHTML = value - 1;
}
function fnNewLockerCreation() {    
    var LockerCreationModel = {
        LockerUnitNo: parseInt($("#exampleModalCenter #lokernumber").val()),
        TotalLocker: parseInt($("#exampleModalCenter #count").text()),
        UsedLocker: parseInt("0"),
        CreatedOn: new Date(),  //.toISOString().split('T')
        CreatedBy: null,
        IsDelete: false,
        ModifiedOn: new Date(),
        //ModifiedBy: "Admin",
        
                
    };
    //var url = "@Url.Action("CreateNewLocker","Admin")";

        $.ajax({    
            type: "POST",
            url: "/Admin/CreateNewLocker",
            headers: { "RequestVerificationToken": $('input[name="__RequestVerificationToken"]').val() },
            contentType: "application/json",
            data: JSON.stringify(LockerCreationModel),
            success: function (response) {
                if (response.success) {
                    window.location.href = response.redirectUrl;
                } else {
                    alert(response.message);
                }
            },
            error: function (xhr, status, error) {
                console.log(error);
            }
        });
    
}