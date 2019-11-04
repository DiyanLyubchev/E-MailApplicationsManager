const serverResponseHandler = (serverData) => {
    console.log(serverData);

    $('.info-word').remove();

    const teamContainer = $('#fill-email');

    serverData
        .map(email => $(`<div class="info-word"> ${email.sender}   ${email.dateReceived}  ${email.status}</div>`))
        .forEach(teamElement => {
            teamContainer.append(teamElement);
        });

};

$('#search-text').on('keyup', function() {
    console.log($(this).val());
});

$('#search-button').click(function() {
    const searchText = $('#search-text').val();

    $.get('/email/search?name=' + searchText, serverResponseHandler);
});
