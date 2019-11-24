//fill loan form

$('#send-button').on('click', function () {

    const addName = $('#fullname').val();
    const addEGN = $('#egn').val();
    const addPhoneNumber = $('#phone-number').val();
    const gmailId = $('#send-button').val();

    let massege = 'Something went wrong!';

    if (addName.length === 0 || addEGN.length === 0 || addPhoneNumber.length === 0) {
        massege = "The client's details cannot be null!";
    }
    else if (addName.length < 3 || addName.length > 50) {
        massege = "The length of the client's name is not correct!";
    }
    else if (addEGN.length < 10 || addEGN.length > 10) {
        massege = "The client's Egn must be 10 symbols!";
    }
    else if (addPhoneNumber.length < 8 || addPhoneNumber.length > 50) {
        massege = "The length of the client's phone number is not correct!";
    }

    $.ajax({
        url: '/Loan/Loanform',
        data: { userData: addName, egnData: addEGN, phoneData: addPhoneNumber, idData: gmailId },
        type: 'POST',
        dataType: 'json',
        traditional: true,
        cache: false,
        success: function (result) {
            if (result.emailId) {
                Swal.fire({
                    position: 'top-end',
                    icon: 'success',
                    title: 'Your work has been saved',
                    showConfirmButton: false,
                    timer: 1000
                })
                window.setInterval(foo, 1000);
                function foo() {
                    window.location.href = "/home/index/" + result.emailId;
                }
            }
            else if (result.exeption) {
                Swal.fire({
                    icon: 'error',
                    title: 'Oops...',
                    showConfirmButton: true,
                    text: massege
                })
                window.setInterval(errorRequest, 5000);
                function errorRequest() {
                    window.location.href = "/email/fillemailform/" + result.exeption;
                }
            }
        }
    });
});


// Approve Loan 

$('#loan-approve').click(function () {

    const approve = $('#loan-approve').val();

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

$('#loan-approve').click(function () {
    $('#loan-approve').css('background', '#ff6a00');
});

// Reject Loan  

$('#loan-reject').click(function () {

    const reject = $('#loan-reject').val();

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

$('#loan-reject').click(function () {
    $('#loan-reject').css('background', '#ff6a00');
});

