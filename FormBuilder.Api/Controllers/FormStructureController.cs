using FormBuilder.Dtos.Request;
using FormBuilder.Services.FormStructure;
using Microsoft.AspNetCore.Mvc;

namespace FormBuilder.Api.Controllers;

[ApiController]
[Route("api/form-structures")]
public class FormStructureController(IFormStructureService formStructureService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var response = await formStructureService.GetAsync();
        return response.Success ? Ok(response) : BadRequest(response);
    }

    [HttpPost]
    public async Task<IActionResult> Post(FormStructureRequestDto formStructure)
    {
        var response = await formStructureService.AddAsync(formStructure);
        return response.Success ? Ok(response) : BadRequest(response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(string id, FormStructureRequestDto formStructure)
    {
        var response = await formStructureService.UpdateAsync(id, formStructure);
        return response.Success ? Ok(response) : BadRequest(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var response = await formStructureService.DeleteAsync(id);
        return response.Success ? Ok(response) : BadRequest(response);
    }
}