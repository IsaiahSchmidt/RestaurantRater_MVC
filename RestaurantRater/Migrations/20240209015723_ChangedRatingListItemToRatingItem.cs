using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantRater.Migrations
{
    /// <inheritdoc />
    public partial class ChangedRatingListItemToRatingItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Score",
                table: "Ratings",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Score",
                table: "Ratings");
        }
    }
}
