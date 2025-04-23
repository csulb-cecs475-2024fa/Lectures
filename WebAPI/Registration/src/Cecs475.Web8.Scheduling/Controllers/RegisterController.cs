using Cecs475.Web8.Scheduling;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;

namespace Cecs475.Scheduling.Web.Controllers {
	public class ClassSectionDto {
		public int Id { get; set; }
		public int SemesterTermId { get; set; }
		public CatalogCourseDto CatalogCourse { get; set; }
		public int SectionNumber { get; set; }

		public static ClassSectionDto From(Model.ClassSection section) {
			return new ClassSectionDto {
				Id = section.Id,
				SemesterTermId = section.Semester.Id,
				SectionNumber = section.SectionNumber,
				CatalogCourse = CatalogCourseDto.From(section.CatalogCourse)
			};
		}
	}

	public class RegistrationDto {
		public int StudentID { get; set; }
		public ClassSectionDto CourseSection { get; set; }
	}

	[ApiController]
	[Route("api/register")]
	public class RegisterController : ControllerBase {
		private Model.CatalogContext mContext = new Model.CatalogContext(ApplicationSettings.ConnectionString);

		[HttpPost]
		[Route("")]
		public async Task<IActionResult> RegisterForCourse([FromBody]RegistrationDto studentCourse) {
			var student = await mContext.Students.SingleOrDefaultAsync(s => s.Id == studentCourse.StudentID);
			// Simulate a slow connection / complicated operation by sleeping.
			Thread.Sleep(3000);

			if (student is null) {
				return NotFound();
			}

			var term = await mContext.SemesterTerms.SingleOrDefaultAsync(
				t => t.Id == studentCourse.CourseSection.SemesterTermId);

			if (term is null) {
				return NotFound();
			}

			var section = term.CourseSections.SingleOrDefault(
				c => c.CatalogCourse.DepartmentName == studentCourse.CourseSection.CatalogCourse.DepartmentName
					  && c.CatalogCourse.CourseNumber == studentCourse.CourseSection.CatalogCourse.CourseNumber
					  && c.SectionNumber == studentCourse.CourseSection.SectionNumber);
			if (section is null) {
				return NotFound();
			}

			var regResult = student.CanRegisterForCourseSection(section);
			if (regResult == Model.RegistrationResults.Success) {
				section.EnrolledStudents.Add(student);
				await mContext.SaveChangesAsync();
			}

			return Ok(regResult);
		}
	}
}
