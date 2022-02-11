using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EnsolversBL.Data;
using EnsolversBL.Models;
using EnsolversBL.Data.Interface;
using EnsolversBL.Services;
using EnsolversBL.DTOs;

namespace EnsolversApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository repo;
        private readonly ITokenService tokenService;

        public AuthController(IAuthRepository repo, ITokenService tokenService)
        {
            this.repo = repo;
            this.tokenService = tokenService;

        }

        // POST: api/register
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDTO userDTO)
        {
            userDTO.Email = userDTO.Email.ToLower();
            if (await repo.UserExist(userDTO.Email))
            {
                return BadRequest("That email already exist");
            }
            var newUser = new User
            {
                Name = userDTO.Name,
                Email = userDTO.Email
            };
            var createdUser = await repo.Register(newUser, userDTO.Password);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDTO userLoginDTO)
        {
            var userFromRepo = await repo.Login(userLoginDTO.Email, userLoginDTO.Password);

            if(userFromRepo == null)
            {
                return Unauthorized();
            }
            var newUser = new UserListDTO
            {
                Id = userFromRepo.Id,
                Name = userFromRepo.Name,
                Email = userFromRepo.Email,
                Active = userFromRepo.Active,
            };

            var token = tokenService.CreateToken(userFromRepo);

            return Ok(new
            {
                token = token,
                user = newUser
            });
        }
    }
}
