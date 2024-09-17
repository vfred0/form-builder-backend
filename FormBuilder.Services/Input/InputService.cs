using AutoMapper;
using FormBuilder.Dtos.Request;
using FormBuilder.Dtos.Response;
using FormBuilder.Entities;
using FormBuilder.Repositories.Input;

namespace FormBuilder.Services.Input;

public class InputService(IInputRepository inputRepository, IMapper mapper) : IInputService
{
    public async Task<GenericBaseResponseDto<ICollection<InputDto>>> GetAsync()
    {
        var response = new GenericBaseResponseDto<ICollection<InputDto>>();
        try
        {
            var data = await inputRepository.GetAsync();
            response.Data = mapper.Map<ICollection<InputDto>>(data);
            response.Success = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = "No se pudo obtener los inputs";
        }

        return response;
    }

    public async Task<GenericBaseResponseDto<string>> AddAsync(InputDto inputDto)
    {
        var response = new GenericBaseResponseDto<string>();
        try
        {
            response.Data = await inputRepository.AddAsync(mapper.Map<InputEntity>(inputDto));
            response.Success = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = "No se pudo guardar el input";
        }

        return response;
    }

    public async Task<BaseResponse> UpdateAsync(string id, InputDto inputDto)
    {
        var response = new BaseResponse();
        try
        {
            await inputRepository.UpdateAsync(id, inputDto);
            response.Success = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = "No se pudo actualizar el input";
        }

        return response;
    }

    public async Task<BaseResponse> DeleteAsync(string id)
    {
        var response = new BaseResponse();
        try
        {
            await inputRepository.DeleteAsync(id);
            response.Success = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = "No se pudo eliminar el input";
        }

        return response;
    }
}