var obj = new Suraya();
$(function () {
    LoadTabItem();
    LoadSixMenuItem();
});


function LoadTabItem() {
    var res = obj.Getdata({
        url: rootPath + '/ViewMenu/LoadFoodMenu',
        values: ''
        
    });
    var li = '';
   for (var i = 0; i < res.length; i++) {
       li += '<li class="active"><a href="#' + res[i].MCID + '" data-toggle="tab">' + res[i].CategoryName + '</a></li>';
   }
   $('#ul').append(li);

   //$('selector').on('click', function () {

   //})
}

function LoadSixMenuItem() {
    obj.loaddropV({
        url: rootPath + '/Home/LoadSixMenuItem',
        values: '',
        select: $('#FoodMenuSixItem')
    });
}