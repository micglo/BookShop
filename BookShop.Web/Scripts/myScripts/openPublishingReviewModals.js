//JS dla widoków /Views/Publishing/GetPublishing i /Views/Manage/MyReviews


//Dla uruchomienia modala do usunięcia recencji o wydawnictwie
function openDeletePublishingReviewModal(publishingReviewId) {
    $('#publishingReviewId').val(publishingReviewId);
    $('#deletePublishingReviewModal').modal();
}

//Dla uruchomienia modala do edycji recencji o wydawnictwie
function openEditPublishingReviewModal(publishingReviewId, reviewRate) {
    var url = "/PublishingReview/EditReview?publishingReviewId=" + publishingReviewId;
    $.get(url,
        function (result) {
            $('#editPublishingReviewResult').html(result);

            $('.editRatingDiv > img.ratingStar.editVoteStar' + reviewRate).attr("src", "/Images/yellowstar.png").addClass('selected')
                .prevAll("img.ratingStar").attr("src", "/Images/yellowstar.png");

            $('#editPublishingReviewModal').modal();
            $.validator.unobtrusive.parse("#editPublishingReviewForm");
        });
}