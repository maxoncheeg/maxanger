using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Maxanger.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveReplyPreview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "reply_preview",
                table: "chat_messages");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "reply_preview",
                table: "chat_messages",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
