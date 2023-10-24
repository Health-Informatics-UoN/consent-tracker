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

    /// <summary>
    /// Retrieves a list of studies.
    /// </summary>
    /// <returns>A list of studies.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(List<Study>), StatusCodes.Status200OK)]
    [HttpGet]
    public async Task<ActionResult<List<Study>>> Index() 
        => Ok(await _studyService.List());

    /// <summary>
    /// Creates a new study with the specified study ID.
    /// </summary>
    /// <param name="studyId">The study ID of the study to be created.</param>
    /// <returns>A response indicating the success of the operation.</returns>
    /// <response code="204">The study was successfully created.</response>
    /// <response code="400">If the study ID is invalid or the study already exists.</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
    
    /// <summary>
    /// Registers a new patient for a study.
    /// </summary>
    /// <param name="patient">The patient information to be registered.</param>
    /// <returns>A response indicating the success of the registration.</returns>
    /// <response code="204">The patient was successfully registered.</response>
    /// <response code="400">If the patient data is invalid or the patient is already registered.</response>
    /// <response code="404">If the specified study does not exist.</response>
    [HttpPost("RegisterPatient")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> RegisterPatient(RegisterPatient patient)
    {
        try
        {
            await _studyService.RegisterPatient(patient);
            return NoContent();
        }
        catch (ArgumentException e)
        {
            return BadRequest(e.Message);
        }
        catch (NullReferenceException e)
        {
            return BadRequest(e.Message);
        }
        catch (InvalidOperationException e)
        {
            return NotFound(e.Message);
        }
    }
}