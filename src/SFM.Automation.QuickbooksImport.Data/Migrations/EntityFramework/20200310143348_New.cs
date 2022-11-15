using Microsoft.EntityFrameworkCore.Migrations;

namespace SFM.Automation.QuickbooksImport.Data.Migrations.EntityFramework
{
    /// <summary>
    ///   The new migration.
    /// </summary>
    public partial class New : Migration
    {
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Token");
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Token",
                table => new
                {
                    RealmId = table.Column<string>(maxLength: 50),
                    AccessToken = table.Column<string>(maxLength: 1000),
                    RefreshToken = table.Column<string>(maxLength: 1000),
                },
                constraints: table => { table.PrimaryKey("PK_Token", x => x.RealmId); });
        }
    }
}