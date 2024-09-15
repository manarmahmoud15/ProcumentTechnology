using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Entities.Migrations
{
    /// <inheritdoc />
    public partial class initnwsm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Proposals");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "FreelancerReviews");

            migrationBuilder.DropColumn(
                name: "DateReviewed",
                table: "FreelancerReviews");

            migrationBuilder.DropColumn(
                name: "FreelancerId",
                table: "FreelancerReviews");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "FreelancerReviews");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "ClientReviews");

            migrationBuilder.DropColumn(
                name: "DateReviewed",
                table: "ClientReviews");

            migrationBuilder.DropColumn(
                name: "FreelancerId",
                table: "ClientReviews");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "ClientReviews");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "ClientOrders");

            migrationBuilder.DropColumn(
                name: "DeliveryDate",
                table: "ClientOrders");

            migrationBuilder.DropColumn(
                name: "FreelancerId",
                table: "ClientOrders");

            migrationBuilder.DropColumn(
                name: "OrderStatusId",
                table: "ClientOrders");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "ClientOrders");

            migrationBuilder.RenameColumn(
                name: "ReviewText",
                table: "FreelancerReviews",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "FreelancerReviews",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "ReviewText",
                table: "ClientReviews",
                newName: "Size");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "ClientReviews",
                newName: "ProductName");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "FreelancerReviews",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "FreelancerReviews",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "ClientReviews",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "ClientReviews",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "ClientReviews",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "ClientReviews",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Price",
                table: "ClientReviews",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "ClientOrders",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Detailes",
                table: "ClientOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "ClientOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "ClientOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Quantity",
                table: "ClientOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "price",
                table: "ClientOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Bill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BillNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BillFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateUserId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUserId = table.Column<int>(type: "int", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsBlock = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Communications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoImg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateUserId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUserId = table.Column<int>(type: "int", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsBlock = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Communications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Electronics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductPrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateUserId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUserId = table.Column<int>(type: "int", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsBlock = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Electronics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Product = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalPrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Convenant = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RestCovenant = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateUserId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUserId = table.Column<int>(type: "int", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsBlock = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bill");

            migrationBuilder.DropTable(
                name: "Communications");

            migrationBuilder.DropTable(
                name: "Electronics");

            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "FreelancerReviews");

            migrationBuilder.DropColumn(
                name: "Details",
                table: "FreelancerReviews");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "ClientReviews");

            migrationBuilder.DropColumn(
                name: "Details",
                table: "ClientReviews");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "ClientReviews");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "ClientReviews");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "ClientReviews");

            migrationBuilder.DropColumn(
                name: "Detailes",
                table: "ClientOrders");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "ClientOrders");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "ClientOrders");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ClientOrders");

            migrationBuilder.DropColumn(
                name: "price",
                table: "ClientOrders");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "FreelancerReviews",
                newName: "ReviewText");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "FreelancerReviews",
                newName: "Rating");

            migrationBuilder.RenameColumn(
                name: "Size",
                table: "ClientReviews",
                newName: "ReviewText");

            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "ClientReviews",
                newName: "Rating");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "FreelancerReviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateReviewed",
                table: "FreelancerReviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "FreelancerId",
                table: "FreelancerReviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "JobId",
                table: "FreelancerReviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "ClientReviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateReviewed",
                table: "ClientReviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "FreelancerId",
                table: "ClientReviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "JobId",
                table: "ClientReviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "ClientOrders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "ClientOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveryDate",
                table: "ClientOrders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "FreelancerId",
                table: "ClientOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderStatusId",
                table: "ClientOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "ClientOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AverageRating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Budget = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUserId = table.Column<int>(type: "int", nullable: true),
                    IsBlock = table.Column<bool>(type: "bit", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyUserId = table.Column<int>(type: "int", nullable: true),
                    Spending = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalJobsPosted = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUserId = table.Column<int>(type: "int", nullable: true),
                    Earnings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Experience = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HourlyRate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsBlock = table.Column<bool>(type: "bit", nullable: false),
                    Languages = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyUserId = table.Column<int>(type: "int", nullable: true),
                    PortfolioID = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Skills = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalJobsCompleted = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proposals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BidAmount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUserId = table.Column<int>(type: "int", nullable: true),
                    DateSubmitted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FreelancerId = table.Column<int>(type: "int", nullable: false),
                    IsBlock = table.Column<bool>(type: "bit", nullable: false),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyUserId = table.Column<int>(type: "int", nullable: true),
                    ProposalText = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proposals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUserId = table.Column<int>(type: "int", nullable: true),
                    FreelancerId = table.Column<int>(type: "int", nullable: false),
                    IsBlock = table.Column<bool>(type: "bit", nullable: false),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyUserId = table.Column<int>(type: "int", nullable: true),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                });
        }
    }
}
