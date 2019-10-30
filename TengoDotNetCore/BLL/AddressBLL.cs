using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using TengoDotNetCore.BLL.Base;
using TengoDotNetCore.BLL.Data;
using TengoDotNetCore.Models;
using TengoDotNetCore.Models.Base;

namespace TengoDotNetCore.BLL {
    public class AddressBLL : BaseBLL {
        public AddressBLL(TengoDbContext db) : base(db) { }
    }
}
