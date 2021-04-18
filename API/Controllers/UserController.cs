using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Data;
using Models;

namespace Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase ,IUserController
    {
        private IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<User>> RegisterUser([FromBody] User user)
        {
            try
            {
                userService.RegisterUser(user);
                return Ok(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet]
        public async Task<ActionResult<User>> ValidateUser([FromQuery]string username, [FromQuery]string password)
        {
            try
            {
                User valid = userService.ValidateUser(username, password);
                return Ok(valid);
            }catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500, e.Message);
            }
        }
        [HttpPut]
        public async Task<ActionResult<User>> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
        [HttpDelete]
        public async Task<ActionResult<User>> RemoveUser(int userId)
        {
            throw new NotImplementedException();
        }

        
    }
}