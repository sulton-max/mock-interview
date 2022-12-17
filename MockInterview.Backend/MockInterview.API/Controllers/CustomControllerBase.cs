using Microsoft.AspNetCore.Mvc;

namespace MockInterview.API.Controllers;

[ApiController()]
[Route("api/[controller]")]
public class CustomControllerBase : ControllerBase
{
    protected readonly IWebHostEnvironment HostEnvironment;
    protected readonly ILogger Logger;

    public CustomControllerBase(IWebHostEnvironment hostEnvironment, ILogger logger)
    {
        HostEnvironment = hostEnvironment;
        Logger = logger;
    }
}