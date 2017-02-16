//ustawienia dla jquery-ui tooltip
$(function () {
    $(document).tooltip({
        position: {
            my: "center bottom-20",
            at: "center top",
            using: function (position, feedback) {
                $(this).css(position);
                $("<div>")
                  .addClass("arrow")
                  .addClass(feedback.vertical)
                  .addClass(feedback.horizontal)
                  .appendTo(this);
            }
        },
        show: {
            effect: "slideDown",
            delay: 250
        },
        hide: {
            effect: "fade",
            delay: 250
        }
    });
});