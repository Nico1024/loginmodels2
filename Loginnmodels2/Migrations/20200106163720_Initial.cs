using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Loginnmodels2.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    database_id = table.Column<string>(nullable: true),
                    is_valid = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    user_name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.user_name);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ParentCaseName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menu_Cases_ParentCaseName",
                        column: x => x.ParentCaseName,
                        principalTable: "Cases",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserCaseRelation",
                columns: table => new
                {
                    int_counter = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usruser_name = table.Column<string>(nullable: true),
                    connected_caseName = table.Column<string>(nullable: true),
                    Sequence = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCaseRelation", x => x.int_counter);
                    table.ForeignKey(
                        name: "FK_UserCaseRelation_Cases_connected_caseName",
                        column: x => x.connected_caseName,
                        principalTable: "Cases",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserCaseRelation_Users_usruser_name",
                        column: x => x.usruser_name,
                        principalTable: "Users",
                        principalColumn: "user_name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MenuElements",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    ParentMenuId = table.Column<Guid>(nullable: true),
                    Sequence = table.Column<int>(nullable: false),
                    is_single_page = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuElements", x => x.Name);
                    table.ForeignKey(
                        name: "FK_MenuElements_Menu_ParentMenuId",
                        column: x => x.ParentMenuId,
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Paginas",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    CaseMenuId = table.Column<Guid>(nullable: true),
                    CaseName = table.Column<string>(nullable: true),
                    MenuPagesName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paginas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Paginas_Menu_CaseMenuId",
                        column: x => x.CaseMenuId,
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Paginas_Cases_CaseName",
                        column: x => x.CaseName,
                        principalTable: "Cases",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Paginas_MenuElements_MenuPagesName",
                        column: x => x.MenuPagesName,
                        principalTable: "MenuElements",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Menu_ParentCaseName",
                table: "Menu",
                column: "ParentCaseName");

            migrationBuilder.CreateIndex(
                name: "IX_MenuElements_ParentMenuId",
                table: "MenuElements",
                column: "ParentMenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Paginas_CaseMenuId",
                table: "Paginas",
                column: "CaseMenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Paginas_CaseName",
                table: "Paginas",
                column: "CaseName");

            migrationBuilder.CreateIndex(
                name: "IX_Paginas_MenuPagesName",
                table: "Paginas",
                column: "MenuPagesName");

            migrationBuilder.CreateIndex(
                name: "IX_UserCaseRelation_connected_caseName",
                table: "UserCaseRelation",
                column: "connected_caseName");

            migrationBuilder.CreateIndex(
                name: "IX_UserCaseRelation_usruser_name",
                table: "UserCaseRelation",
                column: "usruser_name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Paginas");

            migrationBuilder.DropTable(
                name: "UserCaseRelation");

            migrationBuilder.DropTable(
                name: "MenuElements");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Cases");
        }
    }
}
