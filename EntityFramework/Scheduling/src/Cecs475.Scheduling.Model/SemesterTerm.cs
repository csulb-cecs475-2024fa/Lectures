using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cecs475.Scheduling.Model {
	/// <summary>
	/// Represents one semester of an academic year.
	/// </summary>
	public class SemesterTerm {
		// This file shows "attributes" describing the relational model representation
		// of this class' properties. 
		// This is the OLD WAY of doing things; we don't like this approach anymore, 
		// because this class is not a "POCO"; it has code specific to a relational database
		// representation, instead of being a pure C#/OOP design.

		// [Key] denotes a primary key. EntityFramework will infer "Id" or "[typename]Id" fields
		// to be keys, but you can also manually specify it.
		[Key]
		public int Id { get; set; }

		[MaxLength(50)]
		[Required]
		public string Name { get; set; }
		[Required]
		public DateTime StartDate { get; set; }
		[Required]
		public DateTime EndDate { get; set; }

		[Required]
		public ICollection<CourseSection> CourseSections { get; set; } = new List<CourseSection>();
	}
}
