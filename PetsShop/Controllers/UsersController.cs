using Microsoft.AspNetCore.Mvc;
using Services;
using System.Reflection.PortableExecutable;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetsShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
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
            UserService userService = new UserService();
            User user = userService.getUserById(id);
            if(user ==null)


                        return Ok(user);//write in c# code
             
             return NotFound();//write in c# code


        }

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            int numberOfUsers = System.IO.File.ReadLines(path).Count();
            user.UserId = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(path, userJson + Environment.NewLine);
            return CreatedAtAction(nameof(Get), new { id = user.UserId }, user);


        }

        //POST api/<UsersController>
        [HttpPost("login")]
         public IActionResult Post([FromBody] UserLogin userLogin)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "users.txt");
            using (StreamReader reader = System.IO.File.OpenText(path))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.UserName == userLogin.UserName && user.Password == userLogin.Password)
                        return Ok(user);
                   }
            }
            return Unauthorized();

        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User userToUpdate)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "users.txt");
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText(path))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {

                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.UserId == id)
                        textToReplace = currentUserInFile;
                }
            }

            if (textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText(path);
                text = text.Replace(textToReplace, JsonSerializer.Serialize(userToUpdate));
                System.IO.File.WriteAllText(path, text);
            }

        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
