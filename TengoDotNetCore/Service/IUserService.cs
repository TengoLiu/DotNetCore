﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TengoDotNetCore.Models;
using TengoDotNetCore.Models.Base;

namespace TengoDotNetCore.Service {
    public interface IUserService {

        Task<PageList<User>> List(PageInfo pageInfo);
    }
}
