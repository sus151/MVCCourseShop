using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using CourseShop.Domain.Entities.CMS;
using CourseShop.Domain.Entities.Shop;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CourseShop.Infrastructure.Persistence
{
    public class CourseShopDbContext : IdentityDbContext
    {
        public CourseShopDbContext(DbContextOptions<CourseShopDbContext> options) : base(options)
        {
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<DifficultyLevel> DifficultyLevels { get; set; }
        public DbSet<HighlightedCategory> HighlightedCategories { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<PromotedItem> PromotedItems { get; set; }
        public DbSet<Reference> References { get; set; }
        public DbSet<Opinion> Opinions { get; set; }
        public DbSet<CourseStep> CourseSteps { get; set; }
        public DbSet<FavoriteCourses> FavoriteCourses { get; set; }
        public DbSet<Cart> Carts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PromotedItem>(entity =>
            {
                entity.HasCheckConstraint("CK_PromotedItems_OneIdNotNull",
                        "([IdCourse] IS NOT NULL AND [IdCategory] IS NULL AND [IdMainCategory] IS NULL) OR " +
                        "([IdCourse] IS NULL AND [IdCategory] IS NOT NULL AND [IdMainCategory] IS NULL) OR " +
                        "([IdCourse] IS NULL AND [IdCategory] IS NULL AND [IdMainCategory] IS NOT NULL)")
                    .HasComment("Upewnij się, że tylko jedno z pól IdCourse, IdCategory, IdMainCategory ma wartość");
            });
            modelBuilder.Entity<News>(entity =>
            {
                entity.HasCheckConstraint("CK_News_OneIdNotNull",
                        "([IdCourse] IS NOT NULL AND [IdCategory] IS NULL AND [IdMainCategory] IS NULL) OR " +
                        "([IdCourse] IS NULL AND [IdCategory] IS NOT NULL AND [IdMainCategory] IS NULL) OR " +
                        "([IdCourse] IS NULL AND [IdCategory] IS NULL AND [IdMainCategory] IS NOT NULL)")
                    .HasComment("Upewnij się, że tylko jedno z pól IdCourse, IdCategory, IdMainCategory ma wartość");
            });

            

            modelBuilder.Entity<Category>().HasIndex(u => u.Name).IsUnique();

            modelBuilder.Entity<FavoriteCourses>()
                .HasKey(c => new { c.Id, c.IdCourse });

            modelBuilder.Entity<Cart>()
                .HasKey(c => new { c.Id, c.IdCourse });


        }
        
    }
}
    