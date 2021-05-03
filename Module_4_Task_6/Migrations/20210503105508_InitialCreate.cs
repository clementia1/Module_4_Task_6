using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Module_4_Task_6.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    ArtistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    InstagramUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.ArtistId);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Song",
                columns: table => new
                {
                    SongId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DurationSeconds = table.Column<int>(type: "int", nullable: false),
                    ReleasedDate = table.Column<DateTime>(type: "date", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Song", x => x.SongId);
                    table.ForeignKey(
                        name: "FK_Song_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SongArtist",
                columns: table => new
                {
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    SongId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongArtist", x => new { x.ArtistId, x.SongId });
                    table.ForeignKey(
                        name: "FK_SongArtist_Artist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artist",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SongArtist_Song_SongId",
                        column: x => x.SongId,
                        principalTable: "Song",
                        principalColumn: "SongId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Song_GenreId",
                table: "Song",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_SongArtist_SongId",
                table: "SongArtist",
                column: "SongId");

            migrationBuilder.Sql("INSERT INTO Genre(Title) VALUES('folk')");
            migrationBuilder.Sql("INSERT INTO Genre(Title) VALUES('hip hop')");
            migrationBuilder.Sql("INSERT INTO Genre(Title) VALUES('deep house')");
            migrationBuilder.Sql("INSERT INTO Genre(Title) VALUES('alternative rock')");
            migrationBuilder.Sql("INSERT INTO Genre(Title) VALUES('house')");

            migrationBuilder.Sql("INSERT INTO Song(Title, DurationSeconds, ReleasedDate, GenreId) VALUES('Your Power', '245', '2021-04-29', (SELECT GenreId FROM Genre WHERE Title = 'folk'))");
            migrationBuilder.Sql("INSERT INTO Song(Title, DurationSeconds, ReleasedDate, GenreId) VALUES('Astronaut In The Ocean', '132', '2021-01-06', (SELECT GenreId FROM Genre WHERE Title = 'hip hop'))");
            migrationBuilder.Sql("INSERT INTO Song(Title, DurationSeconds, ReleasedDate, GenreId) VALUES('The Business', '164', '2020-09-25', (SELECT GenreId FROM Genre WHERE Title = 'deep house'))");
            migrationBuilder.Sql("INSERT INTO Song(Title, DurationSeconds, ReleasedDate, GenreId) VALUES('Shy Away', '155', '2021-04-07', (SELECT GenreId FROM Genre WHERE Title = 'alternative rock'))");
            migrationBuilder.Sql("INSERT INTO Song(Title, DurationSeconds, ReleasedDate, GenreId) VALUES('BED', '178', '2021-02-26', (SELECT GenreId FROM Genre WHERE Title = 'house'))");

            migrationBuilder.Sql("INSERT INTO Artist(Name, DateOfBirth) VALUES('Billie Eilish', '2001-12-18')");
            migrationBuilder.Sql("INSERT INTO Artist(Name, DateOfBirth) VALUES('Masked Wolf', '1992-01-01')");
            migrationBuilder.Sql("INSERT INTO Artist(Name, DateOfBirth) VALUES('Tiësto', '1969-01-17')");
            migrationBuilder.Sql("INSERT INTO Artist(Name, DateOfBirth) VALUES('Twenty One Pilots', '2009-01-01')");
            migrationBuilder.Sql("INSERT INTO Artist(Name, DateOfBirth) VALUES('Joel Corry', '1989-06-10')");

            migrationBuilder.Sql("INSERT INTO SongArtist(SongId, ArtistId) VALUES((SELECT SongId FROM Song WHERE Title = 'Your Power'), (SELECT ArtistId FROM Artist WHERE Name = 'Billie Eilish'))");
            migrationBuilder.Sql("INSERT INTO SongArtist(SongId, ArtistId) VALUES((SELECT SongId FROM Song WHERE Title = 'Astronaut In The Ocean'), (SELECT ArtistId FROM Artist WHERE Name = 'Masked Wolf'))");
            migrationBuilder.Sql("INSERT INTO SongArtist(SongId, ArtistId) VALUES((SELECT SongId FROM Song WHERE Title = 'The Business'), (SELECT ArtistId FROM Artist WHERE Name = 'Tiësto'))");
            migrationBuilder.Sql("INSERT INTO SongArtist(SongId, ArtistId) VALUES((SELECT SongId FROM Song WHERE Title = 'Shy Away'), (SELECT ArtistId FROM Artist WHERE Name = 'Twenty One Pilots'))");
            migrationBuilder.Sql("INSERT INTO SongArtist(SongId, ArtistId) VALUES((SELECT SongId FROM Song WHERE Title = 'BED'), (SELECT ArtistId FROM Artist WHERE Name = 'Joel Corry'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SongArtist");

            migrationBuilder.DropTable(
                name: "Artist");

            migrationBuilder.DropTable(
                name: "Song");

            migrationBuilder.DropTable(
                name: "Genre");
        }
    }
}
