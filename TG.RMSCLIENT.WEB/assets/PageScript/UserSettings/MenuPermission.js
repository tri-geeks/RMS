var JQMenuListGrid;
var obj = new Suraya();
var msg = new UIStyle();
$(function () {
    //****************JQGrid*************
    GridName = 'JQMenuPermissionList';
    Gridfooter = 'Menupager';
    //edit = true;
    //add = false;
    //del = false;
    ViewControl(true, false, false, false, false, false)
    JQMenuListGrid = $('#JQMenuPermissionList');
    //JQMenuList(JQMenuListGrid);
    
    //****************Submit*********************
    $('form').submit(function () {        
        var formdata = new FormData(this);
        var menulist = $('#JQMenuPermissionList').getRowData();
        formdata.append('UserID', $('#UserID').val());
        obj.addListWithForm(formdata, menulist, 'menuList'); 
        obj.Save({
            url: rootPath + '/UserSettings/MenuPermissionS',
            form: formdata
        });
        JQMenuListGrid.trigger("reloadGrid");
    });
    //***************Leave Event********************   
    $('#UserID').change(function () {
        var userid = $('#UserID').val();       
        $("#JQMenuPermissionList").setGridParam({ postData: { id: userid } });
        $("#JQMenuPermissionList").trigger('reloadGrid', [{ id: userid }]);
    })
    JQMenuList(JQMenuListGrid);

});
$(window).triggerHandler('resize.jqGrid');
function JQMenuList(JQMenuListGrid) {
    JQMenuListGrid.jqGrid({
        url: rootPath + '/UserSettings/GetMenuList',
        postData: { id: '0' },
        datatype: "json",
        mtype: 'GET',
        colNames: ['PermissionID', 'UserID', 'MenuID', 'MenuName', 'DisplayName', 'Authorization', 'Commit|Cancel'],
        colModel: [
            { name: 'PermissionID', index: 'PermissionID', width: 100, hidden: true },
            { name: 'UserID', index: 'UserID', width: 150, hidden: true },
            { name: 'MenuID', index: 'MenuID', width: 250, key: true, hidden: true },
            { name: 'MenuName', index: 'MenuName', width: 250, hidden: true },
            { name: 'DisplayName', index: 'DisplayName', width: 250 },
            {
                name: 'Authorization', index: 'Authorization', width: 250,
                sortable: true,
                align: 'center',
                editable: true,
                cellEdit: true,
                edittype: 'select',
                formatter: 'select',
                editoptions: { value: getAllSelectOptions() }
            },
            {
                name: 'LinkButton',
                formatter: function (cellvalue, options, rowObject) {
                    return "<a href='#' style='align:center'><span class='glyphicon glyphicon-ok'  style='color:green'></a>|<a href='#' class='glyphicon glyphicon-remove' style='color:red'></a>";
                }, sortable: false, align: 'left', width: 100, align: "center"
            },
            
        ],
        sortname: 'PermissionID',
        viewrecords: true,
        sortorder: "asc",
        caption: "Menu List",
        rowNum: 500,
        //rowList: [10, 20, 30],
        altRows: true,       
        multiboxonly: true,
        height: 300,
        loadonce: false,
        pager: "#Menupager",
        beforeSelectRow: function (rowid, e) {
            //var selectedRow = JQMenuListGrid.jqGrid('getRowData', rowid);
            var $self = $(this),
                $td = $(e.target).closest("td"),
                rowid = $td.closest("tr.jqgrow").attr("id"),
                iCol = $.jgrid.getCellIndex($td[0]),
                cm = $self.jqGrid("getGridParam", "colModel");
            if (cm[iCol].name === "LinkButton" && e.target.tagName.toUpperCase() === "A") {
                jQuery('#JQMenuPermissionList').jqGrid('restoreRow', rowid)
                return false; // don't select the row on click
            }
            if (cm[iCol].name === "LinkButton" && e.target.tagName.toUpperCase() === "SPAN") {                
                jQuery('#JQMenuPermissionList').jqGrid('saveRow', rowid)                
                return false;
            }
        }
        //loadComplete: function () {
        //    var table = this;
        //    setTimeout(function () {               
        //        updatePagerIcons(table);
        //        enableTooltips(table);
        //    }, 0);
        //},
    });
};



function getAllSelectOptions() {
    var states = {
        '1': 'No Authorization', '2': 'Read-Only', '3': 'Full Authorization'
    };
    return states;
}
//$("#jqTable").setGridParam({'postData': data});

//("#grid id").setGridParam({ postData: { data: dataval } });
//$("#grid id").trigger('reloadGrid', [{ page: 1, data: dataval }]);