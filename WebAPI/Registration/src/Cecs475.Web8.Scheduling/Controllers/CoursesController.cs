using Cecs475.Web8.Scheduling;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace Cecs475.Scheduling.Web.Controllers {
	public class CatalogCourseDto {
		public int Id { get; set; }
		public required string DepartmentName { get; set; }
		public required string CourseNumber { get; set; }
		public required IEnumerable<int> PrerequisiteCourseIds { get; set; }

		public static CatalogCourseDto From(Model.CatalogCourse course) {
			return new CatalogCourseDto {
				Id = course.Id,
				DepartmentName = course.DepartmentName,
				CourseNumber = course.CourseNumber,
				PrerequisiteCourseIds = course.Prerequisites.Select(c => c.Id)
			};
		}
	}
	[ApiController]
	[Route("api/courses")]
	public class CoursesController : ControllerBase {
		private Model.CatalogContext mContext = new Model.CatalogContext(ApplicationSettings.ConnectionString);

		[HttpGet]
		public async Task<IEnumerable<CatalogCourseDto>> GetCourses() {
			var courses = await mContext.Courses.Include(c => c.Prerequisites).ToListAsync();
			return courses.Select(CatalogCourseDto.From);
		}

		[HttpGet]
		[Route("{id:int}")]
		public async Task<IActionResult> GetCourse(int id) {
			var course = await mContext.Courses.Include(c => c.Prerequisites).SingleOrDefaultAsync(c => c.Id == id);
			if (course is null) {
				return NotFound();
			}
			return Ok(CatalogCourseDto.From(course));
		}

		[HttpGet]
		[Route("{name:alpha}")]
		public async Task<IActionResult> GetCourse(string name) {
			var course = await mContext.Courses.Include(c => c.Prerequisites)
				.SingleOrDefaultAsync(c => c.DepartmentName + " " + c.CourseNumber == name);

			if (course is null) {
				return NotFound();
			}
			return Ok(CatalogCourseDto.From(course));
		}
	}
}