var JQProductionDetails;

var obj = new Suraya();
var alerts = new UIStyle();

var EfficiencyRate = 0;
var PicesPerCartun = 0;
var UnitWeightGM = 0;
//-**********************-- on load--**********************
$(function () {
    //alert(rootPath);
    obj.DatePicker();
    GridName = 'JQProductionDetails';
    Gridfooter = 'Productionpager';
    ViewControl(true, true, true, true, true, true)

    JQProductionDetails = $('#JQProductionDetails');
    JQGetDailyProduction(JQProductionDetails);
    //***************--Save--**********************---------
    $('form').submit(function (e) {
        e.preventDefault();
        alert($('#ProductionDate').val())
        var formdata = new FormData(this);
        var prodlist = $('#JQProductionDetails').getRowData();
        obj.addListWithForm(formdata, prodlist, 'prodlist');
        obj.Save({
            url: rootPath+'/DailyProduction/DailyProductionCC',
            form: formdata
        });

    })

    //****************--Click Search--****************************
    $('#search').click(function () {
        Search();
    });
    //*******************--Change Event--**************************
    $('#ItemID').change(function () {
        ItemChange($('#ItemID').val())
    });
    
    $('#FurID').change(function () {
        FurnaceChange($('#FurID').val())
    });
});
//--****************************Clear Control--****************************-----
function fNew() {
    obj.RefreshControll();    
    //JQProductionDetails.jqGrid("clearGridData", true).trigger("reloadGrid");
    JQProductionDetails.jqGrid("clearGridData", true);
    EfficiencyRate = 0;
    PicesPerCartun = 0;
    UnitWeightGM = 0;
    $('#ProductionMasterID').val('');
    $('#TotalEfficiency').val('');
    $('#TotalKG').val('');
    $('#TotalPices').val('');
}
//---*********************************** JQ Grid--*****************************************
function JQGetDailyProduction(JQProductionDetails) {
    JQProductionDetails.jqGrid({
        url: rootPath + '/DailyProduction/GetProductionDetails',
        postData: { ProductionMasterID: '0' },
        datatype: "json",
        mtype: 'GET',
        colNames: ['ProductionID', 'ProductionMasterID', 'ShiftID', 'Eff-Rate', 'Section', 'Efficiency', 'PicesPerCartun', 'TotalCartun', 'TotalPices', 'UnitWeightGM', 'TotalWeightKG', 'Commit|Cancel'],
        colModel: [
            { name: 'ProductionID', index: 'ProductionID', key: false, width: 100, hidden: false },
            { name: 'ProductionMasterID', index: 'ProductionMasterID', key: false, width: 100, hidden: false },
            {
                name: 'ShiftID',
                index: 'ShiftID',
                width: 100,                
                sortable: true,
                align: 'center',
                editable: true,
                cellEdit: true,
                edittype: 'select',
                formatter: 'select',
                editoptions: { value: obj.JQGridDropDown({
                    url: rootPath+'/DailyProduction/GetQualityCbo',
                    values: ''
                    })
                }
            },
            {
                name: 'EfficiencyRate', index: 'EfficiencyRate', width: 100, editable: true, cellEdit: false, sorter: "number",
                align: "right",
                readOnly: true
            },
            { name: 'Section', index: 'Section', width: 100, editable: true, align: "right" },
            { name: 'Efficiency', index: 'Efficiency', width: 100, editable: false, align: "right" },
            { name: 'PicesPerCartun', index: 'PicesPerCartun', width: 100, align: "right" },
            { name: 'TotalCartun', index: 'TotalCartun', width: 100, editable: true, align: "right" },
            { name: 'TotalPices', index: 'TotalPices', width: 150, editable: false, align: "right" },
            { name: 'UnitWeightGM', index: 'UnitWeightGM', width: 100, align: "right" },
            { name: 'TotalWeightKG', index: 'TotalWeightKG', width: 150, editable: false, align: "right" },
            {
                name: 'LinkButton',
                formatter: function (cellvalue, options, rowObject) {
                    return "<a href='#' style='align:center'><span class='glyphicon glyphicon-ok'  style='color:green'></a>|<a href='#' class='glyphicon glyphicon-remove' style='color:red'></a>";
                }, sortable: false, align: 'left', width: 100, align: "center"
            },
        ],        
        sortname: 'ProductionID',
        viewrecords: true,
        sortorder: "asc",
        caption: "Production List",
        rowNum: 5,
        height: "100",
        loadonce: false,
        pager: "#Productionpager",
        footerrow: true,
        userDataOnFooter: true, 
        beforeSelectRow: function (rowid, e) {
            var selectedRow = JQProductionDetails.jqGrid('getRowData', rowid);
            var $self = $(this),
                $td = $(e.target).closest("td"),
                rowid = $td.closest("tr.jqgrow").attr("id"),
                iCol = $.jgrid.getCellIndex($td[0]),
                cm = $self.jqGrid("getGridParam", "colModel");

            JQProductionDetails.jqGrid("setCell", rowid, 'EfficiencyRate', EfficiencyRate);
            JQProductionDetails.jqGrid("setCell", rowid, 'PicesPerCartun', PicesPerCartun);
            JQProductionDetails.jqGrid("setCell", rowid, 'UnitWeightGM', UnitWeightGM);

            if (cm[iCol].name === "LinkButton" && e.target.tagName.toUpperCase() === "A") {
                jQuery('#JQProductionDetails').jqGrid('restoreRow', rowid)
                return false; // don't select the row on click
            }
            if (cm[iCol].name === "LinkButton" && e.target.tagName.toUpperCase() === "SPAN") {
                //var selectedRow = JQProductionDetails.jqGrid('getRowData', rowid); 
                
                
                jQuery('#JQProductionDetails').jqGrid('saveRow', rowid)
                //********************--Calculated Column--****************************
                var EffRate = parseFloat(JQProductionDetails.jqGrid("getCell", rowid, 'EfficiencyRate'));
                var Section = parseFloat(JQProductionDetails.jqGrid("getCell", rowid, 'Section'));
                var PPerCartun = parseFloat(JQProductionDetails.jqGrid("getCell", rowid, 'PicesPerCartun'));
                var TotalCart = parseFloat(JQProductionDetails.jqGrid("getCell", rowid, 'TotalCartun'));
                var uweight = parseFloat(JQProductionDetails.jqGrid("getCell", rowid, 'UnitWeightGM'));

                JQProductionDetails.jqGrid("setCell", rowid, 'TotalPices', PPerCartun * TotalCart);
                var TPices = parseFloat(JQProductionDetails.jqGrid("getCell", rowid, 'TotalPices'));

                JQProductionDetails.jqGrid("setCell", rowid, 'Efficiency', (TPices / (EffRate * Section * 480) * 100).toFixed(2));
                JQProductionDetails.jqGrid("setCell", rowid, 'TotalWeightKG', (TPices * uweight / 1000).toFixed(2));

                //*********************------Summary-----********************************************               

                var colSumTotalWeightKG = JQProductionDetails.jqGrid("getCol", 'TotalWeightKG', false, 'sum');
                var colSumTotalCartun = JQProductionDetails.jqGrid("getCol", 'TotalCartun', false, 'sum');
                var colSumTotalPices = JQProductionDetails.jqGrid("getCol", 'TotalPices', false, 'sum');
                var colSumEfficiency = JQProductionDetails.jqGrid("getCol", 'Efficiency', false, 'sum');
                var rowno = parseFloat(JQProductionDetails.getGridParam("reccount"))

                JQProductionDetails.jqGrid('footerData', 'set', { TotalPices: 'Sum: ' + colSumTotalPices });
                JQProductionDetails.jqGrid('footerData', 'set', { TotalWeightKG: 'Sum: ' + colSumTotalWeightKG });
                JQProductionDetails.jqGrid('footerData', 'set', { TotalCartun: 'Sum: ' + colSumTotalCartun });
                JQProductionDetails.jqGrid('footerData', 'set', { Efficiency: 'Avg: ' + colSumEfficiency / rowno + '%' });

                $('#TotalEfficiency').val(colSumEfficiency / rowno);
                $('#TotalKG').val(colSumTotalWeightKG);
                $('#TotalPices').val(colSumTotalPices);
              
                //JQProductionDetails.getGridParam("reccount")
                //alert(JQProductionDetails.getGridParam("reccount"))
                return false;
            }
        },      
        
    });
}

