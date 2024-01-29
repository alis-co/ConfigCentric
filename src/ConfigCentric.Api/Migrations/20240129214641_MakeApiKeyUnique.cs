using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConfigCentric.Api.Migrations
{
    /// <inheritdoc />
    public partial class MakeApiKeyUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Projects_ApiKey",
                table: "Projects",
                column: "ApiKey",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Projects_ApiKey",
                table: "Projects");
        }
    }
}
