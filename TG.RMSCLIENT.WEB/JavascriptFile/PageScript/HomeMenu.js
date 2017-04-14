var obj = new Suraya();
$(function () {
    LoadTabItem();
   // LoadSixMenuItem();
    $('.a').click(function () {
        var categoryName = $(this).attr('href').replace('#', '');
        LoadSixMenuItem(categoryName);
        
    })
});


function LoadTabItem() {
    var res = obj.Getdata({
        url: rootPath + '/ViewMenu/LoadFoodMenu',
        values: ''
        
    });
    var li = '';
    for (var i = 0; i < res.length; i++) {
        if (i == 0) {
            li += '<li class="active"><a href="#' + res[i].CategoryName.toLowerCase() + '" data-toggle="tab" class="a">' + res[i].CategoryName + '</a></li>';
            LoadSixMenuItem(res[i].CategoryName.toLowerCase())
        }
        else {
            li += '<li><a href="#' + res[i].CategoryName.toLowerCase() + '" data-toggle="tab" class="a">' + res[i].CategoryName + '</a></li>';
        }
    }
    $('#ul').append(li);

   //$('selector').on('click', function () {

   //})
}

function LoadSixMenuItem(categoryName) {
    var footerdiv = '';
    var divRight = '';
    var liLeft = '';
    var liRight = '';
    var div = '';
    var enddiv = '';
    var result = '';
    res = obj.Getdata({
        url: rootPath + '/ViewMenu/LoadSixMenuItem',
        values: {'categoryName':categoryName},
    });
    
    div = '<div class="tab-pane fade in active" id="' + categoryName + '">' +
                '<div class="mu-tab-content-area">'+
                    '<div class="row">'+
                        '<div class="col-md-6">'+
                            '<div class="mu-tab-content-left">'+
                                '<ul class="mu-menu-item-nav">';
    
    enddiv = '</ul>' +
                        '</div>' +
                    '</div>' + 
                '</div>' +
              '</div>' +
            '</div>';
    
    footerdiv = '<a href="' + rootPath + '/FoodMenuCategoryWise/Index?categoryName=' + categoryName + '"> Read More </a> ';
    
    divRight = '<div class="col-md-6">  <div class="mu-tab-content-right"> <ul class="mu-menu-item-nav">';
    
    for (var i = 0; i < res.length; i++) {
        liLeft += '<li>' +
                    '<div class="media">' +
                        '<div class="media-left">' +
                            '<a href="#">' +
                                '<img class="media-object" src="' + res[i].ActualPathLeft + '" alt="img">' +
                            '</a>' +
                        '</div>' +
                        '<div class="media-body">' +
                            '<h4 class="media-heading"><a href="#">'+res[i].MenuNameLeft+'</a></h4>' +
                            '<span class="mu-menu-price">$' + res[i].PriceLeft + '</span>' +
                            '<p>' + res[i].MenuDetailsLeft + '</p>' +
                        '</div>' +
                    '</div>' +
                '</li>';

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
    result = div + liLeft + '</ul> </div> </div>' + divRight + liRight + enddiv + footerdiv;
    $('#tabMenuDetails').append(result);

    }