using Int20h.BLL.Interfaces;
using Int20h.Common.Dtos.Question;
using Int20h.Common.Response;
using Microsoft.AspNetCore.Mvc;

namespace Int20h.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        public QuestionController(IQuestionService testService)
        {
            _questionService = testService;
        }

        [HttpPost(Name = "Get")]
        public async Task<IActionResult> Get(Guid taskId)
        {
            var response = await _questionService.GetByTaskId(taskId);
            if (response.Status == Status.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Guid taskId, [FromBody] QuestionDto request)
        {
            var response = await _questionService.Create(request, taskId);
            if (response.Status == Status.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Guid taskId, [FromBody] QuestionDto request)
        {
            var response = await _questionService.Edit(request, taskId);
            if (response.Status == Status.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("/{id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var response = await _questionService.Delete(Id);
            if (response.Status == Status.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
