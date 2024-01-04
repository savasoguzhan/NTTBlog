$(document).ready(function () {
    $('#categoriesTable').DataTable({
        dom:
            "<'row'<'col-sm-3'l><'col-sm-6 text-center'B><'col-sm-3'f>>" +
            "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-sm-5'i><'col-sm-7'p>>",
        buttons: [
        ],
        language: {
            "sDecimal": ",",
            "sEmptyTable": "There is no data in the table",
            "sInfo": "Showing records from _START_ to _END_ from _TOTAL_ record",
            "sInfoEmpty": "No record",
            "sInfoFiltered": "(_MAX_ found in the record )",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "Show _MENU_ record on page",
            "sLoadingRecords": "Loading...",
            "sProcessing": "Processing...",
            "sSearch": "Search:",
            "sZeroRecords": "Eşleşen kayıt bulunamadı",
            "oPaginate": {
                "sFirst": "First",
                "sLast": "Last",
                "sNext": "Next",
                "sPrevious": "Previous"
            },
            "oAria": {
                "sSortAscending": ": enable ascending column sorting",
                "sSortDescending": ": enable descending column sorting"
            },
            "select": {
                "rows": {
                    "_": "%d record selected",
                    "0": "",
                    "1": "1 record selected"
                }
            }
        }
    });
});