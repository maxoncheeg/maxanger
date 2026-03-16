using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Maxanger.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MessageStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "chat_messages",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "chat_messages");
        }
    }
}
