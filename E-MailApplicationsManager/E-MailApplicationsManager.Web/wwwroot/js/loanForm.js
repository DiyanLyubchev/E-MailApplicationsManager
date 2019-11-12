//fill loan form

$('#send-button').on('click', function () {

    const addName = $('#fullname').val();
    const addEGN = $('#egn').val();
    const addPhoneNumber = $('#phone-number').val();
    const gmailId = $('#send-button').val();

    $.ajax({
        url: '/Loan/Loanform',
        data: { userData: addName, egnData: addEGN, phoneData: addPhoneNumber, idData: gmailId },
        type: 'POST',
        dataType: 'json',
        traditional: true,
        cache: false,
        success: function (result) {
            console.log(result);
            window.location.href = "/home/index/" + result.emailId;           
        }
    });

});


// See boby before setting status "New"

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

   
// Approve Loan 

$('#loan-approve').click(function () {

    const approve = $('#loan-approve').val();

    $(this).css('background-color', 'red');
    clicked = false;

    $.ajax({
        url: '/Loan/ApproveLoan',
        data: { approveData: approve },
        type: 'POST',
        dataType: 'json',
        traditional: true,
        cache: false,
        success: function (result) {
            console.log(result);
            window.location.href = "/home/index/" + result.emailId;
        }
    });
});


// Reject Loan  

$('#loan-reject').click(function () {

    const reject = $('#loan-reject').val();

    $(this).css('background-color', 'red');
    clicked = false;

    $.ajax({
        url: '/Loan/ApproveLoan',
        data: { rejectData: reject },
        type: 'POST',
        dataType: 'json',
        traditional: true,
        cache: false,
        success: function (result) {
            console.log(result);
            window.location.href = "/home/index/" + result.emailId;
        }
    });
});