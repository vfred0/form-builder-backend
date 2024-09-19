using System.Text.Json.Serialization;

namespace FormBuilder.Dtos.Request;

public class InputDto
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string DataType { get; set; } = string.Empty;
    public bool Required { get; set; }
    [JsonIgnore]
    public string Value { get; set; } = string.Empty;
}