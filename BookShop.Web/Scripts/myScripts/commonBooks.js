//JS dla /Views/Books/GetBooksByBookCategory /Views/Books/GetBooksBySearchString /Views/Books/GetBooksBySubMainCategory
//updateBooks() zależnie od widoku w plikach: updateBooksByBookCategory.js updateBooksBySearchString.js updateBooksBySubMainCategory.js


//przeladowuje widok zaleznie od wyboru z select listy
$('#itemsPerPageList')
            .on('change',
                function () {
                    updateBooks();
                });

//przeladowuje widok zaleznie od wyboru z select listy
$('#sortOrderList')
    .on('change',
        function () {
            updateBooks();
        });

//przeladowuje widok zaleznie od wyboru strony (stronicowanie)
$(document).on("click", "#contentPager a[href]", function () {
    $('#spinner').fadeIn("fast");
    $.ajax({
        url: $(this).attr("href"),
        type: 'GET',
        cache: false,
        success: function (data) {
            $('#books').html(data);
            $('#spinner').fadeOut("slow");
        }
    });
    return false;
});