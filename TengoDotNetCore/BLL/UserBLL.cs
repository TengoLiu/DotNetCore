using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TengoDotNetCore.MyDbContext;

namespace TengoDotNetCore.BLL {
    public class UserBLL {

        private TengoDbContext db;

        public UserBLL(TengoDbContext db) {
            this.db = db;
        }
    }
}
