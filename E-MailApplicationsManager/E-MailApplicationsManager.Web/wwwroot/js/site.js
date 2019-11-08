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

    $.get('/email/search?name=' + searchText, serverResponseHandler);
});



const serverHandler = (serverData) => {
    console.log(serverData);
};

$('#send-button').click(function () {
    const addName = $('#fullname').val();
    const addEGN = $('#egn').val();
   // const addPhoneNumber = $('#phone-number').val();
  
    $.get('/email/loanform?name=' + addName, '&egn=' + addEGN, /*'&phoneNumber=' + addPhoneNumber,*/ serverHandler);
});
  /////////////////////////////////////
    //$.ajax({
    //    type: 'GET',
    //    url: 'Email/Loanform',
    //    data: {
    //        AddName: $('#fullname').val(),
    //        AddEGN: $('#egn').val(),
    //        AddPhoneNumber: $('#phone-number').val()
    //    },
    //    cache: false,
    //    success: function (result) {
    //        desc = result;
    //    }
    //});

    //////////////////////////////////////////////////////