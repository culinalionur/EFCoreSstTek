using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreTutorialData.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "course",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    isactive = table.Column<bool>(name: "is_active", type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "students",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstname = table.Column<string>(name: "first_name", type: "nvarchar(100)", maxLength: 100, nullable: false),
                    lastname = table.Column<string>(name: "last_name", type: "nvarchar(100)", maxLength: 100, nullable: false),
                    birthdate = table.Column<DateTime>(name: "birth_date", type: "datetime2", nullable: false),
                    number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "teachers",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstname = table.Column<string>(name: "first_name", type: "nvarchar(100)", maxLength: 100, nullable: false),
                    lastname = table.Column<string>(name: "last_name", type: "nvarchar(100)", maxLength: 100, nullable: false),
                    birthdate = table.Column<DateTime>(name: "birth_date", type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teachers", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "course",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "students",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "teachers",
                schema: "dbo");
        }
    }
}
