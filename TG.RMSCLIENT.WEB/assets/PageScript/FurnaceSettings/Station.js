var JQStation;
var obj = new Suraya();
var alert = new UIStyle();
//-**********************-- on load--**********************
$(function () {
    JQStation = $('#JQStation');
    JQGetStation(JQStation);

    //***************--Save--**********************---------
    $('form').submit(function (e) {
        e.preventDefault();        
        var formData = new FormData(this);
        obj.Save({
            url: rootPath + '/FurnaceSettings/Station',
            form: formData
        });       
        JQStation.trigger("reloadGrid");

    })

})

//****************--Load Data in control************------
function LoadControll(data) {
    $('#StationID').val(data.StationID);
    $('#FurID').val(data.FurID);
    $('#StationName').val(data.StationName);
    $('#StationDescription').val(data.StationDescription);
}

//--****************************Clear Control--****************************-----
function fNew() {
    obj.RefreshControll();
}

//---*********************************** JQ Grid--*****************************************
function JQGetStation(JQStation) {
    JQStation.jqGrid({
        url: rootPath + '/FurnaceSettings/GetStationList',
        datatype: "json",
        mtype: 'GET',
        colNames: ['Station Id','FurID', 'Furnace', 'Station','Description', 'Edit|Delete'],
        colModel: [
            { name: 'StationID', index: 'StationID', key: true, width: 100 },
            { name: 'FurID', index: 'FurID', width: 150, hidden: true },
            { name: 'FurName', index: 'FurName', width: 150},
            { name: 'StationName', index: 'StationName', width: 150},
            { name: 'StationDescription', index: 'StationDescription', width: 250 },
            {
                name: 'LinkButton',
                formatter: function (cellvalue, options, rowObject) {
                    return "<a href='#' style='align:center'><span class='glyphicon glyphicon-pencil'  style='color:green'></a>|<a href='#' class='glyphicon glyphicon-trash' style='color:red'></a>";
                }, sortable: false, align: 'left', width: 100, align: "center"
            },
        ],
        sortname: 'StationID',
        viewrecords: true,
        sortorder: "asc",
        caption: "Station List",
        rowNum: 10,
        height: "auto",
        loadonce: false,
        pager: "#pager",
        beforeSelectRow: function (rowid, e) {
            var selectedRow = JQStation.jqGrid('getRowData', rowid);
            var $self = $(this),
                $td = $(e.target).closest("td"),
                rowid = $td.closest("tr.jqgrow").attr("id"),
                iCol = $.jgrid.getCellIndex($td[0]),
                cm = $self.jqGrid("getGridParam", "colModel");
            if (cm[iCol].name === "LinkButton" && e.target.tagName.toUpperCase() === "A") {
                return false; // don't select the row on click
            }
            if (cm[iCol].name === "LinkButton" && e.target.tagName.toUpperCase() === "SPAN") {
                var selectedRow = JQStation.jqGrid('getRowData', rowid);
                LoadControll(selectedRow)
                return false;
            }
        }
    });
}