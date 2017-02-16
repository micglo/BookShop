//JS do widoku /Views/Books/GetBooksByBookCategory

function updateBooks() {
    $('#spinner').fadeIn("fast");
    var mainCategory = $('#currentMainCategory').val();
    var subMainCategory = $('#currentSubMainCategory').val();
    var bookCategory = $('#currentBookCategory').val();
    var itemsPerPage = $('#itemsPerPageList').val();
    var sortOrder = $('#sortOrderList').val();

    var url = '/Kategoria/' + mainCategory +
        '/' + subMainCategory +
        '/' + bookCategory +
        '/1/' + itemsPerPage +
        '/' + sortOrder;

    $.get(url, function (data) {
        $('#books').html(data);
        $('#spinner').fadeOut("slow");
    });
}