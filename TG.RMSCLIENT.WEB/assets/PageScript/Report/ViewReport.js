var obj = new Suraya();
var JQReportParam;
$(function () {
    ReportMenu();
    $('#demo_menu').easytree();

    //*************** Report menu click--**********
    $('a').click(function () {
        var ReportID = $(this).attr('href').replace('#/', '');
        LoadReportMenu(ReportID);
        LoadReportParam(ReportID);
    })

    //*****************--JQ Grid--***********************
    GridName = 'JQReportParam';
    Gridfooter = 'JQReportpager';
    ViewControl(true, false, false, false, false, false)
    JQReportParam = $('#JQReportParam')
    JQReportParamList(JQReportParam);

    //************** Preview Report--**************
    $('form').submit(function (e) {
        e.preventDefault();
        alert($('#ReportPath').val())
        var formdata = new FormData(this);
        var rptchildlist = $('#JQReportParam').getRowData();
        //formdata.append('rpturl', $('#ReportPath').val());
        obj.addListWithForm(formdata, rptchildlist, 'rptchildlist');        
        obj.PostrptParm({
            url: rootPath + '/Report/ViewReport',
            form: formdata,
            rptUrl: $('#ReportPath').val()
        });

    })
    //************** Preview PDF --********************

})

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
        colNames: ['ParmID', 'ReportID', 'Parameter Name', 'QueryString','Parameter Value', 'Commit|Cancel'],
        colModel: [
            { name: 'ParmID', index: 'ParmID', key: false, width: 100, hidden: true },
            { name: 'ReportID', index: 'ReportID', key: false, width: 100, hidden: true },
            { name: 'ParmName', index: 'ParmName', width: 200, editable: false, align: 'left' },
            { name: 'QueryString', index: 'QueryString', width: 450, editable: false, edittype: 'textarea', align: 'left',hidden: true },
            { name: 'ParmVal', index: 'ParmVal', width: 350, editable: true, align: 'left' },
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
        height: "auto",
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
        ondblClickRow: function (rowId, iRow, iCol, e) {
            var selectedRow = JQReportParam.jqGrid('getRowData', rowId);
            var QueryString = JQReportParam.jqGrid("getCell", rowId, 'QueryString');            
            var res = ReportFinder(QueryString, rowId);
        },
        

    });
}

//ondblClickRow: function (rowId, iRow, iCol, e) {
//*******************--Load All Control--**********************
function LoadReportMenu(ReportID) {
    var data = obj.Getdata({
        url: rootPath + '/Report/GetReportMenuByReportID',
        values: { 'ReportID': ReportID }
    });
    if (data != 'null') {    
        $('#ReportPath').val(data.ReportPath);

    }
}

function LoadReportParam(ReportId) {
    JQReportParam.setGridParam({ postData: { ReportID: ReportId } });
    JQReportParam.trigger('reloadGrid', [{ ReportID: ReportId }]);
}

function ReportFinder(queryString, rowId) {   
    var data = obj.loadReportTableFinder({
        url: rootPath + '/Report/GetTableHTML',
        values: { 'sql': queryString },
        CallBackCustomFun: function (Parmval) {            
            JQReportParam.jqGrid("setCell", rowId, 'ParmVal', Parmval);
        }
    });
}