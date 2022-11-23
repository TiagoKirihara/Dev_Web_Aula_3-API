using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fiap2022.core.Migrations
{
    /// <inheritdoc />
    public partial class AddContinentToTimes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Continent",
                table: "Times",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Continent",
                table: "Times");
        }
    }
}
