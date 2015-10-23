$(document).ready(function () {

    var url = document.location.href;

    $.each($("#menu li a"), function () {
        if (this.href == url) { $(this).addClass('active'); };

    });

    $.each($(".sub-menu-guides li a"), function () {
        alert(url);
        if (this.href == url) { $(this).addClass('active-sub'); };
    });
});