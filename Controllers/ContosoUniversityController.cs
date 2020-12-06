using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPNETCore5Demo.Models;

namespace ASPNETCore5Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContosoUniversityController : ControllerBase
    {
        private readonly ContosoUniversityContext db;
        public ContosoUniversityController(ContosoUniversityContext db)
        {
            this.db = db;
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<Course>> GetCourses()
        {
            return db.Courses.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Course> GetCourseById(int id)
        {
            return db.Courses.Find(id);
        }

        [HttpPost("")]
        public ActionResult<Course> PostCourse(Course model)
        {
            db.Courses.Add(model);
            db.SaveChanges();
            return Created($"/api/Course/{model.CourseId}",model);
        }

        [HttpPut("{id}")]
        public IActionResult PutCourse(int id, Course model)
        {
            var course = db.Courses.Find(id);
            course.Title = model.Title;
            course.Credits = model.Credits;

            db.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Course> DeleteCourseById(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
            db.SaveChanges();
            return Ok(course);
        }
    }
}