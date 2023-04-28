$(document).ready(function () {
    $('.user-menu a').click(function () {
        $('.user-menu a.active').removeClass('active');
        $(this).toggleClass('active');

    });
});

function fnRemoveUserPopup() {
    $("#RemoveUserModal").modal("show");
}

var $el = $("#options img");
var $ee = $("#options #menus");
$el.click(function (e) {
    e.stopPropagation();
    $("#options #menus").toggleClass('show');
});
$(document).on('click', function (e) {
    if (($(e.target) != $el) && ($ee.hasClass('show'))) {
        $ee.removeClass('show');
    }
});

$(document).on("click", 'input[type="radio"]', function () {
    if ($("#test4").is(":checked")) {
        $('#other-relation').addClass('show');
    }
    else if ($("#test3,#test2,#test1").is(":checked")) {
        $('#other-relation').removeClass('show');
    }
});


$(document).ready(function () {
    $('.user-menu a').click(function () {
        $('.user-menu a.active').removeClass('active');
        $(this).toggleClass('active');

    });
});


var $el = $("#options img");
var $ee = $("#options #menus");
$el.click(function (e) {
    e.stopPropagation();
    $("#options #menus").toggleClass('show');
});
$(document).on('click', function (e) {
    if (($(e.target) != $el) && ($ee.hasClass('show'))) {
        $ee.removeClass('show');
    }
});

$(document).ready(function () {
    $('.user-menu a').click(function () {
        $('.user-menu a.active').removeClass('active');
        $(this).toggleClass('active');
    });
    $('.js-example-basic-single').select2();
});


var $el = $("#options img");
var $ee = $("#options #menus");
$el.click(function (e) {
    e.stopPropagation();
    $("#options #menus").toggleClass('show');
});
$(document).on('click', function (e) {
    if (($(e.target) != $el) && ($ee.hasClass('show'))) {
        $ee.removeClass('show');
    }
});
// select 2
var typed = "";
$('#mySelect2, #mySelect3, #mySelect4').select2({
    language: {
        noResults: function (term) {
            typed = $('.select2-search__field').val();
        }
    }

});
$('#mySelect2, #mySelect3, #mySelect4').on('select2:select', function (e) {
    typed = ""; // clear
});
$("#but").on("click", function () {
    if (typed) {
       
        // Set the value, creating a new option if necessary
        if ($('#mySelect2, #mySelect3, #mySelect4').find("option[value='" + typed + "']").length) {
            $('#mySelect2, #mySelect3, #mySelect4').val(typed).trigger('change');
        } else {
            // Create a DOM Option and pre-select by default

            var newOption = new Option(typed, typed, true, true);
            // Append it to the select
            $('#mySelect2, #mySelect3, #mySelect4').append(newOption).trigger('change');
        }
    }
});
$('#mySelect2, #mySelect3, #mySelect4').select2({
    dropdownParent: $('#movelocker')
});

     /*clickaction*/

function fnUpdateRelation() {
    debugger;
    var lockerId = fnGetParameterByName("lockerId");
    var relationShipModel = {
        GuardianName: $(".raltion-model .user-name").val().trim(),
        RelationShip: $('input[name="radio-group"]:checked').val() == "others" ? $('#relation').val() : $('input[name="radio-group"]:checked').val(),
        CreatedOn: new Date(),
        UpdatedOn: new Date(),
        LockerId: lockerId
    };

    //var isValidated = ValidateUserCreation(JSON.stringify(relationShipModel));


    debugger;
    $.ajax({
       
        type: "POST",
        url: "/Admin/Guardian",
        contentType: "application/json",
        data: JSON.stringify(relationShipModel),
        success: function (response) {
            debugger;           
            window.location.href = "/Admin/LockerDetails?lockerId=" + parseInt(lockerId);
            
        },
        error: function (xhr, status, error) {
            console.log(error);
        }
    });
    
}
function fnremoveAllItems() {
    var lockerId = fnGetParameterByName("lockerId")
    $.ajax({
        type: "POST",
        url: "/Admin/RemoveAllItems?lockerId=" + parseInt(lockerId),
        data: { lockerId: lockerId },
        success: function (response) {
            // handle success
            console.log(response);
        },
        error: function (xhr, status, error) {
            // handle error
            console.log(error);
        }
    });
}
function fnRemoveitem(ctrl) {
    debugger;
    ctrl.parentElement.previousElementSibling.textContent = ""
}

function fnRemoveUser() {
    $("#removeUserModel").modal("show");
}

function fnMoveLocker() {
    $("#movelocker").modal("show");
}
/*Update Loccker */
$(document).ready(function () {
    $('.user-menu a').click(function () {
        $('.user-menu a.active').removeClass('active');
        $(this).toggleClass('active');

    });
});
$(document).ready(function () {
    var numItems = $('.item').length;

    $("#add-product").click(function () {
        var numItems = $('.item').length;
        if (numItems <= 5) {
            $("#products").append('<div class="col-lg-12 mb-3 d-flex align-items-center item"><input type="text" name="product" id="" class="form-control"><img src="img/remove.png" class="ml-4" alt="remove-product" id="remove-product"  onclick="fnRemoveCurrentItem(this)"></div>');
        }
        else if (numItems == 5) {
            $('#add-product').hide();
        }
        else {
            $('#add-product').show();
        }
    });
});


function fnRemoveCurrentItem(ctrl) {
    $(ctrl.parentElement).remove();
}