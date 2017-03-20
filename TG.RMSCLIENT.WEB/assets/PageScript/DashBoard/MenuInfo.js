var obj = new Suraya();
$(function () {
    LoadLeftMenu();    
})

function LoadLeftMenu()
{
    var data = obj.Getdata({
        url: rootPath+'/DashBoard/Menu',
        values: {}
    });
    if(data!=0)
        $('#leftmenu').append(data);
    else
    {
        //var abc = '@Url.Action("Home","Search")';
        var url = rootPath + "/Account/LogOut";
        //window.location.href = abc;
        window.open(url);
    }
}