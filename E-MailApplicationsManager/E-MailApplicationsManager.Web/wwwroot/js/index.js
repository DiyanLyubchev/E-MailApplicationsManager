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
                    labels: result.map(element => element.status),
                    datasets: [{
                        label: 'My First dataset',
                        backgroundColor: result.map(element => {
                            var colorNumber = 255 - 255 / (element.id + 1);
                            return `rgb(${255},${colorNumber},${colorNumber})`
                        }),
                        borderColor: result.map(element => {
                            var colorNumber = 255 - 255 / (element.id + 1);
                            return `rgb(${255},${colorNumber},${colorNumber})`
                        }),
                        data: result.map(element => element.emails.length)
                    }]
                },
                options: {}
            });
        }
    });
};