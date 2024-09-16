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

    public async Task<GenericBaseResponseDto<FormStructureResponseDto>> GetFormStructureAsync(string id)
    {
        var response = new GenericBaseResponseDto<FormStructureResponseDto>();
        try
        {
            var data = await formStructureRepository.GetAsync(id);
            response.Data = mapper.Map<FormStructureResponseDto>(data);
            response.Success = data != null;
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
            var data = await formStructureRepository.GetAsync(id);
            if (data is null)
            {
                response.ErrorMessage = $"La estructura del formulario con el id {id} no fue encontrada";
                return response;
            }

            mapper.Map(formStructureRequestDto, data);
            await formStructureRepository.UpdateAsync();
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

    public async Task<BaseResponse> AddInputAsync(FormStructureInputRequestDto formStructureInput)
    {
        var response = new BaseResponse();
        try
        {
            await formStructureRepository.AddInput(formStructureInput.FormStructureId, formStructureInput.InputId);
            response.Success = true;
        }
        catch (Exception e)
        {
            response.ErrorMessage = "No se pudo agregar el input a la estructura del formulario";
        }

        return response;
    }
}