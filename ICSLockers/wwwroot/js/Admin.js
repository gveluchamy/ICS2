$(document).ready(function () {
    $('.user-menu a').click(function () {
        $('.user-menu a.active').removeClass('active');
        $(this).toggleClass('active');
    });

    $('#example').DataTable({
        "searching": true,
        "paging": true,
        "info": false,
        "lengthChange": false,

        pagingType: 'full_numbers',
        pageLength: 5,
        language: {
            oPaginate: {
                sNext: '<i class="fa-solid fa-angle-right"></i>',
                sPrevious: '<i class="fa-solid fa-angle-left"></i>',
                sFirst: '<i class="fa-solid fa-angles-left"></i>',
                sLast: '<i class="fa-solid fa-angles-right"></i>'
            }
        },

        fixedColumns: true,
        responsive: true,
    });
    $('.dataTables_filter input').addClass('search');

    $('#example-2').DataTable({
        "searching": true,
        "paging": true,
        "info": false,
        "lengthChange": false,

        pagingType: 'full_numbers',
        pageLength: 5,
        language: {
            oPaginate: {
                sNext: '<i class="fa-solid fa-angle-right"></i>',
                sPrevious: '<i class="fa-solid fa-angle-left"></i>',
                sFirst: '<i class="fa-solid fa-angles-left"></i>',
                sLast: '<i class="fa-solid fa-angles-right"></i>'
            }
        },

        fixedColumns: true,
        responsive: true,
    });
    $('.dataTables_filter input').addClass('search');

    $('#example-3').DataTable({
        "searching": true,
        "paging": true,
        "info": false,
        "lengthChange": false,

        pagingType: 'full_numbers',
        pageLength: 5,
        language: {
            oPaginate: {
                sNext: '<i class="fa-solid fa-angle-right"></i>',
                sPrevious: '<i class="fa-solid fa-angle-left"></i>',
                sFirst: '<i class="fa-solid fa-angles-left"></i>',
                sLast: '<i class="fa-solid fa-angles-right"></i>'
            }
        },

        fixedColumns: true,
        responsive: true,
    });
    $('.dataTables_filter input').addClass('search');
});

$('#myModal').on('shown.bs.modal', function () {
    $('#myInput').trigger('focus')
})

function increaseValue (button, limit) {
    const numberInput = button.parentElement.querySelector('.number');
    var value = parseInt(numberInput.innerHTML, 10);
    if (isNaN(value)) value = 0;
    if (limit && value >= limit) return;
    numberInput.innerHTML = value + 1;
}

function decreaseValue (button) {
    const numberInput = button.parentElement.querySelector('.number');
    var value = parseInt(numberInput.innerHTML, 10);
    if (isNaN(value)) value = 0;
    if (value < 1) return;
    numberInput.innerHTML = value - 1;
}

function fnAddLockerPopup () {
    $("#AddLockerModal #count").val(1);
    $("#AddLockerModal").modal("show");
}

