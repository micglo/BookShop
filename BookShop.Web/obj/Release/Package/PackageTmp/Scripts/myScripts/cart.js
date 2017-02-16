//JS dla widoku /Views/Cart/Index

//update widoku /Views/Cart/Index
function updateCart(data) {
    if (data) {
        $('#spinner').fadeIn("fast");
        $("#cart").html(data);

        //update widoku modala /Views/Cart/CartModal
        $.get('/Cart/ModalIndex',
            function(result) {
                $('#cartModalResult').html(result);
            });

        $('#spinner').fadeOut("slow");

        //update ilości przedmiotów, funkcja w common.js
        updateCartCount();
    }
}


//update ilości przedmiotów w widoku /Views/Cart/Index
function updateCartQuantity(bookId, returnUrl, event) {
    var currentTarget = $(event.currentTarget);

    var currentValue = currentTarget.val();

    var url = '/Cart/UpdateCartQuantity?bookId=' + bookId + '&returnUrl=' + returnUrl + '&quantity=' + currentValue;
    $.get(url, updateCart);
}


//Ustawia metode wysyłki 
function setDeliveryMethod(event) {
    var currentTarget = $(event.currentTarget);

    var isChecked = currentTarget.prop('checked');

    if (isChecked) {
        var deliveryType = currentTarget.val();
        var returnUrl = $('#returnUrl').val();
        var url = '/Cart/SetDeliveryMethod?delivery=' + deliveryType + '&returnUrl=' + returnUrl;
        $.get(url, updateCart);
    };
}


//Ustawia metode płatności 
function setPayMentMethod(event) {
    var currentTarget = $(event.currentTarget);

    var isChecked = currentTarget.prop('checked');

    if (isChecked) {
        var returnUrl = $('#returnUrl').val();
        var paymentMethod = currentTarget.val();
        var url = '/Cart/SetPaymentMethod?payment=' + paymentMethod + '&returnUrl=' + returnUrl;
        $.get(url, updateCart);
    };
}