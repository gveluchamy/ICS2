
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

function increaseValue(button, limit) {
    const numberInput = button.parentElement.querySelector('.number');
    var value = parseInt(numberInput.innerHTML, 10);
    if (isNaN(value)) value = 0;
    if (limit && value >= limit) return;
    numberInput.innerHTML = value + 1;
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
                $(".locker-unit-list").append(response.unitsHtml);
                toastr.success(response.message, 'Success', { timeOut: 4000 });
            } else {
                alert(response.message);
            }
        },
        error: function (xhr, status, error) {
            console.log(error);
        }
    });

}

function decreaseValue (button) {
    const numberInput = button.parentElement.querySelector('.number');
    var value = parseInt(numberInput.innerHTML, 10);
    if (isNaN(value)) value = 0;
    if (value < 1) return;
    numberInput.innerHTML = value - 1;
}
var totalPoints = document.getElementById('totalPoints').innerHTML;
var differenceValue = '100';
var calculatePointsPercentage = totalPoints / differenceValue * ('100');
var dataPercentage = calculatePointsPercentage.toFixed(0);

$(function (value) {
    $("#tierPointsValue").attr("data-percent", dataPercentage);
    $('.target-chart').easyPieChart({
        animate: 2000,
        lineWidth: 30,
        scaleColor: false,
        lineCap: 'butt',
        size: 300,
        responsive: true,
        trackColor: "rgba(0, 0, 0, 0.15)",
        barColor: "#2B4889" // ADVANTAGE TIER COLOR
        // #8a090d - CHOICE TIER COLOR
        // #b88c3b - PREFERRED TIER COLOR
        // #636466 - ELITE TIER COLOR
        // #000000 - OWNERS CLUB COLOR
    });
});
$('.totalTierPoints').each(function () {
    $(this).prop('Counter', 0).animate({
        Counter: $(this).text()
    }, {
        duration: 2000,
        easing: 'swing',
        step: function (now) {
            $(this).text(Math.ceil(now));
        }
    });
});
$('.locker-unit h1').each(function () {
    $(this).prop('Counter', 0).animate({
        Counter: $(this).text()
    }, {
        duration: 2000,
        easing: 'swing',
        step: function (now) {
            $(this).text(Math.ceil(now));
        }
    });
});