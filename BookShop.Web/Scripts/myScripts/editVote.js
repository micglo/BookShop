//JS dla /Views/Shared/_VoteEditPartial


//zmiana na zlota gwiazdke po najechaniu wskaznikiem na gwiazdke
$(".ratingStar").mouseover(function () {
    $('.ratingStar').attr("src", "/Images/whitestar.png");
    $(this).attr("src", "/Images/yellowstar.png").prevAll("img.ratingStar").attr("src", "/Images/yellowstar.png");
});


//zmiana na biala gwiazdke po opuszczeniu wskaznika myszy a nie kliknieciu
$(".ratingStar").mouseout(function () {
    $('.ratingStar').attr("src", "/Images/whitestar.png");
    $('.ratingStar.selected').attr("src", "/Images/yellowstar.png");
    $('.ratingStar.selected').prevAll("img.ratingStar").attr("src", "/Images/yellowstar.png");
});


//zaznaczenie kliknietej gwiazki i wszyskich poprzednich jako zlote uzupelnienie formularza wartoscia liczbowa
$(".ratingStar").click(function () {
    $(".ratingStar").attr("src", "/Images/whitestar.png").removeClass('selected');
    $(this)
        .addClass('selected')
        .attr("src", "/Images/yellowstar.png")
        .prevAll("img.ratingStar")
        .attr("src", "/Images/yellowstar.png");

    var value = $(this).attr("data-value");
    $('#authoeReviewRateEdit').val(value);
    $('#bookReviewRateEdit').val(value);
    $('#publishingReviewRateEdit').val(value);
});