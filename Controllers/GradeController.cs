using Microsoft.AspNetCore.Mvc;
using Siemens.Internship2026.GradeBook.Interfaces;

namespace Siemens.Internship2026.GradeBook.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GradeController : ControllerBase
{
    private readonly IGradeService _gradeService;

    public GradeController(IGradeService gradeService)
    {
        _gradeService = gradeService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var results = await _gradeService.GetPassingActiveGradesAsync(100);
        return Ok(results);
    }

    [HttpGet("filtered/{n}")]
    public async Task<IActionResult> GetFiltered(int n)
    {
        if (n <= 0) return BadRequest("N must be greater than 0.");

        var results = await _gradeService.GetPassingActiveGradesAsync(n);
        return Ok(results);
    }
}