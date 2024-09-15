using AutoMapper;
using FormBuilder.Dtos.Request;
using FormBuilder.Dtos.Response;
using FormBuilder.Entities;

namespace FormBuilder.Services.Profiles;

public class FormStructureProfile : Profile
{
    public FormStructureProfile()
    {
        CreateMap<FormStructureEntity, FormStructureResponseDto>();
        CreateMap<FormStructureRequestDto, FormStructureEntity>();
    }
}