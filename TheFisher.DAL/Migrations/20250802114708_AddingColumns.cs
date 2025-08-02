using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheFisher.DAL.Migrations
{
    public partial class AddingColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "OrderShare",
                table: "OrderPurchases",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SettledAmount",
                table: "OrderPurchases",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                computedColumnSql: "[KiloPrice] * [Weight] + [Tax]",
                stored: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderShare",
                table: "OrderPurchases");

            migrationBuilder.DropColumn(
                name: "SettledAmount",
                table: "OrderPurchases");
        }
    }
}
