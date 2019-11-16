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



// change status

$('#change-email-status').click(function () {
    const statusId = $('#change-email').val();
    const gmailId = $('#change-email-status').val();

    $.ajax({
        url: '/Email/ChangeEmailStatus',
        data: { statusData: statusId, idData: gmailId },
        type: 'POST',
        dataType: 'json',
        traditional: true,
        cache: false,
        success: function (result) {
            console.log(result);
            window.location.href = "/email/emailinfomanager/" + result;
        }
    });
});


// refresh button for new emails

$('#refresh-email').click(function () {
    const refresh = $('#refresh-email').val();

    $(this).css('#refresh-email', 'red').val();
    clicked = false;

    $.ajax({
        url: '/Email/RefreshEmails',
        data: { refreshData: refresh},
        type: 'POST',
        dataType: 'json',
        traditional: true,
        cache: false,
        success: function (result) {
           
        }
    });
});


//Countinue to work with email status 3

$('#continue-with-email').on('click', function () {
    const currentEmail = $('#continue-with-email').val();

    $.ajax({
        url: '/Email/ContinueWithEmmail',
        data: { currentEmailId: currentEmail },
        type: 'POST',
        dataType: 'json',
        traditional: true,
        cache: false,
        success: function (result) {
            console.log(result);
            window.location.href = "/email/fillemailform/" + result.emailId;
        }
    });
});