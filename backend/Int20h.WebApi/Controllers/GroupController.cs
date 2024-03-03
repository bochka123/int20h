using Int20h.BLL.Interfaces;
using Int20h.Common.Dtos.Group;
using Int20h.Common.Request;
using Int20h.Common.Response;
using Microsoft.AspNetCore.Mvc;

namespace Int20h.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GroupController : ControllerBase
{
    private readonly IGroupService _groupService;
    public GroupController(IGroupService groupService)
    {
        _groupService = groupService;
    }

    [HttpPost]
    public async Task<ActionResult> CreateGroup([FromBody] CreateGroupDto createGroupDto)
    {
        var response = await _groupService.CreateGroup(createGroupDto);

        if (response.Status == Status.Success)
        {
            return Ok(response);
        }

        return BadRequest(response);
    }

    [HttpPost("GetAll")]
    public async Task<ActionResult> GetAllGroups([FromBody]GetRequest getRequest)
    {
        var response = await _groupService.GetAllGroups(getRequest);

        if (response.Status == Status.Success)
        {
            return Ok(response);
        }

        return BadRequest(response);
    }
}
