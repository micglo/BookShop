//JS dla widoku /Areas/Admin/Views/Books/Index

//trigger click na przejście do widoku tworzenia nowej książki /Areas/Admin/Views/Books/Create
$('#create').on('click', function () {
    window.location = '/Admin/Books/Create';
});


//trigger click z pozycji zaznaczonej w tabeli na przejście do widoku edycji książki /Areas/Admin/Views/Books/Edit
$('#edit').on('click', function () {
    clearAlert();
    var data = table.row('.selected').data();
    if (data === undefined) {
        alert("Nie wybrano żadnego elementu - proszę wybrać wiersz w tabeli, a następnie przejść do właściwej akcji");
    } else {
        window.location = '/Admin/Books/Edit/' + data[3];
    };
});


//trigger click z pozycji zaznaczonej w tabeli na przejście do widoku książki /Views/Books/GetSingleBook
$('#details').on('click', function () {
    clearAlert();
    var data = table.row('.selected').data();
    if (data === undefined) {
        alert("Nie wybrano żadnego elementu - proszę wybrać wiersz w tabeli, a następnie przejść do właściwej akcji");
    } else {
        window.location = '/Produkt/' + '/' + data[0] + '/' + data[1] + '/' + data[3] + '/' + data[2];
    };
});


//trigger click z pozycji zaznaczonej w tabeli na modal do usunięcia książki /Areas/Admin/Views/Books/DeleteModal
$('#delete').on('click', function () {
    clearAlert();
    var data = table.row('.selected').data();
    if (data === undefined) {
        alert("Nie wybrano żadnego elementu - proszę wybrać wiersz w tabeli, a następnie przejść do właściwej akcji");
    } else {
        var url = '/Admin/Books/DeleteModal/' + data[3];

        $.get(url,
            function (modalResult) {
                $('#modalInsert').html(modalResult);
                $('#deleteBookModal').modal('show');
            });
    };
});


//trigger click z pozycji zaznaczonej w tabeli na ustawienie książki jako bestseller 
$('#setBestseller').on('click', function () {
    clearAlert();
    var data = table.row('.selected').data();
    if (data === undefined) {
        alert("Nie wybrano żadnego elementu - proszę wybrać wiersz w tabeli, a następnie przejść do właściwej akcji");
    } else {
        var url = '/Admin/Books/SetBestseller/' + data[3];

        $.get(url,
            function () {
                var result = '<span class="glyphicon glyphicon-ok" style="color: green"></span>';
                $('#booksTable > tbody > tr.selected > td.text-center.bestsellerResult').html(result);
            });
    };
});


//trigger click z pozycji zaznaczonej w tabeli na usunięcie książki z pozycji bestsellerów
$('#removeBestseller').on('click', function () {
    clearAlert();
    var data = table.row('.selected').data();
    if (data === undefined) {
        alert("Nie wybrano żadnego elementu - proszę wybrać wiersz w tabeli, a następnie przejść do właściwej akcji");
    } else {
        var url = '/Admin/Books/RemoveBestseller/' + data[3];

        $.get(url,
            function () {
                var result = '<span class="glyphicon glyphicon-remove" style="color: #8b0000"></span>';
                $('#booksTable > tbody > tr.selected > td.text-center.bestsellerResult').html(result);
            });
    };
});


//wyświetla alert z informacja o braku zaznaczenia wiersza tabeli
function alert(message) {
    $('#alertPlaceholder').html('<div class="row"><div class="col-md-12 text-center"><div class="alert alert-warning alert-dismissible" role="alert"><a class="close" data-dismiss="alert">×</a><span><span class="glyphicon glyphicon glyphicon-exclamation-sign"></span>&nbsp;' + message + '</span></div></div></div>');
};


//czyści alert
function clearAlert() {
    $('#alertPlaceholder').html('');
};


//wyświetla informacje o usunięciu ksiązki w modalu /Areas/Admin/Views/Books/DeleteModal
function showDeleteBookResult(data) {
    $('#deleteBookResult').html(data);
    var url = '/Admin/Books/IndexPartial';

    $.get(url, updateTable);
}


//przeladowuje widok z tabela 
function updateTable(data) {
    $('#booksResult').html(data);
}