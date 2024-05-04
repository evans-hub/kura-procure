$(document).ready(function () {
    // DataTable
    var dtable = $('#table_opentenders').DataTable();
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
//$(document).ready(function () {

//    // DataTable
//    var dtable = $('#example').DataTable();

//    $('.filter-button').on('click', function () {
//        //clear global search values
//        dtable.search('');
//        $('.filter').each(function () {
//            if (this.value.length) {
//                dtable.column($(this).data('columnIndex')).search(this.value);
//            }
//        });
//        dtable.draw();
//    });

//    $(".dataTables_filter input").on('keyup change', function () {
//        //clear column search values
//        dtable.columns().search('');
//        //clear input values
//        $('.filter').val('');
//    });

//});