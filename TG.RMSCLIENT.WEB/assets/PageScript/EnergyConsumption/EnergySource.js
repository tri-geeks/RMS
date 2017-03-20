var JQEnergySource;
var obj = new Suraya();
var msg = new UIStyle();

$(function () {
    GridName = 'JQEnergySource';
    Gridfooter = 'EnergySourcepager';

    ViewControl(true, true, true, false, false, false)
    JQEnergySource = $('#JQEnergySource');
    JQEnergySourceFun(JQEnergySource);


    //****************Submit*********************
    $('form').submit(function () {
        var formdata = new FormData(this);
        var eslist = $('#JQEnergySource').getRowData();
        //formdata.append('UserID', $('#UserID').val());
        obj.addListWithForm(formdata, eslist, 'eslist');
        obj.Save({
            url: rootPath + '/EnergyConsumptionSetting/EnergySourceC',
            form: formdata
        });
        JQEnergySource.trigger("reloadGrid");
    });
});


function JQEnergySourceFun(JQEnergySource) {

    JQEnergySource.jqGrid({
        url: rootPath + '/EnergyConsumptionSetting/GetEnergySurcelist',
        //postData: { swpid: '0' },
        datatype: "json",
        mtype: 'GET',
        colNames: ['ECSID', 'ECSName', 'Description', 'Commit|Cancel'],
        colModel: [
           { name: 'ECSID', index: 'ECSID', key: false, width: 100, hidden: true },
           { name: 'ECSName', index: 'ECSName', key: false, width: 200, hidden: false, editable: true },
           { name: 'Description', index: 'Description', key: false, width: 300, hidden: false, editable: true },
           {
               name: 'LinkButton',
               formatter: function (cellvalue, options, rowObject) {
                   return "<a href='#' style='align:center'><span class='glyphicon glyphicon-ok'  style='color:green'></a>|<a href='#' class='glyphicon glyphicon-remove' style='color:red'></a>";
               }, sortable: false, align: 'left', width: 100, align: "center"
           },
        ],
        sortname: 'PUID',
        viewrecords: true,
        sortorder: "asc",
        caption: "Source Of Energy",
        rowNum: 5,
        height: "100",
        loadonce: false,
        pager: "#EnergySourcepager",
        footerrow: true,
        userDataOnFooter: true,
        beforeSelectRow: function (rowid, e) {
            var selectedRow = JQEnergySource.jqGrid('getRowData', rowid);
            var $self = $(this),
                $td = $(e.target).closest("td"),
                rowid = $td.closest("tr.jqgrow").attr("id"),
                iCol = $.jgrid.getCellIndex($td[0]),
                cm = $self.jqGrid("getGridParam", "colModel");

            if (cm[iCol].name === "LinkButton" && e.target.tagName.toUpperCase() === "A") {
                JQEnergySource.jqGrid('restoreRow', rowid)
                return false; // don't select the row on click
            }

            if (cm[iCol].name === "LinkButton" && e.target.tagName.toUpperCase() === "SPAN") {
                JQEnergySource.jqGrid('saveRow', rowid)
            }
        }

    });
}