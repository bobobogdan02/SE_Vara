using Microsoft.EntityFrameworkCore.Migrations;

namespace Classroom.Migrations
{
    public partial class _5th : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssignmentSubmits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    assignmentid = table.Column<int>(nullable: true),
                    userId = table.Column<int>(nullable: true),
                    content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignmentSubmits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssignmentSubmits_Assignments_assignmentid",
                        column: x => x.assignmentid,
                        principalTable: "Assignments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssignmentSubmits_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentSubmits_assignmentid",
                table: "AssignmentSubmits",
                column: "assignmentid");

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentSubmits_userId",
                table: "AssignmentSubmits",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignmentSubmits");
        }
    }
}
