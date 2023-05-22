using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Contracts.GaiaLogistics.Services;
using Domain.GaiaLogistics.Entities;
using UI.GaiaLogistics.ViewModels;

namespace UI.GaiaLogistics.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IMapper mapper, IProductService productService)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _productService.GetAll();
            List<ProductListResponseViewModel> viewModels = _mapper.Map<List<ProductListResponseViewModel>>(products);
            return Ok(viewModels);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var product = _productService.GetById(id);
            if (product is null) return NotFound();
            ProductResponseViewModel viewModel = _mapper.Map<ProductResponseViewModel>(product);
            return Ok(viewModel);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ProductCreateRequestViewModel viewModel)
        {
            var product = _mapper.Map<Product>(viewModel);
            _productService.Create(product);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var product = _productService.GetById(id);
            if (product is null) return NotFound();
            _productService.Delete(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] ProductUpdateRequestViewModel viewModel)
        {
            var product = _productService.GetById(id);
            if (product is null) return NotFound();
            _mapper.Map(viewModel, product);
            _productService.Update(product);
            return Ok();
        }
    }
}
