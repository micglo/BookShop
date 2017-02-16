//JS dla widoku /Areas/Admin/Views/Books/IndexPartial

//tworzy obiekt dataTable w widoku /Areas/Admin/Views/Books/IndexPartial
var table;
$(function () {
    table = $('#booksTable').DataTable({
        "columnDefs": [
            {
                "targets": [0],
                "visible": false,
                "searchable": false
            },
            {
                "targets": [1],
                "visible": false,
                "searchable": false
            },
            {
                "targets": [2],
                "visible": false,
                "searchable": false
            },
            {
                "targets": [3],
                "visible": false,
                "searchable": false
            }
        ],
        "order": [[3, "asc"]]
    });
});


//umożliwia zaznaczenie wiersza tabeli
$('#booksTable tbody').on('click', 'tr', function () {
    if ($(this).hasClass('selected')) {
        $(this).removeClass('selected');
    } else {
        table.$('tr.selected').removeClass('selected');
        $(this).addClass('selected');
    }
});


//Podwójny click, aby przejsc do widoku autora /Views/Books/GetSingleBook
$('#booksTable tbody')
    .on('dblclick',
    'tr',
    function () {
        $('#spinner').fadeIn("fast");
        var data = table.row(this).data();
        $(this).addClass('selected');

        window.location = '/Produkt/' + '/' + data[0] + '/' + data[1] + '/' + data[3] + '/' + data[2];
    });