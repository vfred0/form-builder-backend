namespace FormBuilder.Dtos.Response;

public class InputResponseDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string DataType { get; set; }
    public bool Required { get; set; }
}