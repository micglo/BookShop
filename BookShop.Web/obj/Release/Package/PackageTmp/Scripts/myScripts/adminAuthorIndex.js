//JS do widoku /Areas/Admin/Views/Authors/Index


//Walidacja formy z widoku /Areas/Admin/Views/Authors/CreateModal
$(function () {
    myFormValidation('createAuthorForm');
});


//trigger click wyświetla modal do utworzenia nowego autora /Areas/Admin/Views/Authors/CreateModal
$('#create').on('click', function () {
    $('#createAuthorResult').html('');
    $('.form-group').removeClass('has-error').removeClass('has-success');
    $('#createAuthorFirstName').val('');
    $('#createAuthorLastNameForDisplay').val('');
    $('#createAuthorLastName').val('');
    $('#createAuthorDescription').val('');
    $('#createAuthorModal').modal('show');
});


//trigger click wyświetla modal do edycji autora z pozycji zaznaczonej w tabeli /Areas/Admin/Views/Authors/EditModal
$('#edit').on('click', function () {
    clearAlert();
    var data = table.row('.selected').data();
    if (data === undefined) {
        alert("Nie wybrano żadnego elementu - proszę wybrać wiersz w tabeli, a następnie przejść do właściwej akcji");
    } else {
        var url = '/Admin/Authors/EditModal/' + data[0];

        $.get(url,
            function (modalResult) {
                $('#modalInsert').html(modalResult);
                $('#editAuthorForm').removeData('validator');
                $('#editAuthorForm').removeData('unobtrusiveValidation');
                $.validator.unobtrusive.parse('#editAuthorForm');
                $('#editAuthorModal').modal('show');
            });
    };
});


//trigger click przechodzi do widoku autora /Views/Author/GetAuthor/id
$('#details').on('click', function () {
    clearAlert();
    var data = table.row('.selected').data();
    if (data === undefined) {
        alert("Nie wybrano żadnego elementu - proszę wybrać wiersz w tabeli, a następnie przejść do właściwej akcji");
    } else {
        var url = '/Autor/' + data[0] + '/' + data[1];
        window.location = url;
    };
});


//trigger click wyświetla modal do usunięcia autora z pozycji zaznaczonej w tabeli /Areas/Admin/Views/Authors/DeleteModal
$('#delete').on('click', function () {
    clearAlert();
    var data = table.row('.selected').data();
    if (data === undefined) {
        alert("Nie wybrano żadnego elementu - proszę wybrać wiersz w tabeli, a następnie przejść do właściwej akcji");
    } else {
        var url = '/Admin/Authors/DeleteModal/' + data[0];

        $.get(url,
            function (modalResult) {
                $('#modalInsert').html(modalResult);
                $('#deleteAuthorModal').modal('show');
            });
    };
});


//wyświetla alert o braku wybrania wiersza z tabeli w widoku /Areas/Admin/Views/Authors/Index
function alert(message) {
    $('#alertPlaceholder').html('<div class="row"><div class="col-md-12 text-center"><div class="alert alert-warning alert-dismissible" role="alert"><a class="close" data-dismiss="alert">×</a><span><span class="glyphicon glyphicon glyphicon-exclamation-sign"></span>&nbsp;' + message + '</span></div></div></div>');
};


//czyści alert 
function clearAlert() {
    $('#alertPlaceholder').html('');
};


//wyświetla informacje o utworzeniu nowego autora w modalu /Areas/Admin/Views/Authors/CreateModal
function showCreateAuthorResult(data) {
    $('#createAuthorResult').html(data);
    var url = '/Admin/Authors/IndexPartial';

    $.get(url, updateTable);
}


//wyświetla informacje o edycji autora w modalu /Areas/Admin/Views/Authors/EditModal
function showEditAuthorResult(data) {
    var authorId = $('#authorId').val();
    var url = '/Admin/Authors/GetAuthorData/' + authorId;
    $('#editAuthorResult').html(data);

    $.get(url,
        function (result) {
            $('#authorsTable > tbody > tr.selected > td.text-center > span.authorFirstName').text(result.FirstName);
            $('#authorsTable > tbody > tr.selected > td.text-center > span.authorLastNameForDisplay').text(result.LastNameForDisplay);
        });
}


//wyświetla informacje o usunięciu autora w modalu /Areas/Admin/Views/Authors/DeleteModal
function showDeleteAuthorResult(data) {
    $('#deleteAuthorResult').html(data);
    var url = '/Admin/Authors/IndexPartial';

    $.get(url, updateTable);
}


//przeladowuje widok z tabela 
function updateTable(data) {
    $('#authorsResult').html(data);
}