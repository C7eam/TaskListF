using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskListF.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TaskDescription = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    DateAdded = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateEnding = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateDone = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDone = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");
        }
    }
}
