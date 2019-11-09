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