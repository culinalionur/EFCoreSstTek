using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreTutorialData.Migrations
{
    /// <inheritdoc />
    public partial class migrationChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "student_address_id_fk",
                schema: "dbo",
                table: "students");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                schema: "dbo",
                table: "students",
                newName: "address_id");

            migrationBuilder.RenameIndex(
                name: "IX_students_AddressId",
                schema: "dbo",
                table: "students",
                newName: "IX_students_address_id");

            migrationBuilder.AddForeignKey(
                name: "student_address_student_id_fk",
                schema: "dbo",
                table: "students",
                column: "address_id",
                principalSchema: "dbo",
                principalTable: "student_address",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "student_address_student_id_fk",
                schema: "dbo",
                table: "students");

            migrationBuilder.RenameColumn(
                name: "address_id",
                schema: "dbo",
                table: "students",
                newName: "AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_students_address_id",
                schema: "dbo",
                table: "students",
                newName: "IX_students_AddressId");

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
    }
}
