using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustBlog.Core.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    AboutMe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UrlSlug = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UrlSlug = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDescription = table.Column<string>(name: "Short Description", type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    PostContent = table.Column<string>(name: "Post Content", type: "nvarchar(max)", nullable: false),
                    UrlSlug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Published = table.Column<bool>(type: "bit", nullable: false),
                    ViewCount = table.Column<int>(type: "int", nullable: false),
                    RateCount = table.Column<int>(type: "int", nullable: false),
                    TotalRate = table.Column<int>(type: "int", nullable: false),
                    PostedOn = table.Column<DateTime>(name: "Posted On", type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    CommentHeader = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostTagMaps",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTagMaps", x => new { x.TagId, x.PostId });
                    table.ForeignKey(
                        name: "FK_PostTagMaps_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTagMaps_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("3764eb80-b651-4d6f-a2e5-c539322921a5"), "a531b543-b012-44a1-8511-3fd22f53f374", "User", "USER" },
                    { new Guid("3d59be22-6814-4fbf-9b46-99539b04222d"), "600d512e-2649-4047-889e-53882cb44beb", "Contributor", "CONTRIBUTOR" },
                    { new Guid("83b38610-00bd-4593-b663-cefbd7d260cf"), "81e9c20a-be8e-4d15-89ef-240e27c1aa02", "Blog Owner", "BLOG OWNER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AboutMe", "AccessFailedCount", "Age", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("3cd9f771-f6e6-4c55-94ec-824b86c6b95a"), "Welcome to my blogs", 0, 20, "08ccb1dd-e166-45d0-8008-a49b27d3c05f", "ngoccm@gmail.com", true, false, null, "NGOCCM@GMAIL.COM", "NGOCCM@GMAIL.COM", "AQAAAAEAACcQAAAAEBmRa41UFlzSxs2lusvWD3kmGA7QSqk3Xy+B+kjqtAtejSs4Ewr8rPu8raqajUHg7A==", null, false, "f955c3b6-86d9-47a2-8994-ad91cafa91a8", false, "ngoccm@gmail.com" },
                    { new Guid("3fb38b96-29ec-4ccf-a988-8f85c55460f7"), "Welcome to my blogs", 0, 20, "4e47ca1b-d1fa-4867-9021-38a47cdceeec", "ngoccm2@gmail.com", true, false, null, "NGOCCM2@GMAIL.COM", "NGOCCM2@GMAIL.COM", "AQAAAAEAACcQAAAAEJLp/M7pdTcPK9cpI2+h6LmYVNkZBCyXNf5k7KhLGWuL4Rr6ok6Or5EmJpDphonTJg==", null, false, "44a3a7da-cf70-4165-9120-1fe2bec964c4", false, "ngoccm2@gmail.com" },
                    { new Guid("bc73dbef-1bf7-4c2f-9077-3d991b9dcb56"), "Welcome to my blogs", 0, 20, "b044f4a1-149e-44e4-a247-bff3751c18dc", "ngoccm1@gmail.com", true, false, null, "NGOCCM1@GMAIL.COM", "NGOCCM1@GMAIL.COM", "AQAAAAEAACcQAAAAEFjk9pA3/yvOdmNK316awB/D4kw8Mgs7Wz079M7wjtJyI/FcBYtfY0Pov8pbH5qZjQ==", null, false, "19a81c7a-6ac6-4235-9d08-7a4c72ea0b77", false, "ngoccm1@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "UrlSlug" },
                values: new object[,]
                {
                    { 1, "The latest news and updates on technology", "Technology", "technology" },
                    { 2, "All about sports from around the world", "Sports", "sports" },
                    { 3, "Movies, TV shows, music, and more", "Entertainment", "entertainment" },
                    { 4, "Discover new destinations and plan your next trip", "Travel", "travel" },
                    { 5, "Delicious recipes and restaurant recommendations", "Food", "food" },
                    { 6, "Tips and tricks for a healthy lifestyle", "Health and Fitness", "health-and-fitness" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Count", "Description", "Name", "UrlSlug" },
                values: new object[,]
                {
                    { 1, 50, "All about the latest tech news and gadgets", "Technology", "technology" },
                    { 2, 30, "Tips and tricks on how to live life to the fullest", "Lifestyle", "lifestyle" },
                    { 3, 20, "Mouth-watering recipes and food reviews", "Food", "food" },
                    { 4, 25, "The latest trends in the world of fashion", "Fashion", "fashion" },
                    { 5, 40, "Amazing destinations and travel guides", "Travel", "travel" },
                    { 6, 15, "Informational articles on mental and physical wellbeing", "Health", "health" },
                    { 7, 19, "Strategies for advancing your career and achieving your goals", "Career Development", "career-development" },
                    { 8, 27, "Ideas and inspiration for decorating your home", "Home Decor", "home-decor" },
                    { 9, 11, "Insights and research on human behavior and mental processes", "Psychology", "psychology" },
                    { 10, 16, "Exploring the cultural significance of food and cuisine", "Food Culture", "food-culture" },
                    { 11, 13, "Motivation and inspiration for staying fit and active", "Fitness Inspiration", "fitness-inspiration" },
                    { 12, 28, "Coverage of the latest sports news and events", "Sports News", "sports-news" },
                    { 13, 21, "Exploring the art and science of cooking and gastronomy", "Culinary Arts", "culinary-arts" },
                    { 14, 16, "Insights and strategies for leveraging digital channels to reach customers", "Digital Marketing", "digital-marketing" },
                    { 15, 19, "Practical advice for building healthy and fulfilling relationships", "Relationship Advice", "relationship-advice" },
                    { 16, 12, "Tips and recommendations for outdoor activities and exploration", "Outdoor Adventures", "outdoor-adventures" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("83b38610-00bd-4593-b663-cefbd7d260cf"), new Guid("3cd9f771-f6e6-4c55-94ec-824b86c6b95a") },
                    { new Guid("3764eb80-b651-4d6f-a2e5-c539322921a5"), new Guid("3fb38b96-29ec-4ccf-a988-8f85c55460f7") },
                    { new Guid("3d59be22-6814-4fbf-9b46-99539b04222d"), new Guid("bc73dbef-1bf7-4c2f-9077-3d991b9dcb56") }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoryId", "Modified", "Post Content", "Posted On", "Published", "RateCount", "Short Description", "Title", "TotalRate", "UrlSlug", "ViewCount" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "A lot of people think that having a smart home means having to spend thousands of dollars on fancy equipment. But that's not the case at all! There are plenty of affordable and easy-to-use gadgets out there that can help you make your home smarter, without breaking the bank.", new DateTime(2018, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 22631, "Discover the latest smart home gadgets that you need!", "Top 10 Gadgets to Make Your Home Smarter", 67723, "top-10-gadgets-to-make-your-home-smarter", 3142 },
                    { 2, 2, new DateTime(2020, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Are you tired of looking at the same old boring walls in your room? It's time to spruce things up and add some personality to your space. Here are 10 easy ways to decorate your room that won't cost you an arm and a leg!", new DateTime(2019, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 36841, "Get inspiration for your next DIY project!", "10 Easy Ways to Decorate Your Room", 83123, "10-easy-ways-to-decorate-your-room", 42203 },
                    { 3, 3, new DateTime(2021, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "There's nothing quite like a perfectly cooked steak. Juicy, tender, and full of flavor… it's no wonder that steak is one of the most beloved foods out there. But cooking a steak to perfection isn't always easy. Here are some tips and tricks to help you cook the perfect steak every time!", new DateTime(2016, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 54068, "Learn the art of cooking steak like a pro!", "How to Cook a Perfect Steak", 236421, "how-to-cook-a-perfect-steak", 65173 },
                    { 4, 4, new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "If you're a fashionista, you know it's important to stay on top of the latest trends. And with a new year comes a whole new set of fashion trends to try out! From bold colors to oversized accessories, here are the fashion trends you need to follow in 2021.", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 65381, "Get ready to update your wardrobe!", "Fashion Trends You Need to Follow in 2021", 214823, "fashion-trends-you-need-to-follow-in-2021", 76437 },
                    { 5, 5, new DateTime(2021, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Europe is home to some of the most stunning and iconic destinations in the world. Whether you're looking for vibrant cities, breathtaking landscapes, or rich cultural experiences, Europe has it all. Here are 10 amazing places in Europe that you won't want to miss!", new DateTime(2017, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 10631, "Get your passport ready!", "10 Amazing Places to Visit in Europe", 42389, "10-amazing-places-to-visit-in-europe", 23142 },
                    { 6, 6, new DateTime(2020, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "In today's fast-paced and stressful world, it's more important than ever to take care of your mental health. Fortunately, there are plenty of simple things that you can do to reduce stress and improve your mental wellbeing. Here are some tips to get you started!", new DateTime(2018, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 64234, "Take care of your mental health!", "Mental Health Tips for a Stress-Free Life", 116196, "mental-health-tips-for-a-stress-free-life", 87631 },
                    { 7, 1, new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Do you love coffee but can't seem to make a good cup at home? Don't worry, you're not alone. Making the perfect cup of coffee is an art, and it takes time and practice to get it just right. But with these tips, you'll be well on your way to becoming a coffee expert!", new DateTime(2019, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 54172, "Become a barista in your own home!", "How to Make the Perfect Cup of Coffee", 195701, "how-to-make-the-perfect-cup-of-coffee", 76853 },
                    { 8, 2, new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Learning a new language is not just about being able to communicate with people from different countries, it's also about opening up new doors of opportunity in your personal and professional life. Whether you want to travel, work abroad or simply broaden your mind, knowing more than one language can be incredibly useful. Research has shown that bilingualism can improve cognitive abilities such as problem-solving and decision-making. So, what are you waiting for? Start learning a new language today!", new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 30230, "In today's globalized world, learning a new language can unlock many opportunities.", "Why You Should Learn a New Language", 148341, "why-you-should-learn-a-new-language", 55230 },
                    { 9, 6, new DateTime(2019, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Regular exercise has been shown to have numerous benefits for both physical and mental health. It can help you maintain a healthy weight, reduce your risk of chronic diseases such as diabetes and heart disease, and improve your overall mood and wellbeing. Studies have also suggested that exercise can boost cognitive function and reduce the risk of age-related cognitive decline. So, whether you prefer jogging, cycling, swimming or yoga, make sure to incorporate regular exercise into your daily routine!", new DateTime(2019, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 84124, "Exercising regularly can have a positive impact on both physical and mental health.", "The Benefits of Regular Exercise", 374049, "the-benefits-of-regular-exercise", 74263 },
                    { 10, 6, new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mindfulness meditation is a simple but powerful technique that involves focusing your attention on the present moment, without judgment. It has been shown to have numerous benefits for mental and physical health, including reducing stress, anxiety, and depression, improving sleep quality, and enhancing immune function. To start practicing mindfulness meditation, find a quiet place where you can sit comfortably, close your eyes, and focus on your breath. If your mind starts to wander, gently bring your attention back to your breath. With regular practice, mindfulness meditation can help you cultivate a greater sense of calm and clarity in your daily life.", new DateTime(2023, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 51426, "Practicing mindfulness meditation can help reduce stress and improve overall wellbeing.", "The Power of Mindfulness Meditation", 181574, "the-power-of-mindfulness-meditation", 68230 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentHeader", "CommentText", "CommentTime", "Email", "Name", "PostId" },
                values: new object[,]
                {
                    { 1, "Great post!", "Thanks for the informative article.", new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@gmail.com", "John Doe", 4 },
                    { 2, "Interesting read", "I learned a lot from this post.", new DateTime(2022, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@gmail.com", "Jane Smith", 3 },
                    { 3, "Helpful tips", "This post was very useful.", new DateTime(2022, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "bob.johnson@gmail.com", "Bob Johnson", 3 },
                    { 4, "Well written", "I enjoyed reading this post.", new DateTime(2022, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "sarah.lee@gmail.com", "Sarah Lee", 7 },
                    { 5, "Insightful", "This post gave me a new perspective.", new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "michael.chen@gmail.com", "Michael Chen", 5 },
                    { 6, "Good job", "Keep up the great work!", new DateTime(2021, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "grace.kim@gmail.com", "Grace Kim", 1 },
                    { 7, "Impressive", "I'm amazed by the quality of this post.", new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "david.wu@gmail.com", "David Wu", 5 },
                    { 8, "Thank you", "Your post helped me solve a problem.", new DateTime(2022, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "emily.park@gmail.com", "Emily Park", 2 },
                    { 9, "Informative", "I learned something new from this post.", new DateTime(2021, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "alex.nguyen@gmail.com", "Alex Nguyen", 2 },
                    { 10, "Well done", "This post was well researched and written.", new DateTime(2022, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "lisa.wang@gmail.com", "Lisa Wang", 6 }
                });

            migrationBuilder.InsertData(
                table: "PostTagMaps",
                columns: new[] { "PostId", "TagId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 4, 1 },
                    { 6, 1 },
                    { 10, 1 },
                    { 3, 2 },
                    { 5, 2 },
                    { 8, 2 },
                    { 10, 2 },
                    { 2, 3 },
                    { 5, 3 },
                    { 7, 3 },
                    { 1, 4 },
                    { 4, 4 },
                    { 6, 4 },
                    { 7, 4 },
                    { 8, 4 },
                    { 1, 5 },
                    { 3, 5 },
                    { 5, 5 },
                    { 9, 5 },
                    { 10, 5 },
                    { 2, 6 },
                    { 6, 6 },
                    { 9, 6 },
                    { 9, 10 },
                    { 3, 12 },
                    { 1, 13 },
                    { 2, 15 },
                    { 6, 16 },
                    { 7, 16 },
                    { 8, 16 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTagMaps_PostId",
                table: "PostTagMaps",
                column: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "PostTagMaps");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
