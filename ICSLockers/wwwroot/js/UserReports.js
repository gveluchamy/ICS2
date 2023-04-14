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
        
    });     
});

