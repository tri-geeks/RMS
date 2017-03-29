var JQReservationTypeList;
var obj = new Suraya();
var msg = new UIStyle();
$(function () {
    GridName = 'JQReservationTypeList';
    Gridfooter = 'JQReservationTypepager';

    ViewControl(true, true, true, false, false, false)
    JQReservationTypeList = $('#JQReservationTypeList');
    MenuList(JQReservationTypeList);


    //****************Submit*********************
    $('form').submit(function () {
        var formdata = new FormData(this);
        var rtypelist = $('#JQReservationTypeList').getRowData();
        //formdata.append('UserID', $('#UserID').val());
        obj.addListWithForm(formdata, rtypelist, 'rtypelist');
        obj.Save({
            url: rootPath + '/Settings/ReservationTypeC',
            form: formdata
        });
        JQReservationTypeList.trigger("reloadGrid");
    });
});

function MenuList(JQReservationTypeList) {
    JQReservationTypeList.jqGrid({
        url: rootPath + '/Settings/GetReservationTypeList',
        mtype: "GET",
        styleUI: 'Bootstrap',
        datatype: "json",
        colModel: [
            { label: 'ReservationTypeID', name: 'ReservationTypeID', key: true, width: 75, hidden: true },
            { label: 'TypeName', name: 'TypeName', width: 400, editable: true },
            { label: 'StartTime', name: 'StartTime', width: 200, editable: true },
            //{
            //    label: 'StartTime', name: 'StartTime', width: 200,
            //    editrules: { required: true },
            //    formatter: 'date',
            //    formatoptions: {
            //        newformat: 'd/m/Y H:i:s'
            //    },
            //    editable: true,
            //    editoptions: {
            //        //dataInit: function (el) {
            //        //    //$(el).datetimepicker({});
            //        //    //$(el).datepicker({ dateFormat: 'yy-mm-dd H:i:s' });
                       
            //        //    $(el).datetimepicker({ dateFormat: 'yy-mm-dd H:i:s' })
            //        //}
            //    }
            //},
            { label: 'EndTime', name: 'EndTime', width: 200, editable: true },
            //{
            //    label: 'EndTime', name: 'EndTime', width: 200,
            //    editrules: { required: true },
            //    formatter: 'date',
            //    formatoptions: {
            //        newformat: 'H:i:s'
            //    },
            //    editable: true,
            //    editoptions: {
            //        //dataInit: function (el) {
            //        //    //$(el).datetimepicker({});
            //        //    //$(el).datepicker({ dateFormat: 'yy-mm-dd H:i:s' });

            //        //    $(el).datetimepicker({ dateFormat: 'yy-mm-dd H:i:s' })
            //        //}
            //    }
            //},
            {
                label: 'Commit|Cancel',
                name: 'LinkButton',
                formatter: function (cellvalue, options, rowObject) {
                    return "<a href='#' style='align:center'><span class='glyphicon glyphicon-ok'  style='color:green'></a>|<a href='#' class='glyphicon glyphicon-remove' style='color:red'></a>";
                }, sortable: false, align: 'left', width: 100, align: "center"
            },
        ],
        viewrecords: true,
        height: 200,
        rowNum: 20,
        pager: "#JQReservationTypepager",
        beforeSelectRow: function (rowid, e) {
            //var selectedRow = JQMenuListGrid.jqGrid('getRowData', rowid);
            var $self = $(this),
                $td = $(e.target).closest("td"),
                rowid = $td.closest("tr.jqgrow").attr("id"),
                iCol = $.jgrid.getCellIndex($td[0]),
                cm = $self.jqGrid("getGridParam", "colModel");
            if (cm[iCol].name === "LinkButton" && e.target.tagName.toUpperCase() === "A") {
                JQReservationTypeList.jqGrid('restoreRow', rowid)
                return false; // don't select the row on click
            }
            if (cm[iCol].name === "LinkButton" && e.target.tagName.toUpperCase() === "SPAN") {
                JQReservationTypeList.jqGrid('saveRow', rowid)
                return false;
            }
        }
    });
}