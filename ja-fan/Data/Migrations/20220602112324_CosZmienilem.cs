using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ja_fan.Data.Migrations
{
    public partial class CosZmienilem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Team_CountryId",
                table: "Team",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Nickname_TeamId",
                table: "Nickname",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nickname_Team_TeamId",
                table: "Nickname",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Team_Country_CountryId",
                table: "Team",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nickname_Team_TeamId",
                table: "Nickname");

            migrationBuilder.DropForeignKey(
                name: "FK_Team_Country_CountryId",
                table: "Team");

            migrationBuilder.DropIndex(
                name: "IX_Team_CountryId",
                table: "Team");

            migrationBuilder.DropIndex(
                name: "IX_Nickname_TeamId",
                table: "Nickname");
        }
    }
}
