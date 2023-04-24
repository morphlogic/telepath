using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Morphware.Telepath.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    ReportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThinkGroupId = table.Column<int>(type: "int", nullable: false),
                    TopicId = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.ReportId);
                });

            migrationBuilder.CreateTable(
                name: "ThinkGroups",
                columns: table => new
                {
                    ThinkGroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThinkGroups", x => x.ThinkGroupId);
                });

            migrationBuilder.CreateTable(
                name: "ThinkMembers",
                columns: table => new
                {
                    ThinkMemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThinkMembers", x => x.ThinkMemberId);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    TopicId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.TopicId);
                });

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

            migrationBuilder.CreateTable(
                name: "Thoughts",
                columns: table => new
                {
                    ThoughtId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThinkGroupId = table.Column<int>(type: "int", nullable: false),
                    ThinkMemberId = table.Column<int>(type: "int", nullable: false),
                    TopicId = table.Column<int>(type: "int", nullable: false),
                    Occurred = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thoughts", x => x.ThoughtId);
                    table.ForeignKey(
                        name: "FK_Thoughts_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "TopicId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReportThought",
                columns: table => new
                {
                    ReportsReportId = table.Column<int>(type: "int", nullable: false),
                    ThoughtsThoughtId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportThought", x => new { x.ReportsReportId, x.ThoughtsThoughtId });
                    table.ForeignKey(
                        name: "FK_ReportThought_Reports_ReportsReportId",
                        column: x => x.ReportsReportId,
                        principalTable: "Reports",
                        principalColumn: "ReportId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReportThought_Thoughts_ThoughtsThoughtId",
                        column: x => x.ThoughtsThoughtId,
                        principalTable: "Thoughts",
                        principalColumn: "ThoughtId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReportThought_ThoughtsThoughtId",
                table: "ReportThought",
                column: "ThoughtsThoughtId");

            migrationBuilder.CreateIndex(
                name: "IX_ThinkGroupThinkMember_ThinkMembersThinkMemberId",
                table: "ThinkGroupThinkMember",
                column: "ThinkMembersThinkMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Thoughts_TopicId",
                table: "Thoughts",
                column: "TopicId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportThought");

            migrationBuilder.DropTable(
                name: "ThinkGroupThinkMember");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Thoughts");

            migrationBuilder.DropTable(
                name: "ThinkGroups");

            migrationBuilder.DropTable(
                name: "ThinkMembers");

            migrationBuilder.DropTable(
                name: "Topics");
        }
    }
}
