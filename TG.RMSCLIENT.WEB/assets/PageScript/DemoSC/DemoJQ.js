var id = 0;
$(function () {
    GridName = 'list2';
    Gridfooter = 'pager2';

    var subgrid_table_id, pager_id;

    

    jQuery("#list2").jqGrid({
        url: '',
        datatype: "json",
        colNames: ['Action','','Inv No', 'Date', 'Client', 'Amount', 'Tax', 'Total', 'Notes'],
        colModel: [
            { name: 'act', index: 'act', width: 75, sortable: false },
            { name: 'MyCol', index: 'MyCol', editable:true, edittype:'checkbox', editoptions: { value:"True:False" },
                cellEdit:true,},
            //{
            //    name: 'id', index: 'id', width: 55,formatter: function (cellvalue, options, rowobject) {
            //        return '<span class="block input-icon input-icon-right"><input type="text" class="form-control" placeholder="id" name="id" /><i class="ace-icon fa fa-user"></i></span>';
            //    }
            //},
            { name: 'id', index: 'id', width: 80, align: "right", editable: true },
            { name: 'invdate', index: 'invdate', width: 90 },           
            {
                name: 'name', index: 'name', width: 200,
                sortable: true,
                align: 'center',
                editable: true,
                cellEdit: true,
                edittype: 'select',
                formatter: 'select',
                editoptions: { value: getAllSelectOptions() }
            },
            { name: 'amount', index: 'amount', width: 80, align: "right", editoptions: { value: "1000" } },
            { name: 'tax', index: 'tax', width: 80, align: "right", editable: true },
            { name: 'total', index: 'total', width: 80, align: "right" },
            { name: 'note', index: 'note', width: 150, align: "center", editable: true, sorttype: "date", formatter: 'date' }
        ],
        rowNum: 10,
        rowList: [10, 20, 30],
        pager: '#pager2',
        sortname: 'id',
        viewrecords: true,
        sortorder: "desc",
        caption: "JSON Example",
        height:'auto',
        grouping: true,
    //    onSelectRow: function (id) {
    //        var data = jQuery('#list2').getRowData(id);
    //        if (data.editable == true) {  // <-- you may have to check this
    //            jQuery('#list2').editRow(id, true);
    //        }
    //    },
    //    onCellSelect: function (rowid) {
    //    var rowData = $(this).jqGrid("getRowData", rowid);
    //        // now you can use rowData.name2, rowData.name3, rowData.name4 ,...
        //}
        subGrid: true,
        caption: "Grid as Subgrid",
        subGridRowExpanded: function(subgrid_id, row_id) {
            // we pass two parameters
            // subgrid_id is a id of the div tag created whitin a table data
            // the id of this elemenet is a combination of the "sg_" + id of the row
            // the row_id is the id of the row
            // If we wan to pass additinal parameters to the url we can use
            // a method getRowData(row_id) - which returns associative array in type name-value
            // here we can easy construct the flowing

            //var subgrid_table_id, pager_id;
            
            //subgrid_table_id = subgrid_id+"_t";
            //pager_id = "p_" + subgrid_table_id;

            //GridName = subgrid_table_id;
            //Gridfooter = pager_id;

            subgrid_table_id = subgrid_id + "_t";
            pager_id = "p_" + subgrid_table_id;

            GridName = subgrid_table_id;
            Gridfooter = pager_id;

            $("#"+subgrid_id).html("<table id='"+subgrid_table_id+"' class='scroll'></table><div id='"+pager_id+"' class='scroll'></div>");
            jQuery("#"+subgrid_table_id).jqGrid({
                url:"subgrid.php?q=2&id="+row_id,
                datatype: "xml",
                colNames: ['No','Item','Qty','Unit','Line Total'],
                colModel: [
                    {name:"num",index:"num",width:80,key:true},
                    {name:"item",index:"item",width:130},
                    {name:"qty",index:"qty",width:70,align:"right"},
                    {name:"unit",index:"unit",width:70,align:"right"},
                    {name:"total",index:"total",width:70,align:"right",sortable:false}
                ],
                rowNum:20,
                pager: pager_id,
                sortname: 'num',
                sortorder: "asc",
                height: '100%'
            });
            //jQuery("#"+subgrid_table_id).jqGrid('navGrid',"#"+pager_id,{edit:true,add:true,del:true})
        },
        subGridRowColapsed: function(subgrid_id, row_id) {
            // this function is called before removing the data
            //var subgrid_table_id;
            //subgrid_table_id = subgrid_id+"_t";
            //jQuery("#"+subgrid_table_id).remove();
        },
        gridComplete: function () {
            var ids = jQuery("#list2").jqGrid('getDataIDs');
            for (var i = 0; i < ids.length; i++) {
                var cl = ids[i];
                be = "<input style='height:22px;width:20px;' type='button' value='E' onclick=\"jQuery('#list2').editRow('" + cl + "');\"  />";
                se = "<input style='height:22px;width:20px;' type='button' value='S' onclick=\"jQuery('#list2').saveRow('" + cl + "');\"  />";
                ce = "<input style='height:22px;width:20px;' type='button' value='C' onclick=\"jQuery('#list2').restoreRow('" + cl + "');\" />";
                jQuery("#list2").jqGrid('setRowData', ids[i], { act: be + se + ce });
            }
        }
        
    });

    $("#list2 td input").each(function () {
        $(this).click(function (e) {
            // e.target point to <input> DOM element
            var tr = $(e.target).closest('tr');
            alert("Current rowid=" + tr[0].id);
        });
    });

});

function getAllSelectOptions() {
    var states = {
        '1': 'Alabama', '2': 'California', '3': 'Florida',
        '4': 'Hawaii', '5': 'London', '6': 'Oxford'
    };
    return states;
}