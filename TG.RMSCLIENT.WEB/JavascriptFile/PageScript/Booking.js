var obj = new Suraya();
var msg = new UIStyle();

$(function () {
    RservationType();

    $('#ReservationTypeID').change(function () {
        var reservationType = $('#ReservationTypeID').val();
        GetTime(reservationType);
    })
    $('#datepicker').on('changeDate', function (ev) {
        $(this).datepicker('hide');
    });
    $('#BookingQty').blur(function () {
        var BookingDate = $('#datepicker').val();
        var reservationType = $('#ReservationTypeID').val();
        var BookingQty = $('#BookingQty').val();
        var data = obj.Getdata({
            url: rootPath + '/Home/CheckAvailability',
            values: { 'Qty': BookingQty, 'BookingDate': BookingDate, 'BookingType': reservationType}
        });
        if (data == 0) {
            msg.message('No availabe site');            
           // $('#BookingQty').focus();
        }
        else if (data == 2) {
            msg.message('No available reservation allocation in this date');            
            //$('#BookingQty').focus();
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
                if (data != 0 && data != 2)
                    window.open('https://www.youtube.com/results?search_query=tumi+andhar+dekho');
                else if (data == 0)
                    msg.message('No availabe site');    
                else if (data == 2)
                    msg.message('No available reservation allocation in this date');   

                //window.location.href(rootPath + '/Home/Index');
                
            },
            error: function () {
                msg.hideloading();
            }
        })
        
    });

    //Rating  Option
     /*
         * Create time 11.45 PM 4/9/17
         * Created By : Mithu
         */
    $('#fContact').submit(function () {
        var formdata = new FormData(this);
        //obj.Save({
        //    url: rootPath + '/Home/SaveBooking',
        //    form: formdata
        //});
        msg.loading();
        $.ajax({
            url: rootPath + '/Home/SaveRatings',
            type: 'POST',
            data: formdata,
            contentType: false,       // The content type used when sending data to the server.
            cache: false,             // To unable request pages to be cached
            processData: false,
            async: false,
            success: function (data) {
                msg.hideloading();

               
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




