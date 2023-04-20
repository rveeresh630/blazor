using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BethanypieShopsHRM.Api.Migrations
{
    /// <inheritdoc />
    public partial class addednewdataforemployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "BirthDate", "City", "Comment", "CountryId", "Email", "ExitDate", "FirstName", "Gender", "JobCategoryId", "JoinedDate", "LastName", "Latitude", "Longitude", "MaritalStatus", "PhoneNumber", "Smoker", "Street", "Zip" },
                values: new object[,]
                {
                    { 2, new DateTime(1979, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Antwerp", "Lorem Ipsum", 2, "gill@bethanyspieshop.com", null, "Gill", 0, 2, new DateTime(2017, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cleeren", null, null, 0, "33999909923", false, "New Street", "2000" },
                    { 3, new DateTime(1979, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Antwerp", "Lorem Ipsum", 2, "gill@bethanyspieshop.com", null, "Gill", 0, 2, new DateTime(2017, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, null, 0, "33999909923", false, "New Street", "2000" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3);
        }
    }
}
