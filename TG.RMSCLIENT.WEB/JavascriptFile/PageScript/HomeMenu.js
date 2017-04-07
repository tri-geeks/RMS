var obj = new Suraya();
$(function () {
    LoadTabItem();
    LoadSixMenuItem();
});


function LoadTabItem() {
    obj.loaddropV({
        url: rootPath + '/Home/LoadTabItem',
        values: '',
        select: $('#FoodMenuTabItem')
    });
}

function LoadSixMenuItem() {
    obj.loaddropV({
        url: rootPath + '/Home/LoadSixMenuItem',
        values: '',
        select: $('#FoodMenuSixItem')
    });
}