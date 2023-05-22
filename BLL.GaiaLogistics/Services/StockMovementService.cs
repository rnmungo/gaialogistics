using AutoMapper;
using Microsoft.EntityFrameworkCore;
using BLL.GaiaLogistics.Exceptions;
using Contracts.GaiaLogistics.Services;
using Contracts.GaiaLogistics.UnitOfWork;
using Domain.GaiaLogistics.Entities;
using Domain.GaiaLogistics.Enums;
using Domain.GaiaLogistics.Models;

namespace BLL.GaiaLogistics.Services
{
    public sealed class StockMovementService : IStockMovementService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public StockMovementService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public void Create(StockMovement entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<StockMovement> GetAll()
        {
            List<StockMovementModel> stockMovementModels = _unitOfWork.StockMovements
                .GetAll(tracking: false)
                .Include(s => s.BranchOrigin)
                .Include(s => s.BranchDestination)
                .Include(s => s.User)
                .Include(s => s.StockMovementItems)
                .ThenInclude(i => i.Product)
                .Select(s => new StockMovementModel() {
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
                .OrderByDescending(s => s.CreatedAt)
                .ToList();
            List<StockMovement> stockMovements = _mapper.Map<List<StockMovement>>(stockMovementModels);
            return stockMovements;
        }

        public StockMovement GetById(Guid id)
        {
            var stockMovementModel = _unitOfWork.StockMovements
                .GetByCondition(s => s.Id == id, includes: "StockMovementItems", tracking: true)
                .Include(s => s.BranchOrigin)
                .Include(s => s.BranchDestination)
                .Include(s => s.User)
                .Include(s => s.StockMovementItems)
                .ThenInclude(i => i.Product)
                .Select(s => new StockMovementModel() {
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
                .FirstOrDefault();
            StockMovement stockMovement = _mapper.Map<StockMovement>(stockMovementModel);
            return stockMovement;
        }

        public void Inventory(Guid originId, Guid userId, List<StockMovementItem> items)
        {
            // TODO: Sumarizar el stock de la sucursal, crear un único movimiento y eliminar el resto
            StockMovementModel stockMovementModel = new StockMovementModel()
            {
                BranchOriginId = originId,
                BranchDestinationId = originId,
                UserId = userId,
                CauseType = CauseTypeEnum.Inventory.ToString(),
            };
            List<StockMovementItemModel> stockMovementItemModels = _mapper.Map<List<StockMovementItemModel>>(items);
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                _unitOfWork.StockMovements.Create(stockMovementModel);
                _unitOfWork.SaveChanges();
                foreach (StockMovementItemModel item in stockMovementItemModels)
                {
                    item.StockMovementId = stockMovementModel.Id;
                    _unitOfWork.StockMovementItems.Create(item);
                }
                _unitOfWork.SaveChanges();
                transaction.Commit();
            }
        }

        public void Transfer(Guid originId, Guid destinationId, Guid userId, List<StockMovementItem> items)
        {
            BranchModel originBranchModel = _unitOfWork.Branches.GetById(originId);
            if (originBranchModel == null)
            {
                throw new BusinessException(BusinessCodeEnum.GAIA_001, $"La sucursal no existe. Id: {originId}");
            }

            if (originBranchModel.BranchType == BranchTypeEnum.Store.ToString())
            {
                throw new BusinessException(BusinessCodeEnum.GAIA_003, $"No es posible enviar stock desde una tienda. Id: {originId}");
            }

            BranchModel destinationBranchModel = _unitOfWork.Branches.GetById(destinationId);
            if (destinationBranchModel == null)
            {
                throw new BusinessException(BusinessCodeEnum.GAIA_001, $"La sucursal no existe. Id: {destinationId}");
            }

            StockMovementModel stockMovementModel = new StockMovementModel() {
                BranchOriginId = originId,
                BranchDestinationId = destinationId,
                UserId = userId,
                CauseType = CauseTypeEnum.Transfer.ToString(),
            };
            List<StockMovementItemModel> stockMovementItemModels = _mapper.Map<List<StockMovementItemModel>>(items);
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                try
                {
                    _unitOfWork.StockMovements.Create(stockMovementModel);
                    _unitOfWork.SaveChanges();
                    foreach (StockMovementItemModel item in stockMovementItemModels)
                    {
                        int availableStock = GetAvailableStock(item.ProductId, originId);
                        if (item.Quantity > availableStock)
                        {
                            ProductModel productModel = _unitOfWork.Products.GetById(item.ProductId);
                            throw new BusinessException(BusinessCodeEnum.GAIA_002, $"Límite de stock, no se puede enviar más de {availableStock} unidades de {productModel.Name}");
                        }
                        item.StockMovementId = stockMovementModel.Id;
                        _unitOfWork.StockMovementItems.Create(item);
                    }
                    _unitOfWork.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void Update(StockMovement entity)
        {
            throw new NotImplementedException();
        }

        private int GetAvailableStock(Guid productId, Guid branchId)
        {
            int initial = _unitOfWork.StockMovementItems
                .GetByCondition(i => i.ProductId == productId, includes: "StockMovement", tracking: false)
                .Where(i => i.StockMovement.BranchDestinationId == branchId && i.StockMovement.CauseType == CauseTypeEnum.Inventory.ToString())
                .Sum(i => i.Quantity);
            int inputs = _unitOfWork.StockMovementItems
                .GetByCondition(i => i.ProductId == productId, includes: "StockMovement", tracking: false)
                .Where(i => i.StockMovement.BranchDestinationId == branchId && i.StockMovement.CauseType == CauseTypeEnum.Transfer.ToString())
                .Sum(i => i.Quantity);
            int outputs = _unitOfWork.StockMovementItems
                .GetByCondition(i => i.ProductId == productId, includes: "StockMovement", tracking: false)
                .Where(i => i.StockMovement.BranchOriginId == branchId && i.StockMovement.CauseType == CauseTypeEnum.Transfer.ToString())
                .Sum(i => i.Quantity);
            return (initial + inputs) - outputs;
        }
    }
}
