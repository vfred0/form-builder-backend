namespace FormBuilder.Dtos.Request;

public class InputDto
{
    public string Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string DataType { get; set; } = default!;
    public bool Required { get; set; }
    public string Value { get; set; } = default!;
    [JsonIgnore]
    public string Value { get; set; } = string.Empty;
}