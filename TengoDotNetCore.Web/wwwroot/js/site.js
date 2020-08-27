//重新设置正方形图片的高度
function resizeSquare() {
    $(".square").each(function () {
        let width = $(this).width;
        $(this).height = width;
    });
}

//文档加载完成事件
$(function () {
    resizeSquare();
});

//浏览器窗口大小调整事件
window.onresize = function () {
    resizeSquare();
}   