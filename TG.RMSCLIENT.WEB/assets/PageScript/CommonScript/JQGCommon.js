var GridName;
var Gridfooter;
var edit;
var add;
var del;
var search;
var refresh;
var view;

function ViewControl(edit, add, del, search, refresh, view) {
    this.edit = edit;
    this.add = add;
    this.del = del;
    this.search = search;
    this.refresh = refresh;
    this.view = view;
}
//glyphicon glyphicon-pencil   ace-icon fa fa-pencil blue
$(function () {
    //-******************navbar options*******************************
    jQuery("#" + GridName + "").jqGrid("navGrid", "#" + Gridfooter + "",
                   {
                       edit: edit,
                       editicon: 'ace-icon fa fa-pencil blue',
                       add: add,
                       addicon: 'ace-icon fa fa-plus-circle purple',
                       del: del,
                       delicon: 'ace-icon fa fa-trash-o red',
                       search: search,
                       searchicon: 'ace-icon fa fa-search orange',
                       refresh: refresh,
                       refreshicon: 'ace-icon fa fa-refresh green',
                       view: view,
                       viewicon: 'ace-icon fa fa-search-plus grey',
                   }
                    //{ addParams: { position: "last" } }                    
					

);

    //-******************add options*******************************
    $("#add_" + GridName + "").on("click", function () {
        $('.ui-widget-overlay').css({ 'z-index': '0', 'background': 'rgba(0,0,0,0)', 'display': 'none' });
        $('#editmod' + GridName + '').css({ 'display': 'none' })
        $("#" + GridName + "").jqGrid('addRow', { position: 'last' });

    });

    //-******************delete options*******************************  , { position: "last" }
    $('#del_' + GridName + '').on('click', function () {
        $('.ui-widget-overlay').css({ 'z-index': '0', 'background': 'rgba(0,0,0,0)', 'display': 'none' });
        $('#delmod' + GridName + '').css({ 'display': 'none' });
        var myGrid = $('#' + GridName + ''),
        selectedRowId = jQuery('#' + GridName + '').jqGrid('getGridParam', 'selrow'),
        cellValue = jQuery('#' + GridName + '').jqGrid('getCell', selectedRowId, 'id');
        $('#' + GridName + '').delRowData(selectedRowId);
        jQuery('#' + GridName + '').jqGrid('saveRow');
        
    });
    //-******************Edit options*******************************
    jQuery("#edit_" + GridName + "").click(function () {


        $('.ui-widget-overlay').css({ 'z-index': '0', 'background': 'rgba(0,0,0,0)', 'display': 'none' });
        $('#editmod' + GridName + '').css({ 'display': 'none' });
        var myGrid = $('#' + GridName + ''),
        selectedRowId = jQuery('#' + GridName + '').jqGrid('getGridParam', 'selrow'),
        cellValue = jQuery('#' + GridName + '').jqGrid('getCell', selectedRowId, 'id');
        //$('#' + GridName + '').delRowData(selectedRowId);

        jQuery('#' + GridName + '').jqGrid('editRow', selectedRowId);
        //this.disabled = 'true';
        //jQuery("#sved1,#cned1").attr("disabled", false);

    });
});

function updatePagerIcons(table) {
    var replacement =
    {
        'ui-icon-seek-first': 'ace-icon fa fa-angle-double-left bigger-140',
        'ui-icon-seek-prev': 'ace-icon fa fa-angle-left bigger-140',
        'ui-icon-seek-next': 'ace-icon fa fa-angle-right bigger-140',
        'ui-icon-seek-end': 'ace-icon fa fa-angle-double-right bigger-140'
    };
    $('.ui-pg-table:not(.navtable) > tbody > tr > .ui-pg-button > .ui-icon').each(function () {
        var icon = $(this);
        var $class = $.trim(icon.attr('class').replace('ui-icon', ''));

        if ($class in replacement) icon.attr('class', 'ui-icon ' + replacement[$class]);
    })
}

function enableTooltips(table) {
    $('.navtable .ui-pg-button').tooltip({ container: 'body' });
    $(table).find('.ui-pg-div').tooltip({ container: 'body' });
}

$(document).one('ajaxloadstart.page', function (e) {
    $.jgrid.gridDestroy("#" + GridName + "");
    $('.ui-jqdialog').remove();
});

