using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KnowledgeAssistant.API.Migrations
{
    /// <inheritdoc />
    public partial class AddAIAnalysisCreatedAt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "AIAnalyses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_AIAnalyses_BusinessRecordId",
                table: "AIAnalyses",
                column: "BusinessRecordId");

            migrationBuilder.AddForeignKey(
                name: "FK_AIAnalyses_BusinessRecords_BusinessRecordId",
                table: "AIAnalyses",
                column: "BusinessRecordId",
                principalTable: "BusinessRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AIAnalyses_BusinessRecords_BusinessRecordId",
                table: "AIAnalyses");

            migrationBuilder.DropIndex(
                name: "IX_AIAnalyses_BusinessRecordId",
                table: "AIAnalyses");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "AIAnalyses");
        }
    }
}
