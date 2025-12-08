using Asp.Versioning;
using Maxanger.Api.Controllers.Abstract;
using Maxanger.Api.Controllers.Routes;
using Microsoft.AspNetCore.Mvc;

namespace Maxanger.Api.Controllers.v1;

[ApiVersion(1)]
public class TestController : AbstractController
{
    private readonly Random _random = new();
    
    [HttpGet(MaxangerRoutes.Test.GetRandomNumber)]
    public async Task<IActionResult> GetRandomNumber()
    {
        return BaseResponse(StatusCodes.Status200OK, _random.Next(1, 6));
    }
    
    [HttpGet(MaxangerRoutes.Test.HelloWorld)]
    public async Task<IActionResult> GetHelloWorld()
    {
        return BaseResponse(StatusCodes.Status200OK, "ПРИВЕТ МИР!");
    }
}