using Int20h.BLL.Interfaces;
using Int20h.BLL.Services;
using Int20h.Common.Dtos.Group;
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
	public async Task<ActionResult> GetAllStudents()
	{
		var response = await _studentService.GetAllStudents();

		if (response.Status == Status.Success)
		{
			return Ok(response);
		}

		return BadRequest(response);
	}
}
