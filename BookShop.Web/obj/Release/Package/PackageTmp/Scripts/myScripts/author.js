//JS dla widoku /Views/Author/GetAuthor

//walidacja formy w widoku /Views/AuthorReview/AddAuthorReviewModal
$(function () {
    myFormValidation('addAuthorReviewForm');
});


//Wyświetla informacje w modalu /Views/AuthorReview/AddAuthorReviewModal o resultacie wykonanej akcji
function addAuthorReview(data) {
    $('#addReviewResult').html(data);

    //update widoku /Views/Author/GetAuthor wyświetla wszystkie recenzje, funkcja w widoku /Views/Author/GetAuthor
    updateAuthorReviews();

    //update widoku /Views/Author/GetAuthor update oceny, funkcja w widoku /Views/Author/GetAuthor
    updateVotes('addReviewResult');
    $('#addAuthorReviewButton').attr('disabled', true);
}


//Wyświetla informacje w modalu /Views/AuthorReview/EditAuthorReviewModal o resultacie wykonanej akcji
function editAuthorReview(data) {
    $('#editAuthorReviewResult').html(data);
    updateAuthorReviews();
    updateVotes('editAuthorReviewResult');
}


//Wyświetla informacje w modalu /Views/AuthorReview/DeleteAuthorReviewModal o resultacie wykonanej akcji
function deleteAuthorReview(data) {
    $('#deleteAuthorReviewResult').html(data);
    updateAuthorReviews();
    updateVotes('deleteAuthorReviewResult');
}