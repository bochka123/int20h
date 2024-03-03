using AutoMapper;
using Int20h.BLL.Interfaces;
using Int20h.BLL.Services.Abstract;
using Int20h.DAL.Context;

namespace Int20h.BLL.Services
{
    public class QuestionService: BaseService, IQuestionService
    {
        public QuestionService(ApplicationDbContext applicationDbContext, IMapper mapper): base(applicationDbContext, mapper)
        {

        }
    }
}
