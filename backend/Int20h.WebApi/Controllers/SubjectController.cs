using Int20h.BLL.Interfaces;
using Int20h.Common.Response;
using Microsoft.AspNetCore.Mvc;
using Int20h.Common.Dtos.Subject;
using Int20h.Common.Request;
using Int20h.BLL.Services;

namespace Int20h.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubjectController : ControllerBase
{
    private readonly ISubjectService _subjectService;
    public SubjectController(ISubjectService subjectService)
    {
        _subjectService = subjectService;
    }

    [HttpPost]
    public async Task<ActionResult> CreateSubject([FromBody] CreateSubjectDto createSubjectDto)
    {
        var response = await _subjectService.CreateSubject(createSubjectDto);

        if (response.Status == Status.Success)
        {
            return Ok(response);
        }

        return BadRequest(response);
    }

    [HttpPost("GetAll")]
    public async Task<ActionResult> GetAllSubjects([FromBody] GetRequest getRequest)
    {
        var response = await _subjectService.GetAllSubjects(getRequest);

        if (response.Status == Status.Success)
        {
            return Ok(response);
        }

        return BadRequest(response);
    }

    [HttpPost("GetUserSubjects")]
    public async Task<ActionResult> GetAllSubjects([FromBody] GetUserSubjectsDto getUserSubjectsDto)
    {
        var response = await _subjectService.GetUserSubjects(getUserSubjectsDto.UserEmail);

        if (response.Status == Status.Success)
        {
            return Ok(response);
        }

        return BadRequest(response);
    }
}
