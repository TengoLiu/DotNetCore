using System.Threading.Tasks;
using TengoDotNetCore.Common.Service;
using TengoDotNetCore.Models;
using TengoDotNetCore.Models.Base;

namespace TengoDotNetCore.Service {
    public interface IGoodsService : IEntityService<Goods> {
        Task<PageList<Goods>> List(PageInfo pageInfo, string keyword, string sortBy);
    }
}
