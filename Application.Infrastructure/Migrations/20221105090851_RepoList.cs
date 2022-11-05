using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Application.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RepoList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Repos_RepoId",
                table: "Authors");

            migrationBuilder.DropIndex(
                name: "IX_Authors_RepoId",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "RepoId",
                table: "Authors");

            migrationBuilder.CreateTable(
                name: "AuthorRepo",
                columns: table => new
                {
                    authorsId = table.Column<int>(type: "integer", nullable: false),
                    reposId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorRepo", x => new { x.authorsId, x.reposId });
                    table.ForeignKey(
                        name: "FK_AuthorRepo_Authors_authorsId",
                        column: x => x.authorsId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorRepo_Repos_reposId",
                        column: x => x.reposId,
                        principalTable: "Repos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorRepo_reposId",
                table: "AuthorRepo",
                column: "reposId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorRepo");

            migrationBuilder.AddColumn<int>(
                name: "RepoId",
                table: "Authors",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Authors_RepoId",
                table: "Authors",
                column: "RepoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Repos_RepoId",
                table: "Authors",
                column: "RepoId",
                principalTable: "Repos",
                principalColumn: "Id");
        }
    }
}
