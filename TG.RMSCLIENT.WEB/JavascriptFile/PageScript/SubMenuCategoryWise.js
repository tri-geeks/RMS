var obj = new Suraya();
$(function () {
    $('.navbar-admin').css({ 'background-color': '#444', 'padding': '10px 0' })
    LoadSubMenuTabItem($('#categoryName').val())
    $('.a').click(function () {
        var SubCategoryName = $(this).attr('href').replace('#', '');
        LoadAllSubCategoryItem(SubCategoryName);

    });
    

    $(document).on('click', 'a.cc', function () {
       
        $('#fade2').height($(window).height() - 20)
        var menuMane = $(this).attr('href').replace('#', '');
        ShowSingleMenuItem(menuMane)
        $('#fade2').fadeIn();
       
    });
    $('#ac').click(function () {
        $('#fade2').fadeOut();

    })
});

function ShowSingleMenuItem(menuMane) {

    var res = obj.Getdata_1({
        url: rootPath + '/FoodMenuCategoryWise/ShowSingleMenuItem',
        values: { 'menuName': menuMane },

    });
   
    $("#si").html("");
    $('#si').append(
           '<div class="col-lg-6 col-md-6">' +
                       '<img class="media-object" src="' +res.VirtualPath + '" alt="img">' +
                   '</div>' +

                   '<div id="si" class="col-lg-6 col-md-6">' +
                       '<h4> ' + res.MenuDetails + '</h4>' +
          '</div>')
}

function LoadSubMenuTabItem(categoryName) {
   //clear();
    var res = obj.Getdata_1({
        url: rootPath + '/FoodMenuCategoryWise/LoadSubMenuTabItem',
        values: { 'categoryName': categoryName },

    });
    var li = '';
    for (var i = 0; i < res.length; i++) {
        if (i == 0) {
            li += '<li class="active"><a href="#' + res[i].SubCategoryName.toLowerCase() + '" data-toggle="tab" class="a">' + res[i].SubCategoryName + '</a></li>';
            LoadAllSubCategoryItem(res[i].SubCategoryName.toLowerCase())
        }
        else {
            li += '<li><a href="#' + res[i].SubCategoryName.toLowerCase() + '" data-toggle="tab" class="a">' + res[i].SubCategoryName + '</a></li>';
        }
    }
    $('#ul').append(li);
}

function LoadAllSubCategoryItem(SubCategoryName) {
    //clear();
    $(".tab-pane").html("");
    res = obj.Getdata_1({
        url: rootPath + '/FoodMenuCategoryWise/LoadAllSubCategoryItem',
        values: { 'SubCategoryName': SubCategoryName },
    });
    var result = '';
    var div = '';
    div = '<div class="tab-pane fade in active" id="' + SubCategoryName + '">' +
                '<div class="mu-tab-content-area" id="1">' +
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
        if (i % 2 == 0) {
            liLeft += '<li>' +
                        '<div class="media">' +
                            '<div class="media-left">' +
                                '<a href="#" >' +
                                    '<img class="media-object" src="' + res[i].VirtualPathLeft + '" alt="img">' +
                                '</a>' +
                            '</div>' +
                            '<div class="media-body">' +
                                '<h4 class="media-heading"><a href="#' + res[i].MenuNameLeft + '" class="cc">' + res[i].MenuNameLeft + '</a></h4>' +
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
                                    '<img id="IMG" class="media-object" src="' + res[i].VirtualPathLeft + '" alt="img">' +
                                '</a>' +
                            '</div>' +
                            '<div class="media-body">' +
                                '<h4 class="media-heading"><a href="#'+ res[i].MenuNameLeft + '"class="cc">' + res[i].MenuNameLeft + '</a></h4>' +
                                '<span class="mu-menu-price">$' + res[i].PriceLeft + '</span>' +
                                '<p>' + res[i].MenuDetailsLeft + '</p>' +
                            '</div>' +
                        '</div>' +
                    '</li>';
        }
    }
    result = div + liLeft + '</ul> </div> </div>' + divRight + liRight + enddiv ;
    //$('#tabMenuDetails').append(result);

    setTimeout(function () {
        $('#tabMenuDetails').append(result);
    }, 500);
  
}
