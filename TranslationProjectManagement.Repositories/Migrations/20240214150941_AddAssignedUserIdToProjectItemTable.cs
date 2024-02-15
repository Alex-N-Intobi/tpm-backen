using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranslationProjectManagement.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class AddAssignedUserIdToProjectItemTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AssignedUserId",
                table: "ProjectItem",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectItem_AssignedUserId",
                table: "ProjectItem",
                column: "AssignedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectItem_User_AssignedUserId",
                table: "ProjectItem",
                column: "AssignedUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectItem_User_AssignedUserId",
                table: "ProjectItem");

            migrationBuilder.DropIndex(
                name: "IX_ProjectItem_AssignedUserId",
                table: "ProjectItem");

            migrationBuilder.DropColumn(
                name: "AssignedUserId",
                table: "ProjectItem");
        }
    }
}
