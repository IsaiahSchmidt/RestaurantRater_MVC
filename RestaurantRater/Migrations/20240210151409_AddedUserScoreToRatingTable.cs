using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantRater.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserScoreToRatingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Score",
                table: "Ratings",
                newName: "UserScore");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserScore",
                table: "Ratings",
                newName: "Score");
        }
    }
}
