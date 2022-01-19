using Microsoft.AspNetCore.Mvc;
using Week1.Model;

namespace Week1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private List<User> users = new List<User>();

        public UserController()
        {
            users.Add(new User { Age = 40, Name = "Irem", Id = 1 });
            users.Add(new User { Age = 20, Name = "Burak", Id = 2 });
            users.Add(new User { Age = 2, Name = "Omus", Id = 3 });
        }

        [HttpGet]
        public List<User> GetUsers()

        {


            return users;
        }

        [HttpGet("userId")]
        public async Task<ActionResult<User>> GetUserByID(int Id)

        {


            
                User a = users.FirstOrDefault(itm => itm.Id == Id);
               if(a == null)
                return BadRequest("invalid user");

               return a;
 



        }

        [HttpPost("postUser")]
        public List<User> AddUser(int id, String name, int age)
        {
            users.Add(new User { Age = age, Id = id, Name = name });
            return users;
        }
    }

 
}