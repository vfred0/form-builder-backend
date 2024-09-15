namespace FormBuilder.Dtos.Request;

public class FormStructureInputRequestDto
{
    public required Guid FormStructureId { get; set; }
    public required Guid InputId { get; set; }
}