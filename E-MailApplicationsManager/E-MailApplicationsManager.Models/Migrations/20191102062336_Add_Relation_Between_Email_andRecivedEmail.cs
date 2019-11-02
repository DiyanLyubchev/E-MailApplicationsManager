using Microsoft.EntityFrameworkCore.Migrations;

namespace E_MailApplicationsManager.Models.Migrations
{
    public partial class Add_Relation_Between_Email_andRecivedEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ReceivedEmails_EmailId",
                table: "ReceivedEmails");

            migrationBuilder.AddColumn<bool>(
                name: "IsSeen",
                table: "Emails",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca678235-7571-4177-984f-e9d1957b0187",
                column: "ConcurrencyStamp",
                value: "2d9f5830-fd91-42b9-b753-4c89fa475115");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef1c4fa2-0b76-4598-aaee-c6e02803d486",
                column: "ConcurrencyStamp",
                value: "6a5b11f3-3169-4be4-a6f0-b5a23032ab02");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c23c3678-6194-4b7e-a928-09614190eb62",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b4ef66af-cc76-450d-961f-6eb5c6b446a8", "AQAAAAEAACcQAAAAEJJ2pyQHKYoFqSlBFrZg/i6JK5kjOqkNPyicPmn44nIEFsBPARoiQ1RqihTsPILn3g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5b2211a-4ddc-4451-af5e-36b5cfad9a2c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8ca424c7-acc4-4578-9c7d-ab584b7f95d3", "AQAAAAEAACcQAAAAEKmCnqyRj9yope/tBa/6TQ2pwavOF/14bTo9alDp23sD60Aw309iHP2YMuggTTkgjA==" });

            migrationBuilder.CreateIndex(
                name: "IX_ReceivedEmails_EmailId",
                table: "ReceivedEmails",
                column: "EmailId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ReceivedEmails_EmailId",
                table: "ReceivedEmails");

            migrationBuilder.DropColumn(
                name: "IsSeen",
                table: "Emails");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca678235-7571-4177-984f-e9d1957b0187",
                column: "ConcurrencyStamp",
                value: "4500e06e-1ef4-4ab9-b60a-a4faefeadfd0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef1c4fa2-0b76-4598-aaee-c6e02803d486",
                column: "ConcurrencyStamp",
                value: "04ee1542-4a2f-4f58-b140-7bfaf26e5ece");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c23c3678-6194-4b7e-a928-09614190eb62",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3f2034ab-ebac-47ec-a2f8-870929921e7d", "AQAAAAEAACcQAAAAEAOIN1iRUtPX2yxD0TbJ+85eS19AXzJunnpTFbsN2fHi5B7LvoEQThhQ6kcvI+A7zg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5b2211a-4ddc-4451-af5e-36b5cfad9a2c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1a9a9409-0a52-4a38-9cb3-732c24d8d6dc", "AQAAAAEAACcQAAAAECY/OkmM+AC6LkW0P0IAjrf4RO6pDwHK9i6syJHHwxdw8CVGE7M/+LSgSyNGViUAwQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_ReceivedEmails_EmailId",
                table: "ReceivedEmails",
                column: "EmailId");
        }
    }
}
