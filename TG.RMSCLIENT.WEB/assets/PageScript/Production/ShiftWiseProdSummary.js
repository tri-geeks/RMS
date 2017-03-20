var JQSWProdSum;

var obj = new Suraya();
var alerts = new UIStyle();

$(function () {
    obj.DatePicker();

    JQSWProdSum = $('#JQSWProdSum');

    var parent_column = $(JQSWProdSum).closest('[class*="col-"]');
    //resize to fit page size
    $(window).on('resize.jqGrid', function () {
        $(JQSWProdSum).jqGrid('setGridWidth', parent_column.width());
    })

    //resize on sidebar collapse/expand
    $(document).on('settings.ace.jqGrid', function (ev, event_name, collapsed) {
        if (event_name === 'sidebar_collapsed' || event_name === 'main_container_fixed') {
            //setTimeout is for webkit only to give time for DOM changes and then redraw!!!
            setTimeout(function () {
                $(JQSWProdSum).jqGrid('setGridWidth', parent_column.width());
            }, 20);
        }
    })


    SWPSummary(JQSWProdSum);
    $(window).triggerHandler('resize.jqGrid');

    $('#ShiftID').change(function () {
        if ($('#ProductionDate').val() != null) {
            JQSWProdSum.setGridParam({ postData: { ShiftID: $('#ShiftID').val(), ProdDate: $('#ProductionDate').val() } });
            JQSWProdSum.trigger('reloadGrid', [{ ShiftID: $('#ShiftID').val(), ProdDate: $('#ProductionDate').val() }]);
        }
    })
});

function SWPSummary(JQSWProdSum) {
    JQSWProdSum.jqGrid({
        subGrid: true,
        caption: "Quality",
        //subGridOptions: {
        //    plusicon: "ace-icon fa fa-plus center bigger-110 blue",
        //    minusicon: "ace-icon fa fa-minus center bigger-110 blue",
        //    openicon: "ace-icon fa fa-chevron-right center orange"
        //},
        subGridRowExpanded: function (subgrid_id, row_id) {            
            subgrid_table_id = subgrid_id + "_t";
            pager_id = "p_" + subgrid_table_id;
            var selectedRow = JQSWProdSum.jqGrid('getRowData', row_id);           
            $("#" + subgrid_id).html("<table id='" + subgrid_table_id + "' class='scroll'></table>");
            jQuery("#" + subgrid_table_id).jqGrid({
                url: rootPath + "/DailyProduction/GetProdQSummary",
                postData: { SWPID: selectedRow.SWPID },
                datatype: "json",
                mtype: 'GET',
                colNames: ['SWPQID', 'QualityName', 'Qty'],
                colModel: [
                    { name: "SWPQID", index: "SWPQID", width: 80, key: true, editable: false, hidden: true },
                    { name: "QualityName", index: "QualityName", width: 200, editable: false },
                    { name: "Quantity", index: "Quantity", width: 100, align: "right", editable: false }
                ],
                //rowNum: 20,
                //pager: pager_id,
                //sortname: 'SWPQID',
                //sortorder: "asc",
                //height: '100%'                
            });
        },
        
        //<div id='" + pager_id + "' class='scroll'></div>

        url: rootPath + "/DailyProduction/GetProdSummary",
        postData: { ShiftID: '0', ProdDate: '01/01/1999' },
        datatype: "json",
        mtype: 'GET',
        height: 190,
        colNames: ['SWPID', 'ProductionDate', 'Furnace', 'Station', 'Section', 'Shift', 'Item', 'PCS', 'KG', 'Prod(MIN)', 'Loss(MIN)', 'Efficiency','UnitWeightGM', 'BPM'],
        colModel: [
            { name: 'SWPID', index: 'SWPID', width: 55, editable: false,hidden:true },
            { name: 'ProductionDate', index: 'ProductionDate', width: 90, editable: false, hidden: true },
            { name: 'FurName', index: 'FurName', width: 100, editable: false },
            { name: 'StationName', index: 'StationName', width: 80, align: "center", editable: false },
            { name: 'Section', index: 'Section', width: 80, align: "center", editable: false },
            { name: 'ShiftName', index: 'ShiftName', width: 60, align: "center", editable: false },
            { name: 'ItemName', index: 'ItemName', width: 250, sortable: false, editable: false,align: "left" },
            { name: 'QuantityPCS', index: 'QuantityPCS', width: 150, sortable: false, editable: false, align: "right" },
            { name: 'QuantityKG', index: 'QuantityKG', width: 100, sortable: false, editable: false, align: "right" },
            { name: 'ProductionMIN', index: 'ProductionMIN', width: 150, sortable: false, editable: false, align: "right" },
            { name: 'ProductionLossMIN', index: 'ProductionLossMIN', width: 150, sortable: false, editable: false, align: "right"},
            { name: 'Efficiency', index: 'Efficiency', width: 100, sortable: false, editable: false, align: "right" },
            { name: 'UnitWeightGM', index: 'UnitWeightGM', width: 100, sortable: false, editable: false, align: "right" },
            { name: 'BPM', index: 'BPM', width: 100, sortable: false, editable: false, hidden: true },
            
        ],
        rowNum: 8,
        rowList: [8, 10, 20, 30],
        pager: '#JQSWProdSumpager',
        sortname: 'SWPID',
        viewrecords: true,
        sortorder: "desc",
        multiselect: false,
        loadonce:false,
        beforeSelectRow: function (rowid, e) {
            var selectedRow = JQSWProdSum.jqGrid('getRowData', rowid);
            var $self = $(this),
                $td = $(e.target).closest("td"),
                rowid = $td.closest("tr.jqgrow").attr("id"),
                iCol = $.jgrid.getCellIndex($td[0]),
                cm = $self.jqGrid("getGridParam", "colModel");

            if (cm[iCol].name === "LinkButton" && e.target.tagName.toUpperCase() === "SPAN") {
                //var selectedRow = JQProductionDetails.jqGrid('getRowData', rowid); 
                JQSWProdSum.jqGrid('saveRow', rowid)
            }
        },        
        subGridRowColapsed: function (subgrid_id, row_id) {
            // this function is called before removing the data
            //var subgrid_table_id;
            //subgrid_table_id = subgrid_id+"_t";
            //jQuery("#"+subgrid_table_id).remove();
        }
    });
}
