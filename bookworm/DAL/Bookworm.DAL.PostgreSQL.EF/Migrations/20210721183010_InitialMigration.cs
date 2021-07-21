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
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
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
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
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
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
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
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
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
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
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
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
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

            migrationBuilder.InsertData(
                schema: "bookworm",
                table: "Rating",
                columns: new[] { "Id", "Number" },
                values: new object[,]
                {
                    { new Guid("985fcaea-2c67-4313-834d-7df5795e2be6"), 1 },
                    { new Guid("4316f1f9-a294-4e2a-b81f-9c6f8127f956"), 2 },
                    { new Guid("07210325-f3ba-48f0-b239-454a70708d6c"), 3 },
                    { new Guid("95e070f0-f676-4b6b-a5c4-b9842d44ff7c"), 4 },
                    { new Guid("42885f94-0b00-4fcd-bc79-86d276c745cc"), 5 },
                    { new Guid("39df5aba-edbf-4a3b-a3eb-ab96a417a4a9"), 6 },
                    { new Guid("a2390a1a-b3d5-4108-8fc5-7b3924076791"), 7 },
                    { new Guid("2dc256a8-2081-40f5-b760-84ae4d27f397"), 8 },
                    { new Guid("fecfcdb1-8638-4a58-a526-11d85e25288e"), 9 },
                    { new Guid("d65a4a3d-6b0f-45ee-8a9b-6f4fca764066"), 10 }
                });

            migrationBuilder.InsertData(
                schema: "bookworm",
                table: "Status",
                columns: new[] { "Id", "Color", "Name" },
                values: new object[,]
                {
                    { new Guid("ef985a10-135e-4d0d-b7a0-1921f5065089"), "Gray", "NotFinished" },
                    { new Guid("d6faf158-3ee0-4459-8725-0fe1eb09790f"), "Green", "Readed" },
                    { new Guid("02fca866-7536-4afc-9f6c-e069555ec219"), "Yellow", "WantToRead" },
                    { new Guid("7bb082f8-1f60-408a-bb49-b3622894799a"), "Blue", "Bought" },
                    { new Guid("c7844c7e-87bd-467c-b3c2-237c37d38a65"), "Red", "Favorite" },
                    { new Guid("6d36db91-75d6-460e-a1e9-a5738a85338e"), "DarkGreen", "ReadingNow" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_AuthorId",
                schema: "bookworm",
                table: "Book",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "AK_BookRating_BookId_RatingId",
                schema: "bookworm",
                table: "BookRating",
                columns: new[] { "BookId", "RatingId" },
                unique: true);

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
                name: "AK_BookStatus_BookId_StatusId",
                schema: "bookworm",
                table: "BookStatus",
                columns: new[] { "BookId", "StatusId" },
                unique: true);

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
