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

$(function () {
    $('#' + GridName + '').navGrid('#' + Gridfooter+'',
        // the buttons to appear on the toolbar of the grid
        { edit: edit, add: add, del: del, search: search, refresh: refresh, view: view, position: "left", cloneToTop: false }
    );


    //Add Row
    $('.glyphicon-plus').on('click', function () {
        $('.ui-overlay').css({ 'z-index': '0', 'background': 'rgba(0,0,0,0)', 'display': 'none' });
        $('#edithd' + GridName+'').css({ 'display': 'none' })
        $('#' + GridName+'').jqGrid('addRow', { position: 'last' });
        return false;
    });

    //Edit Row

    jQuery(".glyphicon-edit").on('click', function () {
        var selectedRowId = '';
        $('.ui-overlay').css({ 'z-index': '0', 'background': 'rgba(0,0,0,0)', 'display': 'none' });
        $('#editmod' + GridName+'').css({ 'display': 'none' });
        var myGrid = $('#' + GridName+'');
        //selectedRowId = jQuery('#jqGrid').jqGrid('getGridParam', 'selrow'),
        selectedRowId = myGrid.jqGrid('getGridParam', 'selrow');
        cellValue = jQuery('#' + GridName+'').jqGrid('getCell', selectedRowId, 'id');
        myGrid.jqGrid('editRow', selectedRowId);
        return false;

    });

    //Delete Row

    $('.glyphicon-trash').on('click', function () {
        $('.ui-widget-overlay').css({ 'z-index': '0', 'background': 'rgba(0,0,0,0)', 'display': 'none' });
        $('#delmod' + GridName+'').css({ 'display': 'none' });
        var myGrid = $('#' + GridName+''),
            selectedRowId = jQuery('#' + GridName+'').jqGrid('getGridParam', 'selrow'),
            cellValue = jQuery('#jqGrid').jqGrid('getCell', selectedRowId, 'id');
        $('#' + GridName+'').delRowData(selectedRowId);
        jQuery('#' + GridName+'').jqGrid('saveRow');

        return false;

    });
});