using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TSKApp.DAL.Migrations
{
    public partial class ReplaceTestTimerProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "timeLimit",
                table: "Tests");

            migrationBuilder.AddColumn<DateTime>(
                name: "PassToDate",
                table: "Tests",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PassToDate",
                table: "Tests");

            migrationBuilder.AddColumn<int>(
                name: "timeLimit",
                table: "Tests",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
