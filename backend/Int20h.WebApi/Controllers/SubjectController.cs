using Int20h.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
}
