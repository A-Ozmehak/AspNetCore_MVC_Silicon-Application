using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Moveddarkappimage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MobileImageDark",
                table: "DownloadApp");

            migrationBuilder.AddColumn<string>(
                name: "StoreImageDark",
                table: "App",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StoreImageDark",
                table: "App");

            migrationBuilder.AddColumn<string>(
                name: "MobileImageDark",
                table: "DownloadApp",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
