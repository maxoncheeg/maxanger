using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Maxanger.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedAt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_chat_messages_chat_id",
                table: "chat_messages");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "chat_messages",
                newName: "updated_at");

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "chats",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "chat_messages",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "added_at",
                table: "chat_members",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "chat_members",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "ix_chat_messages_chat_id_id",
                table: "chat_messages",
                columns: new[] { "chat_id", "id" },
                descending: new[] { false, true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_chat_messages_chat_id_id",
                table: "chat_messages");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "chats");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "chat_messages");

            migrationBuilder.DropColumn(
                name: "added_at",
                table: "chat_members");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "chat_members");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "chat_messages",
                newName: "date");

            migrationBuilder.CreateIndex(
                name: "ix_chat_messages_chat_id",
                table: "chat_messages",
                column: "chat_id");
        }
    }
}
