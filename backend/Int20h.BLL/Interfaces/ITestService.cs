using Int20h.Common.Dtos.Test;
using Int20h.Common.Request;
using Int20h.Common.Response;

namespace Int20h.BLL.Interfaces
{
    public interface ITestService
    {
        Task<PageResponse<IEnumerable<TestDto>>> Get(GetRequest request);
        Task<Response<TestDto>> Create(CreateTestDto testDto);
        Task<Response<TestDto>> Edit(TestEditDto testDto);
    }
}
