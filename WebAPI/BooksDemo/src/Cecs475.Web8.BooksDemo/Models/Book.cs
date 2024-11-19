using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cecs475.Web.BooksDemo.Models {
	public class Book {
		public int Id { get; init; }
		public required string Title { get; init; }
		public required string Publisher { get; init; }
	}
}