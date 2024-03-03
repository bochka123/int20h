using Int20h.Common.Dtos.Question;
using Int20h.Common.Dtos.Session;
using Int20h.Common.Response;

namespace Int20h.BLL.Interfaces
{
    public interface ISessionService
    {
        Response<SessionDto> CreateSession(Guid SessionId);
        Response<QuestionResponseDto> Get(Guid SessionId);
        Response AddSessionAnswer(CreateSessionAnswer sessionAnswer);
        Response<SessionDto> GetSession(Guid SessionId);
    }
}
