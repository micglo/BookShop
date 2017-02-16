//JS do widoku /Areas/Admin/Transactions/Details

//tworzy obiekt dataTable w widoku /Areas/Admin/Transactions/Details
$(document).ready(function () {
    $('#transactionDetailsTable').DataTable();
});


//trigger click wyświetla modal do zmiany statusu transakcji w widoku /Areas/Admin/Transactions/Details
$('#changeStatusModalButton').click(function () {
    $('#changeStatusModal').modal('show');
});


//resultat zmiany statusu, reload widoku
function showChangeStatusResult(data) {
    var transactionId = $('#transactionId').val();
    var url = '/Admin/Transactions/GetTransactionStatus/' + transactionId;

    $('#changeStatusResult').html(data);

    $.get(url,
        function (result) {
            $('#transactionStatus').text(result);
        });
}