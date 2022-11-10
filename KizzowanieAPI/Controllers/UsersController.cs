using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KizzowanieAPI;
using Microsoft.Graph;

namespace KizzowanieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly KizzowanieDbContext _context;

        public UsersController(KizzowanieDbContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet("GetUsers")]
        public IActionResult GetUsers()
        {
            try
            {
                var users = _context.Users.ToList();
                if (users.Count == 0)
                {
                    return StatusCode(404, "No User Found");
                }
                return Ok(users);
            }
            catch (Exception)
            {
                return StatusCode(500, "An eror has occured");
            }

        }

        // GET: api/Users/5
        [HttpGet("GetUser/{id}")]
        public async Task<ActionResult<Users>> GetUsers(int id)
        {
            var users = await _context.Users.FindAsync(id);

            if (users == null)
            {
            }

            return users;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("UpdateUser")]
        public IActionResult Update([FromBody] Users request)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(x => x.UserId == request.UserId);
                if (user == null)
                {
                    return StatusCode(404, "User not Found");
                }

                user.UserEmail = request.UserEmail;
                user.UserName = request.UserName;
                user.UserPassword = request.UserPassword;

                _context.Entry(user).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "idk what happend");
            }

            var users = _context.Users.ToList();
            return Ok(users);
        }

        // POST: api/Users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public IActionResult Create([FromBody] Users request)
        {
            Users user = new Users();
            user.UserEmail = request.UserEmail;
            user.UserName = request.UserName;
            user.UserPassword = request.UserPassword;

            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error has occured");
            }
            var users = _context.Users.ToList();
            return Ok(users);
        }

        // DELETE: api/Users/5
        [HttpDelete("DeleteUser/{id}")]
        public IActionResult Delete([FromRoute]int Id)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(x => x.UserId == Id);
                if (user == null)
                {
                    return StatusCode(404, "User not Found");
                }

                _context.Entry(user).State = EntityState.Deleted;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "idk what happend");
            }

            var users = _context.Users.ToList();
            return Ok(users);
        }
        

       
    }
}
