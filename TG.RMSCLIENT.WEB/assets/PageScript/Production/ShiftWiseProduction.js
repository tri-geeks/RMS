var JQSWPQuality;
var obj = new Suraya();
var MsgBox = new UIStyle();

$(function () {
    obj.DatePicker();

    GridName = 'JQSWPQuality';
    Gridfooter = 'SWPQualitypager';
    ViewControl(true, true, true, true, true, true)

    JQSWPQuality = $('#JQSWPQuality');
    JQGetSWPQuality(JQSWPQuality);

    //****************--Click Search--****************************
    $('#search').click(function () {
        Search();
    });

    //*******************--Change Event--**************************
    $('#FurnaceID').change(function () {
        FurnaceChange($('#FurnaceID').val())
    });

    $('#ItemID').change(function () {
        ItemChange($('#ItemID').val())
    });

    $('#ShiftID').change(function () {
         ShiftChange($('#ShiftID').val())
    });

    //***************--Save--**********************---------
    $('form').submit(function (e) {
        e.preventDefault();        
        var formdata = new FormData(this);
        var swprodQlist = $('#JQSWPQuality').getRowData();
        obj.addListWithForm(formdata, swprodQlist, 'swprodQlist');
        obj.Save({
            url: rootPath + '/DailyProduction/ShiftWiseProductionC',
            form: formdata
        });

    })
});



//*******************--Change Event function--**************************
function FurnaceChange(furnace) {
    obj.loaddropV({
        url: rootPath + '/DailyProduction/GetStation',
        values: { 'furID': furnace },
        select: $('#StationID')
    });
}

function ItemChange(item) {
    var data = obj.Getdata({
        url: rootPath + '/DailyProduction/GetItemPropertiesByItemCode',
        values: { 'ItemID': item }
    });
    if (data != 'null') {        
        $('#BPM').val(data.ProductionRatePerMin);
        $('#UnitWeightGM').val(data.Weight);

    }
}

function ShiftChange(shiftID) {
    var data = obj.Getdata({
        url: rootPath + '/DailyProduction/GetShiftByID',
        values: { 'shiftID': shiftID }
    });
    if (data != 'null') {
        $('#ProductionMIN').val(data.DurationMIN);
    }
}

//****************-- JQ Grid--****************************************
function JQGetSWPQuality(JQSWPQuality) {

    JQSWPQuality.jqGrid({
        url: rootPath + '/DailyProduction/GetSWProdQListBySWPID',
        postData: { swpid: '0' },
        datatype: "json",
        mtype: 'GET',
        colNames: ['SWPQID', 'SWPID', 'QualityID', 'Quantity', 'Commit|Cancel'],
        colModel: [
           { name: 'SWPQID', index: 'SWPQID', key: false, width: 100, hidden: true },
           { name: 'SWPID', index: 'SWPID', key: false, width: 100, hidden: true },
           {
               name: 'QualityID',
               index: 'QualityID',
               width: 300,
               sortable: true,
               align: 'center',
               editable: true,
               cellEdit: true,
               edittype: 'select',
               formatter: 'select',
               editoptions: {
                   value: obj.JQGridDropDown({
                       url: rootPath + '/DailyProduction/GetQualityCbo',
                       values: ''
                   })
               }
           },
           { name: 'Quantity', index: 'Quantity', key: false, width: 300, hidden: false, editable: true, align: "right" },
           {
               name: 'LinkButton',
               formatter: function (cellvalue, options, rowObject) {
                   return "<a href='#' style='align:center'><span class='glyphicon glyphicon-ok'  style='color:green'></a>|<a href='#' class='glyphicon glyphicon-remove' style='color:red'></a>";
               }, sortable: false, align: 'left', width: 100, align: "center"
           },
        ],
        sortname: 'SWPQID',
        viewrecords: true,
        sortorder: "asc",
        caption: "Quality",
        rowNum: 5,
        height: "100",
        loadonce: false,
        pager: "#SWPQualitypager",
        footerrow: true,
        userDataOnFooter: true,
        beforeSelectRow: function (rowid, e) {
            var selectedRow = JQSWPQuality.jqGrid('getRowData', rowid);
            var $self = $(this),
                $td = $(e.target).closest("td"),
                rowid = $td.closest("tr.jqgrow").attr("id"),
                iCol = $.jgrid.getCellIndex($td[0]),
                cm = $self.jqGrid("getGridParam", "colModel");

            if (cm[iCol].name === "LinkButton" && e.target.tagName.toUpperCase() === "A") {
                JQSWPQuality.jqGrid('restoreRow', rowid)
                return false; // don't select the row on click
            }

            if (cm[iCol].name === "LinkButton" && e.target.tagName.toUpperCase() === "SPAN") {
                JQSWPQuality.jqGrid('saveRow', rowid)
                //JQSWPQuality.jqGrid('setRowData', rowid);
                //jQuery("#sved4").attr("disabled", true);
               // JQSWPQuality.trigger("reloadGrid");
                //JQSWPQuality.jqGrid('getRowData', rowid);
                //JQSWPQuality.jqGrid('setRowData', rowid, { Select: selector, Action: be[rowid] });
                //JQSWPQuality.setSelection(rowid, false);

                var colSumTotalPices = JQSWPQuality.jqGrid("getCol", 'Quantity', false, 'sum');
                $('#QuantityPCS').val(colSumTotalPices);
                var toatlKG = parseFloat(colSumTotalPices) * parseFloat($('#UnitWeightGM').val()) / 1000;
                $('#QuantityKG').val(toatlKG);
                JQSWPQuality.jqGrid('footerData', 'set', { Quantity: 'Sum: ' + colSumTotalPices });
                //(TPices / (EffRate * Section * 480) * 100).toFixed(2)
                var efficiency = (parseFloat(colSumTotalPices) / (parseFloat($('#BPM').val()) * parseFloat($('#Section').val()) * parseFloat($('#ProductionMIN').val())) * 100).toFixed(2);
                $('#Efficiency').val(efficiency);
            }
        }

    });
}

