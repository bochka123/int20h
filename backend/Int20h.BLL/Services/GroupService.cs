using AutoMapper;
using Int20h.BLL.Interfaces;
using Int20h.BLL.Services.Abstract;
using Int20h.DAL.Context;

namespace Int20h.BLL.Services;

public class GroupService : BaseService, IGroupService
{
    public GroupService(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
    { }
}
