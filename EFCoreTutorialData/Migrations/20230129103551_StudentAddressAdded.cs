using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreTutorialData.Migrations
{
    /// <inheritdoc />
    public partial class StudentAddressAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                schema: "dbo",
                table: "students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "student_address",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    city = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    district = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    fulladdress = table.Column<string>(name: "full_address", type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student_address", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_students_AddressId",
                schema: "dbo",
                table: "students",
                column: "AddressId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "student_address_id_fk",
                schema: "dbo",
                table: "students",
                column: "AddressId",
                principalSchema: "dbo",
                principalTable: "student_address",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "student_address_id_fk",
                schema: "dbo",
                table: "students");

            migrationBuilder.DropTable(
                name: "student_address",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_students_AddressId",
                schema: "dbo",
                table: "students");

            migrationBuilder.DropColumn(
                name: "AddressId",
                schema: "dbo",
                table: "students");
        }
    }
}
