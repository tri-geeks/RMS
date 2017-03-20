var JQItemGroup;
var obj = new Suraya();
var alert = new UIStyle();
//-**********************-- on load--**********************
$(function () {   
    JQItemGroup = $('#JQItemGroup');
    JQGetItemGroup(JQItemGroup);
    GetAllUser();

    //***************--Save--**********************---------
    $('form').submit(function (e) {
        e.preventDefault();
        //alert($('#ItemGroupName').val())
        var formData = new FormData(this);
        obj.Save({
            url: rootPath +'/FGSettings/FGCategory',
            form: formData
        });
        JQItemGroup.trigger("reloadGrid");

    })

})

//****************--Load Data in control************------
function LoadControll(data) {
    $('#ItemGroupID').val(data.ItemGroupID);
    $('#ItemGroupName').val(data.ItemGroupName);
    $('#ItemGroupDescription').val(data.ItemGroupDescription);
}

//--****************************Clear Control--****************************-----
function fNew() {
    obj.RefreshControll();
}

//--******************Retrive All user--*************
function GetAllUser() {
    var data = obj.Getdata({
        url: rootPath + '/FGSettings/GetItmGrouplist',
        values: ''
    });
}

//---*********************************** JQ Grid--*****************************************
function JQGetItemGroup(JQItemGroup) {
    JQItemGroup.jqGrid({
        url: rootPath + '/FGSettings/GetItmGrouplist',
        datatype: "json",
        mtype: 'GET',
        colNames: ['Item Group Id', 'Item Group Name', 'Description', 'Edit|Delete'],
        colModel: [
            { name: 'ItemGroupID', index: 'ItemGroupID', key: true, width: 100 },
            { name: 'ItemGroupName', index: 'ItemGroupName', width: 150 },
            { name: 'ItemGroupDescription', index: 'ItemGroupDescription', width: 250 },
            {
                name: 'LinkButton',
                formatter: function (cellvalue, options, rowObject) {
                    return "<a href='#' style='align:center'><span class='glyphicon glyphicon-pencil'  style='color:green'></a>|<a href='#' class='glyphicon glyphicon-trash' style='color:red'></a>";
                }, sortable: false, align: 'left', width: 100, align: "center"
            },
        ],
        sortname: 'ItemGroupID',
        viewrecords: true,
        sortorder: "asc",
        caption: "Item Group List",
        rowNum: 10,
        height: "auto",
        loadonce: false,
        pager: "#pager",
        beforeSelectRow: function (rowid, e) {
            var selectedRow = JQItemGroup.jqGrid('getRowData', rowid);
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
                var selectedRow = JQItemGroup.jqGrid('getRowData', rowid);
                LoadControll(selectedRow)
                return false;
            }
        }
    });
}