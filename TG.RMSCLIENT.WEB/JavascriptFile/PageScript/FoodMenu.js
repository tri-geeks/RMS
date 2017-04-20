var obj = new Suraya();
var JQFoodMenuList;
$(function () {
    LoadFoodSubMenu();
    LoadFoodbMenu();
    JQFoodMenuList = $('#JQFoodMenuList');
    FoodMenuList(JQFoodMenuList);




    //*********************Upload*******************************
    $('#upload').click(function () {
        Upload()
    });
    $('#remove').click(function () {
        Remove();
    });
    //***************--Save--**********************---------
    $('form').submit(function (e) {
        e.preventDefault();
        var formData = new FormData(this);       
        obj.Save({
            url: rootPath + '/FoodMenu/FoodChartMenu',
            form: formData
        });

        JQFoodMenuList.trigger("reloadGrid");

    })
});

function LoadFoodbMenu() {
    obj.loaddropV({
        url: rootPath + '/FoodMenu/LoadFoodMenu',
        values: '',
        select: $('#FoodMenu')
    });
}

function LoadFoodSubMenu() {
    obj.loaddropV({
        url: rootPath + '/FoodMenu/LoadFoodSubMenu',
        values: '',
        select: $('#FoodSubMenu')
    });
}

function FoodMenuList(JQFoodMenuList) {
    JQFoodMenuList.jqGrid({
            url: rootPath + '/FoodMenu/GetFoodMenuList',
            mtype: "GET",
            styleUI: 'Bootstrap',
            datatype: "json",
            colModel: [
                { label: 'MenuID', name: 'MenuID', key: true, width: 75, hidden: true },
                { label: 'Menu Category ID', name: 'MenuCategoryID', width: 150, hidden: true },
                { label: 'Category', name: 'CategoryName', width: 150 },
                { label: 'Sub Category ID', name: 'Sub_Category', width: 150, hidden: true },
                { label: 'Sub Category', name: 'SubCategoryName', width: 150 },
                { label: 'Menu Name', name: 'MenuName', width: 150 },
                { label: 'Menu Details', name: 'MenuDetails', width: 250, editable: false  },
                { label: 'VirtualPath', name: 'VirtualPath', width: 150, editable: false, hidden: true },
                { label: 'ActualPath', name: 'ActualPath', width: 150, editable: false, hidden: true },
                { label: 'Currency', name: 'Currency', width: 150, editable: false },
                { label: 'Price', name: 'Price', width: 150, editable: false },
                { label: 'IsAbout', name: 'IsAbout', width: 60, formatter: 'checkbox', align: "center", hidden: true },
                { label: 'IsGallary', name: 'IsGallary', width: 60, formatter: 'checkbox', align: "center", hidden: true },

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
            pager: "#JQFoodMenuPager",
            beforeSelectRow: function (rowid, e) {
                var $self = $(this),
                    $td = $(e.target).closest("td"),
                    rowid = $td.closest("tr.jqgrow").attr("id"),
                    iCol = $.jgrid.getCellIndex($td[0]),
                    cm = $self.jqGrid("getGridParam", "colModel");
                if (cm[iCol].name === "LinkButton" && e.target.tagName.toUpperCase() === "A") {
                    JQFoodMenuList.jqGrid('restoreRow', rowid)
                    return false;
                }
                if (cm[iCol].name === "LinkButton" && e.target.tagName.toUpperCase() === "SPAN") {
                    var selectedRow = JQFoodMenuList.jqGrid('getRowData', rowid);
                    LoadControll(selectedRow)
                    return false;
                }
            }
        });
    }

    //****************--Load Data in control************------
    function LoadControll(res) {
        $('#MenuID').val(res.MenuID);
        $('#FoodMenu').val(res.MenuCategoryID);
        $('#FoodSubMenu').val(res.Sub_Category);
        $('#MenuName').val(res.MenuName);
        $('#MenuDetails').val(res.MenuDetails);
        $('#VirtualPath').val(res.VirtualPath);
        $('#ActualPath').val(res.ActualPath);
        $('#Currency').val(res.Currency);
        $('#Price').val(res.Price);

        $("#IMG").fadeIn("fast").attr('src', '')
        $('#IMG').attr('src', '' + res.VirtualPath + '');

        if (res.IsAbout == 1 || res.IsAbout == 'Yes')
            $('#IsAbout').prop("checked", true);
        else
            $('#IsAbout').prop("checked", false);

        if (res.IsGallary == 1 || res.IsGallary == 'Yes')
            $('#IsGallary').prop("checked", true);
        else
            $('#IsGallary').prop("checked", false);
    }

    function Upload() {
        $('#up').trigger('click', $('input[type=file]').change(function () {
            $("#IMG").fadeIn("fast").attr('src', '')
            $("#IMG").fadeIn("fast").attr('src', URL.createObjectURL(event.target.files[0]))

        }))
    }
    function Remove() {
        $("#IMG").fadeIn("fast").attr('src', '')
    }

    function fNew() {
        clear();
    }

    function clear() {
        $('form').find('input:text, input:password, input:file, select, textarea').val('');
        $("#IMG").fadeIn("fast").attr('src', '')
        $('#IsAbout').prop("checked", false);
        $('#IsGallary').prop("checked", false);
    };
