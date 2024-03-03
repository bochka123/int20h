using Int20h.BLL.Interfaces;
using Int20h.Common.Dtos.Student;
using Int20h.Common.Response;
using Microsoft.AspNetCore.Mvc;

namespace Int20h.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TeacherController : ControllerBase
{
	private readonly ITeacherService _teacherService;

	public TeacherController(ITeacherService teacherService)
	{
		_teacherService = teacherService;
	}

	[HttpGet]
	public async Task<ActionResult> GetAllTeachers([FromQuery] bool notVerified)
	{
		var response = await _teacherService.GetAllTeachers(notVerified);

		if (response.Status == Status.Success)
		{
			return Ok(response);
		}

		return BadRequest(response);
	}

	[HttpGet("{id}")]
	public async Task<ActionResult> GetById(Guid id)
	{
		var response = await _teacherService.GetTeacherById(id);

		if (response.Status == Status.Success)
		{
			return Ok(response);
		}

		return BadRequest(response);
	}
}
