//Wyświetla info o resultacie w widoku /Views/Manage/ManageLogins
function removeLogins(data) {
    if (data) {
        $('#spinner').fadeIn("fast");
        $('#manageLoginsResult').html(data);
        $('#spinner').fadeOut("slow");
    }
}