using Int20h.Common.Request;
using Int20h.Common.Response;

namespace Int20h.BLL.Interfaces
{
    public interface IPagingService
    {
        Task<PageResponse<IEnumerable<TDto>>> ApplyPaging<TEntity, TDto>(IQueryable<TEntity> query, GetRequest request);
    }
}
