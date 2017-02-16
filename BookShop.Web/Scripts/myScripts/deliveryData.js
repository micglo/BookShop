//JS dla widoku /Views/Cart/DeliveryData


//Laduje i ukrywa widok z formularzem do uzupełnienia innego adresu wysyłki
$(document).on("change", ":checkbox", function () {
    var isOtherDeliveryAddress = $('#isOtherDeliveryAddress').prop('checked');

    if (isOtherDeliveryAddress) {
        if ($('#otherDeliveryAddress').hasClass('hidden'))
            $('#otherDeliveryAddress').removeClass('hidden');

        $.get('/Cart/OtherDeliveryAddressPartial', function (data) {
            $('#otherDeliveryAddress').html(data);
            $('#deliveryAddressForm').removeData('validator');
            $('#deliveryAddressForm').removeData('unobtrusiveValidation');
            $.validator.unobtrusive.parse('#deliveryAddressForm');
        });
    } else {
        if (!$('#otherDeliveryAddress').hasClass('hidden'))
            $('#otherDeliveryAddress').addClass('hidden');
    }
});