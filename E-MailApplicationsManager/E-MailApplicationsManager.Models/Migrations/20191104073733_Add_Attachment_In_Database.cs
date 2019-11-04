using Microsoft.EntityFrameworkCore.Migrations;

namespace E_MailApplicationsManager.Models.Migrations
{
    public partial class Add_Attachment_In_Database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GmailId",
                table: "Attachments",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca678235-7571-4177-984f-e9d1957b0187",
                column: "ConcurrencyStamp",
                value: "2787f6ef-a098-4ec7-94bf-3fa3e4f7ef80");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef1c4fa2-0b76-4598-aaee-c6e02803d486",
                column: "ConcurrencyStamp",
                value: "b0fd6c88-1d41-4212-bae8-8177c73ba17b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c23c3678-6194-4b7e-a928-09614190eb62",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cad4c712-57be-460f-858c-9752279f683b", "AQAAAAEAACcQAAAAEH3JroRPrSllb6mTtzdauBwA6suAV4sLCCdvDz6AEFF3Xdj5XyEXOYYY4TU4WdRduQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5b2211a-4ddc-4451-af5e-36b5cfad9a2c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7d8c8cbe-3210-4a25-ae80-ab50da8eb646", "AQAAAAEAACcQAAAAEOYXNZK7MVBmIh4uEbYFQSMwSQpLj3+ucDhWIcNDhNwIUR2/fuHVaQaKIU5GaRdtHg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GmailId",
                table: "Attachments");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca678235-7571-4177-984f-e9d1957b0187",
                column: "ConcurrencyStamp",
                value: "f855e2c0-652a-4a7a-bad2-01a79927bac0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef1c4fa2-0b76-4598-aaee-c6e02803d486",
                column: "ConcurrencyStamp",
                value: "62e49aaf-8807-45c2-bfc8-92884764e5b6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c23c3678-6194-4b7e-a928-09614190eb62",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4816eb2a-c428-4b32-baa9-cf505b4f02e8", "AQAAAAEAACcQAAAAEKII/OAPMFwRoLht0W/iwlZ1HHKou8teWjPHAAV5xVpWBpmJuBYdTx6d7h74+iF5TA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5b2211a-4ddc-4451-af5e-36b5cfad9a2c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6d93f38d-3e70-4de3-aba6-9f14147ce1f7", "AQAAAAEAACcQAAAAELnBg2uKZYnyo+vxiMyPM8FPsV/svZLu443Z2ULQciS+9xbJjvb65Bgorcxz9pKi1Q==" });
        }
    }
}
