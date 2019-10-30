using Microsoft.EntityFrameworkCore.Migrations;

namespace E_MailApplicationsManager.Models.Migrations
{
    public partial class Add_Roles_And_Seed_Users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ca678235-7571-4177-984f-e9d1957b0187", "788b5fa0-cb6b-4fbe-9cff-a7c7fab7a9e4", "RoleUser", "Admin", "ADMIN" },
                    { "ef1c4fa2-0b76-4598-aaee-c6e02803d486", "bfe638e8-3e34-4f17-b0d2-3dc4a1e6c143", "RoleUser", "Manager", "MANAGER" },
                    { "8af3ffe5-1a47-4a68-be62-851092160a36", "5494aeb2-0b70-42a6-8355-d38c3dbdb506", "RoleUser", "Operator", "OPERATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LoanApplicantId", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "c23c3678-6194-4b7e-a928-09614190eb62", 0, "a66e39cb-13db-4042-ad2a-f070be230009", "admin1@admin.com", false, null, true, null, "ADMIN1@ADMIN.COM", "DIYAN", "AQAAAAEAACcQAAAAECfDzsAqoz6oRzwA57PlkoKZvw23jV1dx+gvGLa0p5ZaDg81qe3I4R/qjU1MvxXmfQ==", null, false, "7I5VNHIJTSZNOT3KDWKNFUV5PVYBHGXN", false, "Diyan" },
                    { "d5b2211a-4ddc-4451-af5e-36b5cfad9a2c", 0, "cf0e3213-0531-4042-bc97-080f4e611bc5", "admin2@admin.com", false, null, true, null, "ADMIN2@ADMIN.COM", "BOBI", "AQAAAAEAACcQAAAAEDrecLf1Lxx5oiP6fTCoqtl7nqM7tkrNxVTQALHV8svBx4gjGf98PLVDIHETaAn1tA==", null, false, "74CLJEIXNYLPRXMVXXNSWXZH6R6KJRRU", false, "Bobi" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "c23c3678-6194-4b7e-a928-09614190eb62", "ca678235-7571-4177-984f-e9d1957b0187" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "d5b2211a-4ddc-4451-af5e-36b5cfad9a2c", "ca678235-7571-4177-984f-e9d1957b0187" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8af3ffe5-1a47-4a68-be62-851092160a36");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef1c4fa2-0b76-4598-aaee-c6e02803d486");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "c23c3678-6194-4b7e-a928-09614190eb62", "ca678235-7571-4177-984f-e9d1957b0187" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "d5b2211a-4ddc-4451-af5e-36b5cfad9a2c", "ca678235-7571-4177-984f-e9d1957b0187" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca678235-7571-4177-984f-e9d1957b0187");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c23c3678-6194-4b7e-a928-09614190eb62");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5b2211a-4ddc-4451-af5e-36b5cfad9a2c");
        }
    }
}
