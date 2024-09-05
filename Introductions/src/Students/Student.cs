using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cecs475.Students {
	public class Student {
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

	}
}
