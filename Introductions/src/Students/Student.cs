using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cecs475.Students {
	public class Student : IComparable<Student> {
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }

		public List<string> Hobbies { get; set; }

		public Student(int id, string firstName, string lastName) {
			Id = id;
			FirstName = firstName;
			LastName = lastName;
			Hobbies = [];
		}

		public int CompareTo(Student? s) {
			if (s is null) {
				throw new ArgumentNullException("s");
			}
			return this.Id.CompareTo(s.Id);
		}
	}
}
