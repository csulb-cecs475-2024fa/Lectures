using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Normally these classes would be in a Business project 
// referenced by the Presentation project, 
// but I'm being lazy.
namespace ThreeTier.Business {
	public class Book {
		public int Id { get; set; }
		public string Title { get; set; }
		public string Publisher { get; set; }
		public int AuthorId { get; set; }

		public static IList<Book> GetAllBooks() {
			SqlConnection conn = new SqlConnection(Configuration.ConnectionString);

			return new Data.Book(conn)
				.GetAll()
				.Select(dto => new Book() {
					Id = dto.Id,
					Title = dto.Title,
					Publisher = dto.Publisher,
					AuthorId = dto.AuthorId
				}).ToList();
		}

		public Author GetAuthor() {
			return new Author(AuthorId);
		}

		public static IList<Book> GetBooksByAuthor(int authorId) {
			SqlConnection conn = new SqlConnection(Configuration.ConnectionString);

			return new Data.Book(conn)
				.GetByAuthor(authorId)
				.Select(dto => new Book() {
					Id = dto.Id,
					Title = dto.Title,
					Publisher = dto.Publisher,
					AuthorId = dto.AuthorId
				}).ToList();
		}
	}

	public class Author {
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }

		private List<Book>? mBooks;

		public Author(int id) {
			SqlConnection conn = new SqlConnection(Configuration.ConnectionString);
			var dto = new Data.Author(conn).Get(id);
			if (dto is null) {
				throw new ArgumentException("No author found with id " + id);
			}
			Id = dto.Id;
			FirstName = dto.FirstName;
			LastName = dto.LastName;
		}


		public ICollection<Book> Books {
			get {
				if (mBooks is null) {
					mBooks = new List<Book>();
					foreach (var book in Book.GetBooksByAuthor(Id)) {
						mBooks.Add(book);
					}
				}
				return mBooks;
			}
		}

	}
}