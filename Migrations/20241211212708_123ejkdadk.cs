using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class _123ejkdadk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShowTime_Movie_MovieId",
                table: "ShowTime");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShowTime",
                table: "ShowTime");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "ShowTime",
                newName: "MovieID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ShowTime",
                newName: "RoomID");

            migrationBuilder.RenameIndex(
                name: "IX_ShowTime_MovieId",
                table: "ShowTime",
                newName: "IX_ShowTime_MovieID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Movie",
                newName: "MovieId");

            migrationBuilder.AlterColumn<int>(
                name: "MovieID",
                table: "ShowTime",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RoomID",
                table: "ShowTime",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ShowTimeId",
                table: "ShowTime",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "Time",
                table: "ShowTime",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShowTime",
                table: "ShowTime",
                column: "ShowTimeId");

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Order_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductID);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    RoomID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.RoomID);
                });

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => new { x.OrderID, x.ProductID });
                    table.ForeignKey(
                        name: "FK_OrderProduct_Order_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProduct_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seat",
                columns: table => new
                {
                    SeatID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomID = table.Column<int>(type: "int", nullable: false),
                    SeatNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seat", x => x.SeatID);
                    table.ForeignKey(
                        name: "FK_Seat_Room_RoomID",
                        column: x => x.RoomID,
                        principalTable: "Room",
                        principalColumn: "RoomID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    TicketID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShowTimeID = table.Column<int>(type: "int", nullable: false),
                    SeatID = table.Column<int>(type: "int", nullable: false),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.TicketID);
                    table.ForeignKey(
                        name: "FK_Ticket_Order_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_Seat_SeatID",
                        column: x => x.SeatID,
                        principalTable: "Seat",
                        principalColumn: "SeatID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_ShowTime_ShowTimeID",
                        column: x => x.ShowTimeID,
                        principalTable: "ShowTime",
                        principalColumn: "ShowTimeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShowTime_RoomID",
                table: "ShowTime",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId",
                table: "Order",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_ProductID",
                table: "OrderProduct",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Seat_RoomID",
                table: "Seat",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_OrderID",
                table: "Ticket",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_SeatID",
                table: "Ticket",
                column: "SeatID");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_ShowTimeID",
                table: "Ticket",
                column: "ShowTimeID");

            migrationBuilder.AddForeignKey(
                name: "FK_ShowTime_Movie_MovieID",
                table: "ShowTime",
                column: "MovieID",
                principalTable: "Movie",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShowTime_Room_RoomID",
                table: "ShowTime",
                column: "RoomID",
                principalTable: "Room",
                principalColumn: "RoomID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShowTime_Movie_MovieID",
                table: "ShowTime");

            migrationBuilder.DropForeignKey(
                name: "FK_ShowTime_Room_RoomID",
                table: "ShowTime");

            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Seat");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShowTime",
                table: "ShowTime");

            migrationBuilder.DropIndex(
                name: "IX_ShowTime_RoomID",
                table: "ShowTime");

            migrationBuilder.DropColumn(
                name: "ShowTimeId",
                table: "ShowTime");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "ShowTime");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "MovieID",
                table: "ShowTime",
                newName: "MovieId");

            migrationBuilder.RenameColumn(
                name: "RoomID",
                table: "ShowTime",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_ShowTime_MovieID",
                table: "ShowTime",
                newName: "IX_ShowTime_MovieId");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "Movie",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "ShowTime",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ShowTime",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShowTime",
                table: "ShowTime",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShowTime_Movie_MovieId",
                table: "ShowTime",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id");
        }
    }
}
