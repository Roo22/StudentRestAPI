using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentRestAPI.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentID);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentID", "DepartmentID", "Email", "FirstName", "Gender", "LastName", "PhotoPath" },
                values: new object[,]
                {
                    { 1, 1, "john@john.com", "John", 0, "Doe", "https://upload.wikimedia.org/wikipedia/commons/b/bc/Unknown_person.jpg" },
                    { 2, 2, "alex@alex.com", "Alex", 0, "John", "https://upload.wikimedia.org/wikipedia/commons/b/bc/Unknown_person.jpg" },
                    { 3, 3, "emily@emily.com", "Emily", 1, "Doe", "https://upload.wikimedia.org/wikipedia/commons/b/bc/Unknown_person.jpg" },
                    { 4, 4, "lizzy@lizzy.com", "Lizzy", 1, "Addrison", "https://upload.wikimedia.org/wikipedia/commons/b/bc/Unknown_person.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
