//JS dla widoków /Views/Book/GetSingleBook i /Views/Manage/MyReviews


//Dla uruchomienia modala do usunięcia recencji o książce
function openDeleteBookReviewModal(bookReviewId) {
    $('#bookReviewId').val(bookReviewId);
    $('#deleteBookReviewModal').modal();
}


//Dla uruchomienia modala do edycji recencji o książce
function openEditBookReviewModal(bookReviewId, reviewRate) {
    var url = "/BookReview/EditReview?bookReviewId=" + bookReviewId;
    $.get(url,
        function (result) {
            $('#editBookReviewResult').html(result);

            $('.editRatingDiv > img.ratingStar.editVoteStar' + reviewRate).attr("src", "/Images/yellowstar.png").addClass('selected')
                .prevAll("img.ratingStar").attr("src", "/Images/yellowstar.png");

            $('#editBookReviewModal').modal();
            $.validator.unobtrusive.parse("#editBookReviewForm");
        });
}