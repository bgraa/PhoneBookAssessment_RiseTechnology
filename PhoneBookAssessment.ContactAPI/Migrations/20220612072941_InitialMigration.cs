using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneBookAssessment.ContactAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    Name = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    Surname = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    Company = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PeopleContactInformation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    InformationType = table.Column<string>(type: "character varying(32)", unicode: false, maxLength: 32, nullable: false),
                    InformationContent = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                    PeopleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeopleContactInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PeopleContactInformation_People_PeopleId",
                        column: x => x.PeopleId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PeopleContactInformation_PeopleId",
                table: "PeopleContactInformation",
                column: "PeopleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PeopleContactInformation");

            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
