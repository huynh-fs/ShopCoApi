using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopCoApi.Migrations
{
    /// <inheritdoc />
    public partial class ChangeImageProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Url",
                value: "https://cdn.pixabay.com/photo/2024/04/29/04/21/tshirt-8726716_1280.jpg");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Url",
                value: "https://tse3.mm.bing.net/th/id/OIP.XbpNO0eM9CaAjnmV16uibwHaHa?pid=ImgDet&w=203&h=203&c=7&o=7&rm=3");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "Url",
                value: "https://tse1.mm.bing.net/th/id/OIP.AT3AZiJg2Z04rkIJV0OZWAHaHa?pid=ImgDet&w=203&h=203&c=7&o=7&rm=3");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "Url",
                value: "https://th.bing.com/th/id/OIF.pWER61jZ9Co6Xr1SZGIfYg?w=203&h=254&c=7&r=0&o=7&pid=1.7&rm=3");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "Url",
                value: "https://th.bing.com/th/id/OIP.e__xPKL6FeicKbfiRqli1AHaJ4?w=148&h=198&c=7&r=0&o=7&pid=1.7&rm=3");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Url",
                value: "images/shirt_1.png");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Url",
                value: "images/shirt_2.png");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "Url",
                value: "images/shirt_3.png");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "Url",
                value: "images/new-arrival-2.png");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "Url",
                value: "images/new-arrival-3.png");
        }
    }
}
