/// <summary>
/// 说明：tengo自制分页控件
/// </summary>
/// <param name="count">记录总数</param>
/// <param name="pageSize">页长，每一页记录数</param>
/// <param name="page">当前位置</param>
/// <param name="urlPrefix">需要拼接的地址前缀，需包含作为分页依据的参数，
///                         一般不能包含别的Get参数，例如：/Home/Search.html?page=</param>
///                         
/// <param name="urlPostfix">需要拼接的地址后缀,这里放get的参数,例如：&key_word=电脑</param>
/// <returns></returns>
function getPager(count, pageSize, page, urlPrefix, urlPostfix) {
    if (!checkNumber(count))
        count = 0;
    if (!checkNumber(pageSize))
        pageSize = 10;
    if (!checkNumber(page))
        page = 1;

    count = parseInt(count);
    pageSize = parseInt(pageSize);
    page = parseInt(page);

    if (count <= 0) return "";
    if (page <= 0) {
        page = 1;
    }
    if (pageSize <= 0) {
        pageSize = 10;
    }
    //拼接一个pageSize参数，避免参数丢失
    urlPostfix = "&pageSize=" + pageSize + urlPostfix;
    var sb = "";

    sb += "<div class='pager'>";//最外层包裹一个div

    //拼接上一页按钮
    if (page == 1 || count == 0) {
        sb += "<span class='page_off'>上一页</span>";
    }
    else {
        sb += "<a href='" + urlPrefix + (page - 1) + urlPostfix + "'>上一页</a>";
    }

    var pageCount = count % pageSize == 0 ? parseInt(count / pageSize) : parseInt(count / pageSize + 1);//计算总页数

    if (pageCount <= 8) {
        //个数小于或等于8个的话，就不需要显示“...”了
        for (var i = 1; i <= pageCount; i++) {
            if (page == i) {
                sb += "<a class='p_selected'>" + i + "</a>";
            }
            else {
                sb += "<a href='" + urlPrefix + i + urlPostfix + "'>" + i + "</a>";
            }
        }
    }
    else {
        /*
         * 需要判断当前页处于什么位置，如果有大于等于6和小于6之分
         *  page<6 全打印
         *  1 2 3 4 5 6 7 8 ...  
         *  page>=6
         *  1 2 ...4 5 6 7 8...  page<pageCount-2 打印 6+-2   
         *  1 2 ...8 9 10 11 12  page>=pageCount-2
        */
        if (page < 6) {
            for (var i = 1; i <= 7; i++) {
                if (page == i) {
                    sb += "<a class='p_selected'>" + i + "</a>";
                }
                else {
                    sb += "<a href='" + urlPrefix + i + urlPostfix + "'>" + i + "</a>";
                }
            }
            sb += "<span> ... </span>";
        }
        else {
            sb += "<a href='" + urlPrefix + 1 + urlPostfix + "'>1</a>";
            sb += "<a href='" + urlPrefix + 2 + urlPostfix + "'>2</a>";
            sb += "<span> ... </span>";
            if (page + 2 < pageCount) {
                /*1 2 ... 4 5 6 7 8 ...*/
                sb += "<a href='" + urlPrefix + (page - 2) + urlPostfix + "'>" + (page - 2) + "</a>";
                sb += "<a href='" + urlPrefix + (page - 1) + urlPostfix + "'>" + (page - 1) + "</a>";
                sb += "<a class='p_selected'>" + page + "</a>";
                sb += "<a href='" + urlPrefix + (page + 1) + urlPostfix + "'>" + (page + 1) + "</a>";
                sb += "<a href='" + urlPrefix + (page + 2) + urlPostfix + "'>" + (page + 2) + "</a>";
                sb += "<span> ... </span>";
            }
            else {
                for (var i = pageCount - 5; i <= pageCount; i++) {
                    if (i == page) {
                        sb += "<a class='p_selected'>" + i + "</a>";
                    }
                    else {
                        sb += "<a href='" + urlPrefix + i + urlPostfix + "'>" + i + "</a>";
                    }
                }
            }
        }
    }

    //拼接下一页按钮
    if (page == pageCount || count == 0) {
        sb += "<span class='page_off'>下一页</span>";
    }
    else {
        sb += "<a href='" + urlPrefix + (page + 1) + urlPostfix + "'>下一页</a>";
    }

    // 拼接跳转到某一页表单
    sb += "<form class='pager_form'>";
    sb += "跳转到：<input type='text' min='1' max ='" + pageCount + "' name='page'/>";
    sb += "每页显示 <input type='text' min='1' value ='" + pageSize + "' name='pageSize'/>条记录，";
    var params = urlPostfix.split('&');//从后缀里面取出参数

    if (params.length > 0) {
        for (var i = 0; i < params.length; i++) {
            var index = params[i].indexOf("=");
            if (index < 0)
                continue;
            sb += "<input type='hidden' name='" + params[i].substring(0, index) + "' value='" + params[i].substring(index + 1) + "'/>";
        }
    }
    sb += "<button class='page_to'>确定</button>";

    sb += "</form>";

    sb += " <b>共" + count + "条记录，共" + pageCount + "页</b>";

    sb += "</div>";
    return sb;
}

