var JQUserList;
var obj = new Suraya();
var msg = new UIStyle();
$(function () {    
    JQUserList = $('#JQUserList');
    UserList(JQUserList);

    //***************--Save--**********************---------
    $('form').submit(function (e) {
        e.preventDefault();
        var formData = new FormData(this);
        var IsAdmin = $('#IsAdmin').prop('checked');
        formData.append('IsAdmin', $('#IsAdmin').prop('checked'));
        obj.Save({
            url: rootPath + '/Settings/UserInformationC',
            form: formData
        });
        JQUserList.trigger("reloadGrid");

    })
});

function UserList(JQUserList) {
    JQUserList.jqGrid({
        url: rootPath+'/Settings/GetUserList',
        mtype: "GET",
        styleUI: 'Bootstrap',
        datatype: "json",
        colModel: [
            { label: 'UserID', name: 'UserID', key: true, width: 75,hidden:true },
            { label: 'Full Name', name: 'UserFullName', width: 150 },
            { label: 'Email', name: 'Email', width: 150, editable: false },
            { label: 'Contact', name: 'Contact', width: 150, editable: false },
            { label: 'User Name', name: 'UserName', width: 150, editable: false },
            { label: 'Password', name: 'Password', width: 150, editable: false ,hidden:true },
            { label: 'Confirm Password', name: 'ConfirmPassword', width: 150, editable: false, hidden: true },
            { label: 'IsActive', name: 'IsActive', width: 60, formatter: 'checkbox', align: "center", hidden: true },
            { label: 'IsAdmin', name: 'IsAdmin', width: 60, formatter: 'checkbox', align: "center", hidden: true },
            {
                label: 'Commit|Cancel',
                name: 'LinkButton',
                formatter: function (cellvalue, options, rowObject) {
                    return "<a href='#' style='align:center'><span class='glyphicon glyphicon-pencil'  style='color:green'></a>|<a href='#' class='glyphicon glyphicon-trash' style='color:red'></a>";
                }, sortable: false, align: 'left', width: 100, align: "center"
            },
        ],
        viewrecords: true,
        height: 200,
        rowNum: 20,
        pager: "#JQUserPager",
        beforeSelectRow: function (rowid, e) {
            //var selectedRow = JQMenuListGrid.jqGrid('getRowData', rowid);
            var $self = $(this),
                $td = $(e.target).closest("td"),
                rowid = $td.closest("tr.jqgrow").attr("id"),
                iCol = $.jgrid.getCellIndex($td[0]),
                cm = $self.jqGrid("getGridParam", "colModel");
            if (cm[iCol].name === "LinkButton" && e.target.tagName.toUpperCase() === "A") {
                JQUserList.jqGrid('restoreRow', rowid)
                return false; // don't select the row on click
            }
            if (cm[iCol].name === "LinkButton" && e.target.tagName.toUpperCase() === "SPAN") {
                //JQUserList.jqGrid('saveRow', rowid)
                var selectedRow = JQUserList.jqGrid('getRowData', rowid);
                LoadControll(selectedRow)
                return false;
            }
        }
    });
}

//****************--Load Data in control************------
function LoadControll(data) {
    $('#UserID').val(data.UserID);
    $('#UserFullName').val(data.UserFullName);   
    $('#Email').val(data.Email);
    $('#Contact').val(data.Contact);
    $('#UserName').val(data.UserName);
    $('#Password').val(data.Password);
    $('#ConfirmPassword').val(data.ConfirmPassword);

    if (data.IsActive == 1 || data.IsActive == 'Yes')
        $('#IsActive').prop("checked", true);
    else
        $('#IsActive').prop("checked", false);

    if (data.IsAdmin == 1 || data.IsAdmin == 'Yes')
        $('#IsAdmin').prop("checked", true);
    else
        $('#IsAdmin').prop("checked", false);
}

//--****************************Clear Control--****************************-----
function fNew() {
    clear();
}

function clear() {
    $('form').find('input:text, input:password, input:file, select, textarea').val('');
    //$('form').find('input:radio, input:checkbox').prop('checked', false)//.prop('selected', false);
    $('#IsActive').prop("checked", false);
    $('#IsAdmin').prop("checked", false);
};
