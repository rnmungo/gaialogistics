using Domain.GaiaLogistics.Entities;

namespace Contracts.GaiaLogistics.Services
{
    public interface IStockMovementService : IService<StockMovement>
    {
        StockMovement GetById(Guid id);
        void Transfer(Guid originId, Guid destinationId, Guid userId, List<StockMovementItem> items);
        void Inventory(Guid originId, Guid userId, List<StockMovementItem> items);
    }
}
