using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        // private readonly DataContext _context; // can be removed
        // Change DataContext parameter to IUserRepository parameter
        private readonly IUserRepository _userRepository;
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            // _context = context; // can be removed
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return Ok(await _userRepository.GetUsersAsync()); // Wrap it in Ok() response after change is made from context to userRepo
        }


        [HttpGet("{username}")]
        public async Task<ActionResult<AppUser>> GetUser(string username)
        {
            return await _userRepository.GetElementByUsernameAsync(username);
        }


        /*[HttpPost]
        public ActionResult<IEnumerable<AppUser>> GetUsers() 
        {
            var users = _context.Users.ToList();

            return users;
        }*/
    }
}