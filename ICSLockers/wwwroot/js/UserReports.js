﻿$(document).ready(function () {

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
        pagingType: 'full_numbers',
        pageLength: 10,
        language: {
            oPaginate: {
                sNext: '<i class="fa-solid fa-angle-right"></i>',
                sPrevious: '<i class="fa-solid fa-angle-left"></i>',
                sFirst: '<i class="fa-solid fa-angles-left"></i>',
                sLast: '<i class="fa-solid fa-angles-right"></i>'
            }
        },

        fixedColumns: true,
    });  
    $('.dataTables_filter input').addClass('search');
});


