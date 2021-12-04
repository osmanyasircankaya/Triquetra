﻿using Triquetra.Domain.DTO.Materials;

namespace Triquetra.Domain.Data.Entities
{
    public class ContractMaterial : BaseEntity
    {
        public int ContractId { get; set; }
        public int MaterialId { get; set; }
        public Contract Contract { get; set; }
        public Material Material { get; set; }
    }
}