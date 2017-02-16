//tworzy obiekt dataTable w widoku /Areas/Admin/Views/Authors/IndexPartial
var table;
$(function () {
    table = $('#authorsTable').DataTable({
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
                }
        ],
        "order": [[0, "asc"]]
    });
});


//umożliwia zaznaczenie wiersza tabeli
$('#authorsTable tbody').on('click', 'tr', function () {
    if ($(this).hasClass('selected')) {
        $(this).removeClass('selected');
    } else {
        table.$('tr.selected').removeClass('selected');
        $(this).addClass('selected');
    }
});


//Podwójny click, aby przejsc do widoku autora /Views/Author/GetAuthor/id
$('#authorsTable tbody')
    .on('dblclick',
    'tr',
    function () {
        $('#spinner').fadeIn("fast");
        var data = table.row(this).data();
        $(this).addClass('selected');
        window.location = '/Autor/' + '/' + data[0] + '/' + data[1];
    });