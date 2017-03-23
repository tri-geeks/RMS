var JQUserList;
$(function () {
    //GridName = 'JQUserList';
    //Gridfooter = 'JQUserPager';
    JQUserList = $('#JQUserList');
    UserList(JQUserList);
});

function UserList(JQUserList) {
    JQUserList.jqGrid({
        url: 'http://trirand.com/blog/phpjqgrid/examples/jsonp/getjsonp.php?callback=?&qwery=longorders',
        mtype: "GET",
        styleUI: 'Bootstrap',
        datatype: "jsonp",
        colModel: [
            { label: 'OrderID', name: 'OrderID', key: true, width: 75,hidden:true },
            { label: 'Customer ID', name: 'CustomerID', width: 150 },
            { label: 'Order Date', name: 'OrderDate', width: 150, editable: true },
            { label: 'Freight', name: 'Freight', width: 150, editable: true },
            { label: 'Ship Name', name: 'ShipName', width: 150, editable: true },
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
                JQUserList.jqGrid('saveRow', rowid)
                return false;
            }
        }
    });
}