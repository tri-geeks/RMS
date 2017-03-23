$(document).ready(function () {

    $("#jqGrid").jqGrid({
        url: 'http://trirand.com/blog/phpjqgrid/examples/jsonp/getjsonp.php?callback=?&qwery=longorders',
        mtype: "GET",
        styleUI: 'Bootstrap',
        datatype: "jsonp",
        colModel: [
            { label: 'OrderID', name: 'OrderID', key: true, width: 75 },
            { label: 'Customer ID', name: 'CustomerID', width: 150 },
            { label: 'Order Date', name: 'OrderDate', width: 150, editable: true },
            { label: 'Freight', name: 'Freight', width: 150, editable: true },
            { label: 'Ship Name', name: 'ShipName', width: 150, editable: true },
            {
                label: 'Commit|Cancel',
                name: 'LinkButton',
                formatter: function (cellvalue, options, rowObject) {
                    return "<a href='#' style='align:center'><span class='glyphicon glyphicon-ok'  style='color:green'></a>|<a href='#' class='glyphicon glyphicon-remove' style='color:red'></a>";
                }, sortable: false, align: 'left', width: 100, align: "center"
            },
        ],
        viewrecords: true,
        height: 250,
        rowNum: 20,
        pager: "#jqGridPager",
        beforeSelectRow: function (rowid, e) {
            //var selectedRow = JQMenuListGrid.jqGrid('getRowData', rowid);
            var $self = $(this),
                $td = $(e.target).closest("td"),
                rowid = $td.closest("tr.jqgrow").attr("id"),
                iCol = $.jgrid.getCellIndex($td[0]),
                cm = $self.jqGrid("getGridParam", "colModel");
            if (cm[iCol].name === "LinkButton" && e.target.tagName.toUpperCase() === "A") {
                jQuery('#jqGrid').jqGrid('restoreRow', rowid)
                return false; // don't select the row on click
            }
            if (cm[iCol].name === "LinkButton" && e.target.tagName.toUpperCase() === "SPAN") {
                jQuery('#jqGrid').jqGrid('saveRow', rowid)
                return false;
            }
        }
    });


    $('#jqGrid').navGrid('#jqGridPager',
            // the buttons to appear on the toolbar of the grid
            { edit: true, add: true, del: true, search: false, refresh: false, view: false, position: "left", cloneToTop: false }            
    );

    //Add Row
    $('.glyphicon-plus').on('click', function () {
        $('.ui-overlay').css({ 'z-index': '0', 'background': 'rgba(0,0,0,0)', 'display': 'none' });
        $('#edithdjqGrid').css({ 'display': 'none' })
        $("#jqGrid").jqGrid('addRow', { position: 'last' });
        return false;
    });

    //Edit Row
   
    jQuery(".glyphicon-edit").on('click', function () {
        var selectedRowId = '';
        $('.ui-overlay').css({ 'z-index': '0', 'background': 'rgba(0,0,0,0)', 'display': 'none' });
        $('#editmodjqGrid').css({ 'display': 'none' });
        var myGrid = $('#jqGrid');
        //selectedRowId = jQuery('#jqGrid').jqGrid('getGridParam', 'selrow'),
        selectedRowId = myGrid.jqGrid('getGridParam', 'selrow');
        cellValue = jQuery('#jqGrid').jqGrid('getCell', selectedRowId, 'id');
        myGrid.jqGrid('editRow', selectedRowId);
        return false;

    });

    //Delete Row

    $('.glyphicon-trash').on('click', function () {
        $('.ui-widget-overlay').css({ 'z-index': '0', 'background': 'rgba(0,0,0,0)', 'display': 'none' });
        $('#delmodjqGrid').css({ 'display': 'none' });
        var myGrid = $('#jqGrid'),
        selectedRowId = jQuery('#jqGrid').jqGrid('getGridParam', 'selrow'),
        cellValue = jQuery('#jqGrid').jqGrid('getCell', selectedRowId, 'id');
        $('#jqGrid').delRowData(selectedRowId);
        jQuery('#jqGrid').jqGrid('saveRow');

        return false;

    });

});