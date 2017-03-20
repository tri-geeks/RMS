var JQShiftInformation;
var obj = new Suraya();
var alerts = new UIStyle();
//-**********************-- on load--**********************
$(function () {
    JQShiftInformation = $('#JQShiftInformation');    
    JQGetShift(JQShiftInformation);
    GetAllUser();

    //***************--Save--**********************---------
    $('form').submit(function (e) {
        e.preventDefault();
        var formData = new FormData(this);
        obj.Save({
            url: rootPath + '/IMSSetting/AddShiftInformation',
            form: formData
        });
        JQShiftInformation.trigger("reloadGrid");
    });

    $('#search').click(function () {
        Search();        
    });
   
})

//****************--Load Data in control************------
function LoadControll(data) {
    $('#ShiftID').val(data.ShiftID);
    $('#ShiftName').val(data.ShiftName);
    $('#ShiftDescription').val(data.ShiftDescription);
    $('#DurationMIN').val(data.DurationMIN);
}

//--****************************Clear Control--****************************-----
function fNew() {
    obj.RefreshControll();
}

//--******************Retrive All user--*************
function GetAllUser() {
    var data = obj.Getdata({
        url: rootPath + '/IMSSetting/GetShiftInformationList',
        values: ''
    });
}

//---*********************************** JQ Grid--*****************************************
function JQGetShift(JQShiftInformation) {
    JQShiftInformation.jqGrid({
        url: rootPath + '/IMSSetting/GetShiftInformationList',
        datatype: "json",
        mtype: 'GET',
        colNames: ['Shift Id', 'Shift Name', 'Duration', 'Description', 'Edit|Delete'],
        colModel: [
            { name: 'ShiftID', index: 'ShiftID', key: true, width: 100 },
            { name: 'ShiftName', index: 'ShiftName', width: 150 },
            { name: 'DurationMIN', index: 'DurationMIN', width: 250 },
            { name: 'ShiftDescription', index: 'ShiftDescription', width: 250 },            
            {
                name: 'LinkButton',
                formatter: function (cellvalue, options, rowObject) {
                    return "<a href='#' style='align:center'><span class='glyphicon glyphicon-pencil'  style='color:green'></a>|<a href='#' class='glyphicon glyphicon-trash' style='color:red'></a>";
                }, sortable: false, align: 'left', width: 100, align: "center"
            },
        ],
        sortname: 'ShiftID',
        viewrecords: true,
        sortorder: "asc",
        caption: "Shift List",
        rowNum: 500,
        height: "auto",
        loadonce: false,
        height: 250,
        pager: "#pager",
        beforeSelectRow: function (rowid, e) {
            var selectedRow = JQShiftInformation.jqGrid('getRowData', rowid);
            var $self = $(this),
                $td = $(e.target).closest("td"),
                rowid = $td.closest("tr.jqgrow").attr("id"),
                iCol = $.jgrid.getCellIndex($td[0]),
                cm = $self.jqGrid("getGridParam", "colModel");
            if (cm[iCol].name === "LinkButton" && e.target.tagName.toUpperCase() === "A") {
                //DeleteUser(selectedRow.UserID);
                return false; // don't select the row on click
            }
            if (cm[iCol].name === "LinkButton" && e.target.tagName.toUpperCase() === "SPAN") {
                var selectedRow = JQShiftInformation.jqGrid('getRowData', rowid);
                LoadControll(selectedRow)
                return false;
            }
        }
    });
}

function Search() {   
    //var res = obj.loadtableFinder({
    //    url: '/IMSSetting/GetShiftInformationList',
    //    values: '',
    //    ColumnHead: ['Shift Id', 'Shift Name', 'Description'],
    //    ColumnVal: [{ id: 'ShiftID', hidden: true }, { id: 'ShiftName', hidden: false }, { id: 'ShiftDescription',hidden: false }],
    //    CallBackFunction: function (selectedValue) {
    //        alert(selectedValue.ShiftID);
    //    }
    //});
    return false;
}

