using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EnglishCenterAPI.Models;

namespace EnglishCenterAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Classes")]
    public class ClassesController : Controller
    {
        private readonly englishcenterContext _context;

        public ClassesController(englishcenterContext context)
        {
            _context = context;
        }

        // GET: api/Classes
        [HttpGet]
        public IEnumerable<Classes> GetClasses()
        {
            return _context.Classes;
        }

        // GET: api/Classes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClasses([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var classes = await _context.Classes.SingleOrDefaultAsync(m => m.IdClass == id);

            if (classes == null)
            {
                return NotFound();
            }

            return Ok(classes);
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
            var listAllClasses = await _context.Classes.ToListAsync();
            List<Classes> classes = null;

            if (!string.IsNullOrEmpty(searchString))
                listAllClasses = listAllClasses.Where(x => (!string.IsNullOrEmpty(x.Name) && x.Name.ToString().ToLower().Contains(searchString.ToLower()))
                                        || (!string.IsNullOrEmpty(x.Location) && x.Location.ToString().ToLower().Contains(searchString.ToLower()))
                                        ).ToList();

            if (listAllClasses != null)
                classes = listAllClasses.Skip((_currentPage - 1) * _perPage).Take(_perPage).ToList();

            if (classes == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                TotalRecord = classes.Count,
                PerPage = perPage,
                CurrentPage = currentPage,
                SearchString = searchString,
                Result = classes
            });
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllClasses()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var classes = await _context.Classes.ToListAsync();

            if (classes == null)
            {
                return NotFound();
            }

            return Ok(classes);
        }

        // PUT: api/Classes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClasses([FromRoute] int id, [FromBody] Classes classes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != classes.IdClass)
            {
                return BadRequest();
            }

            _context.Entry(classes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassesExists(id))
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

        // POST: api/Classes
        [HttpPost]
        public async Task<IActionResult> PostClasses([FromBody] Classes classes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Classes.Add(classes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClasses", new { id = classes.IdClass }, classes);
        }

        // DELETE: api/Classes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClasses([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var classes = await _context.Classes.SingleOrDefaultAsync(m => m.IdClass == id);
            if (classes == null)
            {
                return NotFound();
            }

            _context.Classes.Remove(classes);
            await _context.SaveChangesAsync();

            return Ok(classes);
        }

        private bool ClassesExists(int id)
        {
            return _context.Classes.Any(e => e.IdClass == id);
        }
    }
}