var obj = new Suraya();
$(function () {
    LoadBarItem();  
});


//function LoadBarItem() {
//    var res = obj.Getdata({
//        url: rootPath + '/ViewMenu/LoadBarItem',
//        values: ''
        
//    });
//    var li = '';
//    for (var i = 0; i < res.length; i++) {
        
//        li += '<li>'+
//                '<div class="mu-single-chef">' +
//                    '<figure class="mu-single-chef-img">'+
//                        '<img src="' + res[i].VirtualPath + '" alt="chef img">' +
//                    '</figure>'+
//                    '<div class="mu-single-chef-info">'+
//                        '<h4>' + res[i].MenuName + '</h4>' +
//                        '<span>$' + res[i].Price + '</span>' +
//                    '</div>'+              
//                 '</div>'+
//              '</li>'
//    }
//    $('#barul').append(li);

//    //$('selector').on('click', function () {

//    //})
//}

function LoadBarItem() {
       var footerdiv = '';
    var divRight = '';
    var liLeft = '';
    var liRight = '';
    var div = '';
    var enddiv = '';
    var result = '';
    res = obj.Getdata({
        url: rootPath + '/ViewMenu/LoadBarItem',
        values:'',
    });

    div = ' <div class="tab-pane fade in active" id="bar">' +
                '<div class="mu-tab-content-area">' +
                    '<div class="row">' +
                        '<div class="col-md-6">' +
                            '<div class="mu-tab-content-left">' +
                                '<ul class="mu-menu-item-nav">';

    enddiv = '</ul>' +
                        '</div>' +
                    '</div>' +
                '</div>' +
              '</div>' +
            '</div>';

    //footerdiv = '<a class="remove" href="' + rootPath + '/FoodMenuCategoryWise/Index?categoryName=' + categoryName + '"> Read More </a> ';

    divRight = '<div class="col-md-6">  <div class="mu-tab-content-right"> <ul class="mu-menu-item-nav">';

    for (var i = 0; i < res.length; i++) {
        if (i % 2 == 0) {
            liLeft += '<li>' +
                        '<div class="media">' +
                            '<div class="media-left">' +
                                '<a href="#">' +
                                    '<img class="media-object" src="' + res[i].VirtualPath + '" alt="img">' +
                                '</a>' +
                            '</div>' +
                            '<div class="media-body">' +
                                '<h4 class="media-heading"><a href="#">' + res[i].MenuName + '</a></h4>' +
                                '<span class="mu-menu-price">$' + res[i].Price + '</span>' +
                                '<p>' + res[i].MenuDetails + '</p>' +
                            '</div>' +
                        '</div>' +
                    '</li>';
        }
        else {
            liRight += '<li>' +
                        '<div class="media">' +
                            '<div class="media-left">' +
                                '<a href="#">' +
                                    '<img class="media-object" src="' + res[i].VirtualPath + '" alt="img">' +
                                '</a>' +
                            '</div>' +
                            '<div class="media-body">' +
                                '<h4 class="media-heading"><a href="#">' + res[i].MenuName + '</a></h4>' +
                                '<span class="mu-menu-price">$' + res[i].Price + '</span>' +
                                '<p>' + res[i].MenuDetails + '</p>' +
                            '</div>' +
                        '</div>' +
                    '</li>';
        }
    }
    result = div + liLeft + '</ul> </div> </div>' + divRight + liRight + enddiv + footerdiv;


    setTimeout(function () {
        $('#barul').append(result);
    }, 500);

}

