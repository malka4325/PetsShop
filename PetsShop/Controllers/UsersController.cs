using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Reflection.PortableExecutable;
using System.Text.Json;
using Zxcvbn;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetsShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UserService userService = new UserService();
        string path = Path.Combine(Directory.GetCurrentDirectory(), "users.txt");
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            
            User user = userService.getUserById(id);
            if(user ==null)
                return NotFound();

            return Ok(user);//write in c# code
     
        }

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            User userAdd = userService.addUser(user);
            if (userAdd == null) return BadRequest();
            return CreatedAtAction(nameof(Get), new { id = userAdd.UserId }, userAdd);

        }

        //POST api/<UsersController>
        [HttpPost("login")]
         public IActionResult Post([FromBody] UserLogin userLogin)
        {
            
            User user = userService.login(userLogin);
            if (user == null)
                return Unauthorized();

            return Ok(user);//write in c# code
           

        }
        [HttpPost("password")]
        public IActionResult Post([FromBody]  string pass)
        {
            int res = userService.checkPassPower(pass);
            switch (res)
            {
                case 0:
                    return Forbid("Too weak password");
                case 1:
                    return Forbid("Too weak password");
                case 2:
                    return Ok("Weak");
                case 3:
                    return Ok("good");
                case 4:
                    return Ok("strong");
            }
            return BadRequest();
        }
        
           
        
        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User userToUpdate)
        {
           
            userService.updateUser(id, userToUpdate);

        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
