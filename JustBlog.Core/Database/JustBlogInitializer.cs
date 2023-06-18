using JustBlog.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JustBlog.Core.Database
{
    public static class JustBlogInitializer
    {
        public static void Seed(this ModelBuilder builder)
        {
            {
                builder.Entity<Category>().HasData(
                    new Category { Id = 1, Name = "Technology", UrlSlug = "technology", Description = "The latest news and updates on technology" },
                    new Category { Id = 2, Name = "Sports", UrlSlug = "sports", Description = "All about sports from around the world" },
                    new Category { Id = 3, Name = "Entertainment", UrlSlug = "entertainment", Description = "Movies, TV shows, music, and more" },
                    new Category { Id = 4, Name = "Travel", UrlSlug = "travel", Description = "Discover new destinations and plan your next trip" },
                    new Category { Id = 5, Name = "Food", UrlSlug = "food", Description = "Delicious recipes and restaurant recommendations" },
                    new Category { Id = 6, Name = "Health and Fitness", UrlSlug = "health-and-fitness", Description = "Tips and tricks for a healthy lifestyle" }
                );

                builder.Entity<Tag>().HasData(
                    new Tag { Id = 1, Name = "Technology", UrlSlug = "technology", Description = "All about the latest tech news and gadgets", Count = 50 },
                    new Tag { Id = 2, Name = "Lifestyle", UrlSlug = "lifestyle", Description = "Tips and tricks on how to live life to the fullest", Count = 30 },
                    new Tag { Id = 3, Name = "Food", UrlSlug = "food", Description = "Mouth-watering recipes and food reviews", Count = 20 },
                    new Tag { Id = 4, Name = "Fashion", UrlSlug = "fashion", Description = "The latest trends in the world of fashion", Count = 25 },
                    new Tag { Id = 5, Name = "Travel", UrlSlug = "travel", Description = "Amazing destinations and travel guides", Count = 40 },
                    new Tag { Id = 6, Name = "Health", UrlSlug = "health", Description = "Informational articles on mental and physical wellbeing", Count = 15 },
                    new Tag { Id = 7, Name = "Career Development", UrlSlug = "career-development", Description = "Strategies for advancing your career and achieving your goals", Count = 19 },
                    new Tag { Id = 8, Name = "Home Decor", UrlSlug = "home-decor", Description = "Ideas and inspiration for decorating your home", Count = 27 },
                    new Tag { Id = 9, Name = "Psychology", UrlSlug = "psychology", Description = "Insights and research on human behavior and mental processes", Count = 11 },
                    new Tag { Id = 10, Name = "Food Culture", UrlSlug = "food-culture", Description = "Exploring the cultural significance of food and cuisine", Count = 16 },
                    new Tag { Id = 11, Name = "Fitness Inspiration", UrlSlug = "fitness-inspiration", Description = "Motivation and inspiration for staying fit and active", Count = 13 },
                    new Tag { Id = 12, Name = "Sports News", UrlSlug = "sports-news", Description = "Coverage of the latest sports news and events", Count = 28 },
                    new Tag { Id = 13, Name = "Culinary Arts", UrlSlug = "culinary-arts", Description = "Exploring the art and science of cooking and gastronomy", Count = 21 },
                    new Tag { Id = 14, Name = "Digital Marketing", UrlSlug = "digital-marketing", Description = "Insights and strategies for leveraging digital channels to reach customers", Count = 16 },
                    new Tag { Id = 15, Name = "Relationship Advice", UrlSlug = "relationship-advice", Description = "Practical advice for building healthy and fulfilling relationships", Count = 19 },
                    new Tag { Id = 16, Name = "Outdoor Adventures", UrlSlug = "outdoor-adventures", Description = "Tips and recommendations for outdoor activities and exploration", Count = 12 }
                    );

                builder.Entity<Post>().HasData(
                    new Post
                    {
                        Id = 1,
                        Title = "Top 10 Gadgets to Make Your Home Smarter",
                        ShortDescription = "Discover the latest smart home gadgets that you need!",
                        PostContent = "A lot of people think that having a smart home means having to spend thousands of dollars on fancy equipment. But that's not the case at all! There are plenty of affordable and easy-to-use gadgets out there that can help you make your home smarter, without breaking the bank.",
                        UrlSlug = "top-10-gadgets-to-make-your-home-smarter",
                        Published = true,
                        PostedOn = new DateTime(2018, 5, 4),
                        Modified = new DateTime(2020, 3, 15),
                        CategoryId = 1,
                        ViewCount = 3142,
                        RateCount = 22631,
                        TotalRate = 67723,
                    },
                    new Post
                    {
                        Id = 2,
                        Title = "10 Easy Ways to Decorate Your Room",
                        ShortDescription = "Get inspiration for your next DIY project!",
                        PostContent = "Are you tired of looking at the same old boring walls in your room? It's time to spruce things up and add some personality to your space. Here are 10 easy ways to decorate your room that won't cost you an arm and a leg!",
                        UrlSlug = "10-easy-ways-to-decorate-your-room",
                        Published = true,
                        PostedOn = new DateTime(2019, 11, 21),
                        Modified = new DateTime(2020, 2, 20),
                        CategoryId = 2,
                        ViewCount = 42203,
                        RateCount = 36841,
                        TotalRate = 83123,
                    },
                    new Post
                    {
                        Id = 3,
                        Title = "How to Cook a Perfect Steak",
                        ShortDescription = "Learn the art of cooking steak like a pro!",
                        PostContent = "There's nothing quite like a perfectly cooked steak. Juicy, tender, and full of flavor… it's no wonder that steak is one of the most beloved foods out there. But cooking a steak to perfection isn't always easy. Here are some tips and tricks to help you cook the perfect steak every time!",
                        UrlSlug = "how-to-cook-a-perfect-steak",
                        Published = true,
                        PostedOn = new DateTime(2016, 8, 10),
                        Modified = new DateTime(2021, 4, 1),
                        CategoryId = 3,
                        ViewCount = 65173,
                        RateCount = 54068,
                        TotalRate = 236421
                    },
                    new Post
                    {
                        Id = 4,
                        Title = "Fashion Trends You Need to Follow in 2021",
                        ShortDescription = "Get ready to update your wardrobe!",
                        PostContent = "If you're a fashionista, you know it's important to stay on top of the latest trends. And with a new year comes a whole new set of fashion trends to try out! From bold colors to oversized accessories, here are the fashion trends you need to follow in 2021.",
                        UrlSlug = "fashion-trends-you-need-to-follow-in-2021",
                        Published = false,
                        PostedOn = new DateTime(2021, 1, 1),
                        Modified = new DateTime(2021, 5, 5),
                        CategoryId = 4,
                        ViewCount = 76437,
                        RateCount = 65381,
                        TotalRate = 214823
                    },
                    new Post
                    {
                        Id = 5,
                        Title = "10 Amazing Places to Visit in Europe",
                        ShortDescription = "Get your passport ready!",
                        PostContent = "Europe is home to some of the most stunning and iconic destinations in the world. Whether you're looking for vibrant cities, breathtaking landscapes, or rich cultural experiences, Europe has it all. Here are 10 amazing places in Europe that you won't want to miss!",
                        UrlSlug = "10-amazing-places-to-visit-in-europe",
                        Published = true,
                        PostedOn = new DateTime(2017, 6, 12),
                        Modified = new DateTime(2021, 3, 3),
                        CategoryId = 5,
                        ViewCount = 23142,
                        RateCount = 10631,
                        TotalRate = 42389
                    },
                    new Post
                    {
                        Id = 6,
                        Title = "Mental Health Tips for a Stress-Free Life",
                        ShortDescription = "Take care of your mental health!",
                        PostContent = "In today's fast-paced and stressful world, it's more important than ever to take care of your mental health. Fortunately, there are plenty of simple things that you can do to reduce stress and improve your mental wellbeing. Here are some tips to get you started!",
                        UrlSlug = "mental-health-tips-for-a-stress-free-life",
                        Published = true,
                        PostedOn = new DateTime(2018, 3, 30),
                        Modified = new DateTime(2020, 11, 11),
                        CategoryId = 6,
                        ViewCount = 87631,
                        RateCount = 64234,
                        TotalRate = 116196
                    },
                    new Post
                    {
                        Id = 7,
                        Title = "How to Make the Perfect Cup of Coffee",
                        ShortDescription = "Become a barista in your own home!",
                        PostContent = "Do you love coffee but can't seem to make a good cup at home? Don't worry, you're not alone. Making the perfect cup of coffee is an art, and it takes time and practice to get it just right. But with these tips, you'll be well on your way to becoming a coffee expert!",
                        UrlSlug = "how-to-make-the-perfect-cup-of-coffee",
                        Published = false,
                        PostedOn = new DateTime(2019, 5, 15),
                        Modified = new DateTime(2021, 2, 2),
                        CategoryId = 1,
                        ViewCount = 76853,
                        RateCount = 54172,
                        TotalRate = 195701
                    },
                    new Post
                    {
                        Id = 8,
                        Title = "Why You Should Learn a New Language",
                        ShortDescription = "In today's globalized world, learning a new language can unlock many opportunities.",
                        PostContent = "Learning a new language is not just about being able to communicate with people from different countries, it's also about opening up new doors of opportunity in your personal and professional life. Whether you want to travel, work abroad or simply broaden your mind, knowing more than one language can be incredibly useful. Research has shown that bilingualism can improve cognitive abilities such as problem-solving and decision-making. So, what are you waiting for? Start learning a new language today!",
                        UrlSlug = "why-you-should-learn-a-new-language",
                        Published = true,
                        PostedOn = new DateTime(2021, 10, 21),
                        Modified = new DateTime(2022, 3, 4),
                        ViewCount = 55230,
                        RateCount = 30230,
                        TotalRate = 148341,
                        CategoryId = 2
                    },
                    new Post
                    {
                        Id = 9,
                        Title = "The Benefits of Regular Exercise",
                        ShortDescription = "Exercising regularly can have a positive impact on both physical and mental health.",
                        PostContent = "Regular exercise has been shown to have numerous benefits for both physical and mental health. It can help you maintain a healthy weight, reduce your risk of chronic diseases such as diabetes and heart disease, and improve your overall mood and wellbeing. Studies have also suggested that exercise can boost cognitive function and reduce the risk of age-related cognitive decline. So, whether you prefer jogging, cycling, swimming or yoga, make sure to incorporate regular exercise into your daily routine!",
                        UrlSlug = "the-benefits-of-regular-exercise",
                        Published = true,
                        PostedOn = new DateTime(2019, 12, 5),
                        Modified = new DateTime(2019, 12, 6),
                        ViewCount = 74263,
                        RateCount = 84124,
                        TotalRate = 374049,
                        CategoryId = 6
                    },
                    new Post
                    {
                        Id = 10,
                        Title = "The Power of Mindfulness Meditation",
                        ShortDescription = "Practicing mindfulness meditation can help reduce stress and improve overall wellbeing.",
                        PostContent = "Mindfulness meditation is a simple but powerful technique that involves focusing your attention on the present moment, without judgment. It has been shown to have numerous benefits for mental and physical health, including reducing stress, anxiety, and depression, improving sleep quality, and enhancing immune function. To start practicing mindfulness meditation, find a quiet place where you can sit comfortably, close your eyes, and focus on your breath. If your mind starts to wander, gently bring your attention back to your breath. With regular practice, mindfulness meditation can help you cultivate a greater sense of calm and clarity in your daily life.",
                        UrlSlug = "the-power-of-mindfulness-meditation",
                        Published = true,
                        PostedOn = new DateTime(2023, 2, 3),
                        Modified = new DateTime(2023, 2, 5),
                        ViewCount = 68230,
                        RateCount = 51426,
                        TotalRate = 181574,
                        CategoryId = 6
                    }
                );

                builder.Entity<PostTagMap>().HasData(
                    new PostTagMap
                    {
                        PostId = 1,
                        TagId = 1,
                    },
                    new PostTagMap
                    {
                        PostId = 1,
                        TagId = 4,
                    },
                    new PostTagMap
                    {
                        PostId = 1,
                        TagId = 5,
                    },
                    new PostTagMap
                    {
                        PostId = 2,
                        TagId = 3,
                    },
                    new PostTagMap
                    {
                        PostId = 2,
                        TagId = 6,
                    },
                    new PostTagMap
                    {
                        PostId = 3,
                        TagId = 2,
                    },
                    new PostTagMap
                    {
                        PostId = 3,
                        TagId = 5,
                    },
                    new PostTagMap
                    {
                        PostId = 4,
                        TagId = 1,
                    },
                    new PostTagMap
                    {
                        PostId = 4,
                        TagId = 4,
                    },
                    new PostTagMap
                    {
                        PostId = 5,
                        TagId = 2,
                    },
                    new PostTagMap
                    {
                        PostId = 5,
                        TagId = 3,
                    },
                    new PostTagMap
                    {
                        PostId = 5,
                        TagId = 5,
                    },
                    new PostTagMap
                    {
                        PostId = 6,
                        TagId = 1,
                    },
                    new PostTagMap
                    {
                        PostId = 6,
                        TagId = 4,
                    },
                    new PostTagMap
                    {
                        PostId = 6,
                        TagId = 6,
                    },
                    new PostTagMap
                    {
                        PostId = 7,
                        TagId = 3,
                    },
                    new PostTagMap
                    {
                        PostId = 7,
                        TagId = 4,
                    },
                    new PostTagMap
                    {
                        PostId = 8,
                        TagId = 2,
                    },
                    new PostTagMap
                    {
                        PostId = 8,
                        TagId = 4,
                    },
                    new PostTagMap
                    {
                        PostId = 9,
                        TagId = 5,
                    },
                    new PostTagMap
                    {
                        PostId = 9,
                        TagId = 6,
                    },
                    new PostTagMap
                    {
                        PostId = 10,
                        TagId = 1,
                    },
                    new PostTagMap
                    {
                        PostId = 10,
                        TagId = 2,
                    },
                    new PostTagMap
                    {
                        PostId = 10,
                        TagId = 5,
                    },
                    new PostTagMap
                    {
                        PostId = 1,
                        TagId = 13,
                    },
                    new PostTagMap
                    {
                        PostId = 2,
                        TagId = 15,
                    },
                    new PostTagMap
                    {
                        PostId = 3,
                        TagId = 12,
                    },
                    new PostTagMap
                    {
                        PostId = 7,
                        TagId = 16,
                    },
                    new PostTagMap
                    {
                        PostId = 8,
                        TagId = 16,
                    },
                    new PostTagMap
                    {
                        PostId = 9,
                        TagId = 10,
                    },
                    new PostTagMap
                    {
                        PostId = 6,
                        TagId = 16,
                    }
                );

                builder.Entity<Comment>().HasData(
                    new Comment()
                    {
                        Id = 1,
                        Name = "John Doe",
                        Email = "john.doe@gmail.com",
                        CommentHeader = "Great post!",
                        CommentText = "Thanks for the informative article.",
                        CommentTime = new DateTime(2022, 10, 1),
                        PostId = 4
                    },
                    new Comment()
                    {
                        Id = 2,
                        Name = "Jane Smith",
                        Email = "jane.smith@gmail.com",
                        CommentHeader = "Interesting read",
                        CommentText = "I learned a lot from this post.",
                        CommentTime = new DateTime(2022, 8, 6),
                        PostId = 3
                    },
                    new Comment()
                    {
                        Id = 3,
                        Name = "Bob Johnson",
                        Email = "bob.johnson@gmail.com",
                        CommentHeader = "Helpful tips",
                        CommentText = "This post was very useful.",
                        CommentTime = new DateTime(2022, 7, 3),
                        PostId = 3
                    },
                    new Comment()
                    {
                        Id = 4,
                        Name = "Sarah Lee",
                        Email = "sarah.lee@gmail.com",
                        CommentHeader = "Well written",
                        CommentText = "I enjoyed reading this post.",
                        CommentTime = new DateTime(2022, 10, 4),
                        PostId = 7
                    },
                    new Comment()
                    {
                        Id = 5,
                        Name = "Michael Chen",
                        Email = "michael.chen@gmail.com",
                        CommentHeader = "Insightful",
                        CommentText = "This post gave me a new perspective.",
                        CommentTime = new DateTime(2022, 12, 15),
                        PostId = 5
                    },
                    new Comment()
                    {
                        Id = 6,
                        Name = "Grace Kim",
                        Email = "grace.kim@gmail.com",
                        CommentHeader = "Good job",
                        CommentText = "Keep up the great work!",
                        CommentTime = new DateTime(2021, 9, 30),
                        PostId = 1
                    },
                    new Comment()
                    {
                        Id = 7,
                        Name = "David Wu",
                        Email = "david.wu@gmail.com",
                        CommentHeader = "Impressive",
                        CommentText = "I'm amazed by the quality of this post.",
                        CommentTime = new DateTime(2022, 8, 17),
                        PostId = 5
                    },
                    new Comment()
                    {
                        Id = 8,
                        Name = "Emily Park",
                        Email = "emily.park@gmail.com",
                        CommentHeader = "Thank you",
                        CommentText = "Your post helped me solve a problem.",
                        CommentTime = new DateTime(2022, 11, 8),
                        PostId = 2
                    },
                    new Comment()
                    {
                        Id = 9,
                        Name = "Alex Nguyen",
                        Email = "alex.nguyen@gmail.com",
                        CommentHeader = "Informative",
                        CommentText = "I learned something new from this post.",
                        CommentTime = new DateTime(2021, 6, 19),
                        PostId = 2
                    },
                    new Comment()
                    {
                        Id = 10,
                        Name = "Lisa Wang",
                        Email = "lisa.wang@gmail.com",
                        CommentHeader = "Well done",
                        CommentText = "This post was well researched and written.",
                        CommentTime = new DateTime(2022, 11, 12),
                        PostId = 6
                    }
                );


                var roles = new IdentityRole<Guid>[]
                {
                    new IdentityRole<Guid>
                    {
                        Id = Guid.NewGuid(),
                        Name = "Blog Owner",
                        NormalizedName = "BLOG OWNER"
                    },
                    new IdentityRole<Guid>
                    {
                        Id = Guid.NewGuid(),
                        Name = "Contributor",
                        NormalizedName = "CONTRIBUTOR"
                    },
                    new IdentityRole<Guid>
                    {
                        Id = Guid.NewGuid(),
                        Name = "User",
                        NormalizedName = "USER"
                    }
                };

                builder.Entity<IdentityRole<Guid>>().HasData(roles);

                var hasher = new PasswordHasher<AppUser>();

                var users = new AppUser[]
                {
                new AppUser
                {
                    Id = Guid.NewGuid(),
                    Age = 20,
                    AboutMe = "Welcome to my blogs",
                    UserName = "ngoccm@gmail.com",
                    NormalizedUserName = "NGOCCM@GMAIL.COM",
                    Email = "ngoccm@gmail.com",
                    NormalizedEmail = "NGOCCM@GMAIL.COM",
                    EmailConfirmed = true,
                    AccessFailedCount = 0,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PasswordHash = hasher.HashPassword(null, "NgocCM123*!")
                },
                new AppUser
                {
                    Id = Guid.NewGuid(),
                    Age = 20,
                    AboutMe = "Welcome to my blogs",
                    UserName = "ngoccm1@gmail.com",
                    NormalizedUserName = "NGOCCM1@GMAIL.COM",
                    Email = "ngoccm1@gmail.com",
                    NormalizedEmail = "NGOCCM1@GMAIL.COM",
                    EmailConfirmed = true,
                    AccessFailedCount = 0,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PasswordHash = hasher.HashPassword(null, "NgocCM123*!")
                },
                new AppUser
                {
                    Id = Guid.NewGuid(),
                    Age = 20,
                    AboutMe = "Welcome to my blogs",
                    UserName = "ngoccm2@gmail.com",
                    NormalizedUserName = "NGOCCM2@GMAIL.COM",
                    Email = "ngoccm2@gmail.com",
                    NormalizedEmail = "NGOCCM2@GMAIL.COM",
                    EmailConfirmed = true,
                    AccessFailedCount = 0,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PasswordHash = hasher.HashPassword(null, "NgocCM123*!")
                },
                };

                builder.Entity<AppUser>().HasData(users);

                builder.Entity<IdentityUserRole<Guid>>().HasData(
                    new IdentityUserRole<Guid>
                    {
                        RoleId = roles[0].Id,
                        UserId = users[0].Id
                    },
                    new IdentityUserRole<Guid>
                    {
                        RoleId = roles[1].Id,
                        UserId = users[1].Id
                    },
                    new IdentityUserRole<Guid>
                    {
                        RoleId = roles[2].Id,
                        UserId = users[2].Id
                    }
                );
            }
        }
    }
}