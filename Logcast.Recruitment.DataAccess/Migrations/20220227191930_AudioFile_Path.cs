using Microsoft.EntityFrameworkCore.Migrations;

namespace Logcast.Recruitment.DataAccess.Migrations
{
    public partial class AudioFile_Path : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "AudioFile",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Path",
                table: "AudioFile");
        }
    }
}
