//JS do widoku /Views/Books/GetBooksBySubMainCategory

function updateBooks() {
    $('#spinner').fadeIn("fast");
    var mainCategory = $('#currentMainCategory').val();
    var subMainCategory = $('#currentSubMainCategory').val();
    var itemsPerPage = $('#itemsPerPageList').val();
    var sortOrder = $('#sortOrderList').val();

    var url = '/Kategoria/' + mainCategory +
        '/' + subMainCategory +
        '/1/' + itemsPerPage +
        '/' + sortOrder;

    $.get(url, function (data) {
        $('#books').html(data);
        $('#spinner').fadeOut("slow");
    });
}