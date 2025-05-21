using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API_Labb3.Migrations
{
    /// <inheritdoc />
    public partial class init10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonInterests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonID = table.Column<int>(type: "int", nullable: false),
                    InterestID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonInterests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonInterests_Interests_InterestID",
                        column: x => x.InterestID,
                        principalTable: "Interests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonInterests_Persons_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonInterestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Links_PersonInterests_PersonInterestId",
                        column: x => x.PersonInterestId,
                        principalTable: "PersonInterests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { 1, null, "Volleyball" },
                    { 2, "Taking pictures with either an old or a new camera", "Photograph" },
                    { 3, "Both computer and video games", "Gaming" },
                    { 4, "Back and white peices", "Chess" },
                    { 5, "All kind of programming", "Programming" },
                    { 6, "Specificly with oilpaint", "Painting" },
                    { 7, "Outside climbing on big and steep mountains", "Climing" },
                    { 8, "Somewhere, anywhere", "Hiking" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Age", "Firstname", "Lastname", "Phone" },
                values: new object[,]
                {
                    { 1, 16, "Fibie", "MeowMoew", 0 },
                    { 2, 27, "Herman", "Axelsson", 0 },
                    { 3, 78, "Nalle", "Pugh", 0 },
                    { 4, 10, "Holly", "WoofWoof", 0 },
                    { 5, 17, "Rosa", "FierceKitty", 0 }
                });

            migrationBuilder.InsertData(
                table: "PersonInterests",
                columns: new[] { "Id", "InterestID", "PersonID" },
                values: new object[,]
                {
                    { 1, 8, 1 },
                    { 2, 3, 1 },
                    { 3, 5, 1 },
                    { 4, 8, 2 },
                    { 5, 1, 2 },
                    { 6, 3, 3 },
                    { 7, 2, 4 },
                    { 8, 4, 3 },
                    { 9, 6, 5 },
                    { 10, 7, 5 }
                });

            migrationBuilder.InsertData(
                table: "Links",
                columns: new[] { "Id", "PersonInterestId", "URL" },
                values: new object[,]
                {
                    { 1, 2, "www.google.se" },
                    { 2, 4, "www.medium.com" },
                    { 3, 2, "www.youtube.com" },
                    { 4, 1, "www.trail.com" },
                    { 5, 3, "www.chess.com" },
                    { 6, 5, "www.spela.com" },
                    { 7, 1, "www.blocket.com" },
                    { 8, 3, "www.aftonbladet.se" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Links_PersonInterestId",
                table: "Links",
                column: "PersonInterestId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonInterests_InterestID",
                table: "PersonInterests",
                column: "InterestID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonInterests_PersonID",
                table: "PersonInterests",
                column: "PersonID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "PersonInterests");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
