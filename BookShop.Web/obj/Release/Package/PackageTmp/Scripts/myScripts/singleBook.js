//JS dla widoku /Views/Books/GetSingleBook


//walidacja formy w widoku /Views/BookReview/AddBookReviewModal
$(function () {
    myFormValidation('addBookReviewForm');
});


//Wyświetla informacje w modalu /Views/BookReview/AddBookReviewModal o resultacie wykonanej akcji
function addBookReview(data) {
    $('#addReviewResult').html(data);

    //update widoku /Views/Books/GetSingleBook wyświetla wszystkie recenzje, funkcja w widoku /Views/Books/GetSingleBook
    updateBookReviews();

    //update widoku /Views/Books/GetSingleBook update oceny, funkcja w widoku /Views/Books/GetSingleBook
    updateVotes('addReviewResult');
    $('#addBookReviewButton').attr('disabled', true);
}


//Wyświetla informacje w modalu /Views/BookReview/EditBookReviewModal o resultacie wykonanej akcji
function deleteBookReview(data) {
    $('#deleteBookReviewResult').html(data);
    updateBookReviews();
    updateVotes('deleteBookReviewResult');
}


//Wyświetla informacje w modalu /Views/BookReview/EditBookReviewModal o resultacie wykonanej akcji
function editBookReview(data) {
    $('#editBookReviewResult').html(data);
    updateBookReviews();
    updateVotes('editBookReviewResult');
}