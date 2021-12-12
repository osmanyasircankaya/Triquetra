using Triquetra.Domain.Data.Repositories;

namespace Triquetra.Domain.Data
{
    public interface IUnitOfWork
    {
        IContractRepository Contracts { get; }
        IMaterialRepository Materials { get; }
        IMaterialUnitRepository MaterialUnits { get; }
        IContractMaterialRepository ContractMaterials { get; }
        IOfferRepository Offers { get; }
        IProductRepository Products { get; }
        IProductTypeRepository ProductTypes { get; }
        Task CommitAsync();
    }
}