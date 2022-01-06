using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizBack.Migrations
{
    public partial class changeNameTitleColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Quizzes",
                newName: "Title");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Quizzes",
                newName: "Name");
        }
    }
}
