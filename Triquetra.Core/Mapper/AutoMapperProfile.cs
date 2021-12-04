using AutoMapper;
using Triquetra.Domain.Data.Entities;
using Triquetra.Domain.DTO;
using Triquetra.Domain.DTO.Contracts;
using Triquetra.Domain.DTO.Materials;

namespace Triquetra.Core.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Material, MaterialDTO>();
            CreateMap<MaterialUnit, MaterialUnitDTO>();
            CreateMap<Contract, ContractDTO>();
        }
    }
}