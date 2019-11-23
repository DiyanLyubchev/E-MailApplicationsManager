window.onload = function () {
    $.ajax({
        url: '/Home/GetChartData',
        type: 'GET',
        dataType: 'json',
        cache: false,
        success: function (result) {
            console.log(result);
            result = result.filter(element => element.emails.length != 0);
            var ctx = document.getElementById('myChart').getContext('2d');
            new Chart(ctx, {
                type: 'polarArea',
                data: {
                    labels: result.map(element => element.status),  
                    datasets: [{
                        label: 'Email Data',
                        backgroundColor: result.map(element => "#" + ((1 << 24) * Math.random() | 0).toString(16)),
                        borderColor: 'white',
                        data: result.map(element => element.emails.length)
                    }]
                },
                options: {}
            });
        }
    });
};