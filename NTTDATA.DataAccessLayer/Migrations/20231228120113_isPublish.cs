using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NTTBlog.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class isPublish : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("48a8234e-c5ce-4921-afb8-ddf8acf24b25"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("5923f071-c664-48f6-aa2a-5cf46530a048"));

            migrationBuilder.AlterColumn<bool>(
                name: "IsPublish",
                table: "Articles",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsPublish", "ModifiedBy", "ModifiedDate", "Tags", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("49de7c7d-93ad-4fc4-b137-719431cfdb9a"), new Guid("9b1056f6-6171-49a5-9baa-d22c489289b6"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.", "adminTest", new DateTime(2023, 12, 28, 15, 1, 13, 662, DateTimeKind.Local).AddTicks(7537), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1465691c-3690-40b6-9fab-99a388205514"), true, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "deneme", "Data Base Deneme", new Guid("538fab7b-024b-458a-bb52-b2520f3bcc49"), 13 },
                    { new Guid("eef0c837-9b8d-4374-932a-3c62fdfd1994"), new Guid("e90e9e24-83d4-4b50-ae2c-d3187abf3d26"), " Deneme There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.", "adminTest", new DateTime(2023, 12, 28, 15, 1, 13, 662, DateTimeKind.Local).AddTicks(7547), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e37a4a99-7458-4089-a6de-d5dbf52c95cd"), true, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "deneme2", "Data Base Deneme 2", new Guid("0a3adee6-2f0d-42b7-83d3-22f95f64ccab"), 7 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("40dd91bf-4fc6-415e-9f9a-eceb1b3943fc"),
                column: "ConcurrencyStamp",
                value: "67d1bc2d-1a80-4e5b-bb03-bd289036a0a8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("87b47b4d-98ae-4767-b1fa-d39d2bd0e800"),
                column: "ConcurrencyStamp",
                value: "b9a16c6f-9c68-4cc4-b18f-00a3efda9942");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cc17cf5b-4ac8-4720-9046-28b0dd47f2de"),
                column: "ConcurrencyStamp",
                value: "bbe0ed6e-522a-43fb-a793-b04b248933c1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0a3adee6-2f0d-42b7-83d3-22f95f64ccab"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "53f68318-6a79-4a1d-91fa-01fe4a8b4f54", "AQAAAAIAAYagAAAAEJRemy0rxrDnXHuxIqTMXeAUzS2iXfq65OLLy/BT4SHLnlIw9pxvRC0CtAu1dlUp0g==", "a700b545-1df7-4d61-98e6-390039494203" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("538fab7b-024b-458a-bb52-b2520f3bcc49"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9d794e76-1467-4dd6-9436-ff14c6312aa0", "AQAAAAIAAYagAAAAEMpjrSkKneQ7eIWTXwpnFW73dO4bwXE9GG6svC/nnYSeHrjaNVBnPmzIzXaLt2rF1w==", "92812dbf-540c-4a07-99a9-d1edbdc7bff0" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9b1056f6-6171-49a5-9baa-d22c489289b6"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 28, 15, 1, 13, 662, DateTimeKind.Local).AddTicks(8082));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e90e9e24-83d4-4b50-ae2c-d3187abf3d26"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 28, 15, 1, 13, 662, DateTimeKind.Local).AddTicks(8084));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("1465691c-3690-40b6-9fab-99a388205514"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 28, 15, 1, 13, 662, DateTimeKind.Local).AddTicks(6924));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("e37a4a99-7458-4089-a6de-d5dbf52c95cd"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 28, 15, 1, 13, 662, DateTimeKind.Local).AddTicks(6927));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("49de7c7d-93ad-4fc4-b137-719431cfdb9a"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("eef0c837-9b8d-4374-932a-3c62fdfd1994"));

            migrationBuilder.AlterColumn<bool>(
                name: "IsPublish",
                table: "Articles",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsPublish", "ModifiedBy", "ModifiedDate", "Tags", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("48a8234e-c5ce-4921-afb8-ddf8acf24b25"), new Guid("9b1056f6-6171-49a5-9baa-d22c489289b6"), "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.", "adminTest", new DateTime(2023, 12, 27, 16, 32, 26, 425, DateTimeKind.Local).AddTicks(4784), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1465691c-3690-40b6-9fab-99a388205514"), true, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "deneme", "Data Base Deneme", new Guid("538fab7b-024b-458a-bb52-b2520f3bcc49"), 13 },
                    { new Guid("5923f071-c664-48f6-aa2a-5cf46530a048"), new Guid("e90e9e24-83d4-4b50-ae2c-d3187abf3d26"), " Deneme There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.", "adminTest", new DateTime(2023, 12, 27, 16, 32, 26, 425, DateTimeKind.Local).AddTicks(4790), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e37a4a99-7458-4089-a6de-d5dbf52c95cd"), true, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "deneme2", "Data Base Deneme 2", new Guid("0a3adee6-2f0d-42b7-83d3-22f95f64ccab"), 7 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("40dd91bf-4fc6-415e-9f9a-eceb1b3943fc"),
                column: "ConcurrencyStamp",
                value: "b0ae5a2c-2954-4071-8296-589fd218d656");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("87b47b4d-98ae-4767-b1fa-d39d2bd0e800"),
                column: "ConcurrencyStamp",
                value: "05c252bd-b4b7-4d00-8725-41f6143ed10e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cc17cf5b-4ac8-4720-9046-28b0dd47f2de"),
                column: "ConcurrencyStamp",
                value: "f0d96548-d3eb-4342-9755-f9e488083e5e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0a3adee6-2f0d-42b7-83d3-22f95f64ccab"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d8c372d3-a2ea-4db1-9ede-91660f53c4d3", "AQAAAAIAAYagAAAAEG/tOUENtEnB7OClOcq4pjdskQ8/8E5BLKFCVgS6O+VPAtOSpqhZCtXcEJtAAAMslA==", "67088c49-c092-487d-a82a-2be9130f1a8c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("538fab7b-024b-458a-bb52-b2520f3bcc49"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "08ee239b-e95e-4d88-b65c-e1b5e98c8e01", "AQAAAAIAAYagAAAAECpHI8stLTv2tp/SSIbGmtO0xRTJ3mfpNDgA3Y6M6CvkOO+SZmVj1lUTiUvz6Ytm0w==", "0d053b55-1373-413a-9ba8-2b28162e2802" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9b1056f6-6171-49a5-9baa-d22c489289b6"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 27, 16, 32, 26, 425, DateTimeKind.Local).AddTicks(5378));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e90e9e24-83d4-4b50-ae2c-d3187abf3d26"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 27, 16, 32, 26, 425, DateTimeKind.Local).AddTicks(5380));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("1465691c-3690-40b6-9fab-99a388205514"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 27, 16, 32, 26, 425, DateTimeKind.Local).AddTicks(4039));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("e37a4a99-7458-4089-a6de-d5dbf52c95cd"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 27, 16, 32, 26, 425, DateTimeKind.Local).AddTicks(4042));
        }
    }
}
