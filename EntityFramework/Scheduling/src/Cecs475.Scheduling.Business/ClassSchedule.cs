﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cecs475.Scheduling.Model {

	public class ClassSchedule {
		public int Id { get; set; }
		public virtual SemesterTerm SemesterTerm { get; set; }
		public virtual Student Student { get; set; }
		public ICollection<ClassSection> Classes { get; set; } = new List<ClassSection>();
	}
}
