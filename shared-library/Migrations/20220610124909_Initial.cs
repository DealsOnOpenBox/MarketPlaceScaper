using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shared_library.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "contactAddresses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    street_1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    street_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    state = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    postal_code = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contactAddresses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "marketPlaces",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    marketplace_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    five_star_total_rating_count_by_role = table.Column<float>(type: "real", nullable: true),
                    five_star_ratings_average = table.Column<float>(type: "real", nullable: true),
                    min_ratings_required_to_be_public = table.Column<float>(type: "real", nullable: true),
                    good_attributes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bad_attributes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rating_private = table.Column<bool>(type: "bit", nullable: false),
                    total_items = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_marketPlaces", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "contactInfos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    business_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone_number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    addressid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contactInfos", x => x.id);
                    table.ForeignKey(
                        name: "FK_contactInfos_contactAddresses_addressid",
                        column: x => x.addressid,
                        principalTable: "contactAddresses",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "scrapedUsers",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date_added = table.Column<DateTime>(type: "datetime2", nullable: true),
                    contact_infoid = table.Column<int>(type: "int", nullable: false),
                    marketlaceid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_scrapedUsers", x => x.id);
                    table.ForeignKey(
                        name: "FK_scrapedUsers_contactInfos_contact_infoid",
                        column: x => x.contact_infoid,
                        principalTable: "contactInfos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_scrapedUsers_marketPlaces_marketlaceid",
                        column: x => x.marketlaceid,
                        principalTable: "marketPlaces",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_contactInfos_addressid",
                table: "contactInfos",
                column: "addressid");

            migrationBuilder.CreateIndex(
                name: "IX_scrapedUsers_contact_infoid",
                table: "scrapedUsers",
                column: "contact_infoid");

            migrationBuilder.CreateIndex(
                name: "IX_scrapedUsers_marketlaceid",
                table: "scrapedUsers",
                column: "marketlaceid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "scrapedUsers");

            migrationBuilder.DropTable(
                name: "contactInfos");

            migrationBuilder.DropTable(
                name: "marketPlaces");

            migrationBuilder.DropTable(
                name: "contactAddresses");
        }
    }
}
