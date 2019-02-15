using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TengoDotNetCore.Models.Base;

namespace TengoDotNetCore.Models {

    public class Article : BaseModel {
        public int Id { get; set; }

        public string Title { get; set; }

        public string CoverImg { get; set; }

        public string Content { get; set; }

        public string MContent { get; set; }

    }
}
