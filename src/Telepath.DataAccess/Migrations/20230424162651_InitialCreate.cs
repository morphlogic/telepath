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
                name: "Members",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberId);
                });

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
                name: "MemberThinkGroup",
                columns: table => new
                {
                    MembersMemberId = table.Column<int>(type: "int", nullable: false),
                    ThinkGroupsThinkGroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberThinkGroup", x => new { x.MembersMemberId, x.ThinkGroupsThinkGroupId });
                    table.ForeignKey(
                        name: "FK_MemberThinkGroup_Members_MembersMemberId",
                        column: x => x.MembersMemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MemberThinkGroup_ThinkGroups_ThinkGroupsThinkGroupId",
                        column: x => x.ThinkGroupsThinkGroupId,
                        principalTable: "ThinkGroups",
                        principalColumn: "ThinkGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Thoughts",
                columns: table => new
                {
                    ThoughtId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThinkGroupId = table.Column<int>(type: "int", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    TopicId = table.Column<int>(type: "int", nullable: false),
                    Occurred = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thoughts", x => x.ThoughtId);
                    table.ForeignKey(
                        name: "FK_Thoughts_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Thoughts_ThinkGroups_ThinkGroupId",
                        column: x => x.ThinkGroupId,
                        principalTable: "ThinkGroups",
                        principalColumn: "ThinkGroupId",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_MemberThinkGroup_ThinkGroupsThinkGroupId",
                table: "MemberThinkGroup",
                column: "ThinkGroupsThinkGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportThought_ThoughtsThoughtId",
                table: "ReportThought",
                column: "ThoughtsThoughtId");

            migrationBuilder.CreateIndex(
                name: "IX_Thoughts_MemberId",
                table: "Thoughts",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Thoughts_ThinkGroupId",
                table: "Thoughts",
                column: "ThinkGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Thoughts_TopicId",
                table: "Thoughts",
                column: "TopicId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MemberThinkGroup");

            migrationBuilder.DropTable(
                name: "ReportThought");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Thoughts");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "ThinkGroups");

            migrationBuilder.DropTable(
                name: "Topics");
        }
    }
}
