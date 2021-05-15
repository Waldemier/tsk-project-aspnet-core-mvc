using Microsoft.EntityFrameworkCore.Migrations;

namespace TSKApp.DAL.Migrations
{
    public partial class FixuserIdfromUserTestAccess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTestAccesses_AspNetUsers_UserId1",
                table: "UserTestAccesses");

            migrationBuilder.DropIndex(
                name: "IX_UserTestAccesses_UserId1",
                table: "UserTestAccesses");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserTestAccesses");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserTestAccesses",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_UserTestAccesses_UserId",
                table: "UserTestAccesses",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTestAccesses_AspNetUsers_UserId",
                table: "UserTestAccesses",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTestAccesses_AspNetUsers_UserId",
                table: "UserTestAccesses");

            migrationBuilder.DropIndex(
                name: "IX_UserTestAccesses_UserId",
                table: "UserTestAccesses");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserTestAccesses",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "UserTestAccesses",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserTestAccesses_UserId1",
                table: "UserTestAccesses",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTestAccesses_AspNetUsers_UserId1",
                table: "UserTestAccesses",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