/// <summary>
/// 说明：tengo自制分页控件
/// </summary>
/// <param name="count">记录总数</param>
/// <param name="pageSize">页长，每一页记录数</param>
/// <param name="page">当前位置</param>
/// <param name="urlPrefix">需要拼接的地址前缀，需包含作为分页依据的参数，
///                         一般不能包含别的Get参数，例如：/Home/Search.html?page=</param>
///                         
/// <param name="urlPostfix">需要拼接的地址后缀,这里放get的参数,例如：&key_word=电脑</param>
/// <returns></returns>
function getPagerWithoutHref(count, pageSize, page, urlPrefix, urlPostfix) {
    if (!checkNumber(count))
        count = 0;
    if (!checkNumber(pageSize))
        pageSize = 10;
    if (!checkNumber(page))
        page = 1;

    count = parseInt(count);
    pageSize = parseInt(pageSize);
    page = parseInt(page);

    if (count <= 0) return "";
    if (page <= 0) {
        page = 1;
    }
    if (pageSize <= 0) {
        pageSize = 10;
    }

    var sb = "";

    sb += "<div class='pager'>";//最外层包裹一个div

    //拼接上一页按钮
    if (page == 1 || count == 0) {
        sb += "<span class='page_off'>上一页</span>";
    }
    else {
        sb += "<a " + urlPrefix + (page - 1) + urlPostfix + ">上一页</a>";
    }

    var pageCount = count % pageSize == 0 ? parseInt(count / pageSize) : parseInt(count / pageSize + 1);//计算总页数

    if (pageCount <= 8) {
        //个数小于或等于8个的话，就不需要显示“...”了
        for (var i = 1; i <= pageCount; i++) {
            if (page == i) {
                sb += "<a class='p_selected'>" + i + "</a>";
            }
            else {
                sb += "<a " + urlPrefix + i + urlPostfix + ">" + i + "</a>";
            }
        }
    }
    else {
        /*
         * 需要判断当前页处于什么位置，如果有大于等于6和小于6之分
         *  page<6 全打印
         *  1 2 3 4 5 6 7 8 ...  
         *  page>=6
         *  1 2 ...4 5 6 7 8...  page<pageCount-2 打印 6+-2   
         *  1 2 ...8 9 10 11 12  page>=pageCount-2
        */
        if (page < 6) {
            for (var i = 1; i <= 7; i++) {
                if (page == i) {
                    sb += "<a class='p_selected'>" + i + "</a>";
                }
                else {
                    sb += "<a " + urlPrefix + i + urlPostfix + ">" + i + "</a>";
                }
            }
            sb += "<span> ... </span>";
        }
        else {
            sb += "<a " + urlPrefix + 1 + urlPostfix + ">1</a>";
            sb += "<a " + urlPrefix + 2 + urlPostfix + ">2</a>";
            sb += "<span> ... </span>";
            if (page + 2 < pageCount) {
                /*1 2 ... 4 5 6 7 8 ...*/
                sb += "<a " + urlPrefix + (page - 2) + urlPostfix + ">" + (page - 2) + "</a>";
                sb += "<a " + urlPrefix + (page - 1) + urlPostfix + ">" + (page - 1) + "</a>";
                sb += "<a class='p_selected'>" + page + "</a>";
                sb += "<a " + urlPrefix + (page + 1) + urlPostfix + ">" + (page + 1) + "</a>";
                sb += "<a " + urlPrefix + (page + 2) + urlPostfix + ">" + (page + 2) + "</a>";
                sb += "<span> ... </span>";
            }
            else {
                for (var i = pageCount - 5; i <= pageCount; i++) {
                    if (i == page) {
                        sb += "<a class='p_selected'>" + i + "</a>";
                    }
                    else {
                        sb += "<a " + urlPrefix + i + urlPostfix + ">" + i + "</a>";
                    }
                }
            }
        }
    }

    //拼接下一页按钮
    if (page == pageCount || count == 0) {
        sb += "<span class='page_off'>下一页</span>";
    }
    else {
        sb += "<a " + urlPrefix + (page + 1) + urlPostfix + ">下一页</a>";
    }
    sb += " <b>共" + count + "条记录，共" + pageCount + "页</b>";
    sb += "</div>";
    return sb;
}

/* 返回一个值是否是数字类型 */
function checkNumber(value) {
    if (isNaN(value) || value == "") {
        return false;
    }
    else {
        return true;
    }
}
