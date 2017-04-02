var JQMenuSubCategoryList;
var obj = new Suraya();
var msg = new UIStyle();
$(function () {
    GridName = 'JQMenuSubCategoryList';
    Gridfooter = 'JQMenuSubCategorypager';

    ViewControl(true, true, true, false, false, false)
    JQMenuSubCategoryList = $('#JQMenuSubCategoryList');
    MenuSubList(JQMenuSubCategoryList);


    //****************Submit*********************
    $('form').submit(function () {
        var formdata = new FormData(this);
        var menuSubCategoryList = $('#JQMenuSubCategoryList').getRowData();
        //formdata.append('UserID', $('#UserID').val());
        obj.addListWithForm(formdata, menuSubCategoryList, 'menuSubCategoryList');
        obj.Save({
            url: rootPath + '/Settings/MenuSubCategoryC',
            form: formdata
        });
        JQMenuSubCategoryList.trigger("reloadGrid");
    });
});

function MenuSubList(JQMenuSubCategoryList) {
    JQMenuSubCategoryList.jqGrid({
        url: rootPath + '/Settings/GetMenuSubCtegoryList',
        mtype: "GET",
        styleUI: 'Bootstrap',
        datatype: "json",
        colModel: [
            { label: 'ID', name: 'SubCategoryID', key: true, width: 75, hidden: true },
            //{ label: 'MCID', name: 'MCID', key: true, width: 75, hidden: true },
            {
                label: 'Category',
                name: 'CategoryID',
                //index: 'QualityID',
                width: 200,
                sortable: true,
                align: 'center',
                editable: true,
                cellEdit: true,
                edittype: 'select',
                formatter: 'select',
                editoptions: {
                    value: obj.JQGridDropDown({
                        url: rootPath + '/Settings/CboMenuCategory',
                        values: ''
                    })
                }
            },
            { label: 'Sub Category', name: 'SubCategoryName', width: 300, editable: true },
            { label: 'Details', name: 'SubCategoryDetails', width: 500, editable: true },
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
        pager: "#JQMenuSubCategorypager",
        beforeSelectRow: function (rowid, e) {
            //var selectedRow = JQMenuListGrid.jqGrid('getRowData', rowid);
            var $self = $(this),
                $td = $(e.target).closest("td"),
                rowid = $td.closest("tr.jqgrow").attr("id"),
                iCol = $.jgrid.getCellIndex($td[0]),
                cm = $self.jqGrid("getGridParam", "colModel");
            if (cm[iCol].name === "LinkButton" && e.target.tagName.toUpperCase() === "A") {
                JQMenuSubCategoryList.jqGrid('restoreRow', rowid)
                return false; // don't select the row on click
            }
            if (cm[iCol].name === "LinkButton" && e.target.tagName.toUpperCase() === "SPAN") {
                JQMenuSubCategoryList.jqGrid('saveRow', rowid)
                return false;
            }
        }
    });
}