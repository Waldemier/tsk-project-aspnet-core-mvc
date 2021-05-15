using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TSKApp.DAL.Migrations
{
    public partial class ChangeAvatarProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvatarPathOrUrl",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<byte[]>(
                name: "Avatar",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "AvatarPathOrUrl",
                table: "AspNetUsers",
                type: "text",
                nullable: true);
        }
    }
}
