//JS dla widoku /Areas/Admin/Views/Publishings/IndexPartial

//tworzy obiekt dataTable w widoku /Areas/Admin/Views/Publishings/IndexPartial
var table;
$(function () {
    table = $('#publishingsTable').DataTable({
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
$('#publishingsTable tbody').on('click', 'tr', function () {
    if ($(this).hasClass('selected')) {
        $(this).removeClass('selected');
    } else {
        table.$('tr.selected').removeClass('selected');
        $(this).addClass('selected');
    }
});


//Podwójny click, aby przejsc do widoku autora /Views/Publishing/GetPublishing
$('#publishingsTable tbody')
    .on('dblclick',
    'tr',
    function () {
        $('#spinner').fadeIn("fast");
        var data = table.row(this).data();
        $(this).addClass('selected');
        window.location = '/Wydawnictwo/' + data[1];
    });