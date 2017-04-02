var JQMenuCategoryList;
var obj = new Suraya();
var msg = new UIStyle();
$(function () {
    GridName = 'JQMenuCategoryList';
    Gridfooter = 'JQMenuCategorypager';

    ViewControl(true, true, true, false, false, false)
    JQMenuCategoryList = $('#JQMenuCategoryList');
    MenuList(JQMenuCategoryList);


    //****************Submit*********************
    $('form').submit(function () {
        var formdata = new FormData(this);
        var categoryList = $('#JQMenuCategoryList').getRowData();
        //formdata.append('UserID', $('#UserID').val());
        obj.addListWithForm(formdata, categoryList, 'categoryList');
        obj.Save({
            url: rootPath + '/Settings/MenuCategoryC',
            form: formdata
        });
        JQMenuCategoryList.trigger("reloadGrid");
    });
});

function MenuList(JQMenuCategoryList) {
    JQMenuCategoryList.jqGrid({
        url: rootPath+'/Settings/GetMenuCategoryList',
        mtype: "GET",
        styleUI: 'Bootstrap',
        datatype: "json",
        colModel: [
            { label: 'MCID', name: 'MCID', key: true, width: 75, hidden: true },
            { label: 'Category Name', name: 'CategoryName', width: 400, editable: true },
            { label: 'Details', name: 'Details', width: 500, editable: true },            
            {
                label: 'Commit|Cancel',
                name: 'LinkButton',
                formatter: function (cellvalue, options, rowObject) {
                    return "<a href='#' style='align:center'><span class='glyphicon glyphicon-ok'  style='color:green'></a>|<a href='#' class='glyphicon glyphicon-remove' style='color:red'></a>";
                }, sortable: false, align: 'left', width: 100, align: "center"
            },
        ],
        viewrecords: true,
        height: 200,
        rowNum: 20,
        pager: "#JQMenuCategorypager",
        beforeSelectRow: function (rowid, e) {
            //var selectedRow = JQMenuListGrid.jqGrid('getRowData', rowid);
            var $self = $(this),
                $td = $(e.target).closest("td"),
                rowid = $td.closest("tr.jqgrow").attr("id"),
                iCol = $.jgrid.getCellIndex($td[0]),
                cm = $self.jqGrid("getGridParam", "colModel");
            if (cm[iCol].name === "LinkButton" && e.target.tagName.toUpperCase() === "A") {
                JQMenuCategoryList.jqGrid('restoreRow', rowid)
                return false; // don't select the row on click
            }
            if (cm[iCol].name === "LinkButton" && e.target.tagName.toUpperCase() === "SPAN") {
                JQMenuCategoryList.jqGrid('saveRow', rowid)
                return false;
            }
        }
    });
}