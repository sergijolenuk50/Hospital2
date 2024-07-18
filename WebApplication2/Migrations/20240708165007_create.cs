using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Work_experience = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Archived = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Otorhinolaryngologist" },
                    { 2, "Therapist" },
                    { 3, "Surgeon" },
                    { 4, "Bacteriologist" },
                    { 5, "Homeopath" },
                    { 6, "Endoscopist" },
                    { 7, "Podiatrist" },
                    { 8, "Narcologist" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Archived", "Birthday", "CategoryId", "FirstName", "ImageUrl", "LastName", "Name", "Work_experience" },
                values: new object[,]
                {
                    { 1, false, new DateTime(1985, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Grec", "https://img.freepik.com/free-photo/portrait-of-handsome-bearded-man-outside_23-2150266915.jpg", "Ivanivuch", "Stepan", 5 },
                    { 2, false, new DateTime(1988, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, "Ivanov", "https://cdn.pixabay.com/photo/2016/11/23/00/57/adult-1851571_640.jpg", "Ivanivuch", "Stanislav", 6 },
                    { 3, false, new DateTime(1981, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Sidorov", "https://st4.depositphotos.com/1325771/39150/i/450/depositphotos_391507238-stock-photo-confident-smiling-doctor-posing-in.jpg", "Romanovich", "Sergii", 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_CategoryId",
                table: "Doctors",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
