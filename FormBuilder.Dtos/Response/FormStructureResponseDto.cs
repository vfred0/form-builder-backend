namespace FormBuilder.Dtos.Response;

public class FormStructureResponseDto
{
    public string Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required ICollection<InputResponseDto> Inputs { get; set; }
}