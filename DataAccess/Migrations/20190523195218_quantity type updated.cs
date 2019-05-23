using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class quantitytypeupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "Carts",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(long),
                oldDefaultValue: 1L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Quantity",
                table: "Carts",
                nullable: false,
                defaultValue: 1L,
                oldClrType: typeof(int),
                oldDefaultValue: 1);
        }
    }
}
