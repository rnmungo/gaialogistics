using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Contracts.GaiaLogistics.Services;
using Domain.GaiaLogistics.Entities;
using UI.GaiaLogistics.ViewModels;
using BLL.GaiaLogistics.Exceptions;

namespace UI.GaiaLogistics.Controllers
{
    [Route("api/stock-movement")]
    [ApiController]
    public class StockMovementController : Controller
    {
        private readonly IStockMovementService _stockMovementService;
        private readonly IStockMovementReportingService _stockMovementReportingService;
        private readonly IMapper _mapper;

        public StockMovementController(IMapper mapper, IStockMovementService stockMovementService, IStockMovementReportingService _reportingService)
        {
            _mapper = mapper;
            _stockMovementService = stockMovementService;
            _stockMovementReportingService = _reportingService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<StockMovement> stockMovements = _stockMovementService.GetAll();
            var response = _mapper.Map<List<StockMovementPagedResponseViewModel>>(stockMovements);
            return Ok(response);
        }

        [HttpGet("search")]
        public IActionResult Search([FromQuery] StockMovementFiltersRequestViewModel viewModel)
        {
            Paged<StockMovement> result = _stockMovementReportingService.Search(
                viewModel.SizeLimit,
                viewModel.CurrentPage,
                viewModel.From.ToUniversalTime(),
                viewModel.To.ToUniversalTime(),
                viewModel.OriginId,
                viewModel.DestinationId,
                viewModel.UserId,
                viewModel.CauseType,
                viewModel.DepositFilter);
            Paged<StockMovementPagedResponseViewModel> response = new Paged<StockMovementPagedResponseViewModel>()
            {
                CurrentPage = result.CurrentPage,
                SizeLimit = result.SizeLimit,
                Total = result.Total,
                Results = _mapper.Map<List<StockMovementPagedResponseViewModel>>(result.Results)
            };
            return Ok(response);
        }

        [HttpGet("reports/min-three-operations")]
        public IActionResult GetMinThreeOperations()
        {
            List<StockMovement> stockMovements = _stockMovementReportingService.GetMinThreeOperations();
            var response = _mapper.Map<List<StockMovementPagedResponseViewModel>>(stockMovements);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            StockMovement stockMovement = _stockMovementService.GetById(id);
            var response = _mapper.Map<StockMovementPagedResponseViewModel>(stockMovement);
            return Ok(response);
        }

        [HttpPost("transfer")]
        public IActionResult Transfer([FromBody] StockMovementTransferRequestViewModel viewModel)
        {
            var stockMovementItems = _mapper.Map<List<StockMovementItem>>(viewModel.Items);
            try
            {
                _stockMovementService.Transfer(viewModel.OriginId, viewModel.DestinationId, viewModel.UserId, stockMovementItems);
                return Ok();
            }
            catch (BusinessException ex)
            {
                return BadRequest(new { Code = ex.BusinessCode.ToString(), Message = ex.Message });
            }
        }

        [HttpPost("inventory")]
        public IActionResult Inventory([FromBody] StockMovementInventoryRequestViewModel viewModel)
        {
            var stockMovementItems = _mapper.Map<List<StockMovementItem>>(viewModel.Items);
            _stockMovementService.Inventory(viewModel.BranchId, viewModel.UserId, stockMovementItems);
            return Ok();
        }
    }
}
