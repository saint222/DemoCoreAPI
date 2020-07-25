using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoCoreAPI.Data.SQLServer.Migrations
{
    public partial class RemovedIsHeadTeacher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsHeadTeacher",
                table: "Teachers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
