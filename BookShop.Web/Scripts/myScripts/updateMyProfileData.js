//JS do widoku /Views/Manage/UpdateMyProfileData


//Sprawdza czy jest zaznaczony checkbox
$(function () {
    checkIfCompany();
});

$('#isCompany')
    .on('change', function () {
        checkIfCompany();
    });


//Laduje i ukrywa widok /Views/Manage/UpdateMyProfileCompanyData w zaleznosci od zaznaczonego checkboxa
function checkIfCompany() {
    var isCompany = $('#isCompany').prop('checked');

    if (isCompany) {
        if ($('#companyData').hasClass('hidden'))
            $('#companyData').removeClass('hidden');

        $.get('/Manage/UpdateMyProfileCompanyData', function (data) {
            $('#companyData').html(data);
            $('#updateMyProfileDataForm').removeData('validator');
            $('#updateMyProfileDataForm').removeData('unobtrusiveValidation');
            $.validator.unobtrusive.parse('#updateMyProfileDataForm');
        });
    } else {
        if (!$('#companyData').hasClass('hidden'))
            $('#companyData').addClass('hidden');
    }
}