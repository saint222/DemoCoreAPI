using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoCoreAPI.Data.SQLServer.Migrations
{
    public partial class Discriminator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ClassId",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SchoolId",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PupilId",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TeacherDb_SchoolId",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Users",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grade = table.Column<int>(nullable: false),
                    Letter = table.Column<int>(nullable: false),
                    SchoolDbId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classes_Schools_SchoolDbId",
                        column: x => x.SchoolDbId,
                        principalTable: "Schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SchoolAddresses",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Region = table.Column<int>(nullable: false),
                    District = table.Column<string>(maxLength: 50, nullable: false),
                    Locality = table.Column<string>(maxLength: 50, nullable: false),
                    Street = table.Column<string>(maxLength: 50, nullable: false),
                    HouseNumber = table.Column<int>(nullable: false),
                    SchoolDbId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolAddresses_Schools_SchoolDbId",
                        column: x => x.SchoolDbId,
                        principalTable: "Schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SchoolPhoneNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(nullable: false),
                    SchoolDbId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolPhoneNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolPhoneNumbers_Schools_SchoolDbId",
                        column: x => x.SchoolDbId,
                        principalTable: "Schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Discriminator",
                value: "UserDb");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ClassId",
                table: "Users",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_SchoolId",
                table: "Users",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PupilId",
                table: "Users",
                column: "PupilId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TeacherDb_SchoolId",
                table: "Users",
                column: "TeacherDb_SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_SchoolDbId",
                table: "Classes",
                column: "SchoolDbId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolAddresses_SchoolDbId",
                table: "SchoolAddresses",
                column: "SchoolDbId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SchoolPhoneNumbers_SchoolDbId",
                table: "SchoolPhoneNumbers",
                column: "SchoolDbId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Classes_ClassId",
                table: "Users",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Schools_SchoolId",
                table: "Users",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_PupilId",
                table: "Users",
                column: "PupilId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Schools_TeacherDb_SchoolId",
                table: "Users",
                column: "TeacherDb_SchoolId",
                principalTable: "Schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Classes_ClassId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Schools_SchoolId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_PupilId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Schools_TeacherDb_SchoolId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "SchoolAddresses");

            migrationBuilder.DropTable(
                name: "SchoolPhoneNumbers");

            migrationBuilder.DropTable(
                name: "Schools");

            migrationBuilder.DropIndex(
                name: "IX_Users_ClassId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_SchoolId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_PupilId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_TeacherDb_SchoolId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SchoolId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PupilId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TeacherDb_SchoolId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Users");
        }
    }
}
