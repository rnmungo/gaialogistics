using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Contracts.GaiaLogistics.Services;
using Domain.GaiaLogistics.Entities;
using UI.GaiaLogistics.ViewModels;

namespace UI.GaiaLogistics.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IMapper mapper, IUserService userService)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            List<UserListResponseViewModel> viewModels = _mapper.Map<List<UserListResponseViewModel>>(users);
            return Ok(viewModels);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var user = _userService.GetById(id);
            if (user is null) return NotFound();
            UserResponseViewModel viewModel = _mapper.Map<UserResponseViewModel>(user);
            return Ok(viewModel);
        }

        [HttpPost]
        public IActionResult Create([FromBody] UserCreateRequestViewModel viewModel)
        {
            var user = _mapper.Map<User>(viewModel);
            _userService.Create(user);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var user = _userService.GetById(id);
            if (user is null) return NotFound();
            _userService.Delete(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] UserUpdateRequestViewModel viewModel)
        {
            var user = _userService.GetById(id);
            if (user is null) return NotFound();
            _mapper.Map(viewModel, user);
            _userService.Update(user);
            return Ok();
        }
    }
}
