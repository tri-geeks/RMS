﻿var obj = new Suraya();
$(function () {
    LoadTabItemSubMenu();
    // LoadSixMenuItem();
    $('.a').click(function () {
        var categoryName = $(this).attr('href').replace('#', '');
        LoadSixMenuItem(categoryName);

    })
});


function LoadTabItemSubMenu(categoryId) {
    var res = obj.Getdata({
        url: rootPath + '/FoodMenuCategoryWiseController/LoadSubCategory',
        values: { 'categoryID': categoryId },

    });
    var li = '';
    for (var i = 0; i < res.length; i++) {
        if (i == 0) {
            li += '<li class="active"><a href="#' + res[i].CategoryID.toLowerCase() + '" data-toggle="tab" class="a">' + res[i].CategoryName + '</a></li>';
            LoadSixMenuItem(res[i].CategoryID.toLowerCase())
        }
        else {
            li += '<li><a href="#' + res[i].CategoryID.toLowerCase() + '" data-toggle="tab" class="a">' + res[i].CategoryName + '</a></li>';
        }
    }
    $('#ul').append(li);

    //$('selector').on('click', function () {

    //})
}

function LoadSixMenuItem(categoryName) {
    res = obj.Getdata({
        url: rootPath + '/FoodMenuCategoryWiseController/LoadAllSubCategoryItem',
        values: { 'categoryName': categoryID },
    });
    var result = '';
    var div = '';
    div = '<div class="tab-pane fade in active" id="' + res[0].CategoryID + '">' +
                '<div class="mu-tab-content-area">' +
                    '<div class="row">' +
                        '<div class="col-md-6">' +
                            '<div class="mu-tab-content-left">' +
                                '<ul class="mu-menu-item-nav">';
    var enddiv = '';
    enddiv = '</ul>' +
                        '</div>' +
                    '</div>' +
                '</div>' +
              '</div>' +
            '</div>';    
    var divRight = '';
    divRight = '<div class="col-md-6">  <div class="mu-tab-content-right"> <ul class="mu-menu-item-nav">';
    var liLeft = '';
    var liRight = '';
    for (var i = 0; i < res.length; i++) {
        if (i == 0 & i % 2 == 0) {
            liLeft += '<li>' +
                        '<div class="media">' +
                            '<div class="media-left">' +
                                '<a href="#">' +
                                    '<img class="media-object" src="' + res[i].ActualPathLeft + '" alt="img">' +
                                '</a>' +
                            '</div>' +
                            '<div class="media-body">' +
                                '<h4 class="media-heading"><a href="#">' + res[i].MenuNameLeft + '</a></h4>' +
                                '<span class="mu-menu-price">$' + res[i].PriceLeft + '</span>' +
                                '<p>' + res[i].MenuDetailsLeft + '</p>' +
                            '</div>' +
                        '</div>' +
                    '</li>';
        }
        else {
            liRight += '<li>' +
                        '<div class="media">' +
                            '<div class="media-left">' +
                                '<a href="#">' +
                                    '<img class="media-object" src="' + res[i].ActualPathRight + '" alt="img">' +
                                '</a>' +
                            '</div>' +
                            '<div class="media-body">' +
                                '<h4 class="media-heading"><a href="#">' + res[i].MenuNameRight + '</a></h4>' +
                                '<span class="mu-menu-price">$' + res[i].PriceRight + '</span>' +
                                '<p>' + res[i].MenuDetailsRight + '</p>' +
                            '</div>' +
                        '</div>' +
                    '</li>';
        }
    }
    result = div + liLeft + '</ul> </div> </div>' + divRight + liRight + enddiv ;
    $('#tabMenuDetails').append(result);

}
