//search
const serverResponseHandler = (serverData) => {
    console.log(serverData);

    $('.info-email').remove();

    const teamContainer = $('#fill-email');

    serverData
        .map(email => $(`<div class="info-email"> ${email.sender}   ${email.dateReceived}  ${email.emailStatusId}</div>`))
        .forEach(teamElement => {
            teamContainer.append(teamElement);
        });

};

$('#search-email').on('keyup', function () {
    console.log($(this).val());
});

$('#search-button').click(function () {
    const searchText = $('#search-email').val();

    $.get('/email/search?status=' + searchText, serverResponseHandler);
});


//fill loan form

$('#send-button').click(function () {
    const addName = $('#fullname').val();
    const addEGN = $('#egn').val();
    const addPhoneNumber = $('#phone-number').val();
    $.ajax({
        url: '/Email/Loanform',
        data: { userData: addName, egnData: addEGN, phoneData: addPhoneNumber },
        type: 'POST',
        dataType: 'json',
        traditional: true,
        cache: false,
        success: function (result) {

        }
    });
});

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
            window.location.href = "/email/fillemailform/" + result.emailId;
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
            console.log(result.emailId);
            window.location.href = "/email/emailinfo/" + result.emailId;
        }
    });
});