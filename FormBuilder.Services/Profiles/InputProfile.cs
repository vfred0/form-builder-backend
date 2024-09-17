using AutoMapper;
using FormBuilder.Dtos.Request;
using FormBuilder.Dtos.Response;
using FormBuilder.Entities;

namespace FormBuilder.Services.Profiles;

public class InputProfile : Profile
{
    public InputProfile()
    {
        CreateMap<InputEntity, InputDto>();
        CreateMap<InputDto, InputEntity>();
    }
}