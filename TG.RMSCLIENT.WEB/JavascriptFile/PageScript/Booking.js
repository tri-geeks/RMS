var obj = new Suraya();
var msg = new UIStyle();

$(function () {
    RservationType();

    $('#ReservationTypeID').change(function () {
        var reservationType = $('#ReservationTypeID').val();
        GetTime(reservationType);
    })

    $('#BookingQty').blur(function () {
        var BookingDate = $('#datepicker').val();
        var reservationType = $('#ReservationTypeID').val();
        var BookingQty = $('#BookingQty').val();
        var data = obj.Getdata({
            url: rootPath + '/Home/CheckAvailability',
            values: { 'Qty': BookingQty, 'BookingDate': BookingDate, 'BookingType': reservationType}
        });
        if (data == 0) {
            alert('No available sit')
            $('#BookingQty').focus();
        }
            //obj.TGModal("No availabe reservation")


    });

    $('#formR').submit(function () {
        var formdata = new FormData(this); 
        //obj.Save({
        //    url: rootPath + '/Home/SaveBooking',
        //    form: formdata
        //});
        msg.loading();
        $.ajax({
            url: rootPath + '/Home/SaveBooking',
            type: 'POST',
            data: formdata,
            contentType: false,       // The content type used when sending data to the server.
            cache: false,             // To unable request pages to be cached
            processData: false,
            async: false,
            success: function (data) {
                msg.hideloading();
                
                window.location.href(rootPath + '/Home/Index');
                window.open('https://www.youtube.com/results?search_query=tumi+andhar+dekho');
            },
            error: function () {
                msg.hideloading();
            }
        })
        
    });
});


function RservationType() {
    obj.loaddropV({
        url: rootPath + '/Home/CboReservationType',
        values: '',
        select: $('#ReservationTypeID')
    });
}

function GetTime(reservationType) {
    var data = obj.Getdata({
        url: rootPath + '/Home/GetTime',
        values: { 'reservationType': reservationType}        
    });

    $('#StartTime').val(data.StartTime);
    $('#EndTime').val(data.EndTime);
}




