/*发送Ajax请求 开始*/
function ajax(url, type, data, success, error) {
    $.ajax({
        url: url,
        type: type,//get/post
        dataType: "Json",
        data: data,
        success: function (data) {
            if (success != undefined && typeof success == 'function') {
                success(data);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            if (error != undefined && typeof error == 'function') {
                error();
            }
            else {
                //输出整个请求的对象，其中就包含了请求和响应的数据，很全
                console.log(XMLHttpRequest);
                //输出请求结果文本
                console.log(textStatus);
                //输出抛出的异常文本信息
                console.log(errorThrown);
            }
        }
    });
}
/*发送Ajax请求 结束*/


/*截取固定长度的字符串，超过则隐藏*/
function subStr(str, length) {
    if (isNullOrUndefinedOrEmpty(str)) return "";
    else
        return str.length > length ? (str.substring(0, length) + "...") : str;
}


/***********内容格式验证 开始***************/

/* 判断一个值是否存在或未初始化或为空 */
function isNullOrUndefinedOrEmpty(value) {
    if (value == null || value == undefined || value.length === 0) {
        return true;
    }
    else {
        return false;
    }
}

/* 返回一个值是否是数字类型 */
function isNumber(value) {
    if (isNaN(value) || value == "") {
        return false;
    }
    else {
        return true;
    }
}

/* 返回一个值是否是Text并且长度大于0 */
function isText(value) {
    if (value == undefined || value == "") {
        return false;
    }
    else {
        return true;
    }
}

/* 检查一个值是否是日期yyyy-M(M)-d(d) 格式 如:2016-1-1、2016-01-1、2016-12-21等 */
function isDate(value) {
    reg = /^((?:19|20)\d\d)-((0[1-9]|[1-9])|1[012])-((0[1-9]|[1-9])|[12][0-9]|3[01])$/;
    if (reg.test(value)) {
        return true;
    }
    else
        return false;
}

/* 检查一个值如:2016-1-1、2016/1/1 等是否是正确的时间值，比如 2015/2/29 就不是 */
function isTrueDate(date) {
    return (new Date(date).getDate() == date.substring(date.length - 2));
}

/* 判断一个值是否是手机号 */
function isPhone(value) {
    var reg = /^1[1|2|3|4|5|6|7|8|9][0-9]\d{4,8}$/;
    return reg.test(value);
}

/* 判断一个值是否是固定号码 */
function isTelephone(value) {
    var reg = /^(([0+]d{2,3}-)?(0d{2,3})-)(d{7,8})(-(d{3,}))?$/;
    return reg.test(value);
}

/***********内容格式验证 结束***************/


//获取当前url剔除掉域名部分
function getUrl() {
    var path = location.pathname;
    var params = location.search;
    return (path + params);
}

//获取地址栏的get参数
function getUrlParam(name) {
    var reg = new RegExp("(^|\\?|&)" + name + "=([^&]*)(\\s|&|$)", "i");
    if (reg.test(location.href)) return unescape(RegExp.$2.replace(/\+/g, " "));
    return "";
};

//获取url参数
function getUrlParams() {
    return location.search;
}

//获取缩略图
function getThumb(url, width, height) {
    if (url.indexOf("merchant") >= 0) {
        return isText(url) && isNumber(width) && isNumber(height) ? url.replace("/upload/merchant/", "/upload/merchant/thumb_" + width + "x" + height + "/") : url;
    }
    else {
        return isText(url) && isNumber(width) && isNumber(height) ? url.replace("/upload/", "/upload/thumb_" + width + "x" + height + "/") : url;
    }
}

//Date类型的格式化
Date.prototype.format = function (format) {
    var o = {
        "M+": this.getMonth() + 1, //month
        "d+": this.getDate(),    //day
        "h+": this.getHours(),   //hour
        "m+": this.getMinutes(), //minute
        "s+": this.getSeconds(), //second
        "q+": Math.floor((this.getMonth() + 3) / 3),  //quarter
        "S": this.getMilliseconds() //millisecond
    }
    if (/(y+)/.test(format)) format = format.replace(RegExp.$1,
    (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o) if (new RegExp("(" + k + ")").test(format))
        format = format.replace(RegExp.$1,
        RegExp.$1.length == 1 ? o[k] :
        ("00" + o[k]).substr(("" + o[k]).length));
    return format;
}