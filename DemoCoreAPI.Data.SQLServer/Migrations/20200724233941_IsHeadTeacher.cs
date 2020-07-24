using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoCoreAPI.Data.SQLServer.Migrations
{
    public partial class IsHeadTeacher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ClassDbId",
                table: "Teachers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_ClassDbId",
                table: "Teachers",
                column: "ClassDbId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Classes_ClassDbId",
                table: "Teachers",
                column: "ClassDbId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
