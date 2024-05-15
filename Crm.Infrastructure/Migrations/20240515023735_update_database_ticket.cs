using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crm.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class update_database_ticket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Tickets",
                newName: "UsernameSender");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Tickets",
                newName: "UserIdSender");

            migrationBuilder.AddColumn<long>(
                name: "UserIdReciver",
                table: "Tickets",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "UsernameReciver",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserIdReciver",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "UsernameReciver",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "UsernameSender",
                table: "Tickets",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "UserIdSender",
                table: "Tickets",
                newName: "UserId");
        }
    }
}
