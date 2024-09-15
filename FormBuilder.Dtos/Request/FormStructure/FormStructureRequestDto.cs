namespace FormBuilder.Dtos.Request;

public class FormStructureRequestDto
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public ICollection<InputRequestDto> Inputs { get; set; } = new List<InputRequestDto>();
}