using Microsoft.AspNetCore.Mvc;

using Int20h.BLL.Interfaces;
using Int20h.Common.Dtos.User;
using Int20h.Common.Response;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Authorization;

namespace Int20h.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
	private readonly ITokenService _tokenService;

    public AuthController(IAuthService authService, ITokenService tokenService)
    {
        _authService = authService;
        _tokenService = tokenService;
    }
    [HttpPost("sign-in")]
	public async Task<ActionResult> SignIn([FromBody] SignInUserDto userDto)
    {
        var response = await _authService.SignInAsync(userDto);

		if (response.Status == Status.Success)
        {
            var refreshToken = _tokenService.GenerateRefreshToken(response.Value!);
           
            Response.Cookies.Append("X-Refresh-Token", refreshToken.Value!, new CookieOptions
            {
                Expires = DateTime.Now.AddDays(7),
                HttpOnly = true,
                Secure = true,
                IsEssential = true,
                SameSite = Microsoft.AspNetCore.Http.SameSiteMode.None
            });

            return Ok(response);
		}

		return BadRequest(response);
    }

	[HttpPost("sign-up")]
	public async Task<ActionResult> SignUp([FromBody] SignUpUserDto userDto)
    {
		var response = await _authService.SignUpAsync(userDto);

		if (response.Status == Status.Success)
		{
			var refreshToken = _tokenService.GenerateRefreshToken(response.Value!);
			Response.Cookies.Append("X-Refresh-Token", refreshToken.Value!, new CookieOptions
			{
				Expires = DateTime.Now.AddDays(7),
				HttpOnly = true,
				Secure = true,
				IsEssential = true,
				SameSite = Microsoft.AspNetCore.Http.SameSiteMode.None
			});

			return Ok(response);
		}
        
		return BadRequest(response);
	}

	[HttpPost("refresh")]
	public async Task<ActionResult> Refresh()
    {
		var refreshToken = Request.Cookies["X-Refresh-Token"];
		var response = await _tokenService.GenerateAccessTokenAsync(refreshToken!);

		if (response.Status == Status.Success)
		{
			return Ok(response);
		}

		return BadRequest(response);
	}
}
