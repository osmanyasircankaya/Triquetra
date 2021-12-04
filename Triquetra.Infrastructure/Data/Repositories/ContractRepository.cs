using Triquetra.Domain.Data.Entities;
using Triquetra.Domain.Data.Repositories;
using Triquetra.Core.Data.Repositories;
using Triquetra.Migrations;

namespace Triquetra.Infrastructure.Data.Repositories
{
    public class ContractRepository : Repository<Contract>, IContractRepository
    {
        public ContractRepository(DatabaseContext context) : base(context)
        {
        }
    }
}