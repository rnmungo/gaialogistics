using Domain.GaiaLogistics.Entities;
using Domain.GaiaLogistics.Enums;

namespace Contracts.GaiaLogistics.Services
{
    public interface IBranchService : IService<Branch>
    {
        List<Branch> GetByBranchType(BranchTypeEnum branchType);
    }
}
