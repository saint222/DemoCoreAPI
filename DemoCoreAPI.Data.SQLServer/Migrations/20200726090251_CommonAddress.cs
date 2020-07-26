using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoCoreAPI.Data.SQLServer.Migrations
{
    public partial class CommonAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SchoolAddresses_SchoolDbId",
                table: "SchoolAddresses");

            migrationBuilder.AddColumn<long>(
                name: "AddressId",
                table: "Teachers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AddressDb",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Region = table.Column<int>(nullable: false),
                    District = table.Column<string>(maxLength: 50, nullable: false),
                    Locality = table.Column<string>(maxLength: 50, nullable: false),
                    Street = table.Column<string>(maxLength: 50, nullable: false),
                    HouseNumber = table.Column<int>(nullable: false),
                    SchoolDbId = table.Column<long>(nullable: false),
                    PupilDbId = table.Column<long>(nullable: false),
                    ParentDbId = table.Column<long>(nullable: false),
                    PrincipalDbId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressDb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddressDb_Parents_ParentDbId",
                        column: x => x.ParentDbId,
                        principalTable: "Parents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AddressDb_Principals_PrincipalDbId",
                        column: x => x.PrincipalDbId,
                        principalTable: "Principals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AddressDb_Pupils_PupilDbId",
                        column: x => x.PupilDbId,
                        principalTable: "Pupils",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AddressDb_Schools_SchoolDbId",
                        column: x => x.SchoolDbId,
                        principalTable: "Schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_AddressId",
                table: "Teachers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolAddresses_SchoolDbId",
                table: "SchoolAddresses",
                column: "SchoolDbId");

            migrationBuilder.CreateIndex(
                name: "IX_AddressDb_ParentDbId",
                table: "AddressDb",
                column: "ParentDbId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AddressDb_PrincipalDbId",
                table: "AddressDb",
                column: "PrincipalDbId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AddressDb_PupilDbId",
                table: "AddressDb",
                column: "PupilDbId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AddressDb_SchoolDbId",
                table: "AddressDb",
                column: "SchoolDbId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_AddressDb_AddressId",
                table: "Teachers",
                column: "AddressId",
                principalTable: "AddressDb",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_AddressDb_AddressId",
                table: "Teachers");

            migrationBuilder.DropTable(
                name: "AddressDb");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_AddressId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_SchoolAddresses_SchoolDbId",
                table: "SchoolAddresses");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Teachers");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolAddresses_SchoolDbId",
                table: "SchoolAddresses",
                column: "SchoolDbId",
                unique: true);
        }
    }
}
