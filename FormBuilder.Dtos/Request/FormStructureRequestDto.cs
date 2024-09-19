namespace FormBuilder.Dtos.Request;

public class FormStructureRequestDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ICollection<InputDto> Inputs { get; set; } = new List<InputDto>();
}