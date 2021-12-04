using Triquetra.Domain.Data.Entities;
using Triquetra.Domain.Data.Repositories;
using Triquetra.Core.Data.Repositories;
using Triquetra.Migrations;

namespace Triquetra.Infrastructure.Data.Repositories
{
    public class MaterialRepository : Repository<Material>, IMaterialRepository
    {
        public MaterialRepository(DatabaseContext context) : base(context)
        {
        }
    }
}