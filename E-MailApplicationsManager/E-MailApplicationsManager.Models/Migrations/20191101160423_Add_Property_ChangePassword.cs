using Microsoft.EntityFrameworkCore.Migrations;

namespace E_MailApplicationsManager.Models.Migrations
{
    public partial class Add_Property_ChangePassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "FirstLog",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca678235-7571-4177-984f-e9d1957b0187",
                column: "ConcurrencyStamp",
                value: "500d5ce2-310b-4cba-a6b4-566ade43dcd9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef1c4fa2-0b76-4598-aaee-c6e02803d486",
                column: "ConcurrencyStamp",
                value: "e8f979bc-eb27-408f-8c21-174a9aca90cc");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c23c3678-6194-4b7e-a928-09614190eb62",
                columns: new[] { "ConcurrencyStamp", "FirstLog", "PasswordHash" },
                values: new object[] { "7e6232be-2fde-4d41-9ef4-a2abdf8a3ef4", true, "AQAAAAEAACcQAAAAEOUfor3Pp/eo+vbxd7qL+ebfZ7rn7BqfxGgxD8d0DMcaPBawN9tHiLIEOjlxzp4Q+w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5b2211a-4ddc-4451-af5e-36b5cfad9a2c",
                columns: new[] { "ConcurrencyStamp", "FirstLog", "PasswordHash" },
                values: new object[] { "c74f3fe7-1e99-4753-b60b-32942dd3c4fc", true, "AQAAAAEAACcQAAAAECtqx2CWp3495SgU8Ta5KAtW4Ah8oz4JagHqwtlVRnshDvhRb8k8oRURMxe8kMAUkg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstLog",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca678235-7571-4177-984f-e9d1957b0187",
                column: "ConcurrencyStamp",
                value: "8a25e9f0-5a23-4d69-866f-ce6e83d97aee");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef1c4fa2-0b76-4598-aaee-c6e02803d486",
                column: "ConcurrencyStamp",
                value: "3cd15498-1c8b-46dd-b38d-fd4457538518");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c23c3678-6194-4b7e-a928-09614190eb62",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2b72c067-93b9-4633-8afd-d0de1e6cf51a", "AQAAAAEAACcQAAAAEBsLwWBIuQ5A5iL8rChfe1qIcFIPsotvlD+mk2OP06DzFIhTniJfjuGPLYYVaP1pBQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5b2211a-4ddc-4451-af5e-36b5cfad9a2c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "10efedc5-7079-4ead-8860-86b4958a4fc8", "AQAAAAEAACcQAAAAEHtkznmKZHhcC6K5q///YwvPJKLiI+ugqADKM+6MKct60+sWNoCjilIAU/EJbM2+NA==" });
        }
    }
}
