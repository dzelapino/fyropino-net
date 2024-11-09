using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fyropinonet.Migrations
{
    /// <inheritdoc />
    public partial class CreateEventModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contractors",
                keyColumn: "Id",
                keyValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Contractors",
                columns: new[] { "Id", "Address", "Color", "Email", "FullName", "IsActive", "Phone", "ShortName" },
                values: new object[] { 1, "Klonowa 4d/21", "green", "dzelapino@mail.su", "dzelapino sp. zło", true, "500500100", "dzelapino" });
        }
    }
}
