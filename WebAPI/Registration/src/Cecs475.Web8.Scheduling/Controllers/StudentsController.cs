using Cecs475.Web8.Scheduling;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace Cecs475.Scheduling.Web.Controllers {
	// PROBLEM: EntityFramework objects cannot be serialized into Json. Their object relations don't 
	// play nice with a serializer. So instead we create a Data Transfer Object class, and manually (ugh)
	// map entities to DTO instances.
	public class StudentDto {
		public int Id { get; set; }
		public required string FirstName { get; set; }
		public required string LastName { get; set; }

		// Serialization requires a default constructor and NO OTHERS, so we can't add a nice constructor
		// taking a Model.Student object. We'll make a static method instead.

		public static StudentDto From(Model.Student s) {
			return new StudentDto() {
				Id = s.Id,
				FirstName = s.FirstName,
				LastName = s.LastName
			};
		}

	}
	/// <summary>
	/// A controller for Student objects from the Entity Framework context.
	/// </summary>
	[ApiController]
	[Route("api/students")]
	public class StudentsController : ControllerBase {
		// One Context per controller is fine -- they share the same database connection.
		private Model.CatalogContext mContext = new Model.CatalogContext(ApplicationSettings.ConnectionString);

		[HttpGet]
		public async Task<IActionResult> GetStudents() {
			var students = await mContext.Students.ToListAsync();
			return Ok(students.Select(StudentDto.From));
		}

		[HttpGet]
		[Route("{id:int}")]
		public async Task<IActionResult> GetStudent(int id) {
			var student = await mContext.Students.SingleOrDefaultAsync(s => s.Id == id);
			
			if (student is null) {
				return NotFound();
			}
			return Ok(StudentDto.From(student));
		}

		[HttpGet]
		[Route("{name:alpha}")]
		public async Task<IActionResult> GetStudent(string name) {
			var student = await mContext.Students.FirstOrDefaultAsync(s => s.FirstName + " " + s.LastName == name);
			if (student is null) {
				return NotFound();
			}
			return Ok(StudentDto.From(student));
		}

		[HttpGet]
		[Route("{id}/transcript")]
		public async Task<IActionResult> GetTranscript(int id) {
			var student = await mContext.Students.Include(s => s.Transcript)
				.FirstOrDefaultAsync(s => s.Id == id);
			if (student is null) {
				return NotFound();
			}
			return Ok(student.Transcript.Select(g => g.CourseSection.CatalogCourse.ToString()));
		}

		[HttpPost]
		public async void Post([FromBody] StudentDto value) {
			mContext.Students.Add(new Model.Student() {
				FirstName = value.FirstName,
				LastName = value.LastName
			});
			await mContext.SaveChangesAsync();
		}

		[HttpPut]
		[Route("{id}")]
		public async Task<IActionResult> Put(int id, [FromBody] StudentDto value) {
			var student = await mContext.Students.SingleOrDefaultAsync(s => s.Id == id);
			if (student is null) {
				return NotFound();
			}
			student.FirstName = value.FirstName;
			student.LastName = value.LastName;
			await mContext.SaveChangesAsync();
			return Ok();
		}

		[HttpDelete]
		[Route("{id}")]
		public async Task<IActionResult> Delete(int id) {
			var student = await mContext.Students.SingleOrDefaultAsync(s => s.Id == id);
			if (student is null) {
				return NotFound();
			}
			mContext.Students.Remove(student);
			await mContext.SaveChangesAsync();
			return Ok();
		}
	}
}
