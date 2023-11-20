using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Event_Connect_Web.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventManager",
                columns: table => new
                {
                    EventManagerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventManager", x => x.EventManagerID);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    EventID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizerUserID = table.Column<int>(type: "int", nullable: false),
                    EventManagerID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.EventID);
                    table.ForeignKey(
                        name: "FK_Event_EventManager_EventManagerID",
                        column: x => x.EventManagerID,
                        principalTable: "EventManager",
                        principalColumn: "EventManagerID");
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_User_Event_EventID",
                        column: x => x.EventID,
                        principalTable: "Event",
                        principalColumn: "EventID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Event_EventManagerID",
                table: "Event",
                column: "EventManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_Event_OrganizerUserID",
                table: "Event",
                column: "OrganizerUserID");

            migrationBuilder.CreateIndex(
                name: "IX_User_EventID",
                table: "User",
                column: "EventID");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_User_OrganizerUserID",
                table: "Event",
                column: "OrganizerUserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_EventManager_EventManagerID",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_User_OrganizerUserID",
                table: "Event");

            migrationBuilder.DropTable(
                name: "EventManager");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Event");
        }
    }
}
