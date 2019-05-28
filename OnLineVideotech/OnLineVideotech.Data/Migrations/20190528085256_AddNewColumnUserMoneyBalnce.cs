using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnLineVideotech.Data.Migrations
{
    public partial class AddNewColumnUserMoneyBalnce : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserMoneyBalance",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMoneyBalance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserMoneyBalance_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserMoneyBalance_UserId",
                table: "UserMoneyBalance",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserMoneyBalance");
        }
    }
}
