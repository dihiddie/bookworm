using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookworm.DAL.PostgreSQL.EF.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "bookworm");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:pgcrypto", ",,");

            migrationBuilder.CreateTable(
                name: "Author",
                schema: "bookworm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Name = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookReviews",
                schema: "bookworm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BookId = table.Column<Guid>(type: "uuid", nullable: false),
                    Review = table.Column<string>(type: "text", nullable: true),
                    ReviewDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookReviews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                schema: "bookworm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Number = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                schema: "bookworm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Color = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                schema: "bookworm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Name = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Book_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalSchema: "bookworm",
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookRating",
                schema: "bookworm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BookId = table.Column<Guid>(type: "uuid", nullable: false),
                    RatingId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookRating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookRating_Book_BookId",
                        column: x => x.BookId,
                        principalSchema: "bookworm",
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookRating_Rating_RatingId",
                        column: x => x.RatingId,
                        principalSchema: "bookworm",
                        principalTable: "Rating",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookReadingDuration",
                schema: "bookworm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BookId = table.Column<Guid>(type: "uuid", nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookReadingDuration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookReadingDuration_Book_BookId",
                        column: x => x.BookId,
                        principalSchema: "bookworm",
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookStatus",
                schema: "bookworm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BookId = table.Column<Guid>(type: "uuid", nullable: false),
                    StatusId = table.Column<Guid>(type: "uuid", nullable: false),
                    StatusSettingDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookStatus_Book_BookId",
                        column: x => x.BookId,
                        principalSchema: "bookworm",
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookStatus_Status_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "bookworm",
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_AuthorId",
                schema: "bookworm",
                table: "Book",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_BookRating_BookId",
                schema: "bookworm",
                table: "BookRating",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookRating_RatingId",
                schema: "bookworm",
                table: "BookRating",
                column: "RatingId");

            migrationBuilder.CreateIndex(
                name: "IX_BookReadingDuration_BookId",
                schema: "bookworm",
                table: "BookReadingDuration",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookStatus_BookId",
                schema: "bookworm",
                table: "BookStatus",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookStatus_StatusId",
                schema: "bookworm",
                table: "BookStatus",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookRating",
                schema: "bookworm");

            migrationBuilder.DropTable(
                name: "BookReadingDuration",
                schema: "bookworm");

            migrationBuilder.DropTable(
                name: "BookReviews",
                schema: "bookworm");

            migrationBuilder.DropTable(
                name: "BookStatus",
                schema: "bookworm");

            migrationBuilder.DropTable(
                name: "Rating",
                schema: "bookworm");

            migrationBuilder.DropTable(
                name: "Book",
                schema: "bookworm");

            migrationBuilder.DropTable(
                name: "Status",
                schema: "bookworm");

            migrationBuilder.DropTable(
                name: "Author",
                schema: "bookworm");
        }
    }
}
