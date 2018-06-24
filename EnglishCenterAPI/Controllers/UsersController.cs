using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EnglishCenterAPI.Common;
using EnglishCenterAPI.Models;

namespace EnglishCenterAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller
    {
        private readonly englishcenterContext _context;

        public UsersController(englishcenterContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public IEnumerable<User> GetUser()
        {
            return _context.User;
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _context.User.SingleOrDefaultAsync(m => m.IdUser == id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _context.User.ToListAsync();

            if (user == null)
            {
                return NotFound();
            }

            return Ok(new ResultList<User>
            {
                TotalRecord = user.Count,
                Result = user
            });
        }

        [HttpGet("limit")]
        public async Task<IActionResult> GetAll([FromQuery] int? perPage, [FromQuery] int? currentPage, [FromQuery] string searchString)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var _perPage = perPage ?? 10;
            var _currentPage = currentPage ?? 1;
            var listAllUser = await _context.User.ToListAsync();
            List<User> user = null;

            if (!string.IsNullOrEmpty(searchString))
                listAllUser = listAllUser.Where(x => (!string.IsNullOrEmpty(x.Email) && x.Email.ToString().ToLower().Contains(searchString.ToLower()))
                                        || (!string.IsNullOrEmpty(x.FirstName) && x.FirstName.ToString().ToLower().Contains(searchString.ToLower()))
                                        || (!string.IsNullOrEmpty(x.LastName) && x.LastName.ToString().ToLower().Contains(searchString.ToLower()))
                                        ).ToList();

            if (listAllUser != null)
                user = listAllUser.Skip((_currentPage - 1) * _perPage).Take(_perPage).ToList();

            if (user == null)
            {
                return NotFound();
            }

            return Ok(new {
                TotalRecord = user.Count,
                PerPage = perPage,
                CurrentPage = currentPage,
                SearchString = searchString,
                Result = user
            });
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser([FromRoute] int id, [FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.IdUser)
            {
                return BadRequest();
            }

            var passwordHashed = MD5Helper.Encode(user.Password);
            user.Password = passwordHashed;

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_context.User.FirstOrDefault(x => x.Email == user.Email) != null)
                return BadRequest("Email already exist");

            var passwordHashed = MD5Helper.Encode(user.Password);
            user.Password = passwordHashed;

            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.IdUser }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _context.User.SingleOrDefaultAsync(m => m.IdUser == id);
            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.IdUser == id);
        }
    }

    public class ResultList<T>
    {
        public int TotalRecord { get; set; }
        public List<T> Result { get; set; }
    }
}