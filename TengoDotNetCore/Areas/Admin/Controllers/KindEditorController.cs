using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using TengoDotNetCore.Controllers;

namespace WinexHK.Areas.Admin.Controllers {
    [Area("Admin")]
    public class KindEditorController : BaseController {

        private readonly IHostingEnvironment _hostingEnvironment;
        public KindEditorController(IHostingEnvironment hostingEnvironment) {
            _hostingEnvironment = hostingEnvironment;
        }

        #region  Upload 接收客户端上传文件的方法
        public IActionResult Upload(string dir = "", IFormFile imgFile = null) {
            try {
                //if (EsistsSession(Constant.SESSION_MANAGER)) {
                //    return Error("您的登录信息已过期，请刷新页面重新登录.");
                //}
                //文件保存目录物理路径
                string savePath = "/upload/";

                #region 定义允许上传的文件扩展名,目前只能传图片
                var extTable = new Hashtable();
                extTable.Add("image", "gif,jpg,jpeg,png,bmp");
                //extTable.Add("flash", "swf,flv");
                //extTable.Add("media", "swf,flv,mp3,wav,wma,wmv,mid,avi,mpg,asf,rm,rmvb");
                //extTable.Add("file", "doc,docx,xls,xlsx,ppt,htm,html,txt,zip,rar,gz,bz2");
                #endregion

                //最大文件大小，2M
                int maxSize = 1024 * 1024 * 2;

                if (imgFile == null) {
                    return Error("请选择文件。");
                }

                //获取文件保存url对应的物理路径
                string dirPath = _hostingEnvironment.WebRootPath + "\\" + savePath;

                //获取上传文件要保存到的目录，本来来说是会区分img、flash、media等等的，但是我打算把所有文件都放到一起，所以这里的dir仅作为索引从extTable来判断上传类型是否合规
                string dirName = dir;

                //if(string.IsNullOrEmpty(dirName)) {
                //    dirName = "image";
                //}
                //if(!extTable.ContainsKey(dirName)) {
                //    return Content(showError("目录名不正确。"), "application/json", System.Text.Encoding.UTF8);
                //}

                //获取文件名和文件名后缀
                string fileName = imgFile.FileName;
                string fileExt = Path.GetExtension(fileName).ToLower();

                if (imgFile == null || imgFile.Length > maxSize) {
                    return Error("上传文件大小超过限制。");
                }

                //判断是否是允许上传的格式
                if (string.IsNullOrEmpty(fileExt) || Array.IndexOf(((string)extTable[dirName]).Split(','), fileExt.Substring(1).ToLower()) == -1) {
                    return Error("上传文件扩展名是不允许的扩展名。\n只允许" + ((string)extTable[dirName]) + "格式。");
                }

                //判断是否存在要保存的文件夹，这里是指 /upload
                if (!Directory.Exists(dirPath)) {
                    Directory.CreateDirectory(dirPath);
                }
                //用日期来生成文件夹名称
                string ymd = DateTime.Now.ToString("yyyyMMdd", DateTimeFormatInfo.InvariantInfo);

                //拼接文件夹物理路径
                dirPath += ymd + "/";
                //如果还没有文件夹的话，就生成一个 类似 /upload/20180801/
                if (!Directory.Exists(dirPath)) {
                    Directory.CreateDirectory(dirPath);
                }

                //拼接文件保存的完整虚拟路径
                savePath += ymd + "/";

                //我要对文件名进行重新命名，用时间来做文件名
                string newFileName = DateTime.Now.ToString("yyyyMMddHHmmss_ffff", DateTimeFormatInfo.InvariantInfo) + fileExt;

                //采用流式方法保存文件
                using (var fs = new FileStream(dirPath + newFileName, FileMode.Create)) {
                    imgFile.CopyTo(fs);
                }

                string fileUrl = savePath + newFileName;

                Hashtable hash = new Hashtable();
                hash["error"] = 0;
                hash["url"] = fileUrl;
                return Json(hash);
            }
            catch (Exception exp) {
                return Error(exp.Message);
            }
        }
        #endregion

