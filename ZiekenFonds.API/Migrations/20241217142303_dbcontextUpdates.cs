using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZiekenFonds.API.Migrations
{
    /// <inheritdoc />
    public partial class dbcontextUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Opleiding Persoon_Opleiding_OpleidingId",
                table: "Opleiding Persoon");

            migrationBuilder.AddForeignKey(
                name: "FK_Opleiding Persoon_Opleiding_OpleidingId",
                table: "Opleiding Persoon",
                column: "OpleidingId",
                principalTable: "Opleiding",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Opleiding Persoon_Opleiding_OpleidingId",
                table: "Opleiding Persoon");

            migrationBuilder.AddForeignKey(
                name: "FK_Opleiding Persoon_Opleiding_OpleidingId",
                table: "Opleiding Persoon",
                column: "OpleidingId",
                principalTable: "Opleiding",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
