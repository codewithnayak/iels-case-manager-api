using Microsoft.AspNetCore.Mvc;
using CaseManager.Application.Interfaces;

namespace CaseManager.Api.Controllers;

[ApiController]
[Route("api/cases")]
public class SearchController : ControllerBase
{
    private readonly ICaseSearchService _service;

    public SearchController(ICaseSearchService service)
    {
        _service = service;
    }

    [HttpGet("search")]
    public async Task<IActionResult> Search(
        [FromQuery]CaseSearchRequest  request)
    {
        var results = await _service.SearchAsync(request.CrimeType, request.Status, request.Officer);
        return Ok(results);
    }
}