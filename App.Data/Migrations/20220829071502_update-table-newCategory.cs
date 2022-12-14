using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Data.Migrations
{
    public partial class updatetablenewCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CoverImgPath",
                table: "AppCategoryNews",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 125, 0, 168, 31, 174, 189, 94, 152, 50, 233, 80, 228, 200, 0, 100, 134, 172, 171, 209, 165, 140, 91, 244, 228, 19, 93, 2, 185, 216, 225, 27, 219, 161, 87, 17, 138, 147, 223, 155, 104, 254, 217, 194, 60, 76, 143, 190, 230, 160, 141, 140, 238, 225, 93, 229, 218, 3, 210, 48, 42, 189, 70, 214, 208 }, new byte[] { 254, 120, 223, 124, 252, 71, 55, 49, 9, 104, 128, 142, 143, 139, 247, 21, 250, 86, 100, 234, 249, 190, 187, 201, 252, 59, 155, 62, 92, 200, 233, 36, 75, 73, 7, 24, 237, 220, 71, 230, 15, 200, 173, 98, 197, 55, 254, 250, 76, 248, 124, 155, 230, 48, 63, 61, 251, 189, 248, 223, 26, 127, 21, 147, 73, 107, 160, 39, 108, 74, 163, 22, 205, 131, 96, 240, 238, 30, 76, 203, 26, 98, 189, 92, 28, 61, 180, 142, 57, 126, 224, 102, 39, 138, 104, 64, 113, 120, 200, 203, 236, 12, 180, 194, 199, 54, 96, 211, 115, 157, 161, 221, 16, 165, 227, 152, 98, 31, 86, 245, 192, 107, 144, 231, 83, 249, 112, 250 } });

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 125, 0, 168, 31, 174, 189, 94, 152, 50, 233, 80, 228, 200, 0, 100, 134, 172, 171, 209, 165, 140, 91, 244, 228, 19, 93, 2, 185, 216, 225, 27, 219, 161, 87, 17, 138, 147, 223, 155, 104, 254, 217, 194, 60, 76, 143, 190, 230, 160, 141, 140, 238, 225, 93, 229, 218, 3, 210, 48, 42, 189, 70, 214, 208 }, new byte[] { 254, 120, 223, 124, 252, 71, 55, 49, 9, 104, 128, 142, 143, 139, 247, 21, 250, 86, 100, 234, 249, 190, 187, 201, 252, 59, 155, 62, 92, 200, 233, 36, 75, 73, 7, 24, 237, 220, 71, 230, 15, 200, 173, 98, 197, 55, 254, 250, 76, 248, 124, 155, 230, 48, 63, 61, 251, 189, 248, 223, 26, 127, 21, 147, 73, 107, 160, 39, 108, 74, 163, 22, 205, 131, 96, 240, 238, 30, 76, 203, 26, 98, 189, 92, 28, 61, 180, 142, 57, 126, 224, 102, 39, 138, 104, 64, 113, 120, 200, 203, 236, 12, 180, 194, 199, 54, 96, 211, 115, 157, 161, 221, 16, 165, 227, 152, 98, 31, 86, 245, 192, 107, 144, 231, 83, 249, 112, 250 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverImgPath",
                table: "AppCategoryNews");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 197, 71, 179, 71, 35, 238, 136, 21, 170, 149, 188, 144, 171, 14, 160, 110, 248, 145, 154, 134, 80, 22, 149, 112, 153, 95, 14, 140, 192, 189, 12, 242, 164, 82, 130, 142, 227, 160, 102, 48, 192, 151, 112, 197, 51, 99, 224, 98, 225, 224, 98, 104, 184, 129, 213, 71, 75, 34, 91, 159, 173, 34, 27, 218 }, new byte[] { 38, 13, 139, 129, 129, 104, 166, 220, 79, 200, 198, 8, 68, 128, 165, 98, 3, 167, 54, 108, 165, 155, 58, 76, 243, 240, 152, 139, 217, 174, 148, 45, 96, 69, 181, 87, 65, 154, 49, 149, 148, 221, 151, 10, 192, 158, 170, 26, 117, 67, 131, 210, 67, 215, 160, 196, 71, 218, 69, 59, 51, 241, 94, 191, 78, 138, 103, 63, 117, 35, 37, 4, 188, 192, 169, 148, 80, 46, 39, 205, 140, 59, 21, 28, 65, 55, 203, 139, 53, 34, 139, 56, 6, 239, 41, 34, 56, 96, 86, 64, 39, 119, 126, 107, 77, 172, 22, 168, 249, 69, 56, 40, 94, 188, 185, 86, 139, 2, 67, 52, 162, 42, 140, 42, 233, 1, 235, 186 } });

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 197, 71, 179, 71, 35, 238, 136, 21, 170, 149, 188, 144, 171, 14, 160, 110, 248, 145, 154, 134, 80, 22, 149, 112, 153, 95, 14, 140, 192, 189, 12, 242, 164, 82, 130, 142, 227, 160, 102, 48, 192, 151, 112, 197, 51, 99, 224, 98, 225, 224, 98, 104, 184, 129, 213, 71, 75, 34, 91, 159, 173, 34, 27, 218 }, new byte[] { 38, 13, 139, 129, 129, 104, 166, 220, 79, 200, 198, 8, 68, 128, 165, 98, 3, 167, 54, 108, 165, 155, 58, 76, 243, 240, 152, 139, 217, 174, 148, 45, 96, 69, 181, 87, 65, 154, 49, 149, 148, 221, 151, 10, 192, 158, 170, 26, 117, 67, 131, 210, 67, 215, 160, 196, 71, 218, 69, 59, 51, 241, 94, 191, 78, 138, 103, 63, 117, 35, 37, 4, 188, 192, 169, 148, 80, 46, 39, 205, 140, 59, 21, 28, 65, 55, 203, 139, 53, 34, 139, 56, 6, 239, 41, 34, 56, 96, 86, 64, 39, 119, 126, 107, 77, 172, 22, 168, 249, 69, 56, 40, 94, 188, 185, 86, 139, 2, 67, 52, 162, 42, 140, 42, 233, 1, 235, 186 } });
        }
    }
}
