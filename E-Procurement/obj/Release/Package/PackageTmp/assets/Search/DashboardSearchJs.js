$(document).ready(function () {
    // DataTable
    var dtable = $('#tab_dashbord_opentenders').DataTable();
    $('.filter').on('keyup change', function () {
        //clear global search values
        dtable.search('');
        dtable.column($(this).data('columnIndex')).search(this.value).draw();
    });

    $(".dataTables_filter input").on('keyup change', function () {
        //clear column search values
        dtable.columns().search('');
        //clear input values
        $('.filter').val('');
    });

});
