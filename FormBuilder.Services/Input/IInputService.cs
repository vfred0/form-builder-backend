using FormBuilder.Dtos.Request;
using FormBuilder.Dtos.Response;

namespace FormBuilder.Services.Input;

public interface IInputService
{
    Task<GenericBaseResponseDto<ICollection<InputDto>>> GetAsync();
    Task<GenericBaseResponseDto<string>> AddAsync(InputDto inputDto);
    Task<BaseResponse> UpdateAsync(string id, InputDto inputDto);
    Task<BaseResponse> DeleteAsync(string id);
}