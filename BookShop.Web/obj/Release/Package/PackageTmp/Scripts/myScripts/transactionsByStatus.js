//JS dla widoku /Areas/Admin/Views/transactions/GetAllByStatus


//tworzy obiekt dataTable w widoku /Areas/Admin/Views/Transactions/Details
var table;
$(function () {
    table = $('#transactionsTable').DataTable({
        "order": [[0, "desc"]]
    });
});


//umożliwia zaznaczenie wiersza tabeli
$('#transactionsTable tbody')
    .on('click',
        'tr',
        function () {
            if ($(this).hasClass('selected')) {
                $(this).removeClass('selected');
            } else {
                table.$('tr.selected').removeClass('selected');
                $(this).addClass('selected');
            }
        });


//Podwójny click, aby przejsc do widoku transakcji /Areas/Admin/Views/Transactions/Details
$('#transactionsTable tbody')
    .on('dblclick',
        'tr',
        function () {
            $('#spinner').fadeIn("fast");
            var data = table.row(this).data();
            $(this).addClass('selected');
            window.location = '/Admin/Transactions/Details' + '/' + data[0];
        });