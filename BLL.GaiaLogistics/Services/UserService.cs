using AutoMapper;
using Contracts.GaiaLogistics.Services;
using Contracts.GaiaLogistics.UnitOfWork;
using Domain.GaiaLogistics.Entities;
using Domain.GaiaLogistics.Models;

namespace BLL.GaiaLogistics.Services
{
    public sealed class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public void Create(User entity)
        {
            UserModel userModel = _mapper.Map<UserModel>(entity);
            _unitOfWork.Users.Create(userModel);
            _unitOfWork.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var userModel = _unitOfWork.Users.GetById(id);
            _unitOfWork.Users.Delete(userModel);
            _unitOfWork.SaveChanges();
        }

        public List<User> GetAll()
        {
            var userModels = _unitOfWork.Users.GetAll(tracking: false).ToList();
            List<User> users = _mapper.Map<List<User>>(userModels);
            return users;
        }

        public User GetById(Guid id)
        {
            var userModel = _unitOfWork.Users.GetById(id);
            User user = _mapper.Map<User>(userModel);
            return user;
        }

        public void Update(User entity)
        {
            var userModel = _unitOfWork.Users.GetById(entity.Id);
            _mapper.Map(entity, userModel);
            _unitOfWork.Users.Update(userModel);
            _unitOfWork.SaveChanges();
        }
    }
}
