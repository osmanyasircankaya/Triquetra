using Triquetra.Domain.Data.Entities;
using Triquetra.Domain.Data.Repositories;
using Triquetra.Core.Data.Repositories;
using Triquetra.Migrations;

namespace Triquetra.Infrastructure.Data.Repositories
{
    public class ContractMaterialRepository : Repository<ContractMaterial>, IContractMaterialRepository
    {
        public ContractMaterialRepository(DatabaseContext context) : base(context)
        {
        }
    }
}