using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatientConnect.Migrations
{
    /// <inheritdoc />
    public partial class AddedRatingFieldToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Users",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Users");
        }
    }
}
