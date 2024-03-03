using Int20h.BLL.Interfaces;

using Int20h.Common.Response;
using Microsoft.AspNetCore.Mvc;

namespace Int20h.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
	private readonly IStudentService _studentService;

	public StudentController(IStudentService studentService)
	{
		_studentService = studentService;
	}

	[HttpGet]
	public async Task<ActionResult> GetAllStudents([FromQuery] bool notVerified)
	{
		var response = await _studentService.GetAllStudents(notVerified);

		if (response.Status == Status.Success)
		{
			return Ok(response);
		}

		return BadRequest(response);
	}

	[HttpGet("{id}")]
	public async Task<ActionResult> GetById(Guid id)
	{
		var response = await _studentService.GetStudentById(id);

		if (response.Status == Status.Success)
		{
			return Ok(response);
		}

		return BadRequest(response);
	}
}
