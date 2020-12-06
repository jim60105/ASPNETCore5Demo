using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPNETCore5Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCore5Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly ContosoUniversityContext db;
        public DepartmentController(ContosoUniversityContext db)
        {
            this.db = db;
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<Department>> GetDepartments()
        {
            return new List<Department> { };
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Course>> GetDepartmentCourses(int id)
        {
            return db.Departments.Include(p => p.Courses)
                     .First(p => p.DepartmentId == id).Courses.ToList();
        }
    }
}