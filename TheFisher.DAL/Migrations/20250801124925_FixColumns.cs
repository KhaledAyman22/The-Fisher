using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheFisher.DAL.Migrations
{
    public partial class FixColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransportationFees",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Purchases",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "Commission",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldDefaultValue: "Direct");

            migrationBuilder.AddColumn<decimal>(
                name: "Tax",
                table: "Purchases",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TransportationFees",
                table: "Purchases",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tax",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "TransportationFees",
                table: "Purchases");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Purchases",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "Direct",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldDefaultValue: "Commission");

            migrationBuilder.AddColumn<decimal>(
                name: "TransportationFees",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
