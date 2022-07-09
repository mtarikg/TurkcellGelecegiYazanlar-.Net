using Microsoft.EntityFrameworkCore.Migrations;

namespace nbaDemo.DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conferences",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conferences", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Divisions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divisions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoundationYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentOwner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeadCoach = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Arena = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DivisionID = table.Column<int>(type: "int", nullable: false),
                    ConferenceID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Teams_Conferences_ConferenceID",
                        column: x => x.ConferenceID,
                        principalTable: "Conferences",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Teams_Divisions_DivisionID",
                        column: x => x.DivisionID,
                        principalTable: "Divisions",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastAttended = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Height = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JerseyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Experience = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DraftInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfileImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    TeamID = table.Column<int>(type: "int", nullable: true),
                    PositionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Players_Positions_PositionID",
                        column: x => x.PositionID,
                        principalTable: "Positions",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Teams",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "Conferences",
                columns: new[] { "ID", "Logo", "Name" },
                values: new object[,]
                {
                    { 1, "https://seeklogo.com/images/N/nba-eastern-conference-logo-0B7E499625-seeklogo.com.png", "Eastern Conference" },
                    { 2, "https://seeklogo.com/images/N/nba-western-conference-logo-CD123BABD3-seeklogo.com.png", "Western Conference" }
                });

            migrationBuilder.InsertData(
                table: "Divisions",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Southeast Division" },
                    { 2, "Atlantic Division" },
                    { 3, "Northwest Division" },
                    { 4, "Central Division" },
                    { 5, "Southwest Division" },
                    { 6, "Pacific Division" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Center" },
                    { 2, "Forward" },
                    { 3, "Guard" },
                    { 4, "Center-Forward" },
                    { 5, "Guard-Forward" }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "ID", "Arena", "ConferenceID", "CurrentOwner", "DivisionID", "FoundationYear", "HeadCoach", "Logo", "Name" },
                values: new object[] { 1, "FTX Arena", 1, "Micky Arison", 1, "1988", "Erik Spoelstra", "https://cdn.nba.com/logos/nba/1610612748/global/L/logo.svg", "Miami Heat" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "ID", "Arena", "ConferenceID", "CurrentOwner", "DivisionID", "FoundationYear", "HeadCoach", "Logo", "Name" },
                values: new object[] { 2, "Scotiabank Arena", 1, "Maple Leaf Sports and Entertainment", 2, "1995", "Nick Nurse", "https://cdn.nba.com/logos/nba/1610612761/global/L/logo.svg", "Toronto Raptors" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "ID", "Arena", "ConferenceID", "CurrentOwner", "DivisionID", "FoundationYear", "HeadCoach", "Logo", "Name" },
                values: new object[] { 3, "Vivint Arena", 2, "Ryan Smith", 3, "1974", "Quin Snyder", "https://cdn.nba.com/logos/nba/1610612762/global/L/logo.svg", "Utah Jazz" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "ID", "Age", "Country", "DateOfBirth", "DraftInfo", "Experience", "FullName", "Height", "IsActive", "JerseyNumber", "LastAttended", "PositionID", "ProfileImage", "TeamID", "Weight" },
                values: new object[] { 1, "24 years", "USA", "July 18, 1997", "2017 R1 Pick 14", "4 years", "Bam Adebayo", "6 ft 9 in | (2.06m)", true, "#13", "Kentucky", 4, "https://cdn.nba.com/headshots/nba/latest/1040x760/1628389.png", 1, "255lb | 116kg" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "ID", "Age", "Country", "DateOfBirth", "DraftInfo", "Experience", "FullName", "Height", "IsActive", "JerseyNumber", "LastAttended", "PositionID", "ProfileImage", "TeamID", "Weight" },
                values: new object[] { 2, "22 years", "Nigeria", "September 19, 1999", "2020 R1 Pick 20", "1 year", "Precious Achiuwa", "6 ft 8 in | (2.03m)", true, "#13", "Memphis", 2, "https://cdn.nba.com/headshots/nba/latest/1040x760/1630173.png", 2, "225lb | 102kg" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "ID", "Age", "Country", "DateOfBirth", "DraftInfo", "Experience", "FullName", "Height", "IsActive", "JerseyNumber", "LastAttended", "PositionID", "ProfileImage", "TeamID", "Weight" },
                values: new object[] { 3, "29 years", "France", "June 26, 1992", "2013 R1 Pick 27", "8 years", "Rudy Gobert", "7 ft 1 in | (2.16m)", true, "#27", "Cholet", 1, "https://cdn.nba.com/headshots/nba/latest/1040x760/203497.png", 3, "258lb | 117kg" });

            migrationBuilder.CreateIndex(
                name: "IX_Players_PositionID",
                table: "Players",
                column: "PositionID");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamID",
                table: "Players",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_ConferenceID",
                table: "Teams",
                column: "ConferenceID");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_DivisionID",
                table: "Teams",
                column: "DivisionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Conferences");

            migrationBuilder.DropTable(
                name: "Divisions");
        }
    }
}
