//Wyłączą spinner po przejściu do innej zakładki 
$(function () {
    $('.nav-tabs li')
        .click(function () {
            $('#spinner').fadeOut("slow");
        });
});