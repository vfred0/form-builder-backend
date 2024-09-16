using FormBuilder.Dtos.Request;
using FormBuilder.Dtos.Response;

namespace FormBuilder.Services.Input;

public interface IInputService
{
    Task<GenericBaseResponseDto<ICollection<InputResponseDto>>> GetAsync();
    Task<GenericBaseResponseDto<InputResponseDto>> GetInputAsync(string id);
    Task<GenericBaseResponseDto<string>> AddAsync(InputRequestDto inputRequestDto);
    Task<BaseResponse> UpdateAsync(string id, InputRequestDto inputRequestDto);
    Task<BaseResponse> DeleteAsync(string id);
}