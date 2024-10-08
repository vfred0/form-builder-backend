using FormBuilder.Dtos.Request;
using FormBuilder.Services.Input;
using Microsoft.AspNetCore.Mvc;

namespace FormBuilder.Api.Controllers;

[ApiController]
[Route("api/inputs")]
public class InputController(IInputService inputService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var response = await inputService.GetAsync();
        return response.Success ? Ok(response) : BadRequest(response);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post(InputDto input)
    {
        var response = await inputService.AddAsync(input);
        return response.Success ? Ok(response) : BadRequest(response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(string id, InputDto input)
    {
        var response = await inputService.UpdateAsync(id, input);
        return response.Success ? Ok(response) : BadRequest(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var response = await inputService.DeleteAsync(id);
        return response.Success ? Ok(response) : BadRequest(response);
    }
}