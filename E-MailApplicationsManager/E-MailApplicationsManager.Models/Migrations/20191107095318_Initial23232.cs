using Microsoft.EntityFrameworkCore.Migrations;

namespace E_MailApplicationsManager.Models.Migrations
{
    public partial class Initial23232 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca678235-7571-4177-984f-e9d1957b0187",
                column: "ConcurrencyStamp",
                value: "b6d9b3ed-e681-4fde-a53d-f756acedba81");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef1c4fa2-0b76-4598-aaee-c6e02803d486",
                column: "ConcurrencyStamp",
                value: "7941991b-5e16-455c-90e6-4d96a742a6f3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c23c3678-6194-4b7e-a928-09614190eb62",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d9cf4848-e7da-424f-80b8-0255e49d010c", "AQAAAAEAACcQAAAAEJ/j83FcRLnfpI3MBxH9ROgXLqYjG/J87rhqSGBscWTVH4KorsSBncxk+UY2XsojJg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5b2211a-4ddc-4451-af5e-36b5cfad9a2c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7f625754-6943-459a-ab45-fa2f3b0eeef7", "AQAAAAEAACcQAAAAENvs5izY5QBAtLUABonEB0/m7j9b0RYtT6gsJA9RzoJSINM9eYUFExId74wFfbMGXw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca678235-7571-4177-984f-e9d1957b0187",
                column: "ConcurrencyStamp",
                value: "9803141a-40d9-4bba-9a32-719c8c46f1f4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef1c4fa2-0b76-4598-aaee-c6e02803d486",
                column: "ConcurrencyStamp",
                value: "af627778-1dfe-417c-a980-badd6f1f1b55");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c23c3678-6194-4b7e-a928-09614190eb62",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "11fe12be-a90e-4fed-b096-fd3ad290f3e6", "AQAAAAEAACcQAAAAEFBjJqpOPguCYUnuU/gSoMUW03UBPbFVdK7er/KaZGI5eROYV1+tA60RqDxjuRMF9A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5b2211a-4ddc-4451-af5e-36b5cfad9a2c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6ee181ee-44fc-40cf-b3a4-49003ba77c9b", "AQAAAAEAACcQAAAAEPTq2dIu2k/Ih5W6N6rbuwDsur/a9SkZv3iqw9hqGIQHDj+h6D5pQaSUxGqi1xTdOg==" });
        }
    }
}
