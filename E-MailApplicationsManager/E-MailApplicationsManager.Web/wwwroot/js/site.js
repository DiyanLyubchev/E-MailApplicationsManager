//search


$('#search-button').click(function () {
    const searchText = $('#search-email').val();

    $.ajax({
        url: '/email/search?status=' + searchText,
        type: 'GET',
        success: function (serverData) {
            console.log(serverData);

            $('#info-table').remove();
            $('.info-massege').remove();

            const emailContainer = $('#fill-email');

            const tableStart =
                `<table class="table table-bordered" id="info-table"><tr><th scope="col">Number</th><th scope="col">Sender</th><th scope="col">Date Received</th></tr>`;
            const tableEnd = `</table>`;
            const massege = `<div  style="color:#ff6a00" class="info-massege"> We don't have emails with this status!</div>`

            if (serverData === null) {
                emailContainer.append(massege);
            }
            else {
                emailContainer.append(tableStart)
                const emailTable = $('#info-table');
                let count = 1;
                serverData
                    .map(email => $(`<tr scope="row"><td>${count++}</td><td>${email.sender}</td><td>${email.date}</td></tr>`))
                    .forEach(emailElement => {
                        emailTable.append(emailElement);
                    });
                emailContainer.append(tableEnd);
            }
        }
    });
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

    $('#refresh-email').hide('fast');

    $.ajax({
        url: '/Email/RefreshEmails',
        data: { refreshData: refresh },
        type: 'POST',
        dataType: 'json',
        traditional: true,
        cache: false,
        success: function (result) {
            console.log(result);
            window.location.href = "/email/emailinfomanager/" + result.refresh;
        }
    });
});

$('#refresh-email').click( function () {
    $('#refresh-email').css('background', '#ff6a00');
});


//Countinue to work with email status 3

$('.continue-with-email').on('click', function () {
    const currentEmail = $('.continue-with-email').val();

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

$('.continue-with-email').on('click', function () {
    $('.continue-with-email').css('background', '#ff6a00');
});