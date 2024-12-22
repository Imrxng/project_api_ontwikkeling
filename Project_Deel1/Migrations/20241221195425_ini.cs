using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ghaddoura_Imran_Project.Migrations
{
    /// <inheritdoc />
    public partial class ini : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Universities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UniversityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Universities_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "Universities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Results_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("15d7d52c-b339-403d-94ff-81c8b8f507de"), "Amsterdam", "University of Amsterdam" },
                    { new Guid("7406c7e1-0ca2-44c3-85c0-cad6f2c44b1d"), "Delft", "Delft University of Technology" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Firstname", "LastName", "UniversityId" },
                values: new object[,]
                {
                    { new Guid("196b8cd8-70de-4085-b35f-8a96c215f143"), "Imran", "Ghaddoura", new Guid("15d7d52c-b339-403d-94ff-81c8b8f507de") },
                    { new Guid("2614957e-ee64-4d37-9032-692ee9f3b3d5"), "Sara", "De Vries", new Guid("7406c7e1-0ca2-44c3-85c0-cad6f2c44b1d") }
                });

            migrationBuilder.InsertData(
                table: "Results",
                columns: new[] { "Id", "CourseName", "Points", "StudentId" },
                values: new object[,]
                {
                    { new Guid("abbc66b0-5e17-4850-bb6c-ba25b4ae848b"), "Mechanical Engineering", 45, new Guid("2614957e-ee64-4d37-9032-692ee9f3b3d5") },
                    { new Guid("fe55fb8c-8272-4539-8a22-22a81e5ba1ec"), "Computer Science", 60, new Guid("196b8cd8-70de-4085-b35f-8a96c215f143") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Results_StudentId",
                table: "Results",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UniversityId",
                table: "Students",
                column: "UniversityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Universities");
        }
    }
}
