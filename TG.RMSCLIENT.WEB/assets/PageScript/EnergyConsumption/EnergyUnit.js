var JQEnergyUnit;
var obj = new Suraya();
var msg = new UIStyle();

$(function () {
    GridName = 'JQEnergyUnit';
    Gridfooter = 'EnergyUnitpager';

    ViewControl(true, true, true, false, false, false)
    JQEnergyUnitListGrid = $('#JQEnergyUnit');
    JQEnergyUnitFun(JQEnergyUnitListGrid);


    //****************Submit*********************
    $('form').submit(function () {
        var formdata = new FormData(this);
        var eulist = $('#JQEnergyUnit').getRowData();
        //formdata.append('UserID', $('#UserID').val());
        obj.addListWithForm(formdata, eulist, 'eulist');
        obj.Save({
            url: rootPath + '/EnergyConsumptionSetting/EnergyUnitC',
            form: formdata
        });
        JQEnergyUnitListGrid.trigger("reloadGrid");
    });
});


function JQEnergyUnitFun(JQEnergyUnitListGrid) {

    JQEnergyUnitListGrid.jqGrid({
        url: rootPath + '/EnergyConsumptionSetting/GetUnitOfEnergyList',
        //postData: { swpid: '0' },
        datatype: "json",
        mtype: 'GET',
        colNames: ['PUID', 'PUName', 'Description', 'Commit|Cancel'],
        colModel: [
           { name: 'PUID', index: 'PUID', key: false, width: 100, hidden: true },
           { name: 'PUName', index: 'PUName', key: false, width: 200, hidden: false, editable: true },
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
        caption: "Unit Of Energy",
        rowNum: 5,
        height: "100",
        loadonce: false,
        pager: "#EnergyUnitpager",
        footerrow: true,
        userDataOnFooter: true,
        beforeSelectRow: function (rowid, e) {
            var selectedRow = JQEnergyUnitListGrid.jqGrid('getRowData', rowid);
            var $self = $(this),
                $td = $(e.target).closest("td"),
                rowid = $td.closest("tr.jqgrow").attr("id"),
                iCol = $.jgrid.getCellIndex($td[0]),
                cm = $self.jqGrid("getGridParam", "colModel");

            if (cm[iCol].name === "LinkButton" && e.target.tagName.toUpperCase() === "A") {
                JQEnergyUnitListGrid.jqGrid('restoreRow', rowid)
                return false; // don't select the row on click
            }

            if (cm[iCol].name === "LinkButton" && e.target.tagName.toUpperCase() === "SPAN") {
                JQEnergyUnitListGrid.jqGrid('saveRow', rowid)                
            }
        }

    });
}