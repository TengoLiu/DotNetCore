//alert弹窗的回调函数
var alertCallback;
//confirm弹窗的OK回调函数
var confirmOkCallback;
//confirm弹窗的Cancel回调函数
var confirmCancelCallback;

function dialogAlert(title, content, callback) {
    let alertbox = '<div class="dialog dialogAlert">'
        + '<div class="title">' + title + '<a class="exit" href="javascript:void(0)" onclick=\'$(".dialogAlert").remove();$(".dialog-cover").remove();\'>X</a></div>'
        + '<div class="content">' + content + '</div>'
        + '<div class="btns">';
    if (arguments.length == 3 && callback != 'undefined' && typeof callback == 'function') {
        alertCallback = callback;
        alertbox += '<a class="btn ok" href="javascript:void(0)" onclick=\'$(".dialogAlert").remove();$(".dialog-cover").remove();alertCallback();alertCallback=undefined;\'>确 定</a>'
    }
    else {
        alertbox += '<a class="btn ok" href="javascript:void(0)" onclick=\'$(".dialogAlert").remove();$(".dialog-cover").remove();\'>确 定</a>'
    }
    alertbox += '</div>'
    alertbox += '</div>';
    alertbox += '<div class="dialog-cover"></div>';
    $("body").append(alertbox);
}

function dialogConfirm(title, content, okCallback, cancelCallback) {
    console.log(arguments)
    let alertbox = '<div class="dialog dialogConfirm">'
        + '<div class="title">' + title + '<a class="exit" href="javascript:void(0)" onclick=\'$(".dialog").remove();$(".dialog-cover").remove();\'>X</a></div>'
        + '<div class="content">' + content + '</div>'
        + '<div class="btns">';
    if (arguments.length >= 3 && okCallback != 'undefined' && typeof okCallback == 'function') {
        confirmOkCallback = okCallback;
        alertbox += '<a class="btn ok" href="javascript:void(0)" onclick=\'confirmOkCallback();confirmOkCallback=undefined;$(".dialogConfirm").remove();$(".dialog-cover").remove();\'>确 定</a>'
    }
    else {
        alertbox += '<a class="btn ok" href="javascript:void(0)" onclick=\'$(".dialogConfirm").remove();$(".dialog-cover").remove();\'>确 定</a>'
    }
    if (arguments.length == 4 && cancelCallback != 'undefined' && typeof cancelCallback == 'function') {
        confirmCancelCallback = cancelCallback;
        alertbox += '<a class="btn cancel" href="javascript:void(0)" onclick=\'confirmCancelCallback();confirmCancelCallback=undefined;$(".dialogConfirm").remove();$(".dialog-cover").remove();\'>取 消</a>';
    }
    else {
        alertbox += '<a class="btn cancel" href="javascript:void(0)" onclick=\'$(".dialogConfirm").remove();$(".dialog-cover").remove();\'>取 消</a>';
    }
    alertbox += '</div>'
    alertbox += '</div>';
    alertbox += '<div class="dialog-cover"></div>';
    $("body").append(alertbox);
}