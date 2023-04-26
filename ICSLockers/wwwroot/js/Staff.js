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