using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoCoreAPI.Data.SQLServer.Migrations
{
    public partial class TeacherPrincipalChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Principals_Schools_SchoolDbId",
                table: "Principals");

            migrationBuilder.DropIndex(
                name: "IX_Principals_SchoolDbId",
                table: "Principals");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Schools");

            migrationBuilder.AddColumn<int>(
                name: "ProfessionalCategory",
                table: "Teachers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SchoolNumber",
                table: "Schools",
                maxLength: 999,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<long>(
                name: "SchoolDbId",
                table: "Principals",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_Principals_SchoolDbId",
                table: "Principals",
                column: "SchoolDbId",
                unique: true,
                filter: "[SchoolDbId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Principals_Schools_SchoolDbId",
                table: "Principals",
                column: "SchoolDbId",
                principalTable: "Schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Principals_Schools_SchoolDbId",
                table: "Principals");

            migrationBuilder.DropIndex(
                name: "IX_Principals_SchoolDbId",
                table: "Principals");

            migrationBuilder.DropColumn(
                name: "ProfessionalCategory",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "SchoolNumber",
                table: "Schools");

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Schools",
                type: "int",
                maxLength: 999,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<long>(
                name: "SchoolDbId",
                table: "Principals",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Principals_SchoolDbId",
                table: "Principals",
                column: "SchoolDbId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Principals_Schools_SchoolDbId",
                table: "Principals",
                column: "SchoolDbId",
                principalTable: "Schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
