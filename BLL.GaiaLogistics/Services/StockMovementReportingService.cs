using AutoMapper;
using Microsoft.EntityFrameworkCore;
using BLL.GaiaLogistics.Constants;
using BLL.GaiaLogistics.Extensions;
using Contracts.GaiaLogistics.Services;
using Contracts.GaiaLogistics.UnitOfWork;
using Domain.GaiaLogistics.Entities;
using Domain.GaiaLogistics.Models;
using System.Globalization;

namespace BLL.GaiaLogistics.Services
{
    public sealed class StockMovementReportingService : IStockMovementReportingService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public StockMovementReportingService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public List<StockMovement> GetMinThreeOperations()
        {
            DateTime utcNow = DateTime.UtcNow.Date;
            var destinations = _unitOfWork.StockMovements
                .GetAll(tracking: false)
                .Where(s => s.CreatedAt.Date == utcNow)
                .GroupBy(s => s.BranchDestinationId)
                .Where(g => g.Count() > 3)
                .Select(g => g.Key).ToList();
            var models = _unitOfWork.StockMovements
                .GetAll(tracking: false)
                .Include(s => s.BranchOrigin)
                .Include(s => s.BranchDestination)
                .Include(s => s.User)
                .Include(s => s.StockMovementItems)
                .ThenInclude(i => i.Product)
                .Where(s => s.CreatedAt.Date == utcNow)
                .Where(s => destinations.Contains(s.BranchDestinationId))
                .Select(s => new StockMovementModel()
                {
                    Id = s.Id,
                    BranchOriginId = s.BranchOriginId,
                    BranchDestinationId = s.BranchDestinationId,
                    UserId = s.UserId,
                    CauseType = s.CauseType,
                    CreatedAt = s.CreatedAt,
                    BranchOrigin = s.BranchOrigin,
                    BranchDestination = s.BranchDestination,
                    User = s.User,
                    StockMovementItems = s.StockMovementItems.Select(i => new StockMovementItemModel()
                    {
                        Id = i.Id,
                        ProductId = i.ProductId,
                        Product = i.Product,
                        Quantity = i.Quantity,
                    }).ToList(),
                })
                .OrderBy(s => s.CreatedAt)
                .ToList();
            List<StockMovement> stockMovements = _mapper.Map<List<StockMovement>>(models);
            return stockMovements;
        }

        public Paged<StockMovement> Search(int size, int currentPage, DateTime from, DateTime to, string origin = "", string destiny = "", string user = "", string causeType = "", string filterDeposits = Filters.UnionFilter)
        {
            var query = _unitOfWork.StockMovements
                .GetAll(tracking: false)
                .Include(s => s.BranchOrigin)
                .Include(s => s.BranchDestination)
                .Include(s => s.User)
                .Include(s => s.StockMovementItems)
                .ThenInclude(i => i.Product)
                .Where(s => s.CreatedAt >= from && s.CreatedAt <= to)
                .Where(s => s.User.Email.Contains(user));
            if (filterDeposits.Equals(Filters.UnionFilter))
            {
                if (!origin.IsNullOrEmpty())
                {
                    query = query.Where(s => s.BranchOrigin.Code.Contains(origin));
                }

                if (!destiny.IsNullOrEmpty())
                {
                    query = query.Where(s => s.BranchDestination.Code.Contains(destiny));
                }
            }
            else
            {
                query = query.Where(s => s.BranchOrigin.Code.Contains(origin) || s.BranchDestination.Code.Contains(destiny));
            }

            if (!causeType.IsNullOrEmpty())
            {
                query = query.Where(s => s.CauseType.Contains(causeType));
            }

            var orderedQuery = query.Select(s => new StockMovementModel()
            {
                Id = s.Id,
                BranchOriginId = s.BranchOriginId,
                BranchDestinationId = s.BranchDestinationId,
                UserId = s.UserId,
                CauseType = s.CauseType,
                CreatedAt = s.CreatedAt,
                BranchOrigin = s.BranchOrigin,
                BranchDestination = s.BranchDestination,
                User = s.User,
                StockMovementItems = s.StockMovementItems.Select(i => new StockMovementItemModel()
                {
                    Id = i.Id,
                    ProductId = i.ProductId,
                    Product = i.Product,
                    Quantity = i.Quantity,
                }).ToList(),
            }).OrderByDescending(s => s.CreatedAt);
            List<StockMovementModel> pagedElements = orderedQuery.Skip((currentPage - 1) * size).Take(size).ToList();
            List<StockMovementModel> totalElements = orderedQuery.ToList();
            List<StockMovement> stockMovements = _mapper.Map<List<StockMovement>>(pagedElements);
            return new Paged<StockMovement>()
            {
                Results = stockMovements,
                CurrentPage = currentPage,
                SizeLimit = size,
                Total = totalElements.Count,
            };
        }
    }
}
