using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConfigCentric.Api.Migrations
{
    /// <inheritdoc />
    public partial class MakeNamesUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Projects_Name",
                table: "Projects",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Environments_Name_ProjectId",
                table: "Environments",
                columns: new[] { "Name", "ProjectId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConfigValues_Name_EnvironmentId",
                table: "ConfigValues",
                columns: new[] { "Name", "EnvironmentId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Projects_Name",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Environments_Name_ProjectId",
                table: "Environments");

            migrationBuilder.DropIndex(
                name: "IX_ConfigValues_Name_EnvironmentId",
                table: "ConfigValues");
        }
    }
}
