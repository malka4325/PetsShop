using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Reflection.PortableExecutable;
using System.Text.Json;
using System.Threading.Tasks;
using Zxcvbn;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetsShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            
            User user = await _userService.getUserById(id);
            if(user ==null)
                return NotFound();

            return Ok(user);//write in c# code
     
        }
        //register
        // POST api/<UsersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            if (user.Password != null)
            {
            int score = _userService.checkPassPower(user.Password);
                if (score < 2)
                    return BadRequest("Password is too weak");
 
            User userAdd =await _userService.addUser(user);
           if (userAdd == null) return BadRequest(); 
            return CreatedAtAction(nameof(Get), new { id = userAdd.UserId }, userAdd);
            }
            return BadRequest("No password entered.");
        }

        //POST api/<UsersController>
        [HttpPost("login")]
         public async Task<IActionResult> Post([FromBody] UserLogin userLogin)
        {
            
            User user =await _userService.login(userLogin);
            if (user == null)
                return Unauthorized();

            return Ok(user);//write in c# code
           

        }
        [HttpPost("password")]
        public IActionResult Post([FromBody]  string pass)
        {
            int res = _userService.checkPassPower(pass);
            switch (res)
            {
                case 0:
                    return Ok("Too weak password");
                case 1:
                    return Ok("Too weak password");
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
        public async Task<IActionResult> Put(int id, [FromBody] User userToUpdate)
        {
            if (userToUpdate.Password != null)
            {
                int score = _userService.checkPassPower(userToUpdate.Password);
            if (score < 2)
                return BadRequest("Password is too weak");
            await _userService.updateUser(id, userToUpdate);
            return Ok();
            }
            return BadRequest("No password entered.");
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
