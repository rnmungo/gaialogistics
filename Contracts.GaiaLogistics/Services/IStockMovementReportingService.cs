using Domain.GaiaLogistics.Entities;

namespace Contracts.GaiaLogistics.Services
{
    public interface IStockMovementReportingService
    {
        Paged<StockMovement> Search(int size, int currentPage, DateTime from, DateTime to, string origin, string destiny, string user, string causeType, string filterDeposits);
        List<StockMovement> GetMinThreeOperations();
    }
}
