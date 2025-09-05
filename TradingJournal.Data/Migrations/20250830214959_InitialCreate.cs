using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TradingJournal.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Symbol = table.Column<string>(type: "TEXT", nullable: false),
                    Lots = table.Column<double>(type: "REAL", nullable: false),
                    RisikoProzent = table.Column<double>(type: "REAL", nullable: false),
                    RisikoEuro = table.Column<double>(type: "REAL", nullable: false),
                    ProfitProzent = table.Column<double>(type: "REAL", nullable: false),
                    ProfitEuro = table.Column<double>(type: "REAL", nullable: false),
                    Gedanken = table.Column<string>(type: "TEXT", nullable: false),
                    DailyBias = table.Column<string>(type: "TEXT", nullable: false),
                    Datum = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trades", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trades");
        }
    }
}
