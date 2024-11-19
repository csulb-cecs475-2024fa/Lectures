﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cecs475.Scheduling.Model {
	[Flags]
	public enum DaysOfWeek : byte {
		None = 0,
		Sunday = 1,
		Monday = 1 << 1,
		Tuesday = 1 << 2,
		Wednesday = 1 << 3,
		Thursday = 1 << 4,
		Friday = 1 << 5,
		Saturday = 1 << 6
	}

	/// <summary>
	/// Represents one offering of a course section during a semester.
	/// </summary>
	public class ClassSection {
		public int Id { get; set; }
		public CatalogCourse CatalogCourse { get; set; }
		public Instructor Instructor { get; set; }
		public SemesterTerm Semester { get; set; }

		public int SectionNumber { get; set; }
		public DaysOfWeek MeetingDays { get; set; }	
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }

		public ICollection<Student> EnrolledStudents { get; set; } = new List<Student>();

		public override string ToString() {
			return $"{CatalogCourse}-{SectionNumber:D2}";
		}
	}
}
