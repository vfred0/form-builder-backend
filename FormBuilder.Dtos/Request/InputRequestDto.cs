namespace FormBuilder.Dtos.Request;

public class InputRequestDto
{
    public string Name { get; set; } = default!;
    public string DataType { get; set; } = default!;
    public bool Required { get; set; }
}