var JQBookingList;
var JQBookingSummary;
var obj = new Suraya();
var msg = new UIStyle();
$(function () {
   
    GridName = 'JQBookingList';
    Gridfooter = 'JQBookingpager';

    ViewControl(false, false, false, false, false, false)
    ReservationType();
    ReservationStatus();

    //--------------------------------------
    $('#search').click(function (e) {
        var bookingType = $('#ReservationType').val();
        var bookingDate = $('#datepicker').val();
        var bookingStatus = $('#ReservationStatus').val();


        JQBookingList.setGridParam({ postData: { 'BookingType': bookingType, 'BookingDate': bookingDate, 'BookingStatus': bookingStatus } });

        setTimeout(function () {
            var colSumTotalPices = JQBookingList.jqGrid("getCol", 'BookingQty', false, 'sum');
            JQBookingList.jqGrid('footerData', 'set', { BookingQty: 'Total: ' + colSumTotalPices });

        }, 1000); 
        JQBookingList.trigger('reloadGrid', [{ 'BookingType': bookingType, 'BookingDate': bookingDate, 'BookingStatus': bookingStatus }]);
    });

    
    //------------------------------------

    JQBookingList = $('#JQBookingList');
    MenuList(JQBookingList);  

    //***********************************
    JQBookingSummary = $('#JQBookingSummary');
    BookingSummary(JQBookingSummary);
});

function MenuList(JQBookingList) {
    JQBookingList.jqGrid({
        url: rootPath + '/DashBoard/GetBookingList',
        postData: { 'BookingType': '0', 'BookingDate': '','BookingStatus':'0'},
        mtype: "GET",
        styleUI: 'Bootstrap',
        datatype: "json",
        colModel: [
            { label: 'BookingID', name: 'BookingID', key: true, width: 75, hidden: true },
            { label: 'InvoiceID', name: 'InvoiceID', width: 120, editable: false },
            //{ label: 'BookingDate', name: 'BookingDate', width: 100, editable: false },
            {
                label: 'Booking Date', name: 'BookingDate', width: 100,
                editrules: { required: true },
                formatter: 'date',
                formatoptions: {
                    newformat: 'm/d/Y'
                },

            },
            { label: 'ReservationvType', name: 'ReservationTypeID', width: 100, editable: false, hidden: true },
            { label: 'R-Type', name: 'TypeName', width: 100, editable: false },
            { label: 'Booking-Qty', name: 'BookingQty', width: 120, editable: false },
            { label: 'Start-Time', name: 'StartTime', width: 100, editable: false },            
            { label: 'End-Time', name: 'EndTime', width: 100, editable: false },
            { label: 'Name', name: 'Name', width: 150, editable: false },
            { label: 'Email', name: 'Email', width: 150, editable: false },
            { label: 'Contact', name: 'Contact', width: 150, editable: false },
            { label: 'Remark', name: 'Remark', width: 100, hidden: true },
            { label: 'Booking-Status', name: 'BookingStatus', width: 100, hidden: true },
            { label: 'Status', name: 'StatusName', width: 100, editable: false }
            
        ],
        viewrecords: true,
        height: 400,
        rowNum: 2000,
        pager: "#JQBookingpager",
        footerrow: true,
        userDataOnFooter: true,
        beforeSelectRow: function (rowid, e) {
            //var selectedRow = JQMenuListGrid.jqGrid('getRowData', rowid);
            var $self = $(this),
                $td = $(e.target).closest("td"),
                rowid = $td.closest("tr.jqgrow").attr("id"),
                iCol = $.jgrid.getCellIndex($td[0]),
                cm = $self.jqGrid("getGridParam", "colModel");

            var colSumTotalPices = JQBookingList.jqGrid("getCol", 'BookingQty', false, 'sum'); 
            JQBookingList.jqGrid('footerData', 'set', { BookingQty: 'Total: ' + colSumTotalPices });

            //if (cm[iCol].name === "LinkButton" && e.target.tagName.toUpperCase() === "A") {
            //    JQBookingList.jqGrid('restoreRow', rowid)
            //    return false; // don't select the row on click
            //}
            //if (cm[iCol].name === "LinkButton" && e.target.tagName.toUpperCase() === "SPAN") {
            //    JQBookingList.jqGrid('saveRow', rowid)
            //    return false;
            //}
        },
        
    });
}

function ReservationType() {
    obj.loaddropV({
        url: rootPath + '/DashBoard/GetReservationCategory',
        values: '',
        select: $('#ReservationType')
    });
}

function ReservationStatus() {
    obj.loaddropV({
        url: rootPath + '/DashBoard/GetReservationStatus',
        values: '',
        select: $('#ReservationStatus')
    });
}



function BookingSummary(JQBookingSummary) {
    JQBookingSummary.jqGrid({
        url: rootPath + '/DashBoard/GetBookingSummary',
        //postData: { 'BookingType': '0', 'BookingDate': '', 'BookingStatus': '0' },
        mtype: "GET",
        styleUI: 'Bootstrap',
        datatype: "json",
        colModel: [
            { label: 'Booking Name', name: 'TypeName', key: true, width: 300, hidden: false },
            { label: 'Booking Qty', name: 'BookingQty', width: 250, editable: false },
            { label: 'Status', name: 'StatusName', width: 250, editable: false },
            {
                label: 'Booking Date', name: 'BookingDate', width: 300,
                editrules: { required: true },
                formatter: 'date',
                formatoptions: {
                    newformat: 'm/d/Y'
                },

            }

        ],
        viewrecords: true,
        height: 200,
        rowNum: 500,
        pager: "#JQBookingSummarypager",
        footerrow: true,
        userDataOnFooter: true,
        beforeSelectRow: function (rowid, e) {
            //var selectedRow = JQMenuListGrid.jqGrid('getRowData', rowid);
            var $self = $(this),
                $td = $(e.target).closest("td"),
                rowid = $td.closest("tr.jqgrow").attr("id"),
                iCol = $.jgrid.getCellIndex($td[0]),
                cm = $self.jqGrid("getGridParam", "colModel");

            //var colSumTotalPices = JQBookingSummary.jqGrid("getCol", 'BookingQty', false, 'sum');
            //JQBookingSummary.jqGrid('footerData', 'set', { BookingQty: 'Total: ' + colSumTotalPices });

            //if (cm[iCol].name === "LinkButton" && e.target.tagName.toUpperCase() === "A") {
            //    JQBookingList.jqGrid('restoreRow', rowid)
            //    return false; // don't select the row on click
            //}
            //if (cm[iCol].name === "LinkButton" && e.target.tagName.toUpperCase() === "SPAN") {
            //    JQBookingList.jqGrid('saveRow', rowid)
            //    return false;
            //}
        },

    });
}

var intervalID = setInterval(function () { JQBookingSummary.trigger("reloadGrid");; }, 5000);