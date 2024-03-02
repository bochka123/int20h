using Int20h.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
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


}
