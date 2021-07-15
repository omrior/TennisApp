using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
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
        private readonly IMapper _mapper;
        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            // _context = context; // can be removed
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers() // CHange return type from AppUser to MemberDto
        {
            var users = await _userRepository.GetUsersAsync();
            var usersToReturn = _mapper.Map<IEnumerable<MemberDto>>(users); // We map the users to the MemberDto
            return Ok(usersToReturn); // Wrap it in Ok() response after change is made from context to userRepo
        }


        [HttpGet("{username}")]
        public async Task<ActionResult<MemberDto>> GetUser(string username) // CHange return type from AppUser to MemberDto
        {
            var user = await _userRepository.GetElementByUsernameAsync(username);
            return _mapper.Map<MemberDto>(user);
        }


        /*[HttpPost]
        public ActionResult<IEnumerable<AppUser>> GetUsers() 
        {
            var users = _context.Users.ToList();

            return users;
        }*/
    }
}