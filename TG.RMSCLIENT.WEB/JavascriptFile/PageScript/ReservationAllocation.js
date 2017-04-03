var JQReservationAllocationList;
var obj = new Suraya();
var msg = new UIStyle();
$(function () {
    GridName = 'JQReservationAllocationList';
    Gridfooter = 'JQReservationAllocationpager';

    ViewControl(true, true, true, false, false, false)
    JQReservationAllocationList = $('#JQReservationAllocationList');
    ReservationAllocationList(JQReservationAllocationList);


    //****************Submit*********************
    $('form').submit(function () {
        var formdata = new FormData(this);
        var allocationList = $('#JQReservationAllocationList').getRowData();
        formdata.append('datepicker', $('#datepicker').val());
        obj.addListWithForm(formdata, allocationList, 'allocationList');
        obj.Save({
            url: rootPath + '/Reservation/ReservationAllocationC',
            form: formdata
        });
        JQReservationAllocationList.trigger("reloadGrid");
    });

    //***************Load data ****************
    $('#datepicker').change(function () {        
        if ($('#datepicker').val() != null) {
            JQReservationAllocationList.setGridParam({ postData: { allocationDate: $('#datepicker').val() } });
            JQReservationAllocationList.trigger('reloadGrid', [{ allocationDate: $('#datepicker').val() }]);
        }
    });
});

function ReservationAllocationList(JQReservationAllocationList) {
    JQReservationAllocationList.jqGrid({
        url: rootPath + '/Reservation/GetAllocationList',
        postData: { allocationDate: '01/01/9999' },
        mtype: "GET",
        styleUI: 'Bootstrap',
        datatype: "json",
        colModel: [
            { label: 'AllocationID', name: 'AllocationID', key: true, width: 75, hidden: true },            
            {
                label: 'Reservation Type',
                name: 'ReservationTypeID',
                //index: 'QualityID',
                width: 200,
                sortable: true,
                align: 'center',
                editable: true,
                cellEdit: true,
                edittype: 'select',
                formatter: 'select',
                editoptions: {
                    value: obj.JQGridDropDown({
                        url: rootPath + '/Reservation/CboReservationType',
                        values: ''
                    })
                }
            },
            //{ label: 'AllocationDate', name: 'AllocationDate', width: 200, editable: false },
            {
                label: 'Date', name: 'AllocationDate', width: 200,
                editrules: { required: true },
                formatter: 'date',
                formatoptions: {
                    newformat: 'm/d/Y'
                },
                
            },
            { label: 'Start Time', name: 'StartTime', width: 200, editable: false },
            { label: 'End Time', name: 'EndTime', width: 200, editable: false },
            { label: 'Allocation Qty', name: 'AllocationQty', width: 100, editable: true },
            {
                label: 'Commit|Cancel',
                name: 'LinkButton',
                formatter: function (cellvalue, options, rowObject) {
                    return "<a href='#' style='align:center'><span class='glyphicon glyphicon-ok'  style='color:green'></a>|<a href='#' class='glyphicon glyphicon-remove' style='color:red'></a>";
                }, sortable: false, align: 'left', width: 150, align: "center"
            },
        ],
        viewrecords: true,
        height: 200,
        rowNum: 20,
        pager: "#JQReservationAllocationpager",
        beforeSelectRow: function (rowid, e) {
            //var selectedRow = JQMenuListGrid.jqGrid('getRowData', rowid);
            var $self = $(this),
                $td = $(e.target).closest("td"),
                rowid = $td.closest("tr.jqgrow").attr("id"),
                iCol = $.jgrid.getCellIndex($td[0]),
                cm = $self.jqGrid("getGridParam", "colModel");           
            if (cm[iCol].name === "LinkButton" && e.target.tagName.toUpperCase() === "A") {
                JQReservationAllocationList.jqGrid('restoreRow', rowid)
                return false; // don't select the row on click
            }
            if (cm[iCol].name === "LinkButton" && e.target.tagName.toUpperCase() === "SPAN") {
                
                JQReservationAllocationList.jqGrid('saveRow', rowid)
                var AllocationType = JQReservationAllocationList.jqGrid("getCell", rowid, 'ReservationTypeID');
                var data = obj.Getdata({
                    url: rootPath + '/Reservation/GetTimePeriod',
                    values: { 'ReservationTypeID': AllocationType}
                })

                JQReservationAllocationList.jqGrid("setCell", rowid, 'StartTime', data.StartTime);
                JQReservationAllocationList.jqGrid("setCell", rowid, 'EndTime', data.EndTime);
                return false;
            }
        }
    });
}
