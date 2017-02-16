//JS dla widoków /Views/Author/GetAuthor i /Views/manage/MyReviews


//Dla uruchomienia modala do usunięcia recencji o autorze
function openDeleteAuthorReviewModal(authorReviewId) {
    $('#authorReviewId').val(authorReviewId);
    $('#deleteAuthorReviewModal').modal();
}


//Dla uruchomienia modala do edycji recencji o autorze
function openEditAuthorReviewModal(authorReviewId, reviewRate) {
    var url = "/AuthorReview/EditReview?authorReviewId=" + authorReviewId;
    $.get(url,
        function (result) {
            $('#editAuthorReviewResult').html(result);

            $('.editRatingDiv > img.ratingStar.editVoteStar' + reviewRate).attr("src", "/Images/yellowstar.png").addClass('selected')
                .prevAll("img.ratingStar").attr("src", "/Images/yellowstar.png");

            $('#editAuthorReviewModal').modal();
            $.validator.unobtrusive.parse("#editAuthorReviewForm");
        });
}