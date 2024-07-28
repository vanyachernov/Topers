using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Topers.DataAccess.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGoodImageField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Goods");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "GoodScopes",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "GoodScopes");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Goods",
                type: "text",
                nullable: true);
        }
    }
}
