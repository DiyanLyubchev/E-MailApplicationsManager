using Microsoft.EntityFrameworkCore.Migrations;

namespace E_MailApplicationsManager.Models.Migrations
{
    public partial class add_SIze_And_FileNameIN_ReceivedMail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "ReceivedEmails",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SizeInMb",
                table: "ReceivedEmails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Emails",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SizeInMb",
                table: "Emails",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca678235-7571-4177-984f-e9d1957b0187",
                column: "ConcurrencyStamp",
                value: "8059006f-e8fa-4aff-aaaf-ee9612df327b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef1c4fa2-0b76-4598-aaee-c6e02803d486",
                column: "ConcurrencyStamp",
                value: "b9c7aa2d-fa46-49aa-b259-14c39c3fd5c4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c23c3678-6194-4b7e-a928-09614190eb62",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "52dc780d-dac0-403b-a08e-095486c5e7ef", "AQAAAAEAACcQAAAAEBRaQ01SLX7rZd6xe6h5Xn4am09fImEa8uCWgvi9706f+59IkOugZPKRfDbyg3owxQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5b2211a-4ddc-4451-af5e-36b5cfad9a2c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d1ab9dd0-e5e1-4258-bab8-9b15e4c2080c", "AQAAAAEAACcQAAAAEDh92Xe4YyAn6ZS+Kys11NpagmKdpHjkEuALAl6zCryR5b11C3doQMEWHdzQo1xf3w==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "ReceivedEmails");

            migrationBuilder.DropColumn(
                name: "SizeInMb",
                table: "ReceivedEmails");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Emails");

            migrationBuilder.DropColumn(
                name: "SizeInMb",
                table: "Emails");

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
    }
}
