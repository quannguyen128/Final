using Microsoft.EntityFrameworkCore.Migrations;

namespace Final.Migrations
{
    public partial class Quan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    ProjectName = table.Column<string>(nullable: true),
                    ProjectDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProjectParticipant",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    CompanyName = table.Column<string>(nullable: true),
                    Major = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectParticipant", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProjectRoster",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    ProjectParticipantID = table.Column<string>(nullable: false),
                    ProjectID = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectRoster", x => new { x.ProjectID, x.ProjectParticipantID });
                    table.ForeignKey(
                        name: "FK_ProjectRoster_Project_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Project",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectRoster_ProjectParticipant_ProjectParticipantID",
                        column: x => x.ProjectParticipantID,
                        principalTable: "ProjectParticipant",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectRoster_ProjectParticipantID",
                table: "ProjectRoster",
                column: "ProjectParticipantID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectRoster");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "ProjectParticipant");
        }
    }
}
