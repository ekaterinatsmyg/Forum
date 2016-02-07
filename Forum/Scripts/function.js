function OnSuccessLoginAjax(data)
{
    if (data.isValid) {
        $('#error_message_authorize').text('');
        location.replace("/Home/Index");
    }
    else {
        $('#error_message_authorize').text(data.errorMessage);
        return false;
    }

}
function OnSuccessAddMessageAjax(data)
{

}

function DeleteMessageAjax(data)
{

}

function CreateThemeAjax(data) {
    $('#closeAddTheme').click();
}


function UpdateMessageAjax(data) {

}

function showHideEditMessage(id) {
    if ($('#message_' + id).is(":visible")) {
        $('#message_' + id).hide();
        $('#editMessage_' + id).show();      
        $('#textEditMessage_' + id).val($('#message_' + id).text());
    } else {
        $('#message_' + id).show();
        $('#editMessage_' + id).hide();
    }
}

function checkRequiredRegisterField() {
    if ($('#email').val() == '' || $('#login').val() == '' || $('#password').val() == '' || $('#conf_password').val() == '' ||
        $('#email_error').text() != '' || $('#login_error').text() != '' || $('#password_error').text() != '' || $('#conf_password_error').text() != '') {
        $('#error_registration').show();
    } else {
        $('#required_fields').hide();
        $('#not_required_fiels').show();
        $('#required_tab').removeClass('active');
        $('#not_required_tab').addClass('active');
        $('#error_registration').hide();
        $('#registration').show();
        $('#next_step_register').hide();
    }

}