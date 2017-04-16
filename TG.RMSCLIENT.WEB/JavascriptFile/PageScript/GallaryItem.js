var obj = new Suraya();
$(function () {
    LoadGallaryItem();
});

function LoadGallaryItem() {
    var res = obj.Getdata({
        url: rootPath + '/DashBoard/LoadGallaryItem',
        values: ''
    });
    var gallaryItem = '';
    for (var i = 0; i < res.length; i++) {
        gallaryItem += '<div class="mu-single-gallery col-md-4">' +
                '<div class="mu-single-gallery-item">' +
                    '<figure class="mu-single-gallery-img">' +
                        '<a href="#"><img alt="img" src="' + res[i].VirtualPathLeft + '"></a>' +
                    '</figure>' +
                    '<div class="mu-single-gallery-info">' +
                        '<a href="#" class="mu-view-btn">' +
                            '<img src="assets/img/plus.png" alt="plus icon img">' +
                        '</a>' +
                        '<div class="portfolio-detail">' +
                            '<a href="#" class="modal-close-btn"><span class="fa fa-times"></span></a>' +
                            '<img src="' + res[i].VirtualPathLeft + '" alt="img-1" />' +
                            '<h2>Gallery Item Title</h2>' +
                            '<p>' + res[i].MenuDetailsLeft + '</p>' +
                            '<a href="#" class="view-project-btn">Live Demo</a>' +
                        '</div>' +
                    '</div>' +
                '</div>' +
              '</div>'
    }
    $('#gallaryItem').append(gallaryItem);

}