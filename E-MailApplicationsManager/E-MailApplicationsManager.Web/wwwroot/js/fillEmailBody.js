//fill email body

$('#email-result').click(function () {

    const emailbody = $('#email-result').val();

    $(this).css('background-color', 'red');
    clicked = false;

    $.ajax({
        url: '/Email/FillEmailBody',
        data: { emailData: emailbody },
        type: 'POST',
        dataType: 'json',
        traditional: true,
        cache: false,
        success: function (result) {
            console.log(result.emailId);
            window.location.href = "/email/checkbody/" + result.emailId;
        }
    });


});

$('#email-invalid').click(function () {

    const emailinvalid = $('#email-invalid').val();

    $(this).css('background-color', 'red');
    clicked = false;

    $.ajax({
        url: '/Email/FillEmailBody',
        data: { setInvalidEmail: emailinvalid },
        type: 'POST',
        dataType: 'json',
        traditional: true,
        cache: false,
        success: function (result) {
            console.log(result);
            window.location.href = "/email/emailinfo/" + result;
        }
    });
});