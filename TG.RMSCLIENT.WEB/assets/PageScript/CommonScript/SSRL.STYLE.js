function UIStyle() {
    this.loading = function () {
        document.getElementById('modal').style.display = 'block';
        document.getElementById('fade').style.display = 'block';
    };
    this.hideloading = function () {
        setTimeout(function () {
            document.getElementById('modal').style.display = 'none';
            document.getElementById('fade').style.display = 'none';
        }, 1000);

    };
    this.warning = function () {
        document.getElementById('warning').style.display = 'block';
        setTimeout(function () {
            document.getElementById('warning').style.display = 'none';           
        }, 5000);       
    };
    this.success = function () {
        document.getElementById('success').style.display = 'block';
        setTimeout(function () {
            document.getElementById('success').style.display = 'none';
        }, 5000);
    }
    this.error = function () {
        document.getElementById('error').style.display = 'block';
        setTimeout(function () {
            document.getElementById('error').style.display = 'none';
        }, 5000);
    }

    this.FormatDateString = function (object) {
        var dateString = object.substr(6);
        var currentTime = new Date(parseInt(dateString));
        var month = currentTime.getMonth() + 1;
        var day = currentTime.getDate();
        var year = currentTime.getFullYear();
        var date = month + "/" + day + "/" + year;       
        return date;
    }
};