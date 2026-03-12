using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager_Backend.Interfaces;
using TaskManager_Backend.Models;

namespace TaskManager_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("get-user")]
        public ActionResult<IUser> GetUser()
        {
            System.Console.WriteLine("api called");
            return Ok(new User
            {
                userName="vamshi",
                rollNo= "411",
                city="Hyderabad",
            });
        }

        [HttpPost("insert-user")]
        public IActionResult InsertUser([FromBody] User user)
        {
            return Ok(new
            {
                message= "success",
                name = user.userName,
                user.rollNo
            });
        }
    }
}
