using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace OicdDemo.Controllers;

[Route("Auth")]
public class AuthController : Controller
{
    [HttpGet("login")]
    [AllowAnonymous]
    public async Task<ActionResult> Login(string returnUrl = null)
    {

        return Challenge(new AuthenticationProperties
        {
            //RedirectUri = Url.Action("OpenIdLoginCallback"),
            //Items =
            //{
            //    { "returnUrl", returnUrl }
            //}
        }, OpenIdConnectDefaults.AuthenticationScheme);
    }

    [HttpGet("IsAuthenticated")]
    [AllowAnonymous]
    public async Task<IActionResult> IsAuthenticated()
    {
        if (!User.Identity.IsAuthenticated)
        {
            return StatusCode(302);
        }
        return StatusCode(200);
    }


    //[Authorize]
    //[HttpGet]
    //[Route("OpenIdLoginCallback")]
    //public async Task<IActionResult> OpenIdLoginCallback()
    //{
    //    var result = await HttpContext.AuthenticateAsync(OpenIdConnectDefaults.AuthenticationScheme);
    //    var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectDefaults.AuthenticationScheme, "access_token");
    //    var refreshToken = await HttpContext.GetTokenAsync(OpenIdConnectDefaults.AuthenticationScheme, "refresh_token");
    //    if (result.Principal == null)
    //        throw new Exception("Could not create a principal");
    //    var externalClaims = result.Principal.Claims.ToList();
    //    var subjectIdClaim = externalClaims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
    //    if (subjectIdClaim == null)
    //        throw new Exception("Could not extract a subject id claim");

    //    var props = new AuthenticationProperties
    //    {
    //        IsPersistent = false
    //    };
    //    props.StoreTokens(new[]
    //    {
    //        new AuthenticationToken { Name = "access_token", Value = accessToken! },
    //        new AuthenticationToken { Name = "refresh_token", Value = refreshToken! }
    //    });

    //    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
    //        result.Principal,
    //        props);
    //    return Redirect(result.Properties?.Items["returnUrl"]!);
    //}

}
