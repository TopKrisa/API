using Microsoft.EntityFrameworkCore;
using Zabgc.Application.Interfaces;
using Zabgc.Domain.Models;
using Zabgc.Persistence.EntityTypeConfigurations;

namespace Zabgc.Persistence
{
    public class ZabgcDbContext : DbContext, IZabgcDbContext
    {
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<ScheduleType> ScheduleTypes { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<NewsCategory> NewsCategories { get; set; }
        public DbSet<Newspapper> Newspappers { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<PageCategory> PageCategories { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<PhotoAlbum> PhotoAlbums { get; set; }
        public DbSet<Question> Questions { get; set; }
    

        public ZabgcDbContext(DbContextOptions<ZabgcDbContext> options)
            : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new NewsConfiguration());
            builder.ApplyConfiguration(new PageConfiguration());
            builder.ApplyConfiguration(new CommentConfiguration());
            builder.ApplyConfiguration(new DepartmentConfiguration());
            builder.ApplyConfiguration(new NewsCategoryConfiguration());
            builder.ApplyConfiguration(new ScheduleConfiguration());
            builder.ApplyConfiguration(new ScheduleTypeConfiguration());
            builder.ApplyConfiguration(new NewsPapperConfiguration());
            builder.ApplyConfiguration(new PageCategoryConfiguration());
            builder.ApplyConfiguration(new PhotoAlbumConfiguration());
            builder.ApplyConfiguration(new PhotoConfiguration());
            builder.ApplyConfiguration(new QuestionConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
