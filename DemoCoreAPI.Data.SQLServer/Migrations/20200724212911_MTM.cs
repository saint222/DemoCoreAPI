using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoCoreAPI.Data.SQLServer.Migrations
{
    public partial class MTM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Schools_SchoolDbId",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_SchoolPhoneNumbers_Schools_SchoolDbId",
                table: "SchoolPhoneNumbers");

            migrationBuilder.DropIndex(
                name: "IX_SchoolPhoneNumbers_SchoolDbId",
                table: "SchoolPhoneNumbers");

            migrationBuilder.DropIndex(
                name: "IX_Classes_SchoolDbId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "SchoolDbId",
                table: "SchoolPhoneNumbers");

            migrationBuilder.DropColumn(
                name: "SchoolDbId",
                table: "Classes");

            migrationBuilder.AddColumn<int>(
                name: "Specialization",
                table: "Teachers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Schools",
                maxLength: 999,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "SchoolId",
                table: "SchoolPhoneNumbers",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SchoolId",
                table: "Classes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ClassTeachers",
                columns: table => new
                {
                    TeacherDbId = table.Column<long>(nullable: false),
                    ClassDbId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassTeachers", x => new { x.ClassDbId, x.TeacherDbId });
                    table.ForeignKey(
                        name: "FK_ClassTeachers_Classes_ClassDbId",
                        column: x => x.ClassDbId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassTeachers_Teachers_TeacherDbId",
                        column: x => x.TeacherDbId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parents",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Patronymic = table.Column<string>(maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false),
                    Role = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Principals",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Patronymic = table.Column<string>(maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false),
                    Role = table.Column<int>(nullable: false),
                    SchoolDbId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Principals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Principals_Schools_SchoolDbId",
                        column: x => x.SchoolDbId,
                        principalTable: "Schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VicePrincipals",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Patronymic = table.Column<string>(maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false),
                    ManagementArea = table.Column<int>(nullable: false),
                    Role = table.Column<int>(nullable: false),
                    SchoolId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VicePrincipals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VicePrincipals_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ParentPupils",
                columns: table => new
                {
                    ParentDbId = table.Column<long>(nullable: false),
                    PupilDbId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentPupils", x => new { x.ParentDbId, x.PupilDbId });
                    table.ForeignKey(
                        name: "FK_ParentPupils_Parents_ParentDbId",
                        column: x => x.ParentDbId,
                        principalTable: "Parents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParentPupils_Pupils_PupilDbId",
                        column: x => x.PupilDbId,
                        principalTable: "Pupils",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SchoolPhoneNumbers_SchoolId",
                table: "SchoolPhoneNumbers",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_SchoolId",
                table: "Classes",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassTeachers_TeacherDbId",
                table: "ClassTeachers",
                column: "TeacherDbId");

            migrationBuilder.CreateIndex(
                name: "IX_ParentPupils_PupilDbId",
                table: "ParentPupils",
                column: "PupilDbId");

            migrationBuilder.CreateIndex(
                name: "IX_Principals_SchoolDbId",
                table: "Principals",
                column: "SchoolDbId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VicePrincipals_SchoolId",
                table: "VicePrincipals",
                column: "SchoolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Schools_SchoolId",
                table: "Classes",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolPhoneNumbers_Schools_SchoolId",
                table: "SchoolPhoneNumbers",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Schools_SchoolId",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_SchoolPhoneNumbers_Schools_SchoolId",
                table: "SchoolPhoneNumbers");

            migrationBuilder.DropTable(
                name: "ClassTeachers");

            migrationBuilder.DropTable(
                name: "ParentPupils");

            migrationBuilder.DropTable(
                name: "Principals");

            migrationBuilder.DropTable(
                name: "VicePrincipals");

            migrationBuilder.DropTable(
                name: "Parents");

            migrationBuilder.DropIndex(
                name: "IX_SchoolPhoneNumbers_SchoolId",
                table: "SchoolPhoneNumbers");

            migrationBuilder.DropIndex(
                name: "IX_Classes_SchoolId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "Specialization",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "SchoolId",
                table: "SchoolPhoneNumbers");

            migrationBuilder.DropColumn(
                name: "SchoolId",
                table: "Classes");

            migrationBuilder.AddColumn<long>(
                name: "SchoolDbId",
                table: "SchoolPhoneNumbers",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SchoolDbId",
                table: "Classes",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SchoolPhoneNumbers_SchoolDbId",
                table: "SchoolPhoneNumbers",
                column: "SchoolDbId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_SchoolDbId",
                table: "Classes",
                column: "SchoolDbId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Schools_SchoolDbId",
                table: "Classes",
                column: "SchoolDbId",
                principalTable: "Schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolPhoneNumbers_Schools_SchoolDbId",
                table: "SchoolPhoneNumbers",
                column: "SchoolDbId",
                principalTable: "Schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
