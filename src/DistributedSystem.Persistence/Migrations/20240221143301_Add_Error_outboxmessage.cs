using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DistributedSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Add_Error_outboxmessage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Error",
                table: "OutboxMessages",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Error",
                table: "OutboxMessages");
        }
    }
}
