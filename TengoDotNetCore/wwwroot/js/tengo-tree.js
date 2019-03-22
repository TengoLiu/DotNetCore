//树状分类的html
var tree = '';
//数据集合
var treedata = new Array();

//创建结点的方法，用于递归调用生成树
function createTrNode(parID) {
    for (var i = 0; i < treedata.length; i++) {
        if (treedata[i].ParID === parID) {
            //定义空格占位符,用来填补开始处偏移的位置
            var space = "";
            //如果不是一级结点的话,要弄一点偏移
            if (treedata[i].ParID > 0) {
                for (var j = 0; j < treedata[i].Level; j++) {
                    space += "&ensp;&ensp;";
                }
                //如果不是一级结点的话，要加上一个 ├ 符号
                space += "├&nbsp;";
            }
            var tr = '<tr class="text-c">'
                + '<td><input type="checkbox" name="" value=""></td>'
                + '<td>' + treedata[i].ID + '</td>'
                + '<td>' + treedata[i].ParID + '</td>'
                + '<td>' + treedata[i].Level + '</td>'
                + '<td class="text-l">' + space + treedata[i].Name + '</td>'
                + '<td>' + treedata[i].Sort + '</td>'
                + '<td class="f-14">'
                + '<a title="编辑" href="javascript:;" onclick="category_edit(\'栏目编辑\',\'/admin/category/edit?id=' + treedata[i].ID + '\',' + treedata[i].ID + ',\'640\',\'420\')" style="text-decoration:none"><i class="Hui-iconfont">&#xe6df;</i></a>'
                + '<a title="删除" href="javascript:;" onclick="category_del(this,' + treedata[i].ID + ')" class="ml-5" style="text-decoration:none"><i class="Hui-iconfont">&#xe6e2;</i></a>'
                + '</td>'
                + '</tr>';
            tree += tr;
            createTrNode(treedata[i].ID);
        }
    }
}

//创建option结点的方法，用于递归调用生成树
function createOptionNode(parID) {
    for (var i = 0; i < treedata.length; i++) {
        //如果是当前结点的话，跳过，不然自己的父结点变成自己
        if (treedata[i].ID === curID) {
            continue;
        }
        if (treedata[i].ParID === parID) {
            //定义空格占位符,用来填补开始处偏移的位置
            var space = "";
            //如果不是一级结点的话,要弄一点偏移
            if (treedata[i].ParID > 0) {
                for (var j = 0; j < treedata[i].Level; j++) {
                    space += "&ensp;&ensp;";
                }
                //如果不是一级结点的话，要加上一个 ├ 符号
                space += "├&nbsp;";
            }
            if (treedata[i].ID === curParID) {
                var tr = '<option value="' + treedata[i].ID + '" selected="selected">' + space + treedata[i].Name + '</option>';
            }
            else {
                var tr = '<option value="' + treedata[i].ID + '">' + space + treedata[i].Name + '</option>';
            }
            tree += tr;
            createOptionNode(treedata[i].ID);
        }
    }
}

//创建基于树形结构的table的tr
function createTreeTr(data) {
    this.treedata = data;
    //从父类ID为0开始，生成分类树
    createTrNode(0);
    return tree;
}

//当前结点的父id，用于设定选中
var curParID = 0;
//当前结点的id
var curID = 0;
//创建基于树形结构的option,本方法自动排除自己以及自己的子孙结点，避免导致乱伦问题
function createTreeOption(data, curParID, curID) {
    this.treedata = data;
    this.curParID = curParID;
    this.curID = curID;
    //搞个顶级结点
    tree = '<option value="0">顶级分类</option>';
    //从父类ID为0开始，生成分类树
    createOptionNode(0);
    return tree;
}