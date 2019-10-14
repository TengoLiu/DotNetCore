using System;
using System.Collections.Generic;
using System.Web;

namespace TengoDotNetCore.API.WXPay {
    public class WxPayException : Exception {
        public WxPayException(string msg) : base(msg) {

        }
    }
}