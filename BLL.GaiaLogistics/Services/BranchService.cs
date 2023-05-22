using AutoMapper;
using Contracts.GaiaLogistics.Services;
using Contracts.GaiaLogistics.UnitOfWork;
using Domain.GaiaLogistics.Entities;
using Domain.GaiaLogistics.Enums;
using Domain.GaiaLogistics.Models;

namespace BLL.GaiaLogistics.Services
{
    public sealed class BranchService : IBranchService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public BranchService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public void Create(Branch entity)
        {
            BranchModel branchModel = _mapper.Map<BranchModel>(entity);
            _unitOfWork.Branches.Create(branchModel);
            _unitOfWork.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var branchModel = _unitOfWork.Branches.GetById(id);
            _unitOfWork.Branches.Delete(branchModel);
            _unitOfWork.SaveChanges();
        }

        public List<Branch> GetAll()
        {
            var branchModels = _unitOfWork.Branches.GetAll(tracking: false).ToList();
            List<Branch> branches = _mapper.Map<List<Branch>>(branchModels);
            return branches;
        }

        public List<Branch> GetByBranchType(BranchTypeEnum branchType)
        {
            var branchModels = _unitOfWork.Branches
                .GetByCondition(branch => branch.BranchType == branchType.ToString())
                .ToList();
            List<Branch> branches = _mapper.Map<List<Branch>>(branchModels);
            return branches;
        }

        public Branch GetById(Guid id)
        {
            var branchModel = _unitOfWork.Branches.GetById(id);
            Branch branch = _mapper.Map<Branch>(branchModel);
            return branch;
        }

        public void Update(Branch entity)
        {
            var branchModel = _unitOfWork.Branches.GetById(entity.Id);
            _mapper.Map(entity, branchModel);
            _unitOfWork.Branches.Update(branchModel);
            _unitOfWork.SaveChanges();
        }
    }
}
