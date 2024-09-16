using FormBuilder.Dtos.Request;
using FormBuilder.Dtos.Response;

namespace FormBuilder.Services.FormStructure;

public interface IFormStructureService
{
    Task<GenericBaseResponseDto<ICollection<FormStructureResponseDto>>> GetAsync();
    Task<GenericBaseResponseDto<string>> AddAsync(FormStructureRequestDto formStructureRequestDto);
    Task<BaseResponse> UpdateAsync(string id, FormStructureRequestDto formStructureRequestDto);
    Task<BaseResponse> DeleteAsync(string id);
}