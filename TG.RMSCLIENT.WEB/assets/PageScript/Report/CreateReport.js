var obj = new Suraya();
var JQReportParam;
$(function () {
    ReportMenu();
    $('#demo_menu').easytree();
    $('a').click(function () {        
        var ReportID = $(this).attr('href').replace('#/', '');
        LoadReportMenu(ReportID);
        LoadReportParam(ReportID);
    })
//*****************--JQ Grid--***********************
    GridName = 'JQReportParam';
    Gridfooter = 'JQReportpager';
    ViewControl(true, true, true, true, true, true)
    JQReportParam = $('#JQReportParam')
    JQReportParamList(JQReportParam);

//******************--Change event--*************
    $('#ModuleID').change(function () {
        ModuleChange($('#ModuleID').val());
    });

    //**************--Save--*******************
    $('form').submit(function (e) {
        e.preventDefault();        
        var formdata = new FormData(this);
        var rptChildList = $('#JQReportParam').getRowData();
        obj.addListWithForm(formdata, rptChildList, 'rptChildList');
        obj.Save({
            url: rootPath + '/Report/SaveReport',
            form: formdata
        });

    })
})

//***************-- Clear Control--**************
function fNew() {
    obj.RefreshControll();    
    JQReportParam.jqGrid("clearGridData", true);
}

//**********-- Append Report Menu--*************
function ReportMenu() {
    var data = obj.Getdata({
        url: rootPath + '/Report/GetReportMenu',
        values: {}
    });
    //if (data != 0)
    $('#demo_menu').append(data);
    //else {
    //    //var abc = '@Url.Action("Home","Search")';
    //    var url = rootPath + "/Account/LogOut";
    //    //window.location.href = abc;
    //    window.open(url);
    //}
}


function JQReportParamList(JQReportParam) {
    JQReportParam.jqGrid({
        url: rootPath + '/Report/GetReportParamByReportID',
        postData: { ReportID: '0' },
        datatype: "json",
        mtype: 'GET',
        colNames: ['ParmID', 'ReportID', 'ParmName', 'QueryString', 'Commit|Cancel'],
        colModel: [
            { name: 'ParmID', index: 'ParmID', key: false, width: 100, hidden: true },
            { name: 'ReportID', index: 'ReportID', key: false, width: 100, hidden: true },
            { name: 'ParmName', index: 'ParmName', width: 250, editable: true, align: 'left' },
            { name: 'QueryString', index: 'QueryString', width: 350, editable: true, edittype: 'textarea', align: 'left' },
            {
                name: 'LinkButton',
                formatter: function (cellvalue, options, rowObject) {
                    return "<a href='#' style='align:center'><span class='glyphicon glyphicon-ok'  style='color:green'></a>|<a href='#' class='glyphicon glyphicon-remove' style='color:red'></a>";
                }, sortable: false, align: 'left', width: 100, align: "center"
            },
        ],
        sortname: 'ParmID',
        viewrecords: true,
        sortorder: "asc",
        caption: "Parameter List",
        rowNum: 5,
        height: "100",
        loadonce: false,
        pager: "#JQReportpager",
        footerrow: true,
        userDataOnFooter: true,
        beforeSelectRow: function (rowid, e) {
            var selectedRow = JQReportParam.jqGrid('getRowData', rowid);
            var $self = $(this),
                $td = $(e.target).closest("td"),
                rowid = $td.closest("tr.jqgrow").attr("id"),
                iCol = $.jgrid.getCellIndex($td[0]),
                cm = $self.jqGrid("getGridParam", "colModel");

            if (cm[iCol].name === "LinkButton" && e.target.tagName.toUpperCase() === "A") {
                jQuery('#JQReportParam').jqGrid('restoreRow', rowid)
                return false; // don't select the row on click
            }
            if (cm[iCol].name === "LinkButton" && e.target.tagName.toUpperCase() === "SPAN") {
                //var selectedRow = JQProductionDetails.jqGrid('getRowData', rowid);
                jQuery('#JQReportParam').jqGrid('saveRow', rowid)
                return false;
            }
        },
        
    });
}

//************-- Load Parent ID--*****************
function ModuleChange(ModuleID) {
    obj.loaddropV({
        url: rootPath + '/Report/GetParentByModueID',
        values: { 'ModuleID': ModuleID },
        select: $('#ParentID')
    });
}

//*******************--Load All Control--**********************
function LoadReportMenu(ReportID){
    var data = obj.Getdata({
        url: rootPath + '/Report/GetReportMenuByReportID',
        values: { 'ReportID': ReportID }
    });
    if (data != 'null') {
        $('#ReportID').val(data.ReportID);
        $('#ModuleID').val(data.ModuleID);

        ModuleChange(data.ModuleID);

        $('#ParentID').val(data.ParentID);

        $('#MenuName').val(data.MenuName);
        $('#DisplayName').val(data.DisplayName);
        $('#ReportPath').val(data.ReportPath);

    }
}

function LoadReportParam(ReportId) {
    JQReportParam.setGridParam({ postData: { ReportID: ReportId } });
    JQReportParam.trigger('reloadGrid', [{ ReportID: ReportId }]);
}
//***********************************************************************