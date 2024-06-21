using Microsoft.AspNetCore.Mvc;
using api.Data;
using api.Mappers;
using api.Dto;
using api.Models.Enums;

namespace api.Controllers
{
    [Route("api/v1/users")]
    [ApiController]
    public class UserController(ApplicationDBContext context) : ControllerBase
    {
        private readonly ApplicationDBContext _context = context;

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _context.Users.ToList()
            .Select(s => s.ToUserDto());
            return Ok(users);

        }

        [HttpGet("{user_id}")]
        public IActionResult GetByUserId([FromRoute] Guid user_id)
        {
            var user = _context.Users.Find(user_id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Models.User user)
        {
        
            _context.Users.Add(user);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetByUserId), new { user_id = user.UserId }, user);
        }

        [HttpPut("{user_id}")]
        public IActionResult Update([FromRoute] Guid user_id, [FromBody] UpdateUserReq userBodyModel)
        {
            var userModel = _context.Users.FirstOrDefault(u => u.UserId == user_id);
            if (userModel == null)
            {
                return NotFound();
            }

            
            if (userBodyModel.FullName != null)
            {
                userModel.FullName = userBodyModel.FullName;
            }
            if (userBodyModel.DOB != null)
            {
                userModel.DOB = userBodyModel.DOB;
            }
            if (userBodyModel.Gender != null)
            {
                userModel.Gender = userBodyModel.Gender;
            }

            _context.Users.Update(userModel);
            _context.SaveChanges();
            return Ok(userModel);
        }



        [HttpDelete("{user_id}")]
        public IActionResult Delete([FromRoute] Guid user_id)
        {
            var user = _context.Users.Find(user_id);
            if (user == null)
            {
                return NotFound();
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
            return Ok(new { message = "User deleted successfully" });
        }
    }
}