using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NLayer.Repository.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AveragePlayTime = table.Column<float>(type: "real", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Baskets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baskets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Baskets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserGames",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    PlayTime = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGames", x => new { x.UserId, x.GameId });
                    table.ForeignKey(
                        name: "FK_UserGames_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGames_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BasketGame",
                columns: table => new
                {
                    BasketsId = table.Column<int>(type: "int", nullable: false),
                    GamesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketGame", x => new { x.BasketsId, x.GamesId });
                    table.ForeignKey(
                        name: "FK_BasketGame_Baskets_BasketsId",
                        column: x => x.BasketsId,
                        principalTable: "Baskets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasketGame_Games_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RPG", null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MMORPG", null },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "FPS", null },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Puzzle", null },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "JRPG", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Password", "Role", "UpdatedDate", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "123", "normal_user", null, "Dogukan" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1234", "normal_user", null, "Tuana" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1234", "normal_user", null, "Handan" },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1234", "normal_user", null, "Hakan" }
                });

            migrationBuilder.InsertData(
                table: "Baskets",
                columns: new[] { "Id", "CreatedDate", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2 },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3 },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4 }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "AveragePlayTime", "CreatedDate", "Description", "GenreId", "ImageURL", "Price", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 75f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "THE NEW FANTASY ACTION RPG. Rise, Tarnished, and be guided by grace to brandish the power of the Elden Ring and become an Elden Lord in the Lands Between.", 1, "https://cdn.akamai.steamstatic.com/steam/apps/1245620/header.jpg?t=1683618443", 70f, "Elden Ring", null },
                    { 2, 200f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Don the mask and join the Phantom Thieves of Hearts as they stage grand heists, infiltrate the minds of the corrupt, and make them change their ways!", 5, "https://cdn.akamai.steamstatic.com/steam/apps/1687950/header.jpg?t=1679398700", 65f, "Persona 5", null },
                    { 3, 500f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Take part in an epic and ever-changing FINAL FANTASY as you adventure and explore with friends from around the world.", 2, "https://cdn.akamai.steamstatic.com/steam/apps/39210/header.jpg?t=1684850999", 40f, "Final Fantasy 14 Online", null },
                    { 4, 15f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Call of Duty®: Modern Warfare® II drops players into an unprecedented global conflict that features the return of the iconic Operators of Task Force 141.", 3, "https://cdn.akamai.steamstatic.com/steam/apps/1938090/header_alt_assets_3_turkish.jpg?t=1686273395", 80f, "Call of Duty Modern Warfare 2", null },
                    { 5, 450f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guild Wars 2 is an award-winning online roleplaying game with fast-paced action combat, deep character customization, and no subscription fee required. Choose from an arsenal of professions and weapons, explore a vast open world, compete in PVP modes and more. Join over 16 million players now!", 2, "https://cdn.akamai.steamstatic.com/steam/apps/1284210/header.jpg?t=1681772992", 35f, "Guild Wars 2", null },
                    { 6, 23f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The best-selling Trine series returns to the magic of 2.5D! Join three iconic heroes as they set off on a quest through fantastical fairytale landscapes to save the world from the Nightmare Prince’s shadows.", 4, "https://cdn.akamai.steamstatic.com/steam/apps/690640/header.jpg?t=1686202010", 15f, "Trine 4", null },
                    { 7, 65f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Then, there was fire. Re-experience the critically acclaimed, genre-defining game that started it all. Beautifully remastered, return to Lordran in stunning high-definition detail running at 60fps.", 1, "https://cdn.akamai.steamstatic.com/steam/apps/570940/header.jpg?t=1682652141", 55f, "Dark Souls", null },
                    { 8, 80f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DARK SOULS™ II: Scholar of the First Sin brings the franchise’s renowned obscurity & gripping gameplay to a new level. Join the dark journey and experience overwhelming enemy encounters, diabolical hazards, and unrelenting challenge.", 1, "https://cdn.akamai.steamstatic.com/steam/apps/335300/header.jpg?t=1682651964", 60f, "Dark Souls 2", null },
                    { 9, 60f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dark Souls continues to push the boundaries with the latest, ambitious chapter in the critically-acclaimed and genre-defining series. Prepare yourself and Embrace The Darkness!", 1, "https://cdn.akamai.steamstatic.com/steam/apps/374320/header.jpg?t=1682651227", 70f, "Dark Souls 3", null },
                    { 10, 90f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Game of the Year - The Game Awards 2019 Best Action Game of 2019 - IGN Carve your own clever path to vengeance in the award winning adventure from developer FromSoftware, creators of Bloodborne and the Dark Souls series. Take Revenge. Restore Your Honor. Kill Ingeniously.", 1, "https://cdn.akamai.steamstatic.com/steam/apps/814380/header.jpg?t=1678991267", 60f, "Sekiro: Shadows Die Twice", null }
                });

            migrationBuilder.InsertData(
                table: "UserGames",
                columns: new[] { "GameId", "UserId", "PlayTime" },
                values: new object[,]
                {
                    { 1, 1, 75f },
                    { 7, 1, 60f },
                    { 8, 1, 55f },
                    { 9, 1, 42f },
                    { 10, 1, 39f }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasketGame_GamesId",
                table: "BasketGame",
                column: "GamesId");

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_UserId",
                table: "Baskets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_GenreId",
                table: "Games",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGames_GameId",
                table: "UserGames",
                column: "GameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketGame");

            migrationBuilder.DropTable(
                name: "UserGames");

            migrationBuilder.DropTable(
                name: "Baskets");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
