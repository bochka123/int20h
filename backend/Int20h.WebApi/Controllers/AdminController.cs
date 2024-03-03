using Int20h.BLL.Interfaces;
using Int20h.Common.Dtos.User;
using Int20h.Common.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Int20h.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin")]
public class AdminController : ControllerBase
{
    private readonly IAdminService _adminService;

    public AdminController(IAdminService adminService)
    {
        _adminService = adminService;
    }

    [HttpPost]
    public async Task<ActionResult> CreateAdmin([FromBody] SignUpUserDto userDto)
    {
        var response = await _adminService.CreateAdmin(userDto);

        if (response.Status == Status.Success)
        {
            return Ok(response);
        }

        return BadRequest(response);
    }
}
