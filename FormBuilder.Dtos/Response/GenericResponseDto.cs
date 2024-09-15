namespace FormBuilder.Dtos.Response;

public class GenericBaseResponseDto<T> : BaseResponse
{
    public T? Data { get; set; }
}