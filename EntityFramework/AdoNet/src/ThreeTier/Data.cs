using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Normally these classes would be in their own C# project,
// referenced by the Business and Presentation projects.
// But I'm being lazy.
namespace ThreeTier.Data {
	public class BookDto {
		public int Id { get; set; }
		public string Title { get; set; }
		public string Publisher { get; set; }
		public int AuthorId { get; set; }
	}

	public class Book {
		private SqlConnection mConnection;
		public Book(SqlConnection connection) {
			mConnection = connection;
		}
		public BookDto? Get(int id) {
			try {
				mConnection.Open();

				SqlCommand cmd = mConnection.CreateCommand();
				cmd.CommandText = "SELECT * FROM Book WHERE Id = @BookId";
				cmd.Parameters.Add(new SqlParameter("@BookId", id));

				SqlDataReader reader = cmd.ExecuteReader();
				if (reader.Read()) {
					return new BookDto() {
						Id = (int)reader["Id"],
						Title = (string)reader["Title"],
						Publisher = (string)reader["Publisher"]
					};
				}
				return null;
			}
			catch {
				return null;
			}
			finally {
				mConnection.Close();
			}
		}

		public List<BookDto> GetAll() {
			try {
				mConnection.Open();

				SqlCommand cmd = mConnection.CreateCommand();
				cmd.CommandText = "SELECT * FROM Book";

				SqlDataReader reader = cmd.ExecuteReader();
				List<BookDto> results = [];
				while (reader.Read()) {
					results.Add(new BookDto() {
						Id = (int)reader["Id"],
						Title = (string)reader["Title"],
						Publisher = (string)reader["Publisher"],
						AuthorId = (int)reader["AuthorId"]
					});
				}
				return results;
			}
			catch {
				return [];
			}
			finally {
				mConnection.Close();
			}
		}

		public List<BookDto> GetByAuthor(int authorId) {
			try {
				mConnection.Open();

				SqlCommand cmd = mConnection.CreateCommand();
				cmd.CommandText = "SELECT * FROM Book WHERE AuthorId = @AuthorId";
				cmd.Parameters.Add(new SqlParameter("@AuthorId", authorId));

				SqlDataReader reader = cmd.ExecuteReader();
				List<BookDto> results = [];
				while (reader.Read()) {
					results.Add(new BookDto() {
						Id = (int)reader["Id"],
						Title = (string)reader["Title"],
						Publisher = (string)reader["Publisher"],
						AuthorId = (int)reader["AuthorId"]
					});
				}
				return results;
			}
			catch {
				return [];
			}
			finally {
				mConnection.Close();
			}
		}
	}

	public class AuthorDto {
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}

	public class Author {
		private SqlConnection mConnection;
		public Author(SqlConnection connection) {
			mConnection = connection;
		}
		public AuthorDto? Get(int id) {
			try {
				mConnection.Open();

				SqlCommand cmd = mConnection.CreateCommand();
				cmd.CommandText = "SELECT * FROM Author WHERE Id = @AuthorId";
				cmd.Parameters.Add(new SqlParameter("@AuthorId", id));

				SqlDataReader reader = cmd.ExecuteReader();
				if (reader.Read()) {
					return new AuthorDto() {
						Id = (int)reader["Id"],
						FirstName = (string)reader["FirstName"],
						LastName = (string)reader["LastName"]
					};
				}
				return null;
			}
			catch {
				return null;
			}
			finally {
				mConnection.Close();
			}
		}
	}
}
