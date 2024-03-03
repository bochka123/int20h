using Int20h.BLL.Interfaces;
using Int20h.Common.Dtos.Test;
using Int20h.Common.Request;
using Int20h.Common.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Int20h.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;
        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        [HttpPost(Name = "Get")]
        public async Task<IActionResult> Get(GetRequest request)
        {
            return Ok(await _testService.Get(request));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTestDto request)
        {
            var response = await _testService.Create(request);
            if (response.Status == Status.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] TestEditDto request)
        {
            var response = await _testService.Edit(request);
            if (response.Status == Status.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
