using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fyropinonet.Migrations
{
    /// <inheritdoc />
    public partial class ContractorActiveFlag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Contractors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Contractors",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsActive",
                value: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Contractors");
        }
    }
}
