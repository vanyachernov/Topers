using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Topers.DataAccess.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class UpdateScopeRef : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Goods_GoodId",
                table: "OrderDetails");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_GoodScopes_GoodId",
                table: "OrderDetails",
                column: "GoodId",
                principalTable: "GoodScopes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_GoodScopes_GoodId",
                table: "OrderDetails");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Goods_GoodId",
                table: "OrderDetails",
                column: "GoodId",
                principalTable: "Goods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
