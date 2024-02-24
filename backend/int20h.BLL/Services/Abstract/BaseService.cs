using int20h.DAL.Context;
using AutoMapper;

namespace int20h.BLL.Services.Abstract;

public abstract class BaseService
{
	protected readonly ApplicationDbContext _context;
	protected readonly IMapper _mapper;

	protected BaseService(ApplicationDbContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}
}