        #region FileManager 文件夹目录管理的方法
        public ActionResult FileManager(string dir = "", string path = "", string order = "") {

            //根目录路径，相对路径
            string rootPath = "/upload/";
            //根目录URL，可以指定绝对路径，比如 http://www.yoursite.com/attached/
            string rootUrl = "/upload/";
            //图片扩展名
            string fileTypes = "gif,jpg,jpeg,png,bmp";

            string currentPath = string.Empty;
            string currentUrl = string.Empty;
            string currentDirPath = string.Empty;
            string moveupDirPath = string.Empty;

            string dirPath = _hostingEnvironment.WebRootPath + rootPath; //获取虚拟路径对应的在我们服务器上的物理路径（tengo），例如D：/

            #region 上传文件到指定文件夹的一些设置 由于上传文件不再做类型文件夹区分，所以这段代码先弃用 2018年8月1日14:09:35
            //if(!string.IsNullOrEmpty(dirName)) {//如果指定的文件夹名字不为空的话
            //    if(Array.IndexOf("image,flash,media,file".Split(','), dirName) == -1) {//若文件夹的名字不是我们规定允许的名字的话（仅仅是规定），不让他创建文件夹
            //        return Content("Invalid Directory name.", "application/json", System.Text.Encoding.UTF8);//无效的文件夹名字
            //    }
            //    dirPath += dirName + "/";
            //    rootUrl += dirName + "/";
            //    if(!Directory.Exists(dirPath)) {//如果不存在文件夹，就创建文件夹
            //        Directory.CreateDirectory(dirPath);
            //    }
            //}
            #endregion

            //根据path参数，设置各路径和URL
            if (string.IsNullOrWhiteSpace(path)) {
                path = string.Empty;
                currentPath = dirPath;
                currentUrl = rootUrl;
                currentDirPath = string.Empty;
                moveupDirPath = string.Empty;
            }
            else {
                currentPath = dirPath + path;
                currentUrl = rootUrl + path;
                currentDirPath = path;
                moveupDirPath = Regex.Replace(currentDirPath, @"(.*?)[^\/]+\/$", "$1");
            }

            //排序形式，name or size or type
            order = string.IsNullOrEmpty(order) ? "" : order.ToLower();

            //不允许使用..移动到上一级目录
            if (Regex.IsMatch(path, @"\.\.")) {
                return Content("Access is not allowed.", "application/json", System.Text.Encoding.UTF8);
            }
            //最后一个字符不是/
            if (path != "" && !path.EndsWith("/")) {
                return Content("Parameter is not valid.", "application/json", System.Text.Encoding.UTF8);
            }
            //目录不存在或不是目录
            if (!Directory.Exists(currentPath)) {
                return Content("Directory does not exist.", "application/json", System.Text.Encoding.UTF8);
            }

            //遍历目录取得文件信息
            string[] dirList = Directory.GetDirectories(currentPath);
            string[] fileList = Directory.GetFiles(currentPath);

            switch (order) {
                case "size":
                    Array.Sort(dirList, new NameSorter());
                    Array.Sort(fileList, new SizeSorter());
                    break;
                case "type":
                    Array.Sort(dirList, new NameSorter());
                    Array.Sort(fileList, new TypeSorter());
                    break;
                case "name":
                default:
                    Array.Sort(dirList, new NameSorter());
                    Array.Sort(fileList, new NameSorter());
                    break;
            }

            Hashtable result = new Hashtable();
            result["moveup_dir_path"] = moveupDirPath;
            result["current_dir_path"] = currentDirPath;
            result["current_url"] = currentUrl;
            result["total_count"] = dirList.Length + fileList.Length;
            List<Hashtable> dirFileList = new List<Hashtable>();
            result["file_list"] = dirFileList;
            for (int i = 0; i < dirList.Length; i++) {
                DirectoryInfo directory = new DirectoryInfo(dirList[i]);
                if (!directory.Name.ToLower().Contains("thumb")) {//排除缩略图文件夹
                    Hashtable hash = new Hashtable();
                    hash["is_dir"] = true;
                    hash["has_file"] = (directory.GetFileSystemInfos().Length > 0);
                    hash["filesize"] = 0;
                    hash["is_photo"] = false;
                    hash["filetype"] = string.Empty;
                    hash["filename"] = directory.Name;
                    hash["datetime"] = directory.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
                    dirFileList.Add(hash);
                }
            }
            for (int i = 0; i < fileList.Length; i++) {
                FileInfo file = new FileInfo(fileList[i]);
                var extension = Path.GetExtension(file.Name).ToLower();
                Hashtable hash = new Hashtable();
                hash["is_dir"] = false;
                hash["has_file"] = false;
                hash["filesize"] = file.Length;
                hash["is_photo"] = (Array.IndexOf(fileTypes.Split(','), file.Extension.Substring(1).ToLower()) >= 0);
                hash["filetype"] = file.Extension.Substring(1);
                hash["filename"] = file.Name;
                hash["datetime"] = file.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
                dirFileList.Add(hash);
            }
            return Json(result);
        }
        #endregion

        #region Error 辅助方法 上传文件提示错误信息
        private IActionResult Error(string message) {
            //设置返回的Model
            Hashtable hash = new Hashtable();
            hash["error"] = 1;
            hash["message"] = message;
            return Json(hash);
        }
        #endregion
    }

    #region 辅助类
    public class NameSorter : IComparer {
        public int Compare(object x, object y) {
            if (x == null && y == null) {
                return 0;
            }
            if (x == null) {
                return -1;
            }
            if (y == null) {
                return 1;
            }
            FileInfo xInfo = new FileInfo(x.ToString());
            FileInfo yInfo = new FileInfo(y.ToString());

            return xInfo.FullName.CompareTo(yInfo.FullName);
        }
    }

    public class SizeSorter : IComparer {
        public int Compare(object x, object y) {
            if (x == null && y == null) {
                return 0;
            }
            if (x == null) {
                return -1;
            }
            if (y == null) {
                return 1;
            }
            FileInfo xInfo = new FileInfo(x.ToString());
            FileInfo yInfo = new FileInfo(y.ToString());

            return xInfo.Length.CompareTo(yInfo.Length);
        }
    }

    public class TypeSorter : IComparer {
        public int Compare(object x, object y) {
            if (x == null && y == null) {
                return 0;
            }
            if (x == null) {
                return -1;
            }
            if (y == null) {
                return 1;
            }
            FileInfo xInfo = new FileInfo(x.ToString());
            FileInfo yInfo = new FileInfo(y.ToString());

            return xInfo.Extension.CompareTo(yInfo.Extension);
        }
    }

    public class Size {
        public int Width { get; set; }
        public int Height { get; set; }
    }
    #endregion

}
