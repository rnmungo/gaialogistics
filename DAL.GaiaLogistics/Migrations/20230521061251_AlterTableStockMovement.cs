using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.GaiaLogistics.Migrations
{
    public partial class AlterTableStockMovement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CauseType",
                table: "StockMovements",
                type: "varchar(20)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CauseType",
                table: "StockMovements");
        }
    }
}
