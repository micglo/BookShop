//JS dla widoku /Views/Manage/MyReviews


//update modalu /Views/BookReview/DeleteBookReviewModal o informacje o wykonaniu akcji
function deleteBookReview(data) {
    $('#deleteBookReviewResult').html(data);
    updateBookReviews();
}


//update modalu /Views/BookReview/EditBookReviewModal o informacje o wykonaniu akcji
function editBookReview(data) {
    $('#editBookReviewResult').html(data);
    updateBookReviews();
}


//update widoku /Views/Manage/MyReviews z recenzjami książek po kazdej wykonanej akcji, przeladowanie widoku
function updateBookReviews() {
    var url = "/Manage/GetMyBookReviewsPartial";
    $.get(url,
        function (result) {
            $('#updateMyBookReviews').html(result);
        });
}


//update modalu /Views/AuthorReview/DeleteAuthorReviewModal o informacje o wykonaniu akcji
function deleteAuthorReview(data) {
    $('#deleteAuthorReviewResult').html(data);
    updateAuthorReviews();
}


//update modalu /Views/AuthorReview/EditAuthorReviewModal o informacje o wykonaniu akcji
function editAuthorReview(data) {
    $('#editAuthorReviewResult').html(data);
    updateAuthorReviews();
}


//update widoku /Views/Manage/MyReviews z recenzjami autorów po kazdej wykonanej akcji, przeladowanie widoku
function updateAuthorReviews() {
    var url = "/Manage/GetMyAuthorReviewsPartial";
    $.get(url,
        function (result) {
            $('#updateMyAuthorReviews').html(result);
        });
}


//update modalu /Views/PublishingReview/DeletePublishingReviewModal o informacje o wykonaniu akcji
function deletePublishingReview(data) {
    $('#deletePublishingReviewResult').html(data);
    updatePublishingReviews();
}


//update modalu /Views/PublishingReview/EditPublishingReviewModal o informacje o wykonaniu akcji
function editPublishingReview(data) {
    $('#editPublishingReviewResult').html(data);
    updatePublishingReviews();
}


//update widoku /Views/Manage/MyReviews z recenzjami wydawnictw po kazdej wykonanej akcji, przeladowanie widoku
function updatePublishingReviews() {
    var url = "/Manage/GetMyPublishingReviewsPartial";
    $.get(url,
        function (result) {
            $('#updateMyPublishingReviews').html(result);
        });
}