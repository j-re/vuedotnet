using Microsoft.EntityFrameworkCore.Migrations;

namespace vue.Migrations
{
    public partial class addstocklevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StockLevel",
                table: "ProductVariants",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StockLevel",
                table: "ProductVariants");
        }
    }
}
