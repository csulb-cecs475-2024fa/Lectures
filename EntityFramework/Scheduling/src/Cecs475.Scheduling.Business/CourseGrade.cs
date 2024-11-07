using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cecs475.Scheduling.Model {
	public enum GradeTypes {
		A, B, C, D, F
	}
	public class CourseGrade {
		public int Id { get; set; }
		public Student StudentOfRecord { get; set; }
		public ClassSection CourseSection { get; set; }
		public GradeTypes GradeEarned { get; set; }

		public override string ToString() {
			return $"{CourseSection} ({GradeEarned})";
		}
	}
}