function ItemChange(item)
{    
    var data = obj.Getdata({
        url: rootPath+'/DailyProduction/GetItemPropertiesByItemCode',
        values: { 'ItemID': item }
    });
    if (data != 'null') {
        UnitWeightGM = data.Weight;
        PicesPerCartun = data.PerCartunQty;
        EfficiencyRate = data.ProductionRatePerMin;
        
    }
}

function FurnaceChange(furnace) {
    obj.loaddropV({
        url: rootPath+'/DailyProduction/GetStation',
        values: { 'furID': furnace },
        select: $('#StationID')
    });
}

function Search() {
    var ss = rootPath + '/DailyProduction/GetProductionMasterList';
    var res = obj.loadtableFinder({
        url: rootPath+'/DailyProduction/GetProductionMasterList',
        values: '',
        ColumnHead: ['Master Id', 'Prod-Date', 'Furnace', 'StationName', 'ItemName', 'TotalPices', 'TotalKG', 'TotalEfficiency'],
        ColumnVal: [
            { id: 'ProductionMasterID', hidden: true },
            { id: 'ProductionDate', hidden: false,type:'date' },
            { id: 'FurName', hidden: false },
            { id: 'StationName', hidden: false },
            { id: 'ItemName', hidden: false },
            { id: 'TotalPices', hidden: false },
            { id: 'TotalKG', hidden: false },
            { id: 'TotalEfficiency', hidden: false }
        ],
        CallBackFunction: function (selectedValue) {
            fNew();
            LoadProductionMasterList(selectedValue.ProductionMasterID)
            JQProductionDetails.setGridParam({ postData: { ProductionMasterID: selectedValue.ProductionMasterID } });
            
            
            setTimeout(function () {
                var colSumTotalWeightKG = JQProductionDetails.jqGrid("getCol", 'TotalWeightKG', false, 'sum');
                var colSumTotalCartun = JQProductionDetails.jqGrid("getCol", 'TotalCartun', false, 'sum');
                var colSumTotalPices = JQProductionDetails.jqGrid("getCol", 'TotalPices', false, 'sum');
                var colSumEfficiency = JQProductionDetails.jqGrid("getCol", 'Efficiency', false, 'sum');
                var rowno = parseFloat(JQProductionDetails.getGridParam("reccount"));

                JQProductionDetails.jqGrid('footerData', 'set', { TotalPices: 'Sum: ' + colSumTotalPices });
                JQProductionDetails.jqGrid('footerData', 'set', { TotalWeightKG: 'Sum: ' + colSumTotalWeightKG });
                JQProductionDetails.jqGrid('footerData', 'set', { TotalCartun: 'Sum: ' + colSumTotalCartun });
                JQProductionDetails.jqGrid('footerData', 'set', { Efficiency: 'Avg: ' + colSumEfficiency / rowno + '%' });
                
            }, 1000);
            JQProductionDetails.trigger('reloadGrid', [{ ProductionMasterID: selectedValue.ProductionMasterID }]);
        }
    });
    return false;
}

function LoadProductionMasterList(ProductionMasterID) {
    var data = obj.Getdata({
        url: rootPath+'/DailyProduction/GetProductionMaster',
        values: { 'ProductionMasterID': ProductionMasterID }
    });
    if (data != 'null') {
        $('#ProductionMasterID').val(data.ProductionMasterID);
        $('#TotalEfficiency').val(data.TotalEfficiency);
        $('#TotalKG').val(data.TotalKG);
        $('#TotalPices').val(data.TotalPices);
        $('#ProductionDate').val(alerts.FormatDateString(data.ProductionDate));
        $('#ItemID').val(data.ItemID);
        $('#LossMin').val(data.LossMin);
        $('#FurID').val(data.FurID);

        FurnaceChange(data.FurID);

        $('#StationID').val(data.StationID);
        $('#Remark').val(data.Remark);

        ItemChange(data.ItemID);
        
    }
}

