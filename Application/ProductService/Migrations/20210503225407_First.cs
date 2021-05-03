using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductService.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<string>(type: "TEXT", nullable: true),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Color = table.Column<string>(type: "TEXT", nullable: true),
                    Size = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 0, "plum", "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Sleek Concrete Salad", "269.26", "0", 64, "small" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 72, "turquoise", "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Small Granite Salad", "999.40", "72", 80, "medium" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 71, "teal", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Tasty Fresh Fish", "532.60", "71", 71, "large" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 70, "violet", "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Tasty Wooden Mouse", "928.94", "70", 61, "large" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 69, "silver", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Fantastic Rubber Chicken", "343.16", "69", 55, "large" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 68, "red", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Ergonomic Metal Soap", "362.32", "68", 41, "medium" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 67, "ivory", "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Rustic Fresh Shoes", "648.72", "67", 54, "large" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 66, "grey", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Incredible Cotton Bacon", "486.40", "66", 28, "medium" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 65, "tan", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Practical Concrete Pizza", "561.54", "65", 100, "medium" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 64, "pink", "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Awesome Plastic Chicken", "995.85", "64", 90, "large" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 63, "indigo", "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Small Steel Shoes", "796.80", "63", 55, "large" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 62, "green", "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Incredible Cotton Car", "728.19", "62", 13, "large" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 61, "fuchsia", "The Football Is Good For Training And Recreational Purposes", "Handcrafted Rubber Towels", "585.61", "61", 13, "small" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 60, "lime", "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Generic Rubber Tuna", "658.77", "60", 56, "small" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 59, "blue", "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Practical Concrete Keyboard", "569.80", "59", 9, "large" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 58, "teal", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Incredible Steel Table", "468.98", "58", 53, "medium" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 57, "purple", "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Generic Cotton Table", "760.79", "57", 31, "small" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 56, "white", "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Refined Rubber Pizza", "150.35", "56", 92, "large" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 55, "mint green", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "Tasty Plastic Chips", "578.13", "55", 39, "medium" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 54, "violet", "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Incredible Wooden Fish", "111.97", "54", 19, "small" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 53, "orchid", "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Fantastic Frozen Towels", "455.95", "53", 54, "small" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 52, "black", "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Tasty Soft Towels", "636.55", "52", 15, "small" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 73, "olive", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Rustic Frozen Salad", "775.72", "73", 3, "medium" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 51, "red", "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Small Wooden Pants", "230.03", "51", 80, "small" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 74, "indigo", "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Sleek Soft Towels", "77.04", "74", 23, "large" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 76, "tan", "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Sleek Concrete Shoes", "234.09", "76", 42, "large" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 97, "ivory", "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Refined Steel Hat", "683.06", "97", 51, "large" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 96, "ivory", "The Football Is Good For Training And Recreational Purposes", "Rustic Cotton Cheese", "139.33", "96", 93, "medium" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 95, "ivory", "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Rustic Rubber Sausages", "603.27", "95", 14, "small" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 94, "teal", "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Tasty Wooden Towels", "465.76", "94", 39, "large" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 93, "lavender", "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Awesome Rubber Cheese", "278.45", "93", 16, "small" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 92, "olive", "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Fantastic Cotton Towels", "727.33", "92", 15, "small" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 91, "green", "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Practical Soft Mouse", "115.88", "91", 79, "large" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 90, "black", "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Handcrafted Plastic Computer", "305.67", "90", 7, "small" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 89, "pink", "The Football Is Good For Training And Recreational Purposes", "Gorgeous Frozen Table", "923.85", "89", 13, "small" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 88, "magenta", "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Rustic Rubber Gloves", "724.42", "88", 37, "large" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 87, "azure", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "Ergonomic Fresh Keyboard", "103.68", "87", 26, "medium" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 86, "plum", "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Fantastic Wooden Pizza", "743.42", "86", 3, "medium" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 85, "cyan", "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Licensed Concrete Gloves", "677.64", "85", 71, "medium" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 84, "lavender", "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Handcrafted Soft Pants", "179.47", "84", 26, "medium" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 83, "plum", "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Handcrafted Steel Fish", "317.48", "83", 51, "medium" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 82, "black", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Ergonomic Concrete Shoes", "145.38", "82", 23, "small" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 81, "turquoise", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Unbranded Concrete Keyboard", "287.07", "81", 0, "large" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 80, "salmon", "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Intelligent Steel Hat", "239.14", "80", 82, "large" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 79, "fuchsia", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Handcrafted Steel Pants", "925.14", "79", 96, "medium" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 78, "teal", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Tasty Steel Mouse", "288.51", "78", 19, "small" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 77, "sky blue", "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Ergonomic Fresh Table", "518.72", "77", 54, "small" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 75, "plum", "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Practical Soft Shirt", "821.84", "75", 46, "large" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 50, "orange", "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Licensed Soft Hat", "682.84", "50", 81, "large" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 49, "tan", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Gorgeous Wooden Tuna", "488.55", "49", 80, "large" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 48, "blue", "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Fantastic Soft Hat", "923.34", "48", 0, "medium" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 21, "white", "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Intelligent Frozen Car", "601.13", "21", 83, "medium" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 20, "gold", "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Small Cotton Bacon", "299.65", "20", 38, "small" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 19, "green", "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Intelligent Granite Chicken", "586.96", "19", 85, "medium" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 18, "teal", "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Licensed Steel Pants", "326.63", "18", 64, "large" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 17, "lime", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "Awesome Granite Car", "546.77", "17", 59, "large" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 16, "gold", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Refined Steel Bacon", "679.32", "16", 63, "medium" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 15, "pink", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Refined Fresh Hat", "348.91", "15", 37, "large" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 14, "violet", "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Gorgeous Rubber Sausages", "415.41", "14", 60, "medium" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 13, "gold", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Rustic Soft Salad", "683.94", "13", 63, "large" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 12, "sky blue", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Licensed Fresh Bike", "262.00", "12", 50, "small" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 11, "white", "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Gorgeous Metal Shoes", "317.14", "11", 64, "medium" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 10, "ivory", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Licensed Metal Shoes", "455.13", "10", 21, "small" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 9, "mint green", "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Small Granite Gloves", "12.34", "9", 62, "large" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 8, "fuchsia", "The Football Is Good For Training And Recreational Purposes", "Tasty Metal Mouse", "325.75", "8", 83, "large" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 7, "lime", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Intelligent Granite Chicken", "118.33", "7", 74, "small" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 6, "fuchsia", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Rustic Rubber Fish", "144.24", "6", 96, "small" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 5, "lavender", "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Ergonomic Plastic Cheese", "156.93", "5", 20, "large" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 4, "red", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Small Plastic Chips", "843.60", "4", 72, "large" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 3, "teal", "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Tasty Granite Salad", "966.68", "3", 64, "medium" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 2, "silver", "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Tasty Plastic Shoes", "170.13", "2", 40, "medium" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 1, "white", "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Tasty Wooden Towels", "207.41", "1", 24, "medium" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 22, "red", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "Unbranded Metal Soap", "301.23", "22", 65, "medium" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 23, "blue", "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "Ergonomic Cotton Shirt", "471.06", "23", 6, "large" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 24, "sky blue", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Intelligent Soft Soap", "65.18", "24", 92, "large" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 25, "sky blue", "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Ergonomic Fresh Shirt", "401.33", "25", 60, "medium" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 47, "lime", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Generic Metal Chips", "677.00", "47", 49, "medium" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 46, "silver", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Awesome Cotton Pizza", "908.28", "46", 83, "medium" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 45, "orchid", "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Rustic Frozen Pants", "450.09", "45", 92, "small" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 44, "yellow", "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Unbranded Concrete Towels", "203.10", "44", 98, "medium" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 43, "green", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Refined Cotton Gloves", "737.38", "43", 4, "small" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 42, "green", "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Awesome Steel Gloves", "249.62", "42", 78, "medium" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 41, "white", "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Handcrafted Concrete Mouse", "901.44", "41", 43, "small" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 40, "red", "The Football Is Good For Training And Recreational Purposes", "Sleek Fresh Pizza", "858.39", "40", 85, "large" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 39, "blue", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "Generic Frozen Salad", "131.08", "39", 45, "large" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 38, "pink", "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Practical Plastic Computer", "828.14", "38", 4, "large" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 98, "black", "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Sleek Cotton Bacon", "299.82", "98", 62, "small" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 37, "blue", "The Football Is Good For Training And Recreational Purposes", "Practical Cotton Mouse", "40.45", "37", 3, "large" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 35, "turquoise", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Licensed Steel Chicken", "853.46", "35", 77, "small" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 34, "teal", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Gorgeous Concrete Sausages", "114.09", "34", 63, "small" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 33, "salmon", "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Licensed Rubber Bike", "479.83", "33", 19, "medium" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 32, "green", "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Incredible Metal Ball", "281.77", "32", 69, "small" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 31, "green", "The Football Is Good For Training And Recreational Purposes", "Refined Metal Table", "612.55", "31", 37, "medium" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 30, "orange", "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Gorgeous Concrete Chips", "687.17", "30", 2, "small" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 29, "tan", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Practical Steel Hat", "435.53", "29", 65, "medium" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 28, "fuchsia", "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Incredible Plastic Soap", "828.23", "28", 57, "large" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 27, "olive", "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Sleek Steel Ball", "224.87", "27", 20, "large" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 26, "blue", "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Ergonomic Steel Sausages", "5.11", "26", 62, "small" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 36, "fuchsia", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Incredible Concrete Gloves", "56.76", "36", 98, "medium" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Description", "Name", "Price", "ProductId", "Quantity", "Size" },
                values: new object[] { 99, "maroon", "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Awesome Granite Chair", "114.40", "99", 72, "medium" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
