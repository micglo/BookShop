//JS do widoku /Views/Books/GetBooksBySearchString

function updateBooks() {
    $('#spinner').fadeIn("fast");
    var searchString = $('#searchStringHidden').val();
    var searchOption = $('#searchOptionHidden').val();
    var itemsPerPage = $('#itemsPerPageList').val();
    var sortOrder = $('#sortOrderList').val();

    var url = '/Szukaj/' + searchString +
        '/' + searchOption +
        '/1/' + itemsPerPage +
        '/' + sortOrder;
    $.get(url, function (data) {
        $('#books').html(data);
        $('#spinner').fadeOut("slow");
    });
}