//JS do widoku /Areas/Admin/Views/Transactions/Index


//trigger click przechodzi do widoku transakcji /Areas/Admin/Views/Transactions/Details
$('#details').on('click', function () {
    clearAlert();
    var data = table.row('.selected').data();
    if (data === undefined) {
        alert("Nie wybrano żadnego elementu - proszę wybrać wiersz w tabeli, a następnie przejść do właściwej akcji");
    } else {
        $('#spinner').fadeIn('fast');
        window.location = '/Admin/Transactions/Details/' + data[0];
    };
});


//trigger click laduje modal do zmiany statusu transakcji /Areas/Admin/Views/Transactions/ChangeStatus
$('#changeStatus').on('click', function () {
    clearAlert();
    var data = table.row('.selected').data();
    if (data === undefined) {
        alert("Nie wybrano żadnego elementu - proszę wybrać wiersz w tabeli, a następnie przejść do właściwej akcji");
    } else {
        var transactionId = data[0];
        var url = '/Admin/Transactions/ChangeStatus/' + transactionId;

        $.get(url,
            function (modalResult) {
                $('#changeStatusModalInsert').html(modalResult);
                $('#changeStatusModal').modal('show');
            });
    };
});


//reload tabeli pod względem wybranego statusu
$('#selectStatusList').on('change',
    function () {
        $('#spinner').fadeIn('fast');
        var status = $('#selectStatusList').val();
        var url = '/Admin/Transactions/GetAllByStatus?status=' + status;

        $.get(url,
            function (data) {
                $('#transactions').html(data);
                $('#spinner').fadeOut('fast');
            });
    });


function alert(message) {
    $('#alertPlaceholder').html('<div class="row"><div class="col-md-12 text-center"><div class="alert alert-warning alert-dismissible" role="alert"><a class="close" data-dismiss="alert">×</a><span><span class="glyphicon glyphicon glyphicon-exclamation-sign"></span>&nbsp;' + message + '</span></div></div></div>');
};

function clearAlert() {
    $('#alertPlaceholder').html('');
};


//update statusu transakcji w tabeli
function showChangeStatusResult(data) {
    var transactionId = $('#transactionId').val();
    var url = '/Admin/Transactions/GetTransactionStatus/' + transactionId;

    $('#changeStatusResult').html(data);

    $.get(url,
        function (result) {
            $('#transactionsTable > tbody > tr.selected > td.text-center > span.transactionStatus').text(result);
        });
}