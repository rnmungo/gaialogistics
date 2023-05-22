using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using BLL.GaiaLogistics.Extensions;
using Contracts.GaiaLogistics.Services;
using Domain.GaiaLogistics.Entities;
using Domain.GaiaLogistics.Enums;
using UI.GaiaLogistics.ViewModels;

namespace UI.GaiaLogistics.Controllers
{
    [Route("api/branch")]
    [ApiController]
    public class BranchController : Controller
    {
        private readonly IBranchService _branchService;
        private readonly IMapper _mapper;

        public BranchController(IMapper mapper, IBranchService branchService)
        {
            _branchService = branchService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] BranchFiltersRequestViewModel viewModel)
        {
            List<Branch> branches;
            if (!viewModel.BranchType.IsNullOrEmpty())
            {
                BranchTypeEnum branchType = viewModel.BranchType.ToEnum<BranchTypeEnum>();
                branches = _branchService.GetByBranchType(branchType);
            }
            else
            {
                branches = _branchService.GetAll();
            }
            List<BranchListResponseViewModel> viewModels = _mapper.Map<List<BranchListResponseViewModel>>(branches);
            return Ok(viewModels);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var branch = _branchService.GetById(id);
            if (branch is null) return NotFound();
            BranchResponseViewModel viewModel = _mapper.Map<BranchResponseViewModel>(branch);
            return Ok(viewModel);
        }

        [HttpPost]
        public IActionResult Create([FromBody] BranchCreateRequestViewModel viewModel)
        {
            var branch = _mapper.Map<Branch>(viewModel);
            _branchService.Create(branch);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var branch = _branchService.GetById(id);
            if (branch is null) return NotFound();
            _branchService.Delete(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] BranchUpdateRequestViewModel viewModel)
        {
            var branch = _branchService.GetById(id);
            if (branch is null) return NotFound();
            _mapper.Map(viewModel, branch);
            _branchService.Update(branch);
            return Ok();
        }
    }
}
