$(document).ready(function () {
    $('ul#menu li').hover(function () {
        $('#sub-menu').css("display", "inline");
    },
    function () {
        $('#sub-menu').css("display", "none");
    });
});