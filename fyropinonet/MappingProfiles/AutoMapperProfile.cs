using AutoMapper;
using fyropinonet.Contracts;
using fyropinonet.Models;

namespace fyropinonet.MappingProfiles;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<CreateContractorRequest, Contractor>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
        
        CreateMap<UpdateContractorRequest, Contractor>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
    }
}
