using AutoMapper;
using Contracts.GaiaLogistics.Services;
using Contracts.GaiaLogistics.UnitOfWork;
using Domain.GaiaLogistics.Entities;
using Domain.GaiaLogistics.Models;

namespace BLL.GaiaLogistics.Services
{
    public sealed class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public void Create(Product entity)
        {
            ProductModel productModel = _mapper.Map<ProductModel>(entity);
            _unitOfWork.Products.Create(productModel);
            _unitOfWork.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var productModel = _unitOfWork.Products.GetById(id);
            _unitOfWork.Products.Delete(productModel);
            _unitOfWork.SaveChanges();
        }

        public List<Product> GetAll()
        {
            var productModels = _unitOfWork.Products.GetAll(tracking: false).ToList();
            List<Product> products = _mapper.Map<List<Product>>(productModels);
            return products;
        }

        public Product GetById(Guid id)
        {
            var productModel = _unitOfWork.Products.GetById(id);
            Product product = _mapper.Map<Product>(productModel);
            return product;
        }

        public void Update(Product entity)
        {
            var productModel = _unitOfWork.Products.GetById(entity.Id);
            _mapper.Map(entity, productModel);
            _unitOfWork.Products.Update(productModel);
            _unitOfWork.SaveChanges();
        }
    }
}
