/// <reference path="mainfunction.js" />

var dateFormat;
var timeFormat;
var rootPath = GetRootPath();
var projectTitle;

function GetRootPath() {
    var scripts = document.getElementsByTagName('script');
    var path = scripts[scripts.length - 1].src.split('?')[0];
    path = path.split('/').slice(0, -4).join('/');
    return path;
}