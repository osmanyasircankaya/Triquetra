using Triquetra.Domain.Data;
using Triquetra.Domain.Data.Entities;
using Triquetra.Domain.Data.Repositories;
using Triquetra.Core.Data.Repositories;
using Triquetra.Infrastructure.Data.Repositories;
using Triquetra.Migrations;

namespace Triquetra.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }

        public IMaterialRepository Materials => new MaterialRepository(_context);
        public IContractRepository Contracts => new ContractRepository(_context);
        public IMaterialUnitRepository MaterialUnits => new MaterialUnitRepository(_context);
        public IContractMaterialRepository ContractMaterials => new ContractMaterialRepository(_context);
        public IOfferRepository Offers => new OfferRepository(_context);
        public IProductRepository Products => new ProductRepository(_context);
        public IProductTypeRepository ProductTypes => new ProductTypeRepository(_context);
        public IExchangeRateRepository ExchangeRates => new ExchangeRateRepository(_context);

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}