function fnNewLockerCreation () {
    var LockerCreationModel = {
        LockerUnitNo: parseInt($("#AddLockerModal #lokernumber").val()),
        TotalLocker: parseInt($("#AddLockerModal #count").text()),
        UsedLocker: parseInt("0"),
        CreatedOn: new Date(),
        CreatedBy: null,
        IsDelete: false,
        ModifiedOn: new Date()
    };

    $.ajax({
        type: "POST",
        url: "/Admin/CreateNewLocker",
        headers: { "RequestVerificationToken": $('input[name="__RequestVerificationToken"]').val() },
        contentType: "application/json",
        data: JSON.stringify(LockerCreationModel),
        success: function (response) {
            if (response.success) {
                $(".locker-unit-list").append(response.unitHTML);
                toastr.success(response.message, 'Success', { timeOut: 4000 });
            } else {
                toastr.error(response.message, 'Error', { timeOut: 4000 });
            }
            $("#AddLockerModal").modal("hide");
        },
        error: function (xhr, status, error) {
            toastr.error(response.message, 'Error', { timeOut: 4000 });
            $("#AddLockerModal").modal("hide");
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

function fnAddNewLockerPopup () {
    $("#AddLocationLockerModal").modal("show");
}

function fnCreateNewLocation () {
    //$("#UpdateLockerModal").modal("hide");

    let locationName = $("#AddLocationLockerModal .location-name").val().trim();
    let totalDivisions = parseInt($("#AddLocationLockerModal .division-number").text());
    var locationData = {
        LocationName: locationName,
        TotalDivision: totalDivisions,
        IsDeleted: false,
        CreatedBy: "",
        CreatedOn: new Date(),
        ModifiedBy: "",
        ModifiedOn: new Date()
    };

    $.ajax({
        type: "POST",
        url: "/Admin/AddLocation",
        headers: { "RequestVerificationToken": $('input[name="__RequestVerificationToken"]').val() },
        contentType: "application/json",
        data: JSON.stringify(locationData),
        success: function (response) {
            debugger;
            if (response.success) {
                $(".grid.location-list").append(response.locationHtml);
                toastr.success(response.message, 'Success', { timeOut: 4000 });
            } else {
                toastr.error(response.message, 'Error', { timeOut: 4000 });
            }
            $("#AddLocationLockerModal").modal("hide");
        },
        error: function (xhr, status, error) {
            toastr.error(response.message, 'Error', { timeOut: 4000 });
            $("#AddLocationLockerModal").modal("hide");
        }
    });
}

function fnAddNewDivisionPopup () {
    var locationId = fnGetParameterByName("locationId");

    $.ajax({
        type: "GET",
        url: "/Admin/GetlocationDetails?LocationId=" + parseInt(locationId),
        headers: { "RequestVerificationToken": $('input[name="__RequestVerificationToken"]').val() },
        contentType: "application/json",
        success: function (response) {
            if (response != undefined) {
                $("#AddDivisionModal .locker-unit.location-name").val(response.locationName);
                //$("#AddDivisionModal .number.division-number").text(response.totalDivision);
                $("#AddDivisionModal").modal("show");
            }
            else {
                toastr.error("Some error has occured in adding division. Please refresh the page and try again!", 'Error', { timeOut: 4000 });
            }
        },
        error: function (xhr, status, error) {
            debugger;
            toastr.error(response.message, 'Error', { timeOut: 4000 });
        }
    });
}

function fnAddDivision() {

    var locationId = fnGetParameterByName("locationId");

    let locationName = $("#AddDivisionModal .locker-unit.location-name").val().trim();
    let totalDivisions = parseInt($("#AddDivisionModal .number.division-number").text());
    var locationData = {
        LocationId : parseInt(locationId),
        LocationName: locationName,
        TotalDivision: parseInt(totalDivisions),
        IsDeleted: false,
        CreatedBy: null,
        CreatedOn: new Date(),
        ModifiedBy: null,
        ModifiedOn: new Date()
    };

    $.ajax({
        type: "POST",
        url: "/Admin/AddDivisions",
        headers: { "RequestVerificationToken": $('input[name="__RequestVerificationToken"]').val() },
        contentType: "application/json",
        data: JSON.stringify(locationData),
        success: function (response) {
            debugger;
            if (response != null){
                $("#AddDivisionModal").modal("hide");
                location.reload();
                toastr.success("Divisions has been added successfully!", 'Success', { timeOut: 4000 });
            } else {
                toastr.error(response.message, 'Error', { timeOut: 4000 });
            }
            $("#AddDivisionModal").modal("hide");
        },
        error: function (xhr, status, error) {
            toastr.error(response.message, 'Error', { timeOut: 4000 });
            $("#AddDivisionModal").modal("hide");
        }
    });
}

//function fnUpdateDivisionPopup() {
//    var locationId = fnGetParameterByName("locationId");
//    debugger;

//    $.ajax({
//        type: "GET",
//        url: "/Admin/GetlocationDetails?locationId=" + parseInt(locationId),
//        headers: { "RequestVerificationToken": $('input[name="__RequestVerificationToken"]').val() },
//        contentType: "application/json",
//        success: function (response) {
//            if (response != undefined) {
//                $("#UpdateNewDivisionPopup .locker-unit.location-name").val(response.locationName);
//                $("#UpdateNewDivisionPopup .division-name").val(response.divisionId);
//                $("#UpdateNewDivisionPopup").modal("show");
//            }
//            else {
//                toastr.error("Some error has occured in adding division. Please refresh the page and try again!", 'Error', { timeOut: 4000 });
//            }
//        },
//        error: function (xhr, status, error) {
//            debugger;
//            toastr.error(response.message, 'Error', { timeOut: 4000 });
//        }
//    });
//}
function fnUpdateDivisionPopup() {
    var locationId = fnGetParameterByName("locationId");

    $.ajax({
        type: "GET",
        url: "/Admin/GetlocationDetails?locationId=" + parseInt(locationId),
        headers: { "RequestVerificationToken": $('input[name="__RequestVerificationToken"]').val() },
        contentType: "application/json",
        success: function (response) {
            if (response != undefined) {
                // Set the location name input field
                $("#UpdateNewDivisionPopup .locker-unit.location-name").val(response.locationName);
                $("#UpdateNewDivisionPopup .division-dropdown").val(response.DivisionId);

                // Set up the dropdown list for divisionId
                var divisionDropdown = $("#UpdateNewDivisionPopup .division-dropdown");
                divisionDropdown.empty(); // Clear existing options
                $.each(response.divisions, function (index, division) {
                    // Add a new option for each division
                    var option = $("<option>", {
                        value: division.id,
                        text: division.name
                    });
                    divisionDropdown.append(option);
                });

                // Set the selected division in the dropdown list
                divisionDropdown.val(response.divisionId);

                // Show the modal popup
                $("#UpdateNewDivisionPopup").modal("show");
            }
            else {
                toastr.error("Some error has occured in adding division. Please refresh the page and try again!", 'Error', { timeOut: 4000 });
            }
        },
        error: function (xhr, status, error) {
            toastr.error(response.message, 'Error', { timeOut: 4000 });
        }
    });
}

function fnUpdateDivision() {    
    $("#UpdateNewDivisionPopup").modal("show");
}

function fnUpdateDivision () {
    let locationName = $("#UpdateNewDivisionPopup .location-name").val();
    let totalDivisions = parseInt($("#UpdateNewDivisionPopup .division-name").val());
    var locationData = {
        LocationName: locationName,
        DivisionId: totalDivisions,
        TotalLockers: parseInt($(".locker-number").text()),
        IsDeleted: false,
        CreatedBy: "",
        CreatedOn: new Date(),
        ModifiedBy: "",
        ModifiedOn: new Date()
    };

    $.ajax({
        type: "POST",
        url: "/Admin/UpdateDivision",
        headers: { "RequestVerificationToken": $('input[name="__RequestVerificationToken"]').val() },
        contentType: "application/json",
        data: JSON.stringify(locationData),
        success: function (response) {
            debugger;
            if (response.success) {
                /*$('.unit.division-model').html('');*/
                $(".grid.locker-unit-list .division-model").empty();
                $(".grid.locker-unit-list .division-model").append(response.divisionHtml);
                toastr.success(response.message, 'Success', { timeOut: 4000 });
            } else {
                toastr.error(response.message, 'Error', { timeOut: 4000 });
            }
            $("#UpdateNewDivisionPopup").modal("hide");
        },
        error: function (xhr, status, error) {
            toastr.error(response.message, 'Error', { timeOut: 4000 });
            $("#UpdateNewDivisionPopup").modal("hide");
        }
    });
}

function fnUpdatelocker () {
    let totalLocker = parseInt($("#exampleModalCenter .Locker-count").text());
    var LockerData = {
        LockerID: totalLocker,
        IsDeleted: false,
        CreatedBy: "",
        CreatedOn: new Date(),
        ModifiedBy: "",
        ModifiedOn: new Date()
    };

    $.ajax({
        type: "POST",
        url: "/Admin/UpdateLocker",
        headers: { "RequestVerificationToken": $('input[name="__RequestVerificationToken"]').val() },
        contentType: "application/json",
        data: JSON.stringify(LockerData),
        success: function (response) {
            debugger;
            if (response.success) {
                $(".division-model").append(response.divisionHtml);
                toastr.success(response.message, 'Success', { timeOut: 4000 });
            } else {
                toastr.error(response.message, 'Error', { timeOut: 4000 });
            }
            $("#exampleModalCenter").modal("hide");
        },
        error: function (xhr, status, error) {
            toastr.error(response.message, 'Error', { timeOut: 4000 });
            $("#exampleModalCenter").modal("hide");
        }
    });
}

function fnFilterLockers (ctrl) {
    $(".locker-unit-page .locker").filter(function () {
        var isPresent = true;
        if (ctrl.value == "Avail") {
            isPresent = $(this).hasClass("available");
        }
        else if (ctrl.value == "Not-Avail") {
            isPresent = $(this).hasClass("not-available");
        }
        $(this.parentElement).toggle(isPresent);
    });
}