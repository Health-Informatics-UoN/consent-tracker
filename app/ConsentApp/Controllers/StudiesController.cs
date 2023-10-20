using ConsentApp.Models;
using ConsentApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConsentApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudiesController: ControllerBase
{
    private readonly StudyService _studyService;

    public StudiesController(StudyService studyService)
    {
        _studyService = studyService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Study>>> Index() 
        => Ok(await _studyService.List());

    [HttpPost]
    public async Task<ActionResult> Create(string studyId)
    {
        try
        {
            await _studyService.Create(studyId);
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}