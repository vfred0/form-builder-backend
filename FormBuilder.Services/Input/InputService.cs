using AutoMapper;
using FormBuilder.Dtos.Request;
using FormBuilder.Dtos.Response;
using FormBuilder.Entities;
using FormBuilder.Repositories.Input;

namespace FormBuilder.Services.Input;

public class InputService(IInputRepository inputRepository, IMapper mapper) : IInputService
{
    public async Task<GenericBaseResponseDto<ICollection<InputResponseDto>>> GetAsync()
    {
        var response = new GenericBaseResponseDto<ICollection<InputResponseDto>>();
        try
        {
            var data = await inputRepository.GetAsync();
            response.Data = mapper.Map<ICollection<InputResponseDto>>(data);
            response.Success = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = "No se pudo obtener los inputs";
        }

        return response;
    }

    public async Task<GenericBaseResponseDto<string>> AddAsync(InputRequestDto inputRequestDto)
    {
        var response = new GenericBaseResponseDto<string>();
        try
        {
            response.Data = await inputRepository.AddAsync(mapper.Map<InputEntity>(inputRequestDto));
            response.Success = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = "No se pudo guardar el input";
        }

        return response;
    }

    public async Task<BaseResponse> UpdateAsync(string id, InputRequestDto inputRequestDto)
    {
        var response = new BaseResponse();
        try
        {
            await inputRepository.UpdateAsync(id, inputRequestDto);
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