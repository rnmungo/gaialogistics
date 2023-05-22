using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using Contracts.GaiaLogistics.Repositories;
using Contracts.GaiaLogistics.UnitOfWork;
using DAL.GaiaLogistics.Exceptions;
using DAL.GaiaLogistics.Repositories;
using Domain.GaiaLogistics.Models;

namespace DAL.GaiaLogistics.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly AppDbContext _context;
        private IRepository<BranchModel> _branchesRepository;
        private IRepository<CityModel> _citiesRepository;
        private IRepository<CountryModel> _countriesRepository;
        private IRepository<ProductModel> _productsRepository;
        private IRepository<ProvinceModel> _provincesRepository;
        private IRepository<StockMovementModel> _stockMovementsRepository;
        private IRepository<StockMovementItemModel> _stockMovementItemsRepository;
        private IRepository<UserModel> _usersRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public DbContext Context => _context;

        public IRepository<BranchModel> Branches => _branchesRepository ??= new EntityFrameworkCoreRepository<BranchModel>(_context);

        public IRepository<CityModel> Cities => _citiesRepository ??= new EntityFrameworkCoreRepository<CityModel>(_context);

        public IRepository<CountryModel> Countries => _countriesRepository ??= new EntityFrameworkCoreRepository<CountryModel>(_context);

        public IRepository<ProductModel> Products => _productsRepository ??= new EntityFrameworkCoreRepository<ProductModel>(_context);

        public IRepository<ProvinceModel> Provinces => _provincesRepository ??= new EntityFrameworkCoreRepository<ProvinceModel>(_context);

        public IRepository<StockMovementModel> StockMovements => _stockMovementsRepository ??= new EntityFrameworkCoreRepository<StockMovementModel>(_context);

        public IRepository<StockMovementItemModel> StockMovementItems => _stockMovementItemsRepository ??= new EntityFrameworkCoreRepository<StockMovementItemModel>(_context);
        public IRepository<UserModel> Users => _usersRepository ??= new EntityFrameworkCoreRepository<UserModel>(_context);

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        public int SaveChanges()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ex.Entries.Single().Reload();
                return _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new EFCoreDataException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new EFCoreDataException(ex.Message, ex);
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ex.Entries.Single().Reload();
                return await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new EFCoreDataException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new EFCoreDataException(ex.Message, ex);
            }
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            try
            {
                return await _context.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ex.Entries.Single().Reload();
                return await _context.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateException ex)
            {
                throw new EFCoreDataException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new EFCoreDataException(ex.Message, ex);
            }
        }
    }
}
