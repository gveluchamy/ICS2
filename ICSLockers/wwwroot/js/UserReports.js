$(document).ready(function () {

    //$('#UserReportTable').DataTable();
    $('#UserReportTable').DataTable({
        dom: 'Bfrtip',
        buttons: [
            'excel', 'pdf'
        ],
        "bLengthChange": true,
        "paging": true,
        "pageLength": 25,
        'colReorder': {
            'allowReorder': false
        },
        "order": [[0, 'asc']],
        "search": {
            "search": ""
        },
        "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
        "bInfo": false,
        "pagingType": 'full_numbers',
        "pageLength": 25,
        "language": {
            "oPaginate": {
                "sNext": '<i class="fa-solid fa-angle-right"></i>',
                "sPrevious": '<i class="fa-solid fa-angle-left"></i>',
                "sFirst": '<i class="fa-solid fa-angle-left"></i>',
                "sLast": '<i class="fa-solid fa-angle-right"></i>'
            }
        },

        fixedColumns: true,
    });
    $('.dataTables_filter input').addClass('search');
});
$(document).ready(function () {

    //$('#UserReportTable').DataTable();
    $('#AdminReportTable').DataTable({
        dom: 'Bfrtip',
        buttons: [
            'excel', 'pdf'
        ],
        "bLengthChange": true,
        "paging": true,
        "pageLength": 25,
        'colReorder': {
            'allowReorder': false
        },
        "order": [[0, 'asc']],
        "search": {
            "search": ""
        },
        "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
        "bInfo": false,
        "pagingType": 'full_numbers',
        "pageLength": 25,
        "language": {
            "oPaginate": {
                "sNext": '<i class="fa-solid fa-angle-right"></i>',
                "sPrevious": '<i class="fa-solid fa-angle-left"></i>',
                "sFirst": '<i class="fa-solid fa-angle-left"></i>',
                "sLast": '<i class="fa-solid fa-angle-right"></i>'
            }
        },

        fixedColumns: true,
    });
    $('.dataTables_filter input').addClass('search');
});
$(document).ready(function () {

    //$('#UserReportTable').DataTable();
    $('#sessiontable').DataTable({
        dom: 'Bfrtip',
        buttons: [
            'excel', 'pdf'
        ],
        "bLengthChange": true,
        "paging": true,
        "pageLength": 25,
        'colReorder': {
            'allowReorder': false
        },
        "order": [[0, 'asc']],
        "search": {
            "search": ""
        },
        "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
        "bInfo": false,
        "pagingType": 'full_numbers',
        "pageLength": 25,
        "language": {
            "oPaginate": {
                "sNext": '<i class="fa-solid fa-angle-right"></i>',
                "sPrevious": '<i class="fa-solid fa-angle-left"></i>',
                "sFirst": '<i class="fa-solid fa-angle-left"></i>',
                "sLast": '<i class="fa-solid fa-angle-right"></i>'
            }
        },

        fixedColumns: true,
    });
    $('.dataTables_filter input').addClass('search');
});

$(document).ready(function () {

    //$('#UserReportTable').DataTable();
    $('#StaffReportTable').DataTable({
        dom: 'Bfrtip',
        buttons: [
            'excel', 'pdf'
        ],
        "bLengthChange": true,
        "paging": true,
        "pageLength": 25,
        'colReorder': {
            'allowReorder': false
        },
        "order": [[0, 'asc']],
        "search": {
            "search": ""
        },
        "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
        "bInfo": false,
        "pagingType": 'full_numbers',
        "pageLength": 25,
        "language": {
            "oPaginate": {
                "sNext": '<i class="fa-solid fa-angle-right"></i>',
                "sPrevious": '<i class="fa-solid fa-angle-left"></i>',
                "sFirst": '<i class="fa-solid fa-angle-left"></i>',
                "sLast": '<i class="fa-solid fa-angle-right"></i>'
            }
        },

        fixedColumns: true,
    });
    $('.dataTables_filter input').addClass('search');
});
$(document).ready(function () {

    $('#LockerReportTable').DataTable({
        dom: 'Bfrtip',
        buttons: [
            'excel', 'pdf'
        ],
        "bLengthChange": true,
        "paging": true,
        "pageLength": 25,
        'colReorder': {
            'allowReorder': false
        },
        "order": [[0, 'asc']],
        "search": {
            "search": ""
        },
        "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
        "bInfo": false,
        "pagingType": 'full_numbers',
        "pageLength": 25,
        "language": {
            "oPaginate": {
                "sNext": '<i class="fa-solid fa-angle-right"></i>',
                "sPrevious": '<i class="fa-solid fa-angle-left"></i>',
                "sFirst": '<i class="fa-solid fa-angle-left"></i>',
                "sLast": '<i class="fa-solid fa-angle-right"></i>'
            }
        },

        fixedColumns: true,
    });
    $('.dataTables_filter input').addClass('search');
});

$("#getvalue").click(function () {
    var role = $(".role.active").text().trim();
    debugger;
    $.ajax({
        url: '/Admin/Index',
        type: 'POST',
        dataType: 'html',
        data: { role: role },
        success: function (html) {
            // Update container element with view page HTML
           // window.location.href = '/Admin/Index' + '/' + '?viewid=' + viewid;

            window.location.href = '/Admin/Index?role=' + encodeURIComponent(role);
            $('#container').html(html);
        },
        error: function (xhr) {
            console.error(xhr);
        }
    });
});

$("#getvalues").click(function () {
    var role = $(".role.active").text().trim();
    debugger;
    $.ajax({
        url: '/Admin/Index',
        type: 'POST',
        dataType: 'html',
        data: { role: role },
        success: function (html) {
            // Update container element with view page HTML
            // window.location.href = '/Admin/Index' + '/' + '?viewid=' + viewid;

            window.location.href = '/Admin/Index?role=' + encodeURIComponent(role);
            $('#container').html(html);
        },
        error: function (xhr) {
            console.error(xhr);
        }
    });
});