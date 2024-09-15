namespace FormBuilder.Dtos.Response;

public class BaseResponse
{
    public bool Success { get; set; }
    public string? ErrorMessage { get; set; }
}