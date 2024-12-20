using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZiekenFonds.API.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Programma_Activiteit_ActiviteitId",
                table: "Programma");

            migrationBuilder.AddForeignKey(
                name: "FK_Programma_Activiteit_ActiviteitId",
                table: "Programma",
                column: "ActiviteitId",
                principalTable: "Activiteit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Programma_Activiteit_ActiviteitId",
                table: "Programma");

            migrationBuilder.AddForeignKey(
                name: "FK_Programma_Activiteit_ActiviteitId",
                table: "Programma",
                column: "ActiviteitId",
                principalTable: "Activiteit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}