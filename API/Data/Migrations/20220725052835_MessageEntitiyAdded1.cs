using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    public partial class MessageEntitiyAdded1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SemderDeleted",
                table: "Messages",
                newName: "SenderDeleted");

            migrationBuilder.RenameColumn(
                name: "Recipientname",
                table: "Messages",
                newName: "RecipientUsername");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SenderDeleted",
                table: "Messages",
                newName: "SemderDeleted");

            migrationBuilder.RenameColumn(
                name: "RecipientUsername",
                table: "Messages",
                newName: "Recipientname");
        }
    }
}
