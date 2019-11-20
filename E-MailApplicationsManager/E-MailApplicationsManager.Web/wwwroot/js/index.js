window.onload = function () {
    $.ajax({
        url: '/Home/GetChartData',
        type: 'GET',
        dataType: 'json',
        cache: false,
        success: function (result) {
            console.log(result);
            var ctx = document.getElementById('myChart').getContext('2d');
            new Chart(ctx, {
                type: 'polarArea',
                data: {
                    labels: result.email.map(element => element.EmailStatus),  
                    datasets: [{
                        label: 'My First dataset',
                        backgroundColor: result.element.map(element => {
                            var colorNumber = 255 - 255 / (element.id + 1);
                            return `rgb(${255},${colorNumber},${colorNumber})`
                        }),
                        borderColor: result.element.map(element => {
                            var colorNumber = 255 - 255 / (element.id + 1);
                            return `rgb(${255},${colorNumber},${colorNumber})`
                        }),
                        data: result.emails.map(element => element.emails.StatusId)
                    }]
                },
                options: {}
            });
        }
    });
};