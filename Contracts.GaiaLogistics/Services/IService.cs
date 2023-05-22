using Domain.GaiaLogistics.Contracts;

namespace Contracts.GaiaLogistics.Services
{
    public interface IService<T> where T : class, IBaseEntity
    {
        void Create(T entity);
        void Delete(Guid id);
        List<T> GetAll();
        T GetById(Guid id);
        void Update(T entity);
    }
}