function checksave(result) {
    if (result.responseText == "") { alert("Update is missing!"); return false; }
    return true;
}

function Search() {
    //var ss = rootPath + '/DailyProduction/GetProductionMasterList';
    var res = obj.loadtableFinder({
        url: rootPath + '/DailyProduction/GetSWProdList',
        values: '',
        ColumnHead: ['SWPID', 'ProductionDate', 'ShiftName', 'FurName', 'ItemName', 'QuantityPCS', 'QuantityKG'],
        ColumnVal: [
            { id: 'SWPID', hidden: true },
            { id: 'ProductionDate', hidden: false, type: 'date' },
            { id: 'ShiftName', hidden: false },
            { id: 'FurName', hidden: false },
            { id: 'ItemName', hidden: false },
            { id: 'QuantityPCS', hidden: false },
            { id: 'QuantityKG', hidden: false }
           
        ],
        CallBackFunction: function (selectedValue) {
            fNew();
            LoadProductionMasterList(selectedValue.SWPID)
            JQSWPQuality.setGridParam({ postData: { swpid: selectedValue.SWPID } });


            setTimeout(function () {

                var colSumTotalPices = JQSWPQuality.jqGrid("getCol", 'Quantity', false, 'sum');
                JQSWPQuality.jqGrid('footerData', 'set', { Quantity: 'Sum: ' + colSumTotalPices });                

            }, 1000);
            JQSWPQuality.trigger('reloadGrid', [{ swpid: selectedValue.SWPID }]);
        }
    });
    return false;
}


function fNew() {
    obj.RefreshControll();    
    JQSWPQuality.jqGrid("clearGridData", true);
}

function LoadProductionMasterList(SWPID) {
    var data = obj.Getdata({
        url: rootPath + '/DailyProduction/GetSWProdBySWPID',
        values: { 'swpid': SWPID }
    });
    if (data != 'null') {
        $('#SWPID').val(data.SWPID);
        $('#ProductionDate').val(MsgBox.FormatDateString(data.ProductionDate));
        $('#FurnaceID').val(data.FurnaceID);
        FurnaceChange(data.FurnaceID);
        $('#StationID').val(data.StationID);
        $('#ShiftID').val(data.ShiftID);

        $('#ProductionMIN').val(data.ProductionMIN);
        $('#ItemID').val(data.ItemID);
        $('#UnitWeightGM').val(data.UnitWeightGM);
        $('#BPM').val(data.BPM);
        $('#Section').val(data.Section);
        $('#QuantityPCS').val(data.QuantityPCS);

        $('#QuantityKG').val(data.QuantityKG);
        $('#Efficiency').val(data.Efficiency);
        $('#ProductionLossMIN').val(data.ProductionLossMIN);

        

        
        $('#Comment').val(data.Comment);

        ItemChange(data.ItemID);

    }
}

function Commit(){
    JQSWPQuality.triggerHandler("jqGridInlineAfterSaveRow", i), $.isFunction(i.aftersavefunc) && i.aftersavefunc.call(i), p = !0, JQSWPQuality.removeClass("jqgrid-new-row").unbind("keydown")
}