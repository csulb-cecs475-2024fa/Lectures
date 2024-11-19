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
		public IActionResult GetStudents() {
			return Ok(mContext.Students.Select(StudentDto.From));
		}

		[HttpGet]
		[Route("{id:int}")]
		public IActionResult GetStudent(int id) {
			var result = mContext.Students.Where(s => s.Id == id).Select(StudentDto.From)
				.FirstOrDefault();
			if (result is null) {
				return NotFound();
			}
			return Ok(result);
		}

		[HttpGet]
		[Route("{name:alpha}")]
		public IActionResult GetStudent(string name) {
			var result = mContext.Students.Where(s => s.FirstName + " " + s.LastName == name).Select(StudentDto.From)
				.FirstOrDefault();
			if (result is null) {
				return NotFound();
			}
			return Ok(result);
		}

		[HttpGet]
		[Route("{id}/transcript")]
		public IActionResult GetTranscript(int id) {
			var student = mContext.Students.Include(s => s.Transcript)
				.Where(s => s.Id == id).FirstOrDefault();
			if (student is null) {
				return NotFound();
			}
			return Ok(student.Transcript.Select(g => g.CourseSection.CatalogCourse.ToString()));
		}

		[HttpPost]
		public void Post([FromBody] StudentDto value) {
			mContext.Students.Add(new Model.Student() {
				FirstName = value.FirstName,
				LastName = value.LastName
			});
			mContext.SaveChanges();
		}

		[HttpPut]
		[Route("{id}")]
		public IActionResult Put(int id, [FromBody] StudentDto value) {
			var student = mContext.Students.Where(s => s.Id == id).FirstOrDefault();
			if (student is null) {
				return NotFound();
			}
			student.FirstName = value.FirstName;
			student.LastName = value.LastName;
			mContext.SaveChanges();
			return Ok();
		}

		[HttpDelete]
		[Route("{id}")]
		public IActionResult Delete(int id) {
			var student = mContext.Students.Where(s => s.Id == id).FirstOrDefault();
			if (student is null) {
				return NotFound();
			}
			mContext.Students.Remove(student);
			mContext.SaveChanges();
			return Ok();
		}
	}
}
