using AutoMapper;
using FormBuilder.Dtos.Request;
using FormBuilder.Dtos.Response;
using FormBuilder.Entities;
using FormBuilder.Repositories.FormStructure;

namespace FormBuilder.Services.FormStructure;

public class FormStructureService(IFormStructureRepository formStructureRepository, IMapper mapper)
    : IFormStructureService
{
    public async Task<GenericBaseResponseDto<ICollection<FormStructureResponseDto>>> GetAsync()
    {
        var response = new GenericBaseResponseDto<ICollection<FormStructureResponseDto>>();
        try
        {
            var data = await formStructureRepository.GetAsync();
            response.Data = mapper.Map<ICollection<FormStructureResponseDto>>(data);
            response.Success = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = "No se pudo obtener la estructura del formulario";
        }

        return response;
    }
    

    public async Task<GenericBaseResponseDto<string>> AddAsync(FormStructureRequestDto formStructureRequestDto)
    {
        var response = new GenericBaseResponseDto<string>();
        try
        {
            response.Data =
                await formStructureRepository.AddAsync(mapper.Map<FormStructureEntity>(formStructureRequestDto));
            response.Success = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = "No se pudo agregar la estructura del formulario";
        }

        return response;
    }

    public async Task<BaseResponse> UpdateAsync(string id, FormStructureRequestDto formStructureRequestDto)
    {
        var response = new BaseResponse();
        try
        {
            await formStructureRepository.UpdateAsync(id, formStructureRequestDto);
            response.Success = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = "No se pudo actualizar la estructura del formulario";
        }

        return response;
    }

    public async Task<BaseResponse> DeleteAsync(string id)
    {
        var response = new BaseResponse();
        try
        {
            await formStructureRepository.DeleteAsync(id);
            response.Success = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = "No existe el formulario";
        }

        return response;
    }
}