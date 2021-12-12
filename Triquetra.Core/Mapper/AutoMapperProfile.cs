using AutoMapper;
using Triquetra.Domain.Data.Entities;
using Triquetra.Domain.DTO;
using Triquetra.Domain.DTO.Contracts;
using Triquetra.Domain.DTO.Materials;
using Triquetra.Domain.DTO.Offers;
using Triquetra.Domain.DTO.Products;
using Triquetra.Domain.DTO.ProductTypes;

namespace Triquetra.Core.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Material, MaterialDTO>();
            CreateMap<MaterialUnit, MaterialUnitDTO>();
            CreateMap<Contract, ContractDTO>();
            CreateMap<Product, ProductDTO>();
            CreateMap<Product, ProductTypeDTO>();
            CreateMap<Offer, OfferDTO>();
        }
    }
}