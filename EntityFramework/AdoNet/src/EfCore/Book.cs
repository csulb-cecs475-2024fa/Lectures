using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore {
	public class Book {
		public int Id { get; set; }
		public string Title { get; set; }
		public string Publisher { get; set; }
		public int AuthorId { get; set; }
		public Author Author { get; set; } = null!;	
	}
}
