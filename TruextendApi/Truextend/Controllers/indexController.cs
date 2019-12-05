using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Truextend.Models;
using Truextend.Service;

namespace Truextend.Controllers
{
    [Route("api/[controller]")]
    public class indexController : ControllerBase
    {
        private IUserService userService;
        public indexController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public ActionResult<List<string>> getUsers() {
            try
            {
                return Ok(userService.getUsers());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "something bad happened");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            try
            {
                return Ok(userService.getUser(id));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<User> PostUser([FromBody] User newUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createUser = userService.creatUser(newUser);
            return Created($"/api/computers/{newUser.id}", newUser);
        }

        [HttpDelete]
        public ActionResult<bool> DeleteUser([FromBody]int id)
        {
            try
            {
                var result = userService.deleteUser(id);
                if (!result)
                    return StatusCode(StatusCodes.Status500InternalServerError, "cannot delete this user.");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public ActionResult<User> PutUser([FromBody]User user)
        {
            try
            {
                return Ok(userService.editUser(user));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
