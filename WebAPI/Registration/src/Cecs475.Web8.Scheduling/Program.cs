
namespace Cecs475.Web8.Scheduling {
	public static class ApplicationSettings {
		public static string ConnectionString { get; set; } = string.Empty;
	}
	public class Program {
		public static void Main(string[] args) {
			ApplicationSettings.ConnectionString = @"data source=(localdb)\MSSqlLocalDb; initial catalog=CsulbCatalog";

			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment()) {
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
