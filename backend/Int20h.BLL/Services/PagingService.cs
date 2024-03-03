using AutoMapper;
using Int20h.BLL.Interfaces;
using Int20h.Common.Request;
using Int20h.Common.Response;
using Microsoft.EntityFrameworkCore;
using QueryCraft.Interfaces;

namespace Int20h.BLL.Services
{
    public class PagingService: IPagingService
    {
        private readonly IParser _parser;
        private readonly IMapper _mapper;
        public PagingService(IParser parser, IMapper mapper) 
        {
            _parser = parser;
            _mapper = mapper;
        }

        public async Task<PageResponse<IEnumerable<TDto>>> ApplyPaging<TEntity, TDto>(IQueryable<TEntity> query, GetRequest request)
        {
            if (request.Filter != null)
            {
                var operand = _parser.Parse(request.Filter, typeof(TEntity));
                query = query.Where(operand.GetPredicate<TEntity>());
            }

            var count = query.Count();
            var skip = request.Skip ?? 0;

            if (skip < count)
            {
                query = query.Skip(skip);
            }

            if (request.Take != null && request.Take < count - skip)
            {
                query = query.Take(request.Take.Value);
            }

            var res = _mapper.Map<IEnumerable<TEntity>, IEnumerable<TDto>>(await query.ToListAsync());

            var totalPages = (int)Math.Ceiling((double)count / (request.Take ?? 1));
            var currentPage = (int)Math.Floor((double)skip / (request.Take ?? 1)) + 1;
            var pageResponse = new PageResponse<IEnumerable<TDto>>(res)
            {
                Count = count,
                Skip = skip,
                Page = totalPages > 0 ? currentPage : 1,
                Message = "Items successfully retrieved!"

            };
            return pageResponse;
        }
    }
}
