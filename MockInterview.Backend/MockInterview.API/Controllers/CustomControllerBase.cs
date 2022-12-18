using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace MockInterview.API.Controllers;

[ApiController()]
[Route("api/[controller]")]
public class CustomControllerBase : ControllerBase
{
    protected readonly IMapper Mapper;

    public CustomControllerBase(IMapper mapper)
    {
        Mapper = mapper;
    }
}