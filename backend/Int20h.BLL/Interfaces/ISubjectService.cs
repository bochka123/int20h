using Int20h.Common.Dtos.Subject;
using Int20h.Common.Request;
using Int20h.Common.Response;

namespace Int20h.BLL.Interfaces;

public interface ISubjectService
{
    Task<Response<SubjectDto>> CreateSubject(CreateSubjectDto createSubjectDto);
    Task<PageResponse<IEnumerable<SubjectDto>>> GetAllSubjects(GetRequest getRequest);
}
