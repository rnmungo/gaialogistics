using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Domain.GaiaLogistics.Models;
using Contracts.GaiaLogistics.Repositories;

namespace Contracts.GaiaLogistics.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; }
        IRepository<BranchModel> Branches { get; }
        IRepository<CityModel> Cities { get; }
        IRepository<CountryModel> Countries { get; }
        IRepository<ProductModel> Products { get; }
        IRepository<ProvinceModel> Provinces { get; }
        IRepository<StockMovementItemModel> StockMovementItems { get; }
        IRepository<StockMovementModel> StockMovements { get; }
        IRepository<UserModel> Users { get; }
        IDbContextTransaction BeginTransaction();
        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
