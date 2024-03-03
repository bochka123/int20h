using Int20h.Common.Dtos.Question;
using Int20h.Common.Response;

namespace Int20h.BLL.Interfaces
{
    public interface IQuestionService
    {
        Task<Response<IEnumerable<QuestionResponseDto>>> GetByTaskId(Guid testId);
        Task<Response<IEnumerable<QuestionResponseDto>>> CreateMany(IEnumerable<QuestionDto> questionsDtos, Guid testId);

        Task<Response<QuestionResponseDto>> Create(QuestionDto questionDto, Guid testId);

        Task<Response<QuestionResponseDto>> Edit(QuestionDto questionDto, Guid questionId);

        Task<Response<QuestionResponseDto>> Delete(Guid questionId);
    }
}
