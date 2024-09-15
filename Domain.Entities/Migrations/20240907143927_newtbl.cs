using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Entities.Migrations
{
    /// <inheritdoc />
    public partial class newtbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    FreelancerId = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderStatusId = table.Column<int>(type: "int", nullable: false),
                    CreateUserId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUserId = table.Column<int>(type: "int", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsBlock = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FreelancerId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReviewText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateReviewed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUserId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUserId = table.Column<int>(type: "int", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsBlock = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientReviews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Budget = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalJobsPosted = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AverageRating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Spending = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateUserId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUserId = table.Column<int>(type: "int", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsBlock = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FreelancerReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FreelancerId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReviewText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateReviewed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUserId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUserId = table.Column<int>(type: "int", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsBlock = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreelancerReviews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FreelancerServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FreelancerId = table.Column<int>(type: "int", nullable: false),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DeliveryTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Revisions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateUserId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUserId = table.Column<int>(type: "int", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsBlock = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreelancerServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Skills = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Experience = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HourlyRate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Languages = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalJobsCompleted = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Earnings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PortfolioID = table.Column<int>(type: "int", nullable: false),
                    CreateUserId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUserId = table.Column<int>(type: "int", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsBlock = table.Column<bool>(type: "bit", nullable: false)
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
                    JobId = table.Column<int>(type: "int", nullable: false),
                    FreelancerId = table.Column<int>(type: "int", nullable: false),
                    BidAmount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProposalText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateSubmitted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUserId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUserId = table.Column<int>(type: "int", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsBlock = table.Column<bool>(type: "bit", nullable: false)
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
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    FreelancerId = table.Column<int>(type: "int", nullable: false),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionStatusId = table.Column<int>(type: "int", nullable: false),
                    CreateUserId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUserId = table.Column<int>(type: "int", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsBlock = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserType = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Job = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsVerified = table.Column<bool>(type: "bit", nullable: true),
                    DateJoined = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CreateUserId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUserId = table.Column<int>(type: "int", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsBlock = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsersJobCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateUserId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUserId = table.Column<int>(type: "int", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsBlock = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersJobCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsersJobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    Budget = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deadline = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FreelancerId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    DatePosted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUserId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUserId = table.Column<int>(type: "int", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsBlock = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersJobs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsersJobStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateUserId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUserId = table.Column<int>(type: "int", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsBlock = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersJobStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsersRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CreateUserId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUserId = table.Column<int>(type: "int", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsBlock = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersRoles", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientOrders");

            migrationBuilder.DropTable(
                name: "ClientReviews");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "FreelancerReviews");

            migrationBuilder.DropTable(
                name: "FreelancerServices");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Proposals");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UsersJobCategory");

            migrationBuilder.DropTable(
                name: "UsersJobs");

            migrationBuilder.DropTable(
                name: "UsersJobStatus");

            migrationBuilder.DropTable(
                name: "UsersRoles");
        }
    }
}
