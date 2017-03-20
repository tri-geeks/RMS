var JQFurnace;
var obj = new Suraya();
var alert = new UIStyle();
//-**********************-- on load--**********************
$(function () {
    JQFurnace = $('#JQFurnace');
    JQGetFurnace(JQFurnace);   

    //***************--Save--**********************---------
    $('form').submit(function (e) {
        e.preventDefault();
        //alert($('#ItemGroupName').val())
        var formData = new FormData(this);
        obj.Save({
            url: rootPath + '/FurnaceSettings/Furnace',
            form: formData
        });
        JQFurnace.trigger("reloadGrid");

    })

})

//****************--Load Data in control************------
function LoadControll(data) {
    $('#FurID').val(data.FurID);
    $('#FurName').val(data.FurName);
    $('#Description').val(data.Description);
}

//--****************************Clear Control--****************************-----
function fNew() {
    obj.RefreshControll();
}

//---*********************************** JQ Grid--*****************************************
function JQGetFurnace(JQFurnace) {
    JQFurnace.jqGrid({
        url: rootPath + '/FurnaceSettings/GetFurnaceList',
        datatype: "json",
        mtype: 'GET',
        colNames: ['Furnace Id', 'Furnace Name', 'Description', 'Edit|Delete'],
        colModel: [
            { name: 'FurID', index: 'FurID', key: true, width: 100 },
            { name: 'FurName', index: 'FurName', width: 150 },
            { name: 'Description', index: 'Description', width: 250 },
            {
                name: 'LinkButton',
                formatter: function (cellvalue, options, rowObject) {
                    return "<a href='#' style='align:center'><span class='glyphicon glyphicon-pencil'  style='color:green'></a>|<a href='#' class='glyphicon glyphicon-trash' style='color:red'></a>";
                }, sortable: false, align: 'left', width: 100, align: "center"
            },
        ],
        sortname: 'FurID',
        viewrecords: true,
        sortorder: "asc",
        caption: "Furnace List",
        rowNum: 10,
        height: "auto",
        loadonce: false,
        pager: "#pager",
        beforeSelectRow: function (rowid, e) {
            var selectedRow = JQFurnace.jqGrid('getRowData', rowid);
            var $self = $(this),
                $td = $(e.target).closest("td"),
                rowid = $td.closest("tr.jqgrow").attr("id"),
                iCol = $.jgrid.getCellIndex($td[0]),
                cm = $self.jqGrid("getGridParam", "colModel");
            if (cm[iCol].name === "LinkButton" && e.target.tagName.toUpperCase() === "A") {                
                return false; // don't select the row on click
            }
            if (cm[iCol].name === "LinkButton" && e.target.tagName.toUpperCase() === "SPAN") {
                var selectedRow = JQFurnace.jqGrid('getRowData', rowid);
                LoadControll(selectedRow)
                return false;
            }
        }
    });
}