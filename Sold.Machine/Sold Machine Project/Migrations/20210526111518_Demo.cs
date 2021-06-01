using Microsoft.EntityFrameworkCore.Migrations;

namespace Sold_Machine_Project.Migrations
{
    public partial class Demo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    machineName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    assetName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    assetSeries = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "id", "assetName", "assetSeries", "machineName" },
                values: new object[,]
                {
                    { 1, "Cutter head", "S6", "C300" },
                    { 2, "Cutter head", "S7", "C40" },
                    { 3, "Blade safety cover", "S10", "C300" },
                    { 4, "Blade safety cover", "S11", "C60" },
                    { 5, "Deburring blades", "S6", "C300" },
                    { 6, "Cutter head", "S8", "C60" },
                    { 7, "Clamping fixture", "S2", "C60" },
                    { 8, "Blade safety cover", "S11", "C40" },
                    { 9, "Shutter gripper", "S3", "C40" },
                    { 10, "Shutter gripper", "S4", "C10" },
                    { 11, "Cutter head", "S2", "C10" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assets");
        }
    }
}
