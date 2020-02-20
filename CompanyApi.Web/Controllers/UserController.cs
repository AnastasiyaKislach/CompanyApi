using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using CompanyApi.Services.Contracts;
using CompanyApi.Web.Models;
using CompanyApi.Services.Models;

namespace CompanyApi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserViewModel>> GetById(int id)
        {
            var user = await _userService.GetById(id);

            if (user == null)
            {
                return NotFound();
            }

            var userResource = _mapper.Map<User, UserViewModel>(user);

            return Ok(userResource);
        }

        [HttpGet("")]
        public async Task<ActionResult<List<UserViewModel>>> GetAll()
        {
            var users = await _userService.GetAll();
            var result = _mapper.Map<List<UserViewModel>>(users);
            return Ok(result);
        }

        [HttpPost("")]
        public async Task<ActionResult<UserViewModel>> Create(UserViewModel userViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userToCreate = _mapper.Map<UserViewModel, User>(userViewModel);

            var newUserId = await _userService.Create(userToCreate);

            var user = await _userService.GetById(newUserId);

            var userResource = _mapper.Map<User, UserViewModel>(user);

            return Ok(userResource);
        }

        [HttpPut("")]
        public async Task<ActionResult<UserViewModel>> Update(UserViewModel userViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _mapper.Map<UserViewModel, User>(userViewModel);

            await _userService.Update(user);

            var updatedUser = await _userService.GetById(user.Id);
            var updatedUserResource = _mapper.Map<User, UserViewModel>(updatedUser);

            return Ok(updatedUserResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var user = await _userService.GetById(id);

            if (user == null)
            {
                return NotFound();
            }

            await _userService.Delete(id);

            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Update(UserUpdateCompanyViewModel userViewModel, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userService.GetById(id);

            if (user == null)
            {
                return NotFound();
            }

            var userToUpdate = _mapper.Map<UserUpdateCompanyViewModel, User>(userViewModel);

            user.CompanyId = userToUpdate.CompanyId;

            await _userService.Update(user);

            return new NoContentResult();
        }
    }
}