using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DistributedSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Add_Process_on_utc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ProcessOnUtc",
                table: "OutboxMessages",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProcessOnUtc",
                table: "OutboxMessages");
        }
    }
}
