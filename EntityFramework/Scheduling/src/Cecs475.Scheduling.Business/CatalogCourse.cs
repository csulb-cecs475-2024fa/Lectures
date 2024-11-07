using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cecs475.Scheduling.Model {
	/// <summary>
	/// Represents one course offered at CSULB.
	/// </summary>
	public class CatalogCourse {
		// The preferred way of configuring a relational database representation of a POCO
		// is to NOT use attributes, but to instead use *configuration* statements
		// in the DbContext class.

		public int Id { get; set; }
		public string DepartmentName { get; set; }
		public string CourseNumber { get; set; }

		public ICollection<CatalogCourse> Prerequisites { get; set; } = new List<CatalogCourse>();

		public override string ToString() {
			return DepartmentName + " " + CourseNumber;
		}
	}
}
