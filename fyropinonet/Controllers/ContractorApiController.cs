using fyropinonet.Contracts;
using fyropinonet.Interface;
using fyropinonet.Models;
using Microsoft.AspNetCore.Mvc;

namespace fyropinonet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContractorApiController : ControllerBase
{
    private readonly IContractorServices _contractorServices;

    public ContractorApiController(IContractorServices contractorServices)
    {
        _contractorServices = contractorServices;
    }

    [HttpPost]
    public async Task<IActionResult> CreateContractor(CreateContractorRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await _contractorServices.CreateContractor(request);
            return Ok(new
            {
                message = "Success while creating contractor",
            });
        }
        catch (Exception e)
        {
            return StatusCode(500, "An error occured while creating contractor: " + e.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetContractors()
    {
        try
        {
            var contractors = await _contractorServices.GetAllContractorsAsync();
            
            return Ok(contractors);
        }
        catch (Exception e)
        {
            return StatusCode(500, "An error occured while getting all contractors: " + e.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetContractor(int id)
    {
        try
        {
            var contractor = await _contractorServices.GetContractorById(id);

            if (contractor == null)
            {
                return StatusCode(500, "No contractor with id of: " + id);
            }
            else
            {
                return Ok(contractor);
            }
        }
        catch (Exception e)
        {
            return StatusCode(500, "Error while getting contractor by id: " + e.Message);
        }
    }
}