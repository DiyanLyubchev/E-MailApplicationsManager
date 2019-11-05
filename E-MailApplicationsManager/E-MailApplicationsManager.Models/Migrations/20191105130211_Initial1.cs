using Microsoft.EntityFrameworkCore.Migrations;

namespace E_MailApplicationsManager.Models.Migrations
{
    public partial class Initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca678235-7571-4177-984f-e9d1957b0187",
                column: "ConcurrencyStamp",
                value: "9d5a4c4f-9abf-4f3c-8d68-742765768bf8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef1c4fa2-0b76-4598-aaee-c6e02803d486",
                column: "ConcurrencyStamp",
                value: "71434e1b-0103-40b5-8cdc-674ed614372c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c23c3678-6194-4b7e-a928-09614190eb62",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "571f80b9-3d04-43ae-a49a-2a26bdb01402", "AQAAAAEAACcQAAAAEGpAk8Pv0DBBIo9aSuqRWJ4PGC7n+/qKgRLGwmvzpSrbVly4u1nTE7OzJxnG3ymOiQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5b2211a-4ddc-4451-af5e-36b5cfad9a2c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "048c8853-75a8-44da-9568-fb4ea582d6e7", "AQAAAAEAACcQAAAAEISqbF5zcDm/ZFyrpo0Ng7zu600HAF0df98BF9tJmAweXMX0kqoh9TYSqFVkw1oFHg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca678235-7571-4177-984f-e9d1957b0187",
                column: "ConcurrencyStamp",
                value: "9892b413-be79-42ff-9d5b-b9db37d4f066");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef1c4fa2-0b76-4598-aaee-c6e02803d486",
                column: "ConcurrencyStamp",
                value: "9a8445ba-f6ab-4af4-824c-b95bf830912c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c23c3678-6194-4b7e-a928-09614190eb62",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bab7e94a-0f83-4d30-96e2-b194944db7f4", "AQAAAAEAACcQAAAAEC/JH7Ml4gry9WMO2GLYdIxqI7JwHBfR2o92dcy4u/01nUE0RL4+J0KOt1H3oveLvw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5b2211a-4ddc-4451-af5e-36b5cfad9a2c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e59a07f2-2608-473f-b851-eacd0419b962", "AQAAAAEAACcQAAAAEA82dVpkPwFlXx90Z2d0xX3g+KRWURF9Hu/6Wo8Hbs4gdriJjd0GfV+/T0uV2RF8yQ==" });
        }
    }
}
