using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AI_CampaignGenerator.Presistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubCategry",
                table: "Products",
                newName: "SubCategory");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubCategory",
                table: "Products",
                newName: "SubCategry");
        }
    }
}
