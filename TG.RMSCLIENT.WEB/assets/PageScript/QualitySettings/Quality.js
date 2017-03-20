var JQQuality;
var obj = new Suraya();
var alert = new UIStyle();
//-**********************-- on load--**********************
$(function () {
    JQQuality = $('#JQQuality');
    JQGetQuality(JQQuality);
   
    //***************--Save--**********************---------
    $('form').submit(function (e) {
        e.preventDefault();        
        var formData = new FormData(this);
        obj.Save({
            url: '/FGSettings/Quality',
            form: formData
        });
        JQQuality.trigger("reloadGrid");
    })

})

//****************--Load Data in control************------
function LoadControll(data) {
    $('#QualityID').val(data.QualityID);
    $('#QualityName').val(data.QualityName);
    $('#QualityDescription').val(data.QualityDescription);
}

//--****************************Clear Control--****************************-----
function fNew() {
    obj.RefreshControll();
}
//---*********************************** JQ Grid--*****************************************
function JQGetQuality(JQQuality) {
    JQQuality.jqGrid({
        url: '/FGSettings/GetQualityList',
        datatype: "json",
        mtype: 'GET',
        colNames: ['Quality Id', 'Quality', 'Description', 'Edit|Delete'],
        colModel: [
            { name: 'QualityID', index: 'QualityID', key: true, width: 100 },
            { name: 'QualityName', index: 'QualityName', width: 150 },
            { name: 'QualityDescription', index: 'QualityDescription', width: 250 },
            {
                name: 'LinkButton',
                formatter: function (cellvalue, options, rowObject) {
                    return "<a href='#' style='align:center'><span class='glyphicon glyphicon-pencil'  style='color:green'></a>|<a href='#' class='glyphicon glyphicon-trash' style='color:red'></a>";
                }, sortable: false, align: 'left', width: 100, align: "center"
            },
        ],
        sortname: 'QualityID',
        viewrecords: true,
        sortorder: "asc",
        caption: "Quality List",
        rowNum: 10,
        height: "auto",
        loadonce: false,
        pager: "#pager",
        beforeSelectRow: function (rowid, e) {
            var selectedRow = JQQuality.jqGrid('getRowData', rowid);
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
                var selectedRow = JQQuality.jqGrid('getRowData', rowid);
                LoadControll(selectedRow)
                return false;
            }
        }
    });
}