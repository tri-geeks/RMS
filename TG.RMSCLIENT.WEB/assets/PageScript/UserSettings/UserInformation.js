
var JQUserInformation;
var obj = new Suraya();
var msg = new UIStyle();
//-**********************-- on load--**********************
$(function () {
    JQUserInformation = $('#JQUserInformation');
    JQGetAllUser(JQUserInformation);
    GetAllUser();
   
    //***************--Save--**********************---------
    $('form').submit(function (e) {
        e.preventDefault();       
        var formData = new FormData(this);
        obj.Save({
            url: rootPath + '/UserSettings/UserInformation',
            form: formData
        });
        JQUserInformation.trigger("reloadGrid");
       
    })

    //****************--Validation Part--***************-----
    $('#EmployeeCode').blur(function () {
        var employeeCode = $('#EmployeeCode').val();
        var data = obj.Getdata({
            url: rootPath + '/UserSettings/GetUserInformationByEmployeeCode',
            values: { 'employeeCode': employeeCode }
        });
        if (data != 'null') {
            clear();
            LoadControll(data);
        }

    });

    $('#ConfirmPassword').blur(function () {
        if ($('#ConfirmPassword').val() != $('#Password').val())        {
            msg.warning();
            $("#ConfirmPassword").focus();
            return;
        }
            
    });

    
   
})

//****************--Load Data in control************------
function LoadControll(data) {
    $('#UserID').val(data.UserID);
    $('#EmployeeCode').val(data.EmployeeCode);
    $('#EmployeeName').val(data.EmployeeName);
    $('#Email').val(data.Email);
    $('#Phone').val(data.Phone);
    $('#UserName').val(data.UserName);
    $('#Password').val(data.Password);
    $('#ConfirmPassword').val(data.ConfirmPassword);

    if (data.IsActive == 1 || data.IsActive=='Yes')
        $('#IsActive').prop("checked", true);
    else
        $('#IsActive').prop("checked", false);

    if (data.IsAdmin == 1 || data.IsAdmin=='Yes')
        $('#IsAdmin').prop("checked", true);
    else
        $('#IsAdmin').prop("checked", false);
}

//--****************************Clear Control--****************************-----
function fNew()
{
    clear();
}

function clear() {
    $('form').find('input:text, input:password, input:file, select, textarea').val('');
    $('form').find('input:radio, input:checkbox').prop('checked', false).prop('selected', false);
};


//--******************Retrive All user--*************
function GetAllUser()
{
    var data = obj.Getdata({
        url: '/UserSettings/GetAllUserList',
        values: ''
    });
}

//---*********************************** JQ Grid--*****************************************
function JQGetAllUser(JQUserInformation)
{
        JQUserInformation.jqGrid({
        url: '/UserSettings/GetAllUserList',
        datatype: "json",
        mtype: 'GET',
        colNames: ['User ID','Emp-Code','Emp-Name','E-mail','Contact','User','Password','Confirm Password','IsActive','IsAdmin','Edit|Delete'],
        colModel: [
            { name: 'UserID', index: 'ID', key: true, hidden: true, width: 75 },
            { name: 'EmployeeCode', index: 'EmployeeCode', width: 80 },
            { name: 'EmployeeName', index: 'EmployeeName', width: 150 },
            { name: 'Email', index: 'Email', width: 120 },
            { name: 'Phone', index: 'Phone', width: 100 },
            { name: 'UserName', index: 'UserName', width: 100 },
            { name: 'Password', index: 'Password', width: 0, hidden: true },
            { name: 'ConfirmPassword', index: 'ConfirmPassword', width: 0, hidden: true },
            { name: 'IsActive', index: 'IsActive', width: 60, formatter: 'checkbox', align: "center" },
            { name: 'IsAdmin', index: 'IsAdmin', width: 60, formatter: 'checkbox', align: "center" },
            {
                name: 'LinkButton',
                formatter: function (cellvalue, options, rowObject) {
                    return "<a href='#' style='align:center'><span class='glyphicon glyphicon-pencil'  style='color:green'></a>|<a href='#' class='glyphicon glyphicon-trash' style='color:red'></a>";
                }, sortable: false, align: 'left', width: 80, align: "center"
            },
        ],
        sortname: 'UserID',
        viewrecords: true,
        sortorder: "asc",
        caption: "User List",
        rowNum: 10,
        height: "auto",
        loadonce: false,
        pager: "#pager",
        beforeSelectRow: function (rowid, e) {
            var selectedRow = JQUserInformation.jqGrid('getRowData', rowid);
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
                var selectedRow = JQUserInformation.jqGrid('getRowData', rowid);                
                LoadControll(selectedRow)
                return false;
            }
        }
    });
}