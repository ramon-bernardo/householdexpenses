using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseholdExpenses.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class TransactionsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "transaction",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    description = table.Column<string>(type: "TEXT", maxLength: 400, nullable: false),
                    amount = table.Column<double>(type: "REAL", precision: 18, scale: 2, nullable: false),
                    type = table.Column<string>(type: "TEXT", maxLength: 8, nullable: false),
                    category_id = table.Column<long>(type: "INTEGER", nullable: false),
                    person_id = table.Column<long>(type: "INTEGER", nullable: false),
                    deleted = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transaction", x => x.id);
                    table.ForeignKey(
                        name: "FK_transaction_category_category_id",
                        column: x => x.category_id,
                        principalTable: "category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_transaction_person_person_id",
                        column: x => x.person_id,
                        principalTable: "person",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_transaction_category_id",
                table: "transaction",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_transaction_deleted",
                table: "transaction",
                column: "deleted");

            migrationBuilder.CreateIndex(
                name: "IX_transaction_person_id",
                table: "transaction",
                column: "person_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transaction");
        }
    }
}
