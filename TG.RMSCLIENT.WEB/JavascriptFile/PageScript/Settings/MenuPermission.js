var JQMenuList;
var obj = new Suraya();
var msg = new UIStyle();
$(function () {
    GridName = 'JQMenuList';
    Gridfooter = 'JQMenuPager';
    LoadUser();    
    ViewControl(true, false, false, false, false, false)
    JQMenuList = $('#JQMenuList');
   
    //****************Submit*********************
    $('form').submit(function () {
        var formdata = new FormData(this);
        var menulist = $('#JQMenuList').getRowData();
        obj.addListWithForm(formdata, menulist, 'menuList');
        obj.Save({
            url: rootPath + '/Settings/MenuPermissionC',
            form: formdata
        });
        JQMenuList.trigger("reloadGrid");
    });

    //***************Leave Event********************   
    $('#UserID').change(function () {
        var userid = $('#UserID').val();
        $("#JQMenuList").setGridParam({ postData: { id: userid } });
        $("#JQMenuList").trigger('reloadGrid', [{ id: userid }]);
    })
    MenuList(JQMenuList);
});

function MenuList(JQMenuList) {
    JQMenuList.jqGrid({        
        url: rootPath + '/Settings/GetMenuListBuUserID',
        postData: { id: '0' },
        datatype: "json",
        mtype: 'GET',
        styleUI: 'Bootstrap',
        colModel: [            
            { label: 'PermissionID', name: 'PermissionID', width: 100, hidden: true },
            { label: 'UserID', name: 'UserID', width: 150, hidden: true },
            { label: 'MenuID', name: 'MenuID', width: 250, key: true, hidden: true },
            { label: 'MenuName', name: 'MenuName', width: 250, hidden: true },
            { label: 'DisplayName', name: 'DisplayName', width: 250 },
            {
                label: 'Authorization', name: 'Authorization', width: 250,
                sortable: true,
                align: 'center',
                editable: true,
                cellEdit: true,
                edittype: 'select',
                formatter: 'select',
                editoptions: { value: getAllSelectOptions() }
            },
            {
                label:'Commit|Cancel',
                name: 'LinkButton',
                formatter: function (cellvalue, options, rowObject) {
                    return "<a href='#' style='align:center'><span class='glyphicon glyphicon-ok'  style='color:green'></a>|<a href='#' class='glyphicon glyphicon-remove' style='color:red'></a>";
                }, sortable: false, align: 'left', width: 100, align: "center"
            },
        ],
        viewrecords: true,
        height: 200,
        rowNum: 20,
        pager: "#JQMenuPager",
        beforeSelectRow: function (rowid, e) {
            //var selectedRow = JQMenuListGrid.jqGrid('getRowData', rowid);
            var $self = $(this),
                $td = $(e.target).closest("td"),
                rowid = $td.closest("tr.jqgrow").attr("id"),
                iCol = $.jgrid.getCellIndex($td[0]),
                cm = $self.jqGrid("getGridParam", "colModel");
            if (cm[iCol].name === "LinkButton" && e.target.tagName.toUpperCase() === "A") {
                JQMenuList.jqGrid('restoreRow', rowid)
                return false; // don't select the row on click
            }
            if (cm[iCol].name === "LinkButton" && e.target.tagName.toUpperCase() === "SPAN") {
                JQMenuList.jqGrid('saveRow', rowid)
                return false;
            }
        }
    });
}

function LoadUser() {
    obj.loaddropV({
        url: rootPath+ '/Settings/CboUser',
        values: '',
        select:$('#UserID')
    });
}

function getAllSelectOptions() {
    var states = {
        '1': 'No Authorization','3': 'Full Authorization'
    };
    return states;
}