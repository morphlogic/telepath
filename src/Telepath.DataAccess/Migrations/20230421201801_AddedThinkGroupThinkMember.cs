using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Morphware.Telepath.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedThinkGroupThinkMember : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ThinkGroupThinkMember",
                columns: table => new
                {
                    ThinkGroupsThinkGroupId = table.Column<int>(type: "int", nullable: false),
                    ThinkMembersThinkMemberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThinkGroupThinkMember", x => new { x.ThinkGroupsThinkGroupId, x.ThinkMembersThinkMemberId });
                    table.ForeignKey(
                        name: "FK_ThinkGroupThinkMember_ThinkGroups_ThinkGroupsThinkGroupId",
                        column: x => x.ThinkGroupsThinkGroupId,
                        principalTable: "ThinkGroups",
                        principalColumn: "ThinkGroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ThinkGroupThinkMember_ThinkMembers_ThinkMembersThinkMemberId",
                        column: x => x.ThinkMembersThinkMemberId,
                        principalTable: "ThinkMembers",
                        principalColumn: "ThinkMemberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ThinkGroupThinkMember_ThinkMembersThinkMemberId",
                table: "ThinkGroupThinkMember",
                column: "ThinkMembersThinkMemberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ThinkGroupThinkMember");
        }
    }
}
