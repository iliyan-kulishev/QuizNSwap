using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizNSwap.Migrations
{
    public partial class QCardImportanceDefaultFalse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsImportant",
                table: "QuestionCards",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsImportant",
                table: "QuestionCards",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: false);
        }
    }
}
