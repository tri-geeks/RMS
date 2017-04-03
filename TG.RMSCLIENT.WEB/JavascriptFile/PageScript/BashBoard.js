var JQBookingList;
var obj = new Suraya();
var msg = new UIStyle();
$(function () {
    //GridName = 'JQReservationTypeList';
    //Gridfooter = 'JQReservationTypepager';

    //ViewControl(true, true, true, false, false, false)
    JQBookingList = $('#JQBookingList');
    MenuList(JQBookingList);
});

function MenuList(JQBookingList) {
    JQBookingList.jqGrid({
        url: rootPath + '/DashBoard/GetBookingList',
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
            { label: 'BookingvQty', name: 'BookingQty', width: 100, editable: false },
            { label: 'StartvTime', name: 'StartTime', width: 100, editable: false },            
            { label: 'EndvTime', name: 'EndTime', width: 100, editable: false },
            { label: 'Name', name: 'Name', width: 150, editable: false },
            { label: 'Email', name: 'Email', width: 100, editable: false },
            { label: 'Contact', name: 'Contact', width: 100, editable: false },
            { label: 'Remark', name: 'Remark', width: 100, hidden: true },
            { label: 'BookingvStatus', name: 'BookingStatus', width: 100, hidden: true },
            { label: 'Status', name: 'StatusName', width: 100, editable: false }
            
        ],
        viewrecords: true,
        height: 200,
        rowNum: 20,
        pager: "#JQBookingpager",
        beforeSelectRow: function (rowid, e) {
            //var selectedRow = JQMenuListGrid.jqGrid('getRowData', rowid);
            var $self = $(this),
                $td = $(e.target).closest("td"),
                rowid = $td.closest("tr.jqgrow").attr("id"),
                iCol = $.jgrid.getCellIndex($td[0]),
                cm = $self.jqGrid("getGridParam", "colModel");
            if (cm[iCol].name === "LinkButton" && e.target.tagName.toUpperCase() === "A") {
                JQBookingList.jqGrid('restoreRow', rowid)
                return false; // don't select the row on click
            }
            if (cm[iCol].name === "LinkButton" && e.target.tagName.toUpperCase() === "SPAN") {
                JQBookingList.jqGrid('saveRow', rowid)
                return false;
            }
        }
    });
}