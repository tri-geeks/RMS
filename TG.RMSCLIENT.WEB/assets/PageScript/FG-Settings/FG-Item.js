var JQItem;
var obj = new Suraya();
var alert = new UIStyle();
//-**********************-- on load--**********************
$(function () {
    //***************Numeric field validation*******************
    obj.NumericValidaton($('#Weight'), $('#Weighterrmsg'));
    obj.NumericValidaton($('#PerCartunQty'), $('#PerCartunQtyerrmsg'));
    obj.NumericValidaton($('#ProductionRatePerMin'), $('#ProductionRatePerMinerrmsg'));

    //***********************Grid Initialization*********************************
    JQItem = $('#JQItem');
    JQItemGrid(JQItem);
    GetAllUser();

    //***************--Save--**********************---------
    $('form').submit(function (e) {
        e.preventDefault();
        //alert($('#ItemGroupName').val())
        var formData = new FormData(this);
        obj.Save({
            url: rootPath + '/FGSettings/FGCreation',
            form: formData
        });
        JQItem.trigger("reloadGrid");

    })

})

//****************--Load Data in control************------
function LoadControll(data) {
    $('#ItemID').val(data.ItemID);
    $('#ItemGroupID').val(data.ItemGroupID);
    $('#ItemName').val(data.ItemName);
    $('#ItemDescription').val(data.ItemDescription);
    $('#Weight').val(data.Weight);
    $('#PerCartunQty').val(data.PerCartunQty);
    $('#ProductionRatePerMin').val(data.ProductionRatePerMin);
}

//--****************************Clear Control--****************************-----
function fNew() {
    obj.RefreshControll();
}

//--******************Retrive All user--*************
function GetAllUser() {
    var data = obj.Getdata({
        url: rootPath + '/FGSettings/GetItemList',
        values: ''
    });
}

//---*********************************** JQ Grid--*****************************************
function JQItemGrid(JQItem) {
    JQItem.jqGrid({
        url: rootPath + '/FGSettings/GetItemList',
        datatype: "json",
        mtype: 'GET',
        colNames: ['Item Id', 'Name', 'Item Group Id', 'G-Name', 'Description', 'W(gm)', 'CQTY', 'P-Rate(Min)', 'Edit|Delete'],
        colModel: [
            { name: 'ItemID', index: 'ItemID', key: true, width: 100,hidden:true },
            { name: 'ItemName', index: 'ItemName', width: 250 },
            { name: 'ItemGroupID', index: 'ItemGroupID', width: 100, hidden: true },
            { name: 'ItemGroupName', index: 'ItemGroupName', width: 70 },
            { name: 'ItemDescription', index: 'ItemDescription', width: 250 },
            { name: 'Weight', index: 'Weight', width: 50 },
            { name: 'PerCartunQty', index: 'PerCartunQty', width: 50 },
            { name: 'ProductionRatePerMin', index: 'ProductionRatePerMin', width: 80 },
            {
                name: 'LinkButton',
                formatter: function (cellvalue, options, rowObject) {
                    return "<a href='#' style='align:center'><span class='glyphicon glyphicon-pencil'  style='color:green'></a>|<a href='#' class='glyphicon glyphicon-trash' style='color:red'></a>";
                }, sortable: false, align: 'left', width: 100, align: "center"
            },
        ],
        sortname: 'ItemID',
        viewrecords: true,
        sortorder: "asc",
        caption: "Item List",
        rowNum: 10,
        height: "auto",
        loadonce: false,
        pager: "#pager",
        beforeSelectRow: function (rowid, e) {
            var selectedRow = JQItem.jqGrid('getRowData', rowid);
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
                var selectedRow = JQItem.jqGrid('getRowData', rowid);
                LoadControll(selectedRow)
                return false;
            }
        }
    });
}