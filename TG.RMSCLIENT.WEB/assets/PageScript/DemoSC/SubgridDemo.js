$(function () {

    GridName = 'listsg11';
    Gridfooter = 'pagersg11';
    ViewControl(true, true, true, true, true, true)

    var subgrid_table_id, pager_id;


    jQuery("#listsg11").jqGrid({
        //url: 'server.php?q=1',
        //datatype: "xml",
        height: 190,
        colNames: ['Inv No', 'Date', 'Client', 'Amount', 'Tax', 'Total', 'Notes','E|D'],
        colModel: [
            { name: 'id', index: 'id', width: 55, editable: true },
            { name: 'invdate', index: 'invdate', width: 90, editable: true },
            { name: 'name', index: 'name', width: 100, editable: true },
            { name: 'amount', index: 'amount', width: 80, align: "right", editable: true },
            { name: 'tax', index: 'tax', width: 80, align: "right", editable: true },
            { name: 'total', index: 'total', width: 80, align: "right", editable: true },
            { name: 'note', index: 'note', width: 150, sortable: false, editable: true },
            {
                name: 'LinkButton',
                formatter: function (cellvalue, options, rowObject) {
                    return "<a href='#' style='align:center'><span class='glyphicon glyphicon-ok'  style='color:green'></a>|<a href='#' class='glyphicon glyphicon-remove' style='color:red'></a>";
                }, sortable: false, align: 'left', width: 100, align: "center"
            },
        ],
        rowNum: 8,
        rowList: [8, 10, 20, 30],
        pager: '#pagersg11',
        sortname: 'id',
        viewrecords: true,
        sortorder: "desc",
        multiselect: false,
        beforeSelectRow: function (rowid, e) {
            var selectedRow = jQuery("#listsg11").jqGrid('getRowData', rowid);
            var $self = $(this),
                $td = $(e.target).closest("td"),
                rowid = $td.closest("tr.jqgrow").attr("id"),
                iCol = $.jgrid.getCellIndex($td[0]),
                cm = $self.jqGrid("getGridParam", "colModel");

            if (cm[iCol].name === "LinkButton" && e.target.tagName.toUpperCase() === "SPAN") {
                //var selectedRow = JQProductionDetails.jqGrid('getRowData', rowid); 


                jQuery('#listsg11').jqGrid('saveRow', rowid)
            }
        },
        subGrid: true,
        caption: "Grid as Subgrid",
       
        subGridRowExpanded: function (subgrid_id, row_id) {
            // we pass two parameters
            // subgrid_id is a id of the div tag created whitin a table data
            // the id of this elemenet is a combination of the "sg_" + id of the row
            // the row_id is the id of the row
            // If we wan to pass additinal parameters to the url we can use
            // a method getRowData(row_id) - which returns associative array in type name-value
            // here we can easy construct the flowing
           
            subgrid_table_id = subgrid_id + "_t";
            pager_id = "p_" + subgrid_table_id;

            //GridName = subgrid_table_id;
            //Gridfooter = pager_id;
            //ViewControl(true, true, true, true, true, true)

            $("#" + subgrid_id).html("<table id='" + subgrid_table_id + "' class='scroll'></table><div id='" + pager_id + "' class='scroll'></div>");
            jQuery("#" + subgrid_table_id).jqGrid({
                //url: "subgrid.php?q=2&id=" + row_id,
                //datatype: "xml",
                colNames: ['No', 'Item', 'Qty', 'Unit', 'Line Total','E|D'],
                colModel: [
                    { name: "num", index: "num", width: 80, key: true, editable: true },
                    { name: "item", index: "item", width: 130, editable: true },
                    { name: "qty", index: "qty", width: 70, align: "right", editable: true },
                    { name: "unit", index: "unit", width: 70, align: "right", editable: true },
                    { name: "total", index: "total", width: 70, align: "right", sortable: false, editable: true },
                    {
                        name: 'LinkButton',
                        formatter: function (cellvalue, options, rowObject) {
                            return "<a href='#' style='align:center'><span class='glyphicon glyphicon-ok'  style='color:green'></a>|<a href='#' class='glyphicon glyphicon-remove' style='color:red'></a>";
                        }, sortable: false, align: 'left', width: 100, align: "center"
                    },
                ],
                rowNum: 20,
                pager: pager_id,
                sortname: 'num',
                sortorder: "asc",
                height: '100%',
                beforeSelectRow: function (rowid, e) {
                    var selectedRow = jQuery("#" + subgrid_table_id).jqGrid('getRowData', rowid);
                    var $self = $(this),
                        $td = $(e.target).closest("td"),
                        rowid = $td.closest("tr.jqgrow").attr("id"),
                        iCol = $.jgrid.getCellIndex($td[0]),
                        cm = $self.jqGrid("getGridParam", "colModel");

                    if (cm[iCol].name === "LinkButton" && e.target.tagName.toUpperCase() === "SPAN") {
                        //var selectedRow = JQProductionDetails.jqGrid('getRowData', rowid); 


                        jQuery("#" + subgrid_table_id).jqGrid('saveRow', rowid)
                    }
                }
            });
            //jQuery("#" + subgrid_table_id).jqGrid('navGrid', "#" + pager_id, { edit: false, add: true, del: true })
            jQuery("#" + subgrid_table_id + "").jqGrid("navGrid", "#" + pager_id + "",
                   {
                       edit: true,
                       editicon: 'ace-icon fa fa-pencil blue',
                       add: true,
                       addicon: 'ace-icon fa fa-plus-circle purple',
                       del: true,
                       delicon: 'ace-icon fa fa-trash-o red',
                       search: true,
                       searchicon: 'ace-icon fa fa-search orange',
                       refresh: true,
                       refreshicon: 'ace-icon fa fa-refresh green',
                       view: true,
                       viewicon: 'ace-icon fa fa-search-plus grey',
                   });

            $("#add_" + subgrid_table_id + "").on("click", function () {
                $('.ui-widget-overlay').css({ 'z-index': '0', 'background': 'rgba(0,0,0,0)', 'display': 'none' });
                $('#editmod' + subgrid_table_id + '').css({ 'display': 'none' })
                $("#" + subgrid_table_id + "").jqGrid('addRow', { position: 'last' });

            });
        },
        subGridRowColapsed: function (subgrid_id, row_id) {
            // this function is called before removing the data
            //var subgrid_table_id;
            //subgrid_table_id = subgrid_id+"_t";
            //jQuery("#"+subgrid_table_id).remove();
        }
    });
    //jQuery("#listsg11").jqGrid('navGrid', '#pagersg11', { add: true, edit: true, del: true });
})


