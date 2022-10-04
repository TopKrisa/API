using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Zabgc.Application.Interfaces
{
    public interface IZabgcDbContext
    {
        public DbSet<Domain.Models.Comment> Comments { get; set; }
        public DbSet<Domain.Models.Department> Departments { get; set; }
        public DbSet<Domain.Models.Schedule> Schedules { get; set; }
        public DbSet<Domain.Models.ScheduleType> ScheduleTypes { get; set; }
        public DbSet<Domain.Models.News> News { get; set; }
        public DbSet<Domain.Models.NewsCategory> NewsCategories { get; set; }
        public DbSet<Domain.Models.Newspapper> Newspappers { get; set; }
        public DbSet<Domain.Models.Page> Pages { get; set; }
        public DbSet<Domain.Models.PageCategory> PageCategories { get; set; }
        public DbSet<Domain.Models.Photo> Photos { get; set; }
        public DbSet<Domain.Models.PhotoAlbum> PhotoAlbums { get; set; }
        public DbSet<Domain.Models.Question> Questions { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancelationTocken);
    }
}
