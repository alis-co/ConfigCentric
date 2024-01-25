using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConfigCentric.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddModelsDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Projects",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Environments",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ConfigValues",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Environments");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ConfigValues");
        }
    }
}
