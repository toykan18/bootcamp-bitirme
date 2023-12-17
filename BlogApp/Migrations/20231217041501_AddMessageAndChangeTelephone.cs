using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogApp.Migrations
{
    /// <inheritdoc />
    public partial class AddMessageAndChangeTelephone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Telefon",
                table: "Contact",
                newName: "Telephone");

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "Contact",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Message",
                table: "Contact");

            migrationBuilder.RenameColumn(
                name: "Telephone",
                table: "Contact",
                newName: "Telefon");
        }
    }
}
