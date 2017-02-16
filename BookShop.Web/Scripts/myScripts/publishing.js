//JS dla widoku /Views/Author/GetAuthor

//walidacja formy w widoku /Views/PublishingReview/AddPublishingReviewModal
$(function () {
    myFormValidation('addPublishingReviewForm');
});


//Wyświetla informacje w modalu /Views/PublishingReview/AddPublishingReviewModal o resultacie wykonanej akcji
function addPublishingReview(data) {
    $('#addPublishingReviewResult').html(data);

    //update widoku /Views/Publishing/GetPublishing wyświetla wszystkie recenzje, funkcja w widoku /Views/Publishing/GetPublishing
    updatePublishingReviews();

    //update widoku /Views/Publishing/GetPublishing update oceny, funkcja w widoku /Views/Publishing/GetPublishing
    updateVotes('addPublishingReviewResult');
    $('#addPublishingReviewButton').attr('disabled', true);
}


//Wyświetla informacje w modalu /Views/PublishingReview/EditPublishingReviewModal o resultacie wykonanej akcji
function deletePublishingReview(data) {
    $('#deletePublishingReviewResult').html(data);
    updatePublishingReviews();
    updateVotes('deletePublishingReviewResult');
}


//Wyświetla informacje w modalu /Views/PublishingReview/DeletePublishingReviewModal o resultacie wykonanej akcji
function editPublishingReview(data) {
    $('#editPublishingReviewResult').html(data);
    updatePublishingReviews();
    updateVotes('editPublishingReviewResult');
}