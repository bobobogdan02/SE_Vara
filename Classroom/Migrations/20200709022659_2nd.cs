using Microsoft.EntityFrameworkCore.Migrations;

namespace Classroom.Migrations
{
    public partial class _2nd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Teacher",
                table: "Classes");

            migrationBuilder.AddColumn<int>(
                name: "ClassId",
                table: "StreamMessages",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "courseId",
                table: "Assignments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "Assignments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StreamMessages_ClassId",
                table: "StreamMessages",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_courseId",
                table: "Assignments",
                column: "courseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Classes_courseId",
                table: "Assignments",
                column: "courseId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StreamMessages_Classes_ClassId",
                table: "StreamMessages",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Classes_courseId",
                table: "Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_StreamMessages_Classes_ClassId",
                table: "StreamMessages");

            migrationBuilder.DropIndex(
                name: "IX_StreamMessages_ClassId",
                table: "StreamMessages");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_courseId",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "StreamMessages");

            migrationBuilder.DropColumn(
                name: "courseId",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "description",
                table: "Assignments");

            migrationBuilder.AddColumn<string>(
                name: "Teacher",
                table: "Classes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
