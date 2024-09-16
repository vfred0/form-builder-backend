using FormBuilder.Dtos.Request;
using FormBuilder.Dtos.Response;

namespace FormBuilder.Services.FormStructure;

public interface IFormStructureService
{
    Task<GenericBaseResponseDto<ICollection<FormStructureResponseDto>>> GetAsync();
    Task<GenericBaseResponseDto<FormStructureResponseDto>> GetFormStructureAsync(string id);
    Task<GenericBaseResponseDto<string>> AddAsync(FormStructureRequestDto formStructureRequestDto);
    Task<BaseResponse> UpdateAsync(string id, FormStructureRequestDto formStructureRequestDto);
    Task<BaseResponse> DeleteAsync(string id);
    Task<BaseResponse> AddInputAsync(FormStructureInputRequestDto formStructureInput);
}