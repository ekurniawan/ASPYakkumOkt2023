using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyASPWeb.Migrations
{
    /// <inheritdoc />
    public partial class Delete_ColumnPhone_TableCustomers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Customers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Customers",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }
    }
}
