using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeMyMusicData.Migrations
{
    /// <inheritdoc />
    public partial class _10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "myAlbums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Genre = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    NetPrice = table.Column<float>(type: "REAL", nullable: false),
                    Vat = table.Column<float>(type: "REAL", nullable: false),
                    ArtistId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_myAlbums", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "myArtists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    WikiLink = table.Column<string>(type: "TEXT", nullable: false),
                    MyGenreId = table.Column<int>(type: "INTEGER", nullable: false),
                    Image = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_myArtists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "myBuckets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    TotalAmount = table.Column<float>(type: "REAL", nullable: false),
                    Paid = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_myBuckets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "myGenres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_myGenres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "myBuckectItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BucketId = table.Column<int>(type: "INTEGER", nullable: false),
                    AlbumId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_myBuckectItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_myBuckectItems_myAlbums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "myAlbums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_myBuckectItems_myBuckets_BucketId",
                        column: x => x.BucketId,
                        principalTable: "myBuckets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_myBuckectItems_AlbumId",
                table: "myBuckectItems",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_myBuckectItems_BucketId",
                table: "myBuckectItems",
                column: "BucketId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "myArtists");

            migrationBuilder.DropTable(
                name: "myBuckectItems");

            migrationBuilder.DropTable(
                name: "myGenres");

            migrationBuilder.DropTable(
                name: "myAlbums");

            migrationBuilder.DropTable(
                name: "myBuckets");
        }
    }
}
