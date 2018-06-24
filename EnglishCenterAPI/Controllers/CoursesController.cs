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
    [Route("api/Courses")]
    public class CoursesController : Controller
    {
        private readonly englishcenterContext _context;

        public CoursesController(englishcenterContext context)
        {
            _context = context;
        }

        // GET: api/Courses
        [HttpGet]
        public IEnumerable<Course> GetCourse()
        {
            return _context.Course;
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourse([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var course = await _context.Course.SingleOrDefaultAsync(m => m.IdCourse == id);

            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
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
            var listAllCourse = await _context.Course.ToListAsync();
            List<Course> course = null;

            if (!string.IsNullOrEmpty(searchString))
                listAllCourse = listAllCourse.Where(x => (!string.IsNullOrEmpty(x.Name) && x.Name.ToString().ToLower().Contains(searchString.ToLower()))
                                        || (!string.IsNullOrEmpty(x.Description) && x.Description.ToString().ToLower().Contains(searchString.ToLower()))
                                        ).ToList();

            if (listAllCourse != null)
                course = listAllCourse.Skip((_currentPage - 1) * _perPage).Take(_perPage).ToList();

            if (course == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                TotalRecord = course.Count,
                PerPage = perPage,
                CurrentPage = currentPage,
                SearchString = searchString,
                Result = course
            });
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllCourses()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var courses = await _context.Course.ToListAsync();

            if (courses == null)
            {
                return NotFound();
            }

            return Ok(courses);
        }

        // PUT: api/Courses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse([FromRoute] int id, [FromBody] Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != course.IdCourse)
            {
                return BadRequest();
            }

            _context.Entry(course).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
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

        // POST: api/Courses
        [HttpPost]
        public async Task<IActionResult> PostCourse([FromBody] Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Course.Add(course);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCourse", new { id = course.IdCourse }, course);
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var course = await _context.Course.SingleOrDefaultAsync(m => m.IdCourse == id);
            if (course == null)
            {
                return NotFound();
            }

            _context.Course.Remove(course);
            await _context.SaveChangesAsync();

            return Ok(course);
        }

        private bool CourseExists(int id)
        {
            return _context.Course.Any(e => e.IdCourse == id);
        }
    }
}