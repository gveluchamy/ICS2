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
    if (document.URL.includes("locationId")) {
        var lockerId = fnGetParameterByName("lockerId");
        var locatioId = fnGetParameterByName("locationId")
        var divisionId = fnGetParameterByName("divisionId")
        var relationShipModel = {
            GuardianName: $(".raltion-model .user-name").val().trim(),
            RelationShip: $('input[name="radio-group"]:checked').val() == "others" ? $('#relation').val() : $('input[name="radio-group"]:checked').val(),
            CreatedOn: new Date(),
            UpdatedOn: new Date(),
            LockerId: lockerId
        };
        debugger;
        $.ajax({

            type: "POST",
            url: "/Admin/Guardian",
            contentType: "application/json",
            data: JSON.stringify(relationShipModel),
            success: function (response) {
                window.location.href = "/Admin/UpdateLocker?lockerId=" + parseInt(lockerId)+ "&divisionId=" + parseInt(divisionId) + "&locationId=" + parseInt(locatioId);
                
            },
            error: function (xhr, status, error) {
                console.log(error);
            }
        });
    }
    else
    {
        var lockerId = fnGetParameterByName("lockerId");
        var relationShipModel = {
            GuardianName: $(".raltion-model .user-name").val().trim(),
            RelationShip: $('input[name="radio-group"]:checked').val() == "others" ? $('#relation').val() : $('input[name="radio-group"]:checked').val(),
            CreatedOn: new Date(),
            UpdatedOn: new Date(),
            LockerId: lockerId
        };

        $.ajax({

            type: "POST",
            url: "/Admin/Guardian",
            contentType: "application/json",
            data: JSON.stringify(relationShipModel),
            success: function (response) {
                window.location.href = "/Admin/LockerDetails?lockerId=" + parseInt(lockerId);

            },
            error: function (xhr, status, error) {
                console.log(error);
            }
        });
    }

    
}
function fnRemoveItem() {
    $("#removePopup").modal("show");
}
function fnRemoveCancel() {
    $("#removePopup").modal("hide");
}
function fnremoveAllItems() {
    
    
    var lockerId = fnGetParameterByName("lockerId")
    $.ajax({
        type: "POST",
        url: "/Admin/RemoveAllItems?lockerId=" + parseInt(lockerId),
        data: { lockerId: lockerId },
        success: function (response) {
            // handle success
            $("#removePopup").modal("hide");
        
            console.log(response);
        },
        error: function (xhr, status, error) {
            // handle error
            console.log(error);
        }
    });
}
function fnRemoveitem(ctrl) {
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
    //var numItems = $('.item').length;

    $("#add-product").click(function () {
        var numItems = $('.item').length;
        var n = numItems + 1
        if (numItems < 5) {
            $("#products").append('<div class="col-lg-12 mb-3 d-flex align-items-center item"><input type="text" name="product" id= "product-' + n + '"class="form-control"><img src="/images/png/remove.png" class="ml-4 product" alt="remove-product" id="product-' + n + '"  onclick="fnRemoveCurrentItem(this)"></div>');
            n++
        }         
        else if (numItems == 5) {
            $('#add-product').hide();
        }           
        //else {
        //    $('#add-product').show();
        //}
    });
});
function fnUpdateItems() {
    var lockerId = fnGetParameterByName("lockerId");
    
    var itemupdatemodel = {
        LockerId:lockerId,
        Item1:$("#product").val(),
        Item2:$("#product-2").val(),
        Item3:$("#product-3").val(),
        Item4:$("#product-4").val(),
        Item5:$("#product-5").val(),
        ModifiedOn: new Date(),
        ModifiedBy: null,
    };

    $.ajax({

        type: "POST",
        url: "/Admin/UpdateItems?lockerId" + parseInt(lockerId),
        contentType: "application/json",
        data: JSON.stringify(itemupdatemodel),
        success: function (response) {
            if (response != null) {
                window.location.herf = "/Admin/UpdateItems?lockerId" + parseInt(lockerId)
            }

        },
        error: function (xhr, status, error) {
            console.log(error);
        }
    });
}



function fnRemoveCurrentItem(ctrl) {
    $(ctrl.parentElement).remove();
}