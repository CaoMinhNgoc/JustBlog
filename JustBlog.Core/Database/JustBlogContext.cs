using JustBlog.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JustBlog.Core.Database
{
    public class JustBlogContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        public JustBlogContext() { }
        public JustBlogContext(DbContextOptions<JustBlogContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTagMap> PostTagMaps { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DbSet<AppUser> AppUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = @"Data Source=.;Initial Catalog=JustBlog;Integrated Security=True";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
            }

            modelBuilder.Entity<Post>(post =>
            {
                post.ToTable("Posts");
                post.HasOne(p => p.Category).WithMany(c => c.Posts).HasForeignKey(p => p.CategoryId);
            });

            modelBuilder.Entity<Comment>(comment =>
            {
                comment.ToTable("Comments");
                comment.HasOne(c => c.Post).WithMany(p => p.Comments).HasForeignKey(c => c.PostId);
            });

            modelBuilder.Entity<PostTagMap>(postTagMap =>
            {
                postTagMap.ToTable("PostTagMaps");
                postTagMap.HasKey(ptm => new { ptm.TagId, ptm.PostId });

                postTagMap.HasOne(ptm => ptm.Tag).WithMany(t => t.PostTagMaps).HasForeignKey(ptm => ptm.TagId);
                postTagMap.HasOne(ptm => ptm.Post).WithMany(p => p.PostTagMaps).HasForeignKey(ptm => ptm.PostId);
            });

            modelBuilder.Seed();
        }
    }
}