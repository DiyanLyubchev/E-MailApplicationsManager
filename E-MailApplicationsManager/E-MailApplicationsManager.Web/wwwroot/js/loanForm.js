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
            Swal.fire({
                position: 'top-end',
                icon: 'success',
                title: 'Your work has been saved',
                showConfirmButton: false,
                timer: 1500
            })
            window.setInterval(foo, 500);
            function foo() {
                window.location.href = "/home/index/success" + result.emailId;
            }
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

