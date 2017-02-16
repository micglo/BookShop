//JS dla widoku /Views/Shared/_Layout(czyli wszedzie)

$(function () {
    var menu = $("#menu-search");
    $(window).scroll(function () {
        if ($(this).scrollTop() === 0) {
            if (menu.hasClass('navbar-fixed-top')) {
                menu.removeClass('navbar-fixed-top')
                    .addClass('navbar-static-top');
            }
        }
        else if ($(this).scrollTop() > 100) {
            if (!menu.hasClass('navbar-fixed-top') && menu.hasClass('navbar-static-top')) {
                menu.removeClass('navbar-static-top')
                    .addClass('navbar-fixed-top');
            }
        }
    });

    $('#cartIcon').click(function () {
        $('#cartModal').modal('show');
    });

    $('a').not('.paginate_button').click(function () {
        $('#spinner').fadeIn("fast");
    });

    $('#searchButton').click(function () {
        $('#spinner').fadeIn("fast");
    });

    updateCartCount();
});


//Update wyświetlania przedmiotów w koszyku
function updateCartCount() {
    $.get('/Cart/GetTotalItem', function (data) {
        $('#cartCount').text(data);
    });
}


//akcja dodania produktu do koszyka
function addToCart(bookId) {
    $('#spinner').fadeIn("fast");
    var url = '/Cart/AddToCart?bookId=' + bookId;
    $.get(url, updateCartModal);
}


//update widoku modala koszyka
function updateCartModal(data) {
    if (data) {
        $("#cartModalResult").html(data);
        
        var returnUrl = $('#returnUrl').val();
        $.get('/Cart/IndexPartial?returnUrl=' + returnUrl,
            function(result) {
                $("#cart").html(result);
            });

        $.get('/Cart/SummaryPartial',
            function (result) {
                $("#summaryResult").html(result);
            });

        $('#spinner').fadeOut("slow");

        updateCartCount();
    }
}


//update ilosci produktu w widoku modala koszyka
function updateCartModalQuantity(bookId, event) {
    var currentTarget = $(event.currentTarget);

    var currentValue = currentTarget.val();

    var url = '/Cart/UpdateCartModalQuantity?bookId=' + bookId + '&quantity=' + currentValue;
    $.get(url, updateCartModal);
}

//funkcja wyświetla resultat akcji dla widoków w /Views/Account i /Views/Manage
function showMessage(data) {
    if (data) {
        $('#spinner').fadeIn("fast");
        $('#message').html(data);
        $('#spinner').fadeOut("slow");
    }
}


//wyświetla czerwona/zielona ramke po walidacji formy
function myFormValidation(formId) {
    var form = $('#' + formId);
    var formData = $.data(form[0]);
    var settings = formData.validator.settings;
    var oldErrorPlacement = settings.errorPlacement;
    var oldSuccess = settings.success;

    settings.errorPlacement = function (label, element) {
        oldErrorPlacement(label, element);

        label.parents('.form-group').addClass('has-error');
        label.addClass('text-danger');
    };

    settings.success = function (label) {
        label.parents('.form-group').removeClass('has-error').addClass('has-success');
        oldSuccess(label);
    };
}