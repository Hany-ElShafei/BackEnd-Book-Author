using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthorAndBook.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageData",
                table: "Books",
                newName: "ImageBook");

            migrationBuilder.AddColumn<string>(
                name: "ImageAuthor",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageAuthor",
                table: "Authors");

            migrationBuilder.RenameColumn(
                name: "ImageBook",
                table: "Books",
                newName: "ImageData");
        }
    }
}
