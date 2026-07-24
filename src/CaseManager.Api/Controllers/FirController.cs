using CaseManager.Application.DTOs;
using CaseManager.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CaseManager.Api.Controllers;

[ApiController]
[Route("api/fir")]
public class FirController : ControllerBase
{
    private readonly IFirService _service;

    public FirController(IFirService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreateFir([FromBody] CreateFirRequest request)
    {
        var result = await _service.CreateFirAsync(request);
        return Ok(result);
    }
}