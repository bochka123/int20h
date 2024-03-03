using Int20h.BLL.Interfaces;
using Int20h.Common.Dtos.Session;
using Int20h.Common.Dtos.Test;
using Int20h.Common.Request;
using Int20h.Common.Response;
using Microsoft.AspNetCore.Mvc;

namespace Int20h.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize]
    public class SessionController : ControllerBase
    {
        private readonly ISessionService _sessionService;

        public SessionController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        [HttpPost(Name = "CreateSession")]
        public async Task<IActionResult> CreateSession(Guid sessionId)
        {
            var response = _sessionService.CreateSession(sessionId);
            if (response.Status == Status.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet(Name = "GetSession")]
        public async Task<IActionResult> GetSession(Guid sessionId)
        {
            var response = _sessionService.GetSession(sessionId);
            if (response.Status == Status.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet(Name = "Question")]
        public async Task<IActionResult> GetQuestion(Guid sessionId)
        {
            var response = _sessionService.Get(sessionId);
            if (response.Status == Status.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPost(Name ="Answer")]
        public async Task<IActionResult> AddSessionAnswer([FromBody] CreateSessionAnswer sessionAnswer)
        {
            var response = _sessionService.AddSessionAnswer(sessionAnswer);
            if (response.Status == Status.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
