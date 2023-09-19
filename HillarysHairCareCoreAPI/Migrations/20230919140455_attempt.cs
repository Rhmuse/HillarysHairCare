using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HillarysHairCareCoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class attempt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCanceled",
                table: "AppointmentServices",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AppointmentServices",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsCanceled",
                value: false);

            migrationBuilder.UpdateData(
                table: "AppointmentServices",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsCanceled",
                value: false);

            migrationBuilder.UpdateData(
                table: "AppointmentServices",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsCanceled",
                value: false);

            migrationBuilder.UpdateData(
                table: "AppointmentServices",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsCanceled",
                value: false);

            migrationBuilder.UpdateData(
                table: "AppointmentServices",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsCanceled",
                value: false);

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentServices_ServiceId",
                table: "AppointmentServices",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentServices_Services_ServiceId",
                table: "AppointmentServices",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentServices_Services_ServiceId",
                table: "AppointmentServices");

            migrationBuilder.DropIndex(
                name: "IX_AppointmentServices_ServiceId",
                table: "AppointmentServices");

            migrationBuilder.DropColumn(
                name: "IsCanceled",
                table: "AppointmentServices");
        }
    }
}
