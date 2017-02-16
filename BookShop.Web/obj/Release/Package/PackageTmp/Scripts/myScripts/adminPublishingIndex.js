//JS dla widoku /Areas/Admin/Views/Publishings/Index

//Walidacja formy dla widoku tworzenia nowego wydawnictwa /Areas/Admin/Views/Publishings/CreateModal
$(function () {
    myFormValidation('createPublishingForm');
});


//trigger click wyświetla modal do utworzenia nowego wydawnictwa /Areas/Admin/Views/Publishings/CreateModal
$('#create').on('click', function () {
    $('#createPublishingResult').html('');
    $('.form-group').removeClass('has-error').removeClass('has-success');
    $('#createPublishingName').val('');
    $('#createPublishingNameForDisplay').val('');
    $('#createPublishingImage').val('');
    $('#createPublishingDescription').val('');
    $('#createPublishingModal').modal('show');
});


//trigger click wyświetla modal do edycji wydawnictwa /Areas/Admin/Views/Publishings/EditModal
$('#edit').on('click', function () {
    clearAlert();
    var data = table.row('.selected').data();
    if (data === undefined) {
        alert("Nie wybrano żadnego elementu - proszę wybrać wiersz w tabeli, a następnie przejść do właściwej akcji");
    } else {
        var url = '/Admin/Publishings/EditModal/' + data[0];

        $.get(url,
            function (modalResult) {
                $('#modalInsert').html(modalResult);
                $('#editPublishingForm').removeData('validator');
                $('#editPublishingForm').removeData('unobtrusiveValidation');
                $.validator.unobtrusive.parse('#editPublishingForm');
                $('#editPublishingModal').modal('show');
            });
    };
});


//trigger click przejście do widoku z informacjami o wydawnictwie /Views/Publishings/GetPublishing/id
$('#details').on('click', function () {
    clearAlert();
    var data = table.row('.selected').data();
    if (data === undefined) {
        alert("Nie wybrano żadnego elementu - proszę wybrać wiersz w tabeli, a następnie przejść do właściwej akcji");
    } else {
        var url = '/Wydawnictwo/' + data[1];
        window.location = url;
    };
});


//trigger click wyświetla modal do usunięcia wydawnictwa /Areas/Admin/Views/Publishings/DeleteModal
$('#delete').on('click', function () {
    clearAlert();
    var data = table.row('.selected').data();
    if (data === undefined) {
        alert("Nie wybrano żadnego elementu - proszę wybrać wiersz w tabeli, a następnie przejść do właściwej akcji");
    } else {
        var url = '/Admin/Publishings/DeleteModal/' + data[0];

        $.get(url,
            function (modalResult) {
                $('#modalInsert').html(modalResult);
                $('#deletePublishingModal').modal('show');
            });
    };
});


//wyświetla alert o braku wybrania wiersza z tabeli w widoku /Areas/Admin/Views/Publishings/Index
function alert(message) {
    $('#alertPlaceholder').html('<div class="row"><div class="col-md-12 text-center"><div class="alert alert-warning alert-dismissible" role="alert"><a class="close" data-dismiss="alert">×</a><span><span class="glyphicon glyphicon glyphicon-exclamation-sign"></span>&nbsp;' + message + '</span></div></div></div>');
};


//czyści alert 
function clearAlert() {
    $('#alertPlaceholder').html('');
};


//wyświetla informacje o utworzeniu nowego wydawnictwa w modalu /Areas/Admin/Views/Publishings/CreateModal
function showCreatePublishingResult(data) {
    $('#createPublishingResult').html(data);
    var url = '/Admin/Publishings/IndexPartial';

    $.get(url, updateTable);
}


//wyświetla informacje o edycji wydawnictwa w modalu /Areas/Admin/Views/Publishings/EditModal
function showEditPublishingResult(data) {
    var publishingId = $('#publishingId').val();
    var url = '/Admin/Publishings/GetPublishingData/' + publishingId;
    $('#editPublishingResult').html(data);

    $.get(url,
        function (result) {
            $('#publishingsTable > tbody > tr.selected > td.text-center > span.publishingNameForDisplay').text(result.NameForDisplay);
        });
}


//wyświetla informacje o usunięciu wydawnictwa w modalu /Areas/Admin/Views/Publishings/DeleteModal
function showDeletePublishingResult(data) {
    $('#deletePublishingResult').html(data);
    var url = '/Admin/Publishings/IndexPartial';

    $.get(url, updateTable);
}


//przeladowuje widok z tabela 
function updateTable(data) {
    $('#publishingResult').html(data);
